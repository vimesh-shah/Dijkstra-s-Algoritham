using DijkstraImpl.Data;

//       A-----1-----B-----6------E
//        \         / \          /
//         \       /   \        /
//          4     2     2      3
//           \   /       \   /
//            \ /         \ /
//             C-----3-----D

var a = new Node("A");
var b = new Node("B");
var c = new Node("C");
var d = new Node("D");
var e = new Node("E");

a.AddNeighbour(b, 1);
a.AddNeighbour(c, 4);
b.AddNeighbour(c, 2);
b.AddNeighbour(d, 2);
b.AddNeighbour(e, 6);
c.AddNeighbour(d, 3);
d.AddNeighbour(e, 3);

FindShortestPath(a);

Console.ReadKey();

void FindShortestPath(Node startNode)
{
    var Q = new PriorityQueue<Node, int>();
    startNode.DistanceFromRoute = 0;
    Q.Enqueue(startNode, 0);

    while (Q.Count != 0)
    {
        var visitingNode = Q.Dequeue();
        visitingNode.IsVisited = true;

        foreach (var neigbour in visitingNode.Neighbours)
        {
            if (neigbour.Node.IsVisited == true)
            {
                continue;
            }

            var nNodeRouteDist = neigbour.Node.DistanceFromRoute;
            var vNodeRouteDist = visitingNode.DistanceFromRoute;
            var vNodeToNNodeDist = neigbour.Distance;

            if (nNodeRouteDist > vNodeRouteDist + vNodeToNNodeDist)
            {
                neigbour.Node.Parent = visitingNode;
                neigbour.Node.DistanceFromRoute = vNodeRouteDist + vNodeToNNodeDist;
                Q.Enqueue(neigbour.Node, neigbour.Node.DistanceFromRoute);
            }
        }
    }

    Console.WriteLine($"Shortest Path: {e.DistanceFromRoute}");
    Console.WriteLine($"Shortest Route: {GetShortestRoute(e)}");
}

string GetShortestRoute(Node endNode)
{
    var name = endNode.Name;

    if (endNode.Parent != null)
    {
        return $"{GetShortestRoute(endNode.Parent)} => {name} ";
    }
    else
    {
        return name;
    }
}

