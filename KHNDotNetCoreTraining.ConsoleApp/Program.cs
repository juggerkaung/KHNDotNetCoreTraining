using KHNDotNetCoreTraining.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

// md => mark down
// ( a little similar to html )

// ADO.NET
// Dapper ( clean and ORM )
// EFCore / Entity Framework ( ORM - Object Relational Mapping  )

// C# => sql query =>
// NuGet website 
// pub.dev

// after typing 'SqlConnection' and hold_Ctrl + . then it's will show 'System.Data.SqlClient' to add at the top
// Data Source = (Server name) => . , Initial Catalog = (Database name) , User ID = (User name) )
//string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";
//Console.WriteLine("Connection String : " + connectionString);
//SqlConnection connection = new SqlConnection(connectionString);

//Console.WriteLine("Connection Opening...");
//connection.Open();
//Console.WriteLine("Connection Opened");

//string query = @"SELECT [BlogId]
//      ,[BlogTitle]
//      ,[BlogAuthor]
//      ,[BlogContent]
//      ,[DeleteFlag]
//  FROM [dbo].[Tbl_Blog] WHERE DeleteFlag = 0";
// Query or Command
//SqlCommand cmd = new SqlCommand(query, connection);

// Instead of this :
//-----
// To run that command we need SqlDataAdapter
//  SqlDataAdapter adapter = new SqlDataAdapter(cmd);

//  When C# run the query and then it's need to accept the data from the sql
//  DataTable dt = new DataTable();

//  When it's execute, the value from 'adapter' will went to 'dt'. Fill the Data
//  adapter.Fill(dt);
//------
// Can use this:
//SqlDataReader reader = cmd.ExecuteReader();
//while (reader.Read())
//{
//    Console.WriteLine(reader["BlogId"]);
//    Console.WriteLine(reader["BlogTitle"]);
//    Console.WriteLine(reader["BlogAuthor"]);
//    Console.WriteLine(reader["BlogContent"]);
//}

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr[columnName: "BlogId"]);
//    Console.WriteLine(dr[columnName: "BlogTitle"]);
//    Console.WriteLine(dr[columnName: "BlogAuthor"]);
//    Console.WriteLine(dr[columnName: "BlogContent"]);
//}



//Console.WriteLine("Connection Closing...");
//connection.Close();
//Console.WriteLine("Connection Closed.");

// DataSet = Store multiple DataTable , in there:
// DataTable
// DataRow
// DataColumn

// looping the data can be exist before or after the connection closed
// after opened: after  filling the data into table "adapter.Fill(dt);" so even after connection is closed then no need to worry about the data, because it's already in the memory. So we can loop the data after connection closed.
// It's also necessary to exist before the connection closed, becuase if it's too big and looping multiple line. ( But it's take time when a lot of user enter )
// after closed: when close the connection it's good for controlling the MAX connection limit, so when next user came then no need to worry about.
//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr[columnName: "BlogId"]);
//    Console.WriteLine(dr[columnName: "BlogTitle"]);
//    Console.WriteLine(dr[columnName: "BlogAuthor"]);
//    Console.WriteLine(dr[columnName: "BlogContent"]);
//}

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Read();
// adoDotNetExample.Create();
//adoDotNetExample.Edit();
adoDotNetExample.Update();

Console.ReadKey();

