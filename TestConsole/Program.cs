using Charting.Window;

GraphCreator.Start(x => x * x, "y = x^2");
GraphCreator.Start(x => Math.Cos(x), "y = cos(x)");

Console.ReadKey();