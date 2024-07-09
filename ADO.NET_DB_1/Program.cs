using Microsoft.Data.SqlClient;

namespace ADO.NET_DB_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localDB)\\MSSQLLocalDB;Database=AdventureWorks;Integrated Security=true";
            // Connection String from the db from the SqlConnection Object
            /*SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = connectionString; // Assign connectionstring to Connection String object in 
            // Open connection
            cnn.Open();
            Console.WriteLine(cnn.State);
            cnn.Close(); // We can close manually or use using approach without close request
            */
            // Or this method will automatically close cnn out of the block 
            using (SqlConnection cnn = new SqlConnection())
            {
                try
                {
                    cnn.ConnectionString = connectionString;
                    cnn.Open();
                    // Now create a command like a query object
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    // Command Text with Parameter @ln
                    cmd.CommandText = "Select * from Person.Person where LastName = @ln";
                    // Command is created
                    // Now connect to connection object
                    cmd.Connection = cnn;

                    // Add Parameter
                    cmd.Parameters.AddWithValue("ln", "Smith");
                    // Execute the command
                    // the execute reader returns reader object like a file reader from database results
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // while read one one line
                    while (rdr.Read())
                    {
                        // rdr has Object corresponds to col name we can select as FirstName or LastName
                        Console.WriteLine($"{rdr["FirstName"]} {rdr["LastName"]}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
