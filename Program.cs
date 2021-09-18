using DijkstraImpl.Data;

var a = new Node("A", 0);
var b = new Node("B");
var c = new Node("C");
var d = new Node("D");
var e = new Node("E");

a.Neighbours.Add(b, 1);
a.Neighbours.Add(c, 4);

b.Neighbours.Add(a, 1);
b.Neighbours.Add(c, 2);
b.Neighbours.Add(d, 2);
b.Neighbours.Add(e, 6);

c.Neighbours.Add(a, 4);
c.Neighbours.Add(b, 2);
c.Neighbours.Add(d, 3);

d.Neighbours.Add(b, 2);
d.Neighbours.Add(c, 3);
d.Neighbours.Add(e, 3);

e.Neighbours.Add(b, 6);
e.Neighbours.Add(d, 3);

var Q = new PriorityQueue<Node, int>();
Q.Enqueue(a, 0);

while (Q.Count != 0)
{
    var visitingNode = Q.Dequeue();
    visitingNode.IsVisited = true;

    foreach (var neigbour in visitingNode.Neighbours)
    {
        if (neigbour.Key.IsVisited == true)
        {
            continue;
        }

        var dv = neigbour.Key.Distance;
        var du = visitingNode.Distance;
        var duv = neigbour.Value;

        var parent = visitingNode.Name;

        if (dv > du + duv)
        {
            neigbour.Key.Parent = parent;
            neigbour.Key.Distance = du + duv;
            Q.Enqueue(neigbour.Key, neigbour.Key.Distance);
        }
    }


}

Console.ReadKey();

