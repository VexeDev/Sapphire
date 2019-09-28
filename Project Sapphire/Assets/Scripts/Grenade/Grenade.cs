using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Grenade : MonoBehaviour
{
    public AudioSource audioSource;

    public float delay;

    float countdown;

    public float health = 1f;

    bool hasExploded;

    public GameObject explosionEffect;

    public float radius;

    public int newDamage;

    public GameObject fancyEventSystem;

    public float explodeAfterAudio;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        //audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && hasExploded == false)
        {
            hasExploded = true;
            audioSource.Play();
            StartCoroutine(wait2(explodeAfterAudio));
        }

        if (health <= 0f)
        {
            hasExploded = true;
            audioSource.Play();
            StartCoroutine(wait2(explodeAfterAudio));
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
        StartCoroutine(wait(4));
        //Destroy(gameObject);
    }

    public IEnumerator wait(float waitTime)
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    public IEnumerator wait2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Explode();
    }
}
