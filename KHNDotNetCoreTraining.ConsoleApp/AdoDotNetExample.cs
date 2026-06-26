using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KHNDotNetCoreTraining.ConsoleApp
{
    public class AdoDotNetExample
    {
// If declare at inside the class and at the top then start with '_'
// => 'readonly' cannot be modified
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";

        public void Read()
        {
         //   string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";
            Console.WriteLine("Connection String : " + _connectionString);
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("Connection Opening...");
            connection.Open();
            Console.WriteLine("Connection Opened");

            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
                  ,[DeleteFlag]
              FROM [dbo].[Tbl_Blog] WHERE DeleteFlag = 0";
          //  Query or Command
           SqlCommand cmd = new SqlCommand(query, connection);

            //Instead of this :
            //-----
            // To run that command we need SqlDataAdapter
            //  SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            //When C# run the query and then it's need to accept the data from the sql
            //  DataTable dt = new DataTable();

            //When it's execute, the value from 'adapter' will went to 'dt'. Fill the Data
            //  adapter.Fill(dt);
            //------
            // Can use this:
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
            }

            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine(dr[columnName: "BlogId"]);
            //    Console.WriteLine(dr[columnName: "BlogTitle"]);
            //    Console.WriteLine(dr[columnName: "BlogAuthor"]);
            //    Console.WriteLine(dr[columnName: "BlogContent"]);
            //}

            Console.WriteLine("Connection Closing...");
            connection.Close();
            Console.WriteLine("Connection Closed.");
        }

        public void Create()
        {
            // --- INSERT QUERY PART:

            Console.WriteLine("Blog Title : ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author : ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content : ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            //string queryInsert = $@"INSERT INTO [dbo].[Tbl_Blog]
            //           ([BlogTitle]
            //           ,[BlogAuthor]
            //           ,[BlogContent]
            //           ,[DeleteFlag])
            //     VALUES
            //           ('{title}'
            //           ,'{author}'
            //           ,'{content}'
            //           ,0)";


            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";


            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);


            // => Not selecting the data from the table, this one is insert, so no need to use SqlDataAdapter, DataTable, and adapter.Fill.
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            // => Run the query and produce the integer. If two query run then it's return 2 depends on the query run.
            // cmd2.ExecuteNonQuery();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            //if(result == 1)
            //{
            //    Console.WriteLine("Saving successful");
            //}
            //else
            //{
            //    Console.WriteLine("Saving fail");
            //}

            Console.WriteLine(result == 1 ? "Saving successful" : "Saving fail");

        }

        public void Edit()
        {
            Console.Write("Blog Id: ");
            string id = Console.ReadLine();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);



            connection.Close();

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);

        }

        public void Update()
        {
            // id is an int but using 'string id' becuase the return from Console.ReadLine() is string
            Console.WriteLine("Blog Id:");
            string id = Console.ReadLine();

            Console.WriteLine("Blog Title : ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author : ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content : ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] =  0
 WHERE BlogId = @BlogId";


            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id;
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            connection.Close();


            Console.WriteLine(result == 1 ? "Update successful" : "Update fail");

        }
    
    
    }
}
