namespace OnlineHospitalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            OnlineHospital hospital = new OnlineHospital();
            hospital.GetDetails();
            hospital.AdmitPatient();

            Console.WriteLine("Enter Government ID for free treatment:");
            string id = Console.ReadLine();

            if (id == "Governmentid")
            {
                GovernmentHospital govt = new GovernmentHospital();
                govt.GetDetails();
                govt.AdmitPatient();
            }
            else
            {
                Console.WriteLine("Not eligible for free treatment");
                hospital.GenerateBill();
            }

            Console.ReadLine();
        }
    }
    }

