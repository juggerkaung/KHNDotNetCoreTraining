using DotNetTraininngBatch5.ConsoleApp3;

Console.WriteLine("Hello, World!");

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Read();
//await httpClientExample.Edit(1);
//await httpClientExample.Edit(101);

//await httpClientExample.Create("test title", "test body", 1);
//await httpClientExample.Update(1, "test title", "test body", 10);

//Console.WriteLine("waiting for api...");
//Console.ReadLine();

//RefitExample refitExample = new RefitExample();
//await refitExample.Run();
//    Console.ReadLine();

var id = Guid.NewGuid();
var id2 = Ulid.NewUlid();
Console.WriteLine(id.ToString());
Console.WriteLine(id2.ToString());
Console.WriteLine(id2.ToString().Length);

Console.WriteLine(id2.ToString().ToLower().Substring(0, 3) + "-" + id2.ToString().ToLower().Substring(4,3));

Random r = new Random();
for(int i = 0; i< 10; i++)
{
    Console.WriteLine(r.Next(1, 7));
}
Console.ReadLine();