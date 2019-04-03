using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrow : MonoBehaviour
{

    public GameObject shieldGenerator;
    public float throwForce;
    public bool canToss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shield") && canToss == true)
        {
            throwShield();
            canToss = false;
        }
    }

    void throwShield ()
    {
        GameObject newShield = Instantiate(shieldGenerator, transform.position, transform.rotation);
        Rigidbody rb = newShield.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
