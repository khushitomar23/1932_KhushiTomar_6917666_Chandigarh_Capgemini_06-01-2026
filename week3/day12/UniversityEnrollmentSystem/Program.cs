
namespace UniversityEnrollmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student(1, "KHUSHI", "Computer Science");
            Professor p = new Professor(101, "Mrs. KRISHNA KUMARI", "Data Structures");
            Staff st = new Staff(201, "JAIDEEP", "Administration");

            Console.WriteLine("---- Student Profile ----");
            s.DisplayProfile();
            s.ViewSchedule();

            Console.WriteLine("\n---- Professor Profile ----");
            p.DisplayProfile();
            p.AssignCourse();

            Console.WriteLine("\n---- Staff Profile ----");
            st.DisplayProfile();

            Course c = new Course("Operating Systems");
            Departent d = new Departent("Computer Science");
            Console.WriteLine("\n---- Course & Department ----");
            c.DisplayCourse();
            d.DisplayDepartment();

        }
    }
}
