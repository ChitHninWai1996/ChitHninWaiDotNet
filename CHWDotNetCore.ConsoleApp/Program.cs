using CHWDotNetCore.ConsoleApp.AdoDotNetExamples;
using CHWDotNetCore.ConsoleApp.EFCoreExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");




AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Read();

//adoDotNetExample.Create("title", "author", "content");

//adoDotNetExample.Update(11, "test title", "test author", "test content");

//adoDotNetExample.Delete(12);

//adoDotNetExample.Edit(13);


//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();


EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();

Console.ReadLine();
