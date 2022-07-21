using Charting.Window;
using Charting.Window.Environment;

/*--------------------Fast charting-----------------------*/

GraphCreator.Start(x => x * x, "y = x^2");
GraphCreator.Start(Math.Sqrt, "Sqrt(x)");
GraphCreator.Start(new[] { (1d, 30d), (2d, 25d), (3d, 10d) },
    InterpolationAlgorithm.CatmullRomSpline,
    "Points");

/*========================================================*/
/*------------------Using GraphBuilder--------------------*/

//function 
var builder = new GraphBuilder();
builder.SetFunction(Math.Cos).SetName("Cos(x)").SetDx(0.01).SetRange(-10, 10);
var graph = new GraphCreator(builder);
graph.Start();

//point function
var points = new List<(double, double)>();
points.Add((1, 2)); points.Add((2, 8)); points.Add((3, 4));
var graphPointsBuilder = new GraphBuilder().SetPoints(points).SetName("Points")
    .UseInterpolationAlgorithm(InterpolationAlgorithm.CanonicalSpline);
new GraphCreator(graphPointsBuilder, new DesignBuilder().SetTitle("Points")).Start();

/*========================================================*/
/*--------------------Several graphs----------------------*/

var graphBuilder = new GraphBuilder().SetFunction(x => 2 * x).SetName("2x").SetDx(0.01).SetRange(-20, 20);
var graphs = new GraphCreator(new[] { builder, graphBuilder, graphPointsBuilder });
graphs.Start();

/*========================================================*/

Console.ReadKey();