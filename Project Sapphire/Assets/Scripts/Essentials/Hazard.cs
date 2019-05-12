using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage;
    public float damageCooldown;
    bool cooldownActive;

    GameObject eventSystem;

    private void Start()
    {
        eventSystem = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && cooldownActive == false)
        {
            Debug.Log("i should damage the player");
            cooldownActive = true;
            eventSystem.GetComponent<newPlayerHealth>().Damage(damage);
            StartCoroutine(startCooldown());
        }

        if(other.tag == "Shield" && cooldownActive == false)
        {
            cooldownActive = true;
            other.GetComponent<Health>().Damage(damage);
            StartCoroutine(startCooldown());
        }
    }

    private IEnumerator startCooldown ()
    {
        yield return new WaitForSeconds(damageCooldown);
        cooldownActive = false;
    }

}