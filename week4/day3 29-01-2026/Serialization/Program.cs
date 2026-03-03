using System.Xml.Serialization;

namespace Serialization
{
    public class Student
    {
        public int Id;
        public string Name;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student { Id = 101, Name = "Khushi Tomar" };
            FileStream fs = new FileStream("student.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            serializer.Serialize(fs, s);
            fs.Close();

        }
    }
}
