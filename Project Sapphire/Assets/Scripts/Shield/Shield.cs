using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shieldObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(other.GetComponent<BruteAI>() != null)
            {
                other.GetComponent<BruteAI>().attackingShield = true;
            }
            if(other.GetComponent<StriderAI>() != null)
            {
                Debug.Log("it was a strider, they should be attacking");
                other.GetComponent<StriderAI>().attackingShield = true;
            }
        }

        if(other.tag == "Boss Room")
        {
            if (other.GetComponent<BruteAI>() != null)
            {
                other.GetComponent<BruteAI>().attackingShield = true;
            }
            if (other.GetComponent<StriderAI>() != null)
            {
                other.GetComponent<StriderAI>().attackingShield = true;
            }
        }

        if(other.tag == "Room 1")
        {
            if (other.GetComponent<BruteAI>() != null)
            {
                other.GetComponent<BruteAI>().attackingShield = true;
            }
            if (other.GetComponent<StriderAI>() != null)
            {
                other.GetComponent<StriderAI>().attackingShield = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<Health>().health <= 0)
        {
            if (other.GetComponent<BruteAI>() != null)
            {
                other.GetComponent<BruteAI>().exitShield();
            }
            if (other.GetComponent<StriderAI>() != null)
            {
                other.GetComponent<StriderAI>().exitShield();
            }
        }
        if (shieldObject.GetComponent<Health>().health <= 0)
        {
            if (other.GetComponent<BruteAI>() != null)
            {
                other.GetComponent<BruteAI>().exitShield();
            }
            if (other.GetComponent<StriderAI>() != null)
            {
                other.GetComponent<StriderAI>().exitShield();
            }
        }
    }
}
