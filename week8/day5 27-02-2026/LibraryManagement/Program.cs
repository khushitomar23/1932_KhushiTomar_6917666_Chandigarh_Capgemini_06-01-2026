using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace LibraryStoredProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString =
                   "Server=KHUSHI23\\SQLEXPRESS;" +
                   "Database=LibraryDB;" +
                   "Integrated Security=True;" +
                   "TrustServerCertificate=True;";

                // Get All Books
                GetAllBooks(connectionString);

                // Get Book By ID
                int bookId = 1;
                GetBookByID(connectionString, bookId);

                // Insert Book
                InsertBook(
                    connectionString,
                    "Animal Farm",
                    2,
                    1945
                );

                // Update Book
                UpdateBook(
                    connectionString,
                    1,
                    "Harry Potter Updated",
                    1,
                    1998
                );

                // Delete Book
                DeleteBook(connectionString, 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            Console.ReadLine();
        }

        // ================= GET ALL BOOKS =================
        static void GetAllBooks(string connectionString)
        {
            Console.WriteLine("GetAllBooks Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("GetAllBooks", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"BookId: {reader["BookId"]}, " +
                        $"Title: {reader["Title"]}, " +
                        $"Author: {reader["AuthorName"]}, " +
                        $"Year: {reader["PublishedYear"]}\n"
                    );
                }

                reader.Close();
                connection.Close();
            }
        }

        // ================= GET BOOK BY ID =================
        static void GetBookByID(string connectionString, int bookId)
        {
            Console.WriteLine("GetBookById Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("GetBookById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@BookId", bookId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"Book: {reader["Title"]}, " +
                        $"AuthorId: {reader["AuthorId"]}, " +
                        $"Year: {reader["PublishedYear"]}\n"
                    );
                }

                reader.Close();
                connection.Close();
            }
        }

        // ================= INSERT BOOK =================
        static void InsertBook(
            string connectionString,
            string title,
            int authorId,
            int publishedYear)
        {
            Console.WriteLine("InsertBook Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("InsertBook", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@AuthorId", authorId);
                command.Parameters.AddWithValue("@PublishedYear", publishedYear);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("Book inserted successfully.\n");
            }
        }

        // ================= UPDATE BOOK =================
        static void UpdateBook(
            string connectionString,
            int bookId,
            string title,
            int authorId,
            int publishedYear)
        {
            Console.WriteLine("UpdateBook Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("UpdateBook", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@AuthorId", authorId);
                command.Parameters.AddWithValue("@PublishedYear", publishedYear);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("Book updated successfully.\n");
            }
        }

        // ================= DELETE BOOK =================
        static void DeleteBook(string connectionString, int bookId)
        {
            Console.WriteLine("DeleteBook Stored Procedure Called");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand("DeleteBook", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@BookId", bookId);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                    Console.WriteLine("Book deleted successfully.\n");
                else
                    Console.WriteLine("Book not found.\n");

                connection.Close();
            }
        }
    }
}