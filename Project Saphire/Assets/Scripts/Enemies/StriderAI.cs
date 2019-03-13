using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StriderAI : MonoBehaviour
{

    Animator anim;
    public Transform player;
    public NavMeshAgent agent;

    bool isJabbing;
    bool isIdle;
    bool pursuing = false;

    public float attackDistance;
    public float viewRadius;

    public float attackTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isIdle", true);
        agent.stoppingDistance = attackDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;

        Vector3 target = player.transform.position;
        Vector3 striderLocation = this.transform.position;

        if (Vector3.Distance(player.position, this.transform.position) < viewRadius || pursuing == true)
        {
            //walking and attack
            if(direction.magnitude > attackDistance && isJabbing == false)
            {
                //walk
                walk();
                //initial movement
                agent.SetDestination(target);
            } else if(direction.magnitude <= attackDistance)
            {
                //attack
                attack();
            }
        } else
        {
            if (isJabbing == false)
            {
                //be idle
                beIdle();
            }
        }

        if(isJabbing == true)
        {
            agent.SetDestination(striderLocation);
        }
        if(isIdle == true)
        {
            agent.SetDestination(striderLocation);
        }
    }

    //enemy actions
    void attack()
    {
        isIdle = false;
        isJabbing = true;
        //animations right below here
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", true);
        anim.SetBool("isWalking", false);
        StartCoroutine(waitForAttack());
        pursuing = true;
    }

    void beIdle()
    {
        isIdle = true;
        //add animations right below here
        anim.SetBool("isIdle", true);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isRunning", false);
        pursuing = false;
    }

    void walk()
    {
        isIdle = false;
        //add animations right below here
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isRunning", true);
        pursuing = true;
    }

    private IEnumerator waitForAttack ()
    {
        yield return new WaitForSeconds(attackTime);
        isJabbing = false;
    }
}
