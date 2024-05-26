// See https://aka.ms/new-console-template for more information
using CHWDotNetCore.ConsoleAppHttpClientExamples;

Console.WriteLine("Hello, World!");

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();