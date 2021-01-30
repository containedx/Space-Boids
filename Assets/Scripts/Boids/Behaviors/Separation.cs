
using UnityEngine;

public class Separation
{
    //gives ability to keep safe distance from others (prevent crowding)
    public static int separationRadius = 5;

    public static Vector3 CalculateSeparation(Boid boid)
    {
        Vector3 v = Vector3.zero;

        if (boid.localNeighbours.Count == 0)
            return v;

        foreach (var neighbour in boid.localNeighbours)
        {
            // if offset between positions < separation radius, normalize and apply 1/r^2 (Craig Reynolds's formula) 
            if (Vector3.SqrMagnitude(neighbour.Position - boid.Position) < Mathf.Pow(separationRadius, 2))
            {
                v += Vector3.Normalize(boid.Position - neighbour.Position)/ Mathf.Pow(separationRadius, 2);
            }
        }
        v /= boid.localNeighbours.Count;

        return v;
    }
}
