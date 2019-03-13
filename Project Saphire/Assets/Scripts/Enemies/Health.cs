using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    Animator anim;

    public int health;

    public bool isStrider;
    public bool isBrute;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    public void Damage(int damageAmount)
    {
        health = health - damageAmount;
    }

    void Die()
    {
        if(isBrute == true)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("slash1", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("slash2", false);
            this.GetComponent<BruteAI>().agent.SetDestination(this.transform.position);
            anim.SetBool("isDead", true);
            this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(bruteDie());
            this.GetComponent<BruteAI>().enabled = false;
        }

        if(isStrider == true)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", false);
            this.GetComponent<StriderAI>().agent.SetDestination(this.transform.position);
            anim.SetBool("isDead", true);
            this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(striderDie());
            this.GetComponent<StriderAI>().enabled = false;
        }
    }

    IEnumerator bruteDie ()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    IEnumerator striderDie ()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
