using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Health : MonoBehaviour
{
    Animator anim;

    public int health;

    public bool isStrider;
    public bool isBrute;
    public bool isShield;
    public bool isShieldGenerator;
    public GameObject shieldGenerator;
    public GameObject shield;

    public GameObject bruteWeapon;
    public GameObject fist1;
    public GameObject fist2;

    public bool shouldResetDestination = true;

    public AudioClip shieldBreakClip;
    bool hasPlayed;

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
            bruteWeapon.GetComponent<Hazard>().enabled = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("slash1", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("slash2", false);
            if(shouldResetDestination == true) {
              this.GetComponent<BruteAI>().agent.SetDestination(this.transform.position);
            }
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
            if(shouldResetDestination == true) {
              this.GetComponent<StriderAI>().agent.SetDestination(this.transform.position);
            }
            anim.SetBool("isDead", true);
            this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(striderDie());
            this.GetComponent<StriderAI>().enabled = false;
            fist1.GetComponent<Hazard>().enabled = false;
            fist2.GetComponent<Hazard>().enabled = false;
        }

        if (isShield == true && hasPlayed == false)
        {
            hasPlayed = true;
            shieldGenerator.GetComponent<AudioSource>().clip = shieldBreakClip;
            shield.GetComponent<AudioSource>().Play();
            StartCoroutine(shieldBreakTime());
        }

        if(isShieldGenerator == true && hasPlayed == false)
        {
            hasPlayed = true;
            shieldGenerator.GetComponent<AudioSource>().clip = shieldBreakClip;
            shield.GetComponent<AudioSource>().Play();
            StartCoroutine(shieldBreakTime());
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

    IEnumerator shieldBreakTime ()
    {
        //disable mesh renderer
        shieldGenerator.GetComponent<MeshRenderer>().enabled = false;
        shield.GetComponent<MeshRenderer>().enabled = false;
        shield.GetComponent<BoxCollider>().enabled = false;
        shieldGenerator.GetComponent<BoxCollider>().enabled = false;
        //instantiate shatter effect
        /*insert here*/
        //wait for sound to play before destroying
        yield return new WaitForSeconds(.7f);
        Destroy(shieldGenerator);
    }
}
