using Charting.Window;



var graph = new GraphCreator(x => x * x);
graph.Start();


var newGraph = new GraphCreator(x => Math.Sqrt(x));
await newGraph.Start();