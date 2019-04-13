using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeObject : MonoBehaviour
{
    bool canDamage;

    public int damage;

    public float despawnTime;

    float stopDamageTime = 3f;

    private void Start()
    {
        canDamage = true;
        StartCoroutine(stopDamage());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with something");
        if (other.tag == "Enemy" && canDamage == true)
        {
            other.GetComponent<Health>().Damage(damage);
            Destroy(gameObject);
        }
        if (other.tag == "Boss Room" && canDamage == true)
        {
            other.GetComponent<Health>().Damage(damage);
            Destroy(gameObject);
        }
        if (other.tag == "Room 1" && canDamage == true)
        {
            other.GetComponent<Health>().Damage(damage);
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Debug.Log("collided with player");
            other.GetComponent<RefillAxe>().refillTheAxe();
            Destroy(gameObject);
        }
    }

    IEnumerator stopDamage ()
    {
        yield return new WaitForSeconds(stopDamageTime);
        canDamage = false;
    }

    IEnumerator despawn ()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
