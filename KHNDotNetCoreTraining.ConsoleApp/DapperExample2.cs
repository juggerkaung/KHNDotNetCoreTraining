using Dapper;
using DotNetTrainingBatch5.Shared;
using KHNDotNetCoreTraining.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KHNDotNetCoreTraining.ConsoleApp
{
    internal class DapperExample2
    {
        private readonly string _connectionString = "Data Source =.; Initial Catalog = DotNetTrainingBatch5;User Id = sa; Password = sasa@123;TrustServerCertificate=True;";
        private readonly DapperService _dapperService;

        public DapperExample2()
        {
            _dapperService = new DapperService(_connectionString);

        }

        public void Read()
        {
         
                string query = "SELECT * FROM tbl_blog WHERE DeleteFlag = 0;";
                var lst = _dapperService.Query<BlogDapperDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);

                }
        }


        public void Create(string title, string author, string content)
        {

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

       
                // Execute = to run the query, and return the number of rows affected
                // Execute(query, new {Here are dynamic query that can inputanything})
                int result = _dapperService.Execute(query, new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
                Console.WriteLine(result == 1 ? "Saving Successful" : "Saving Failed");
            
        }

        public void Edit(int id)
        {
         

                string query = "SELECT * FROM tbl_blog WHERE DeleteFlag = 0 AND BlogId = @BlogId;";
                var item = _dapperService.QueryFirstOrDefault<BlogDataModel>(query, new BlogDataModel
                {
                    BlogId = id
                });

                if (item is null)
                {
                    Console.WriteLine("No data found");
                    return;
                }
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }
}
