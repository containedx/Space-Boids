
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 50f;
    public float range = 100f; //how far gun bullet can reach 
    public float fireRate = 15f; //how fast can we shoot
    public float impactForce = 30f;

    private float nextTimeToFire = 0f;

    public Camera cam;

    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    public AudioSource sound;

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButton("Fire1") && Time.time >= nextTimeToFire) // Fire1 default for left mouse button
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            sound.Play();
            Kill();
        }
    }

    // --------------------------------------------------------------------------------------------------------------------------------------------

    void Kill()
    {
        RaycastHit hitInfo; // collects informations about shoot
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range)) //returns true if we hit
        {
            Debug.Log(hitInfo.transform.name);
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            enemy?.DoDamage(damage);

            //Add Force
            hitInfo.rigidbody?.AddForce(hitInfo.normal * impactForce);

            //Particle Effects:
            muzzleFlash.Play();
            GameObject effect = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            effect?.GetComponent<ParticleSystem>()?.Play();
            Destroy(effect, 5f); //Destroy after 2 seconds
        }
    }
}