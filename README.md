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
