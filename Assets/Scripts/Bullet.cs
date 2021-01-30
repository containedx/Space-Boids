using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem explosion;
    public AudioSource sound;

    private void Update()
    {
        if(transform.position.y <= -13f)
        {
            explosion.Play();
            Destroy(gameObject, 2f);
        }
    }

}
