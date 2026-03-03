namespace HospitalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Patient p1 = new Patient(1, "Khushi");
            Doctor d1 = new Doctor(101, "Dr. Sharma", "Cardiology");

            MedicalRecord record = new MedicalRecord("Heart Checkup");
            Appointment app = new Appointment(p1, d1, "21-01-2026");

            Console.WriteLine("---- Hospital System ----");
            p1.Display();
            record.ShowRecord();
            app.ShowAppointment();

        }
    }
}
