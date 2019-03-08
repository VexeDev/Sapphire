using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage;
    public float damageCooldown;
    bool cooldownActive;

    public GameObject eventSystem;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && cooldownActive == false)
        {
            cooldownActive = true;
            eventSystem.GetComponent<newPlayerHealth>().Damage(damage);
            StartCoroutine(startCooldown());
        }
    }

    private IEnumerator startCooldown ()
    {
        yield return new WaitForSeconds(damageCooldown);
        cooldownActive = false;
    }
}
