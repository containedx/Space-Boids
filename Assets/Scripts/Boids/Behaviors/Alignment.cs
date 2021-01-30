
using UnityEngine;

public class Alignment
{
    public static Vector3 CalculateAlignment(Boid boid)
    {
        // Calculate average velocities of local neighbourhood

        Vector3 v = Vector3.zero;

        if (boid.localNeighbours.Count == 0)
            return v;

        foreach(var neighbour in boid.localNeighbours)
        {
            v += neighbour.Velocity; 
        }
        v /= boid.localNeighbours.Count;

        v = Vector3.Normalize(v - boid.Velocity);

        return v; 
    }
}
