using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Range(0.0f,180.0f)]
    public float Speed; 
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * Speed * Time.deltaTime);
    }
}
