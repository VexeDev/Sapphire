using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay;

    float countdown;

    public float health = 1f;

    bool hasExploded;

    public GameObject explosionEffect;

    public float radius;

    public int newDamage;

    public GameObject fancyEventSystem;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }

        if (health <= 0f)
        {
            Explode();
            hasExploded = true;
        }
    }

    public void Explode ()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.gameObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                if (rb.tag == "Player")
                {
                    rb.GetComponent<newPlayerHealth>().Damage(newDamage);
                }
            }

            Collider c = nearbyObject.GetComponent<Collider>();
            if(c != null)
            {
                if (c.tag == "Enemy")
                {
                    c.GetComponent<Health>().Damage(newDamage);
                }
            }
            if (c != null)
            {
                if (c.tag == "Boss Room")
                {
                    c.GetComponent<Health>().Damage(newDamage);
                }
            }
            if (c != null)
            {
                if (c.tag == "Room 1")
                {
                    c.GetComponent<Health>().Damage(newDamage);
                }
            }
        }
        Destroy(gameObject);
    }
}
