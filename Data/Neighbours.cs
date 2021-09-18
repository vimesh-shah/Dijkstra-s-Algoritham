using System.Collections;

namespace DijkstraImpl.Data;

public class Neighbours : IEnumerable<Neighbour>
{
    private List<Neighbour> _neighbours;

    public Neighbours()
    {
        _neighbours = new List<Neighbour>();
    }

    public void Add(Node node, int distance)
    {
        var neighbour = new Neighbour();
        neighbour.Node = node;
        neighbour.Distance = distance;

        _neighbours.Add(neighbour);
    }

    public IEnumerator<Neighbour> GetEnumerator()
    {
        return _neighbours.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _neighbours.GetEnumerator();
    }
}
