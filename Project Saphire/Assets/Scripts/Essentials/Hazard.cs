using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage;
    public float damageCooldown;
    bool cooldownActive;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && cooldownActive == false)
        {
            other.GetComponent<PlayerHealth>().Damage(damage);
            cooldownActive = true;
            StartCoroutine(startCooldown());
        }
    }

    private IEnumerator startCooldown ()
    {
        yield return new WaitForSeconds(damageCooldown);
        cooldownActive = false;
    }
}
