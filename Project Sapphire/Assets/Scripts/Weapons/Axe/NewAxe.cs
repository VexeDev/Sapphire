using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAxe : MonoBehaviour
{

    public bool hasAxe = true;
    public bool canAttack = true;

    public float swingCooldown;
    public float throwCooldown;

    Coroutine co;

    public Camera fpsCam;
    public GameObject throwLocation;

    public float throwForce;
    public float range;
    public int meleeDamage;

    public GameObject axePrefab;

    public GameObject greyAxe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canAttack == true && hasAxe == true)
            {
                swingAxe();
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (hasAxe == true && canAttack == true)
            {
                throwAxe();
            }
        }

        if (hasAxe == true)
        {
            greyAxe.SetActive(false);

            if (co != null)
            {
                StopCoroutine(co);
            }
        } else
        {
            greyAxe.SetActive(true);
        }
    }

    void swingAxe()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Health target = hit.transform.GetComponent<Health>();
            if (target != null)
            {
                target.Damage(meleeDamage);
            }
        }
        canAttack = false;
        co = StartCoroutine(swungCooldown(swingCooldown));
        StartCoroutine(swungCooldown(swingCooldown));
    }

    void throwAxe ()
    {
        GameObject axePosition = Instantiate(axePrefab, throwLocation.transform.position, throwLocation.transform.rotation);
        Rigidbody rb = axePosition.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        canAttack = false;
        hasAxe = false;
        StartCoroutine(thrownCooldown(throwCooldown));
    }

    public void refillTheAxe ()
    {
        hasAxe = true;
        canAttack = true;
    }

    IEnumerator thrownCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        hasAxe = true;
        canAttack = true;
    }

    IEnumerator swungCooldown (float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
