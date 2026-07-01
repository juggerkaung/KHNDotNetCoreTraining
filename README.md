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

=> goto

goto Result;

It's use instead of many 'return' where it's need to jump from one to another by skpping.
use that in other class before return where it's help in breakpoint. But it's may jump some code

Result:
return model;

---

=> Response Model

???

---

=> JsonConvert
( That is Object ( where object model will accept anything ) so cannot check key, so turn that into JSON, and then trun into obj )

public IActionResult Execute(object model)
{

JObject jObj = JObject.Parse(JsonConvert.SeralizeObject(model)):
if(jObj.ContainsKey("Response"))
{

BaseResponseModel baseResponseModel = JsonConvert.DeserailzeObject<BaseResponseModel>(
jObj["Response"]!.ToString()!);

if(baseResponseModel.RespType == EnumRespType.ValidatinError)
return BadRequest(model);

if(baseResponseModel.RespType == EnumRespType.SystemError)
return StatusCode(500, model);

return Ok(model);
}}

???
IActionResult , JsonConvert.SeralizeObject , EnumRespType , BadRequest , StatusCode ?

--------------------------------------------

=> async, await , FirstOrDefaultAsync , .WhenAll , AddAsync , SaveChangesAsync , 

???

Is that one after another ? But with '.WhenAll'(model, model2) then it's will do parallel ?
Is that support the performace ?

--------------------------------------

=> GetAsync

var response = client.GetAsync("https://...");
if(response.IsSuccessStatusCode)
{
  string jsonStr = await response.Content.ReadAsStringAsync();
  Console.WriteLine(jsonStr);
}

----------------------------

=> PostModel()

PostModel model = new PostModel()
{
  body = body 
};

--------------------------------------------------------

=> IEndpointRouteBuilder
???

=> IActionResult
???

-------
HttpClient  API

HttpClient client = new HttpClient();

Client Api which will go and connect with other api. Already Built-in dot.ent . 
---
=> GetAsync("EndPoint/Resource");
=> ReadAsStringAsync();

HttpClient client = new HttpClient();
var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
if (response.IsSuccessStatusCode)
{
    string jsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonStr);
}

need to write those kind in async method:

   public async Task ReadAsync()
        { ...}

------------
=> what is ! at the behind means ???

        public async Task Read()
        {
            RestRequest request = new RestRequest("posts",Method.Get);
            var response = await _client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                Console.WriteLine(jsonStr);
            }
------------------------

### Rest Client 

has ExecuteAsync, where HTTP client doesn't has, that can execute that RestRequest..


---

### Refit

after implementing the interface then it's can start the api:

public interface IGitHubApi
{
   [Get("/users/{user}")]
   Task<User> GetUser(string user);
}

---

### Dependency Injection

1. Constructor Injection
[ Inject in constructor ]

2. Property Injection  
[ using [inject] above the get set ]
 
3. Method Injection

[ Inject in method:
   -> app.MapGet("/blogs", () =>
   -> app.MapGet("/blogs", ([FromServices] AppDbContext db) =>
]

using DotNetTrainingBatch5.Database.Models;
var builder = WebApplication.CreateBuilder(args);

//UI -> BL -> DB
// But it's reverse in here 
// Create the 
//1. 
builder.Services.AddDbContext<AppDbContext>();

---
2.
public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    // generate the AppDbContext(Ctrl+.) , and it's will have 'options' which will have anything to input
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
---

3. Can use like this:

//UI -> BL -> DB
// But it's reverse in here 
// Create the 
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    // this configureation come/needtoinput'ConnectionStrings'  from/in appsettings.json 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

instead of this:


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True";
    //        optionsBuilder.UseSqlServer(connectionString);
    //    }
    //}

-> Connectionstring should be dynamite where the one that will upload on server and the one on local may not be the same.
Also, database, server, may change.

---
### Constructor Injection:

after writing private readonly AppDbContext _db; then ctral+. and generate the constructor:

        private readonly AppDbContext _db;
then it's will product this: ( 
        public BlogService(AppDbContext db)
        {
            _db = db;
        }

---
=> AddScoped 
builder.Services.AddScoped<BlogService>();

---
2. Method Injection:

Instead of this:
   app.MapGet("/blogs", () =>
            {
                AppDbContext db = new AppDbContext();
                var model = db.TblBlogs.AsNoTracking().ToList();
                return Results.Ok(model);

            })

it's will inject into method:


            app.MapGet("/blogs", ([FromServices] AppDbContext db) =>
            {
                var model = db.TblBlogs.AsNoTracking().ToList();
                return Results.Ok(model);

            })
                .WithName("GetBlogs")
                .WithOpenApi();

---
3. Advantages of Dependency Injection 

Swap with Interface to replace the eg: BlogService with BlogV2Service instead of replacing one by one:

builder.Services.AddScoped<IBlogService, BlogV2Service>();

    public interface IBlogService
...
    public class BlogV2Service : IBlogService
...

---

4. To Use Dependency Injection, register first:

//UI -> BL -> DB
// But it's reverse in here 
// Create the 
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    // this configureation come/needtoinput'ConnectionStrings'  from/in appsettings.json 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});
//builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IBlogService, BlogV2Service>();

---------

### ASP.NET Core Service LifeTime

1. Singleton
2. Scoped
3. .

1. Singleton
Only one service instance is created and shared across all requests.
Be aware of concurrency and threading issues.
It's use in helper, utility method where it's doesn't need to change. 
Don't use in Service ( eg: blogservice ), where the requests are not going to be the same.
eg: it's created in one :
using System;
using System.Collections.Generic;
using System.Text;

namespace KHNDotNetCoreTraining.ConsoleApp
{
    internal class AppSettings
    {
        public static string ConnectionString { get} = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";
    }
}
then can be used in others:
        private readonly string _connectionString = AppSettings.ConnectionString;


2. Scoped
One service instance is created for each request and request throughout the request.
Request is considered as scope.
This is like scoped where it's will built and didn't do changes:
private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";



3. Transient
A new service instance is created every time even if it is the same request.
It is most common and always the safest option if you are worried about multihreading.
( In project, it's used in dbcontext where it's can created in every class to use that so if one is deleted but still the others 
are work.
blog => dbcontext , common service => dbcontext

if dbcontext is deleted and remove from the memory then it's will also got removed in common service so 
in big project it's  used with 'ServiceLifttime.Transient, ServiceLifetime.Transient'

)
connection is created in 'Create' but it's will also create in other, read,... 
       public void Create()
        {
      ...
            SqlConnection connection = new SqlConnection(_connectionString);
That is Transient.









