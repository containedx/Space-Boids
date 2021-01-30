using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Rigidbody rigidBody;

    // current position
    public Vector3 Position;

    // current Velocity
    public Vector3 Velocity;

    // List of Neighbours - all other agents
    public List<Boid> Neighbours = new List<Boid>();

    // Neighbours which are in visual range 
    public List<Boid> localNeighbours = new List<Boid>();

    // visual view parameters
    public float Distance;
    public float Angle; 

    void Start()
    {
        // Init
        rigidBody = GetComponent<Rigidbody>();
        Position = transform.position;
        Velocity = rigidBody.velocity;
    }

    void Update()
    {
        //Update surrounding neighbours
        UpdateNeighbours();   
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public void UpdateMove(Vector3 position, Vector3 velocity)
    {
        if (position.y < 0)
            position.y = 0;

        Position = position;
        Velocity = velocity;

        gameObject.transform.position = position;
        //rigidBody.velocity = velocity * Time.deltaTime;
        //gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
    }

    private void UpdateNeighbours()
    {
        UpdateLists();
        foreach(var neighbour in Neighbours)
        {
            /* --- field of view = 360 == all around boid
            if(Vector3.Distance(neighbour.Position, Position) <= Distance && !localNeighbours.Contains(neighbour)) */

            if (IsInFieldOfView(neighbour) && !localNeighbours.Contains(neighbour))
            {
                localNeighbours.Add(neighbour);
            }
            else if(!IsInFieldOfView(neighbour) && localNeighbours.Contains(neighbour))
            {
                localNeighbours.Remove(neighbour);
            }
        }
    }

    private bool IsInFieldOfView(Boid neighbour)
    {
        if (Vector3.Distance(neighbour.Position, Position) <= Distance && !localNeighbours.Contains(neighbour))
        {
            return true;
        }
        else if(Vector3.Distance(neighbour.Position, Position) >= Distance && localNeighbours.Contains(neighbour))
        {
            return false;
        }
        return false;
    }

    private void UpdateLists()
    {
        foreach (var boid in Neighbours)
        {
            if (boid == null)
            {
                Neighbours.Remove(boid);
            }
        }
        foreach (var boid in localNeighbours)
        {
            if (boid == null)
            {
                localNeighbours.Remove(boid);
            }
        }
    }
}
