# KHNDotNetCoreTraining

Console.WriteLine("Hello, World!");

//Console.ReadLine(); // Can write full line and click Enter to finish

Console.ReadKey(); // One word and done, auto finish

// md => markdown

---

commit data ( data that is already exist in the database)
uncommit data ( data that is going to exist in the database but not yet exist in the database)

If using SELECT query then it's will select all the commit data and uncommit data from the database but if someone 
is using UPDATE/INSERTING then the SELECT will wait until it's finish.

---

dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t Tbl_Name -f
- In mysql this will change to mysql version:
 Microsoft.EntityFrameworkCore.SqlServer
-  '-o' Output ( Name of the folder that is going to create) 
- '-c' Context ( Name of the context/ filename that is going to create )
- '-t' is table ( if more than one table is going to use then use comma , can remove if gonna use all the table )
- '-f' is force ( will generate that one that is going to replace whatever is fixed


dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f

---


Console App ( Create Project )
DTO ( Data Transer Object )
Nuget Package  ( To download Library , I think like Mircrosoft.EntityFrameworkCore/.Design/SqlServer/Tools)
ADO.NET
Dapper
- ORM
- Data Model

EFCore
- AppDbContext
- Database First
- Code First
- (Northwind database)

REST API ( ASP.NET Core Web Api)
- Swagger
- Postman
- Http method
- Http status code 

---

Backend API

---

- data model  ( data access, database )    ( eg: 10 columns )
- view model  ( return data for frontend ) ( eg: but the frontend only need 2 columns, so it's better to separate where 
it's don't need to send all the column's data, only need to send the necessary. If  selecting/sending the unncessary data
then it's take time. )


---
? = allow null , int and bool don't need ? becuase their default value are 0 and false - not null.
        public string? Title { get; set; }

---
DDL = Dynamic Link Library ( Might gonna use this in Service part )

---

 // if use params then can remove null
        // public DataTable Query(string query, SqlParameterModel[] sqlParameters = null)
        public DataTable Query(string query, params SqlParameterModel[] sqlParameters)

// becuase of params , instead of this:
                //---
            //SqlParameterModel[] sqlParameters = new SqlParameterModel[1];
            //sqlParameters[0] = new SqlParameterModel
            //{
            //    Name = "@BlogId",
            //    Value = id
            //};

            //var dt = _adoDotNetService.Query(query, sqlParameters);
            // ------
            // Gonna use this:
            // Query(query, 1, 2, 3, etc,... )
            var dt = _adoDotNetService.Query(query, new SqlParameterModel
            {
                Name = "@BlogId",
                Value = id
            });

---
