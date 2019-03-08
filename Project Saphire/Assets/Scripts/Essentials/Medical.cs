using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medical : MonoBehaviour
{

    public int healAmount;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (other.GetComponent<newPlayerHealth>().currentHealth < 99)
            {
                other.GetComponent<newPlayerHealth>().Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
