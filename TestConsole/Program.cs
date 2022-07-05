using Charting.Window;

/*--------------------Fast charting-----------------------*/

GraphCreator.Start(x => x * x, "y = x^2");
GraphCreator.Start(Math.Cos, "y = cos(x)");

/*========================================================*/
/*------------------Using GraphBuilder--------------------*/

var builder = new GraphBuilder();
builder.SetFunction(Math.Sqrt).SetName("Sqrt(x)").SetDx(0.01).SetRange(-10, 10);
var graph = new GraphCreator(builder);
graph.Start();

Console.WriteLine($"is graph active? = {graph.IsActive}"); Console.ReadKey(); Console.Clear();
graph.Stop();
Console.WriteLine($"is graph active? = {graph.IsActive}");

/*========================================================*/

var graphBuilder = new GraphBuilder().SetFunction(Math.Tan).SetName("tan(x)").SetDx(0.01).SetRange(-20, 20);
var graphs = new GraphCreator(new[] { builder, graphBuilder });
graphs.Start();

Console.ReadKey();