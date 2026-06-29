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

Minimal API / [ado.net / dapper => custom service ]
- 

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
=> this keyword:

    // put static here to use 'this'
    public static class BlogEndpoints
    {
        // 'this' keyword:
        // that parameter move forward/front and instead of using this class in other file:
        // BlogEndpoints.Test(9);
        // Can use like this:
        // 9.Test();
        public static string Test(this int i)
        {
            return i.ToString();
        }
---

=> global

global using DotNetTrainingBatch5.Database.Models;

the teacher create a file(GlobalUsing.cs) and take all the using file and put then in one.
---
[PACKAGE DOWNLOAD]
=> Newtonsoft.Json ( 13.0.4)


var blog = new BlogModel
{
    Id = 1,
    Title = "Test Title",
    Author = "Test Author",
    Content = "Test Contenct",

};
string jsonStr = JsonConvert.SerializeObject(blog); // C# to JSON

---
=> Formatting.Indented:

string jsonStr = JsonConvert.SerializeObject(blog, Formatting.Indented); // C# to JSON
// Formatting.Indented is not that necessary unless don't want in format version.

---
=> Extension ( sometimes it's call : DevCode)
Instead of writing like this : 

 string jsonStr = JsonConvert.SerializeObject(blog, Formatting.Indented);

 use Extension and create another class :
 public static class Exentsions // DevCode
{
    public static string ToJson(this object obj)
    {
        string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented); // C# to JSON
        return jsonStr;

    }
}
then we can use like this:
string jsonStr = blog.ToJson(); 

---

=> DeserializeObject

string jsonStr2 = """{"Id":1,"Title":"Test Title","Author":"Test Author","Content":"Test Contenct"}""";
var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);

Console.WriteLine(blog2.Title);
???

---

=> Serialize and Deserialize

Serialize =  turn the .NET object to JSON 
Deserialze = turn the JSON object to C#/.NET Object


string jsonStr2 = """{"Id":1,"Title":"Test Title","Author":"Test Author","Content":"Test Contenct"}""";
var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);

System.Text.Json.JsonSerializer.Serialize(blog); // Not casesensitive, the 'Test title' is still work instead of 'Test Title'
System.Text.Json.JsonSerializer.Deserialize<BlogModel>(jsonStr2); // Case Sensitive

---
HW:
Using JSON, Bind then product API

---


