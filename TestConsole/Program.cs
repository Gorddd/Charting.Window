using Charting.Window;
using Charting.Window.Environment;

/*--------------------Fast charting-----------------------*/

GraphCreator.Start(x => x * x, "y = x^2");
GraphCreator.Start(Math.Sqrt, "Sqrt(x)");
GraphCreator.Start(new[] { new Point(1, 30), new Point(2, 25), new Point(3, 10) },
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
var points = new List<Point>();
points.Add(new Point(1, 2)); points.Add(new Point(2, 8)); points.Add(new Point(3, 1));
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