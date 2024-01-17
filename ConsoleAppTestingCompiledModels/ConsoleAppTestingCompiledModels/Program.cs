// See https://aka.ms/new-console-template for more information
using DatabaseCompiledModels.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Testing Compiled Models Issue!");
Console.WriteLine("Step 1, Use Scaffold Database DbContext!");
Console.WriteLine("Step 2, Run Query, See Results!");
Console.WriteLine("Step 3, Activate Compile Models!");
Console.WriteLine("Step 4, Run Query, See Results Different!");

var db = new CompiledModelsIssueContext();

string test = "Jo";

var result = db.TestValues.Where(x => x.TestValue1.StartsWith(test)).Select(y => y.TestValue1);
var sql = result.ToQueryString();
Console.WriteLine(sql);
foreach(var item in result)
{
    Console.WriteLine(item);
}
Console.ReadLine();