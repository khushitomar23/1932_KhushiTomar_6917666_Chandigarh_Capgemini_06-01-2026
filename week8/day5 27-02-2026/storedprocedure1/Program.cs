using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace storedprocedure1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString =
                   "Server=KHUSHI23\\SQLEXPRESS;" +
                   "Database=UniversityDB;" +
                   "Integrated Security=True;" +
                   "TrustServerCertificate=True;";

                // Get All Students
                GetAllStudents(connectionString);

                // Get Student By ID
                int studentId = 1;
                GetStudentByID(connectionString, studentId);

                // Insert Student
                InsertStudent(
                    connectionString,
                    "Rohan",
                    "Kumar",
                    "rohan@uni.com",
                    1
                );

                // Update Student
                UpdateStudent(
                    connectionString,
                    2,
                    "Aman",
                    "Verma",
                    "aman@uni.com",
                    2
                );

                // Delete Student
                DeleteStudent(connectionString, 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            Console.ReadLine();
        }

        // ================= GET ALL STUDENTS =================
        static void GetAllStudents(string connectionString)
        {
            Console.WriteLine("GetAllStudents Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("sp_GetAllStudents", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"StudentId: {reader["StudentId"]}, " +
                        $"Name: {reader["FirstName"]} {reader["LastName"]}, " +
                        $"Email: {reader["Email"]}, " +
                        $"Department: {reader["DeptName"]}\n"
                    );
                }

                reader.Close();
                connection.Close();
            }
        }

        // ================= GET STUDENT BY ID =================
        static void GetStudentByID(string connectionString, int studentId)
        {
            Console.WriteLine("GetStudentById Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("sp_GetStudentById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"Student: {reader["FirstName"]} {reader["LastName"]}, " +
                        $"Email: {reader["Email"]}, " +
                        $"DeptId: {reader["DeptId"]}\n"
                    );
                }

                reader.Close();
                connection.Close();
            }
        }

        // ================= INSERT STUDENT =================
        static void InsertStudent(
            string connectionString,
            string firstName,
            string lastName,
            string email,
            int deptId)
        {
            Console.WriteLine("InsertStudent Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("sp_InsertStudent", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@DeptId", deptId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("Student inserted successfully.\n");
            }
        }

        // ================= UPDATE STUDENT =================
        static void UpdateStudent(
            string connectionString,
            int studentId,
            string firstName,
            string lastName,
            string email,
            int deptId)
        {
            Console.WriteLine("UpdateStudent Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("sp_UpdateStudent", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StudentId", studentId);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@DeptId", deptId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("Student updated successfully.\n");
            }
        }

        // ================= DELETE STUDENT =================
        static void DeleteStudent(string connectionString, int studentId)
        {
            Console.WriteLine("DeleteStudent Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("sp_DeleteStudent", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                    Console.WriteLine("Student deleted successfully.\n");
                else
                    Console.WriteLine("Student not found.\n");

                connection.Close();
            }
        }
    }
}