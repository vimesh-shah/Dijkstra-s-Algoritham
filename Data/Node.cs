namespace DijkstraImpl.Data;

public class Node
{
    public string Name { get; set; }

    public Neighbours Neighbours { get; set; }

    public bool IsVisited { get; set; }

    public int DistanceFromRoute { get; set; }

    public Node Parent { get; set; }

    public Node(string name, int distance = int.MaxValue)
    {
        Name = name;
        DistanceFromRoute = distance;
        Parent = null;
        Neighbours = new Neighbours();
    }

    public void AddNeighbour(Node node, int distance)
    {
        Neighbours.Add(node, distance);
        node.Neighbours.Add(this, distance);
    }
}
