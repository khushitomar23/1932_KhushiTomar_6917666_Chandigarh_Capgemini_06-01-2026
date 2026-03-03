using System;

namespace OnlineHospitalProject
{
    class OnlineHospital : Hospital, Ibillingcs
    {
        private int availableBeds;
        Patient patient;
        Record<int> patientRecord;

        public OnlineHospital()
        {
            patientRecord = new Record<int>();
            Console.WriteLine("Welcome to the Online Hospital");
        }

        public override void GetDetails()
        {
            try
            {
                Console.WriteLine("Enter Hospital Name:");
                HospitalName = Console.ReadLine();

                Console.WriteLine("Enter Hospital Location:");
                location = Console.ReadLine();

                Console.WriteLine("Enter Available Beds:");
                availableBeds = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Patient Name:");
                patient.Name = Console.ReadLine();

                Console.WriteLine("Enter Patient Age:");
                patient.Age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Patient ID:");
                patient.Id = int.Parse(Console.ReadLine());
                patientRecord.value = patient.Id;

                Console.WriteLine("Select Patient Type (0-General, 1-Emergency, 2-OPD):");
                patient.Type = (PatientType)int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter numbers correctly.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
        }

        public override void AdmitPatient()
        {
            try
            {
                if (availableBeds > 0)
                {
                    availableBeds--;
                    Console.WriteLine("Patient admitted successfully");
                    Console.WriteLine("Patient Type: " + patient.Type);
                    patientRecord.Show();
                    Console.WriteLine("Remaining Beds: " + availableBeds);
                }
                else
                {
                    Console.WriteLine("No Bed Available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during admission: " + ex.Message);
            }
        }

        public void GenerateBill()
        {
            try
            {
                Console.WriteLine("Enter total bill amount:");
                int bill = int.Parse(Console.ReadLine());
                Console.WriteLine("Bill to be paid: " + bill);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid bill amount entered.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Billing error: " + ex.Message);
            }
        }

    }
}
