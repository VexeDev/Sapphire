using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeToss : MonoBehaviour
{

    public float throwForce;
    public GameObject grenade;

    public bool canToss;

    public float upForce;
    public float sideForce;

    public GameObject greyGrenade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Grenade") && canToss == true)
        {
            throwGrenade();
            canToss = false;
        }

        if(canToss == false)
        {
            greyGrenade.SetActive(true);
        } else
        {
            greyGrenade.SetActive(false);
        }
    }

    void throwGrenade ()
    {
        GameObject newGrenade = Instantiate(grenade, transform.position, transform.rotation);
        Rigidbody rb = newGrenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        rb.AddTorque(transform.up * upForce, ForceMode.VelocityChange);
        rb.AddTorque(transform.right * sideForce, ForceMode.VelocityChange);
    }

}
