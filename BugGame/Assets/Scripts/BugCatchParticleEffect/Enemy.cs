using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem deathParticles;
    
    //Anything that carries a collision
    private void OnCollisionEnter(Collision collision)
    {
        //Named under tag Sphere
        if (collision.collider.CompareTag("Sphere"))
        {
            //Calling Function destroy
            Destroy();
        }
    }

    public void Destroy()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
