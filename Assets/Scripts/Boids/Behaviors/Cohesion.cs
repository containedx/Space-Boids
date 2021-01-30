
using UnityEngine;

public class Cohesion
{
    public static Vector3 CalculateCohesion(Boid boid)
    {
        // Calculate average position of local neighbourhood

        Vector3 pos = Vector3.zero;

        if (boid.localNeighbours.Count == 0)
            return pos; 

        foreach(var neighbour in boid.localNeighbours)
        {
            pos += neighbour.Position; 
        }
        pos /= boid.localNeighbours.Count;
        pos /= 100;

        return pos; 
    }
}
