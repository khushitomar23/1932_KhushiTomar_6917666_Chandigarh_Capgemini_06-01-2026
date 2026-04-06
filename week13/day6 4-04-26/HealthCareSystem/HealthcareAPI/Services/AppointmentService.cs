using HealthcareShared.DTOs;
using HealthcareShared.Models;
using HealthcareAPI.Repositories;

namespace HealthcareAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IUserRepository userRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }

        public async Task<AppointmentDto> BookAppointmentAsync(int patientId, CreateAppointmentDto dto)
        {
            try
            {
                // Validate input
                ValidateBookingDto(dto);

                // Validate patient ID
                if (patientId <= 0)
                    throw new InvalidOperationException("Invalid patient ID");

                // Get patient name
                var patient = await _userRepository.GetByIdAsync(patientId);
                if (patient == null)
                    throw new InvalidOperationException("Patient not found");

                // Validate doctor exists - use GetDoctorWithUserAsync to include related entities
                var doctor = await _doctorRepository.GetDoctorWithUserAsync(dto.DoctorId);
                if (doctor == null)
                    throw new InvalidOperationException("Doctor not found");

                // Validate appointment date is in the future
                if (dto.AppointmentDate <= DateTime.Now)
                    throw new InvalidOperationException("Appointment date must be in the future");

                // Validate appointment date is not too far in the future (e.g., max 6 months)
                if (dto.AppointmentDate > DateTime.Now.AddMonths(6))
                    throw new InvalidOperationException("Appointment cannot be scheduled more than 6 months in advance");

                // Check for conflicting appointments - use a lightweight query instead of loading all appointments
                var hasConflict = await _appointmentRepository.HasConflictingAppointmentAsync(patientId, dto.DoctorId, dto.AppointmentDate);
                if (hasConflict)
                    throw new InvalidOperationException("You already have an appointment with this doctor on that date");

                // Get doctor name
                var doctorName = "Unknown";
                if (doctor?.User != null && !string.IsNullOrEmpty(doctor.User.FullName))
                    doctorName = doctor.User.FullName;

                var appointment = new Appointment
                {
                    PatientId = patientId,
                    DoctorId = dto.DoctorId,
                    AppointmentDate = dto.AppointmentDate,
                    Status = "Booked",
                    ProblemDescription = !string.IsNullOrWhiteSpace(dto.ProblemDescription) ? dto.ProblemDescription : null,
                    PatientName = !string.IsNullOrWhiteSpace(patient.FullName) ? patient.FullName : "Patient"
                };

                var createdAppointment = await _appointmentRepository.AddAsync(appointment);
                
                // Create DTO directly without calling MapToAppointmentDtoAsync to avoid extra database calls
                return new AppointmentDto
                {
                    AppointmentId = createdAppointment.AppointmentId,
                    PatientId = createdAppointment.PatientId,
                    DoctorId = createdAppointment.DoctorId,
                    DoctorName = doctorName,
                    AppointmentDate = createdAppointment.AppointmentDate,
                    Status = createdAppointment.Status ?? "Booked",
                    PatientName = createdAppointment.PatientName ?? "Patient",
                    ProblemDescription = createdAppointment.ProblemDescription
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BookAppointmentAsync: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        public async Task<IEnumerable<AppointmentDto>> GetPatientAppointmentsAsync(int patientId)
        {
            if (patientId <= 0)
                throw new InvalidOperationException("Invalid patient ID");

            try
            {
                var appointments = await _appointmentRepository.GetPatientAppointmentsAsync(patientId);
                var dtos = new List<AppointmentDto>();
                
                foreach (var apt in appointments)
                {
                    try
                    {
                        dtos.Add(await MapToAppointmentDtoAsync(apt));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error mapping appointment {apt.AppointmentId}: {ex.Message}");
                        // Add basic DTO without doctor info to prevent total failure
                        dtos.Add(new AppointmentDto
                        {
                            AppointmentId = apt.AppointmentId,
                            PatientId = apt.PatientId,
                            DoctorId = apt.DoctorId,
                            DoctorName = "Unknown",
                            AppointmentDate = apt.AppointmentDate,
                            Status = apt.Status ?? "Booked",
                            PatientName = apt.PatientName ?? "Patient",
                            ProblemDescription = apt.ProblemDescription
                        });
                    }
                }
                
                return dtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetPatientAppointmentsAsync: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        public async Task<IEnumerable<AppointmentDto>> GetDoctorAppointmentsAsync(int doctorId)
        {
            if (doctorId <= 0)
                throw new InvalidOperationException("Invalid doctor ID");

            try
            {
                var appointments = await _appointmentRepository.GetDoctorAppointmentsAsync(doctorId);
                var dtos = new List<AppointmentDto>();
                
                foreach (var apt in appointments)
                {
                    try
                    {
                        dtos.Add(await MapToAppointmentDtoAsync(apt));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error mapping appointment {apt.AppointmentId}: {ex.Message}");
                        // Add basic DTO without doctor info to prevent total failure
                        dtos.Add(new AppointmentDto
                        {
                            AppointmentId = apt.AppointmentId,
                            PatientId = apt.PatientId,
                            DoctorId = apt.DoctorId,
                            DoctorName = "Unknown",
                            AppointmentDate = apt.AppointmentDate,
                            Status = apt.Status ?? "Booked",
                            PatientName = apt.PatientName ?? "Patient",
                            ProblemDescription = apt.ProblemDescription
                        });
                    }
                }
                
                return dtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetDoctorAppointmentsAsync: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        public async Task<AppointmentDto> CancelAppointmentAsync(int appointmentId)
        {
            if (appointmentId <= 0)
                throw new InvalidOperationException("Invalid appointment ID");

            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (appointment == null)
                throw new InvalidOperationException("Appointment not found");

            // Validate appointment can be cancelled
            if (appointment.Status == "Cancelled")
                throw new InvalidOperationException("Appointment is already cancelled");

            if (appointment.Status == "Completed")
                throw new InvalidOperationException("Cannot cancel a completed appointment");

            appointment.Status = "Cancelled";
            var updated = await _appointmentRepository.UpdateAsync(appointment);
            return await MapToAppointmentDtoAsync(updated);
        }

        private void ValidateBookingDto(CreateAppointmentDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.DoctorId <= 0)
                throw new InvalidOperationException("Valid doctor ID is required");

            if (dto.AppointmentDate == default(DateTime))
                throw new InvalidOperationException("Appointment date is required");
        }

        private async Task<AppointmentDto> MapToAppointmentDtoAsync(Appointment appointment)
        {
            try
            {
                // Use GetDoctorWithUserAsync to include User and Department entities
                var doctor = await _doctorRepository.GetDoctorWithUserAsync(appointment.DoctorId);
                var doctorName = "Unknown";
                
                if (doctor != null && doctor.User != null && !string.IsNullOrEmpty(doctor.User.FullName))
                {
                    doctorName = doctor.User.FullName;
                }

                return new AppointmentDto
                {
                    AppointmentId = appointment.AppointmentId,
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    DoctorName = doctorName,
                    AppointmentDate = appointment.AppointmentDate,
                    Status = appointment.Status ?? "Booked",
                    PatientName = appointment.PatientName ?? "Patient",
                    ProblemDescription = appointment.ProblemDescription
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping appointment: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }
    }
}
