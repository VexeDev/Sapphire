using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage;
    public float damageCooldown;
    bool cooldownActive;

    public GameObject eventSystem;

    public GameObject sparkEffect;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && cooldownActive == false)
        {
            cooldownActive = true;
            eventSystem.GetComponent<newPlayerHealth>().Damage(damage);
            StartCoroutine(startCooldown());
        }

        if(other.tag == "Shield" && cooldownActive == false)
        {
            cooldownActive = true;
            other.GetComponent<Health>().Damage(damage);
            StartCoroutine(startCooldown());
            //sparkEffect.SetActive(true);
        }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
         if(other.tag == "Shield")
        {
            sparkEffect.SetActive(false);
        }
    }
    */
    private IEnumerator startCooldown ()
    {
        yield return new WaitForSeconds(damageCooldown);
        cooldownActive = false;
    }

}