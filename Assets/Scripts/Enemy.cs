
using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float health = 100f;

    public ParticleSystem explosion;

    public AudioSource sound;
    public AudioSource explosionSound;
    public AudioSource shotSound;

    // Shoting to Player
    public float damage = 20f;
    public float range = 100f; //how far gun bullet can reach 
    public float impactForce = 30f;

    public float shotInterval = 4f;

    public PlayerController player;
    public GameObject bullet;

    public void Start()
    {
        StartCoroutine("ShotRepetedly");
    }

    public void DoDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        explosion.Play();
        sound.Play();
        Destroy(gameObject, 0.5f);
    }

    void Shot()
    {
        shotSound.Play();
        RaycastHit hitInfo; // collects informations about shoot
        if (Physics.Raycast(transform.position, player.transform.position, out hitInfo, range)) //returns true if we hit
        {
            //Debug.Log(hitInfo.transform.name);
            PlayerController p = hitInfo.transform.GetComponent<PlayerController>();
            p?.DoDamage(damage);

            //Add Force
            //hitInfo.rigidbody?.AddForce(hitInfo.normal * impactForce);

            // bullet
            Rigidbody rb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            explosionSound.PlayDelayed(1f);
        }

        if(Vector3.Distance(transform.position, player.transform.position) < 15)
        {
            player.DoDamage(damage);
        }
    }

    IEnumerator ShotRepetedly()
    {
        while(true)
        {
            Shot();
            yield return new WaitForSeconds(shotInterval);
        }
    }

}
