using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BruteAI : MonoBehaviour
{
    Animator anim;

    public Transform player;

    public NavMeshAgent agent;

    bool isMurdering;
    bool isIdle;

    public float attackDistance;

    public float viewDistance;

    public Transform head;

    public float viewAngle;

    bool pursuing = false;

    public float attackTime = 1.4f;

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
        Vector3 direction = player.transform.position - this.transform.position;
        direction.y = 0;

        Vector3 target = player.transform.position;

        Vector3 bruteLocation = this.transform.position;

        float angle = Vector3.Angle(direction, head.forward);

        if (Vector3.Distance(player.position, this.transform.position) < viewDistance && (angle < viewAngle || pursuing == true))
        {

            if(direction.magnitude > attackDistance)
            {
                isIdle = false;
                agent.SetDestination(target);
                //movement anims
                anim.SetBool("isIdle", false);
                anim.SetBool("slash1", false);
                anim.SetBool("slash2", false);
                anim.SetBool("isWalking", true);
                pursuing = true;
                //face player if it is within a distance that is obviously down a hallway
                if (direction.magnitude < 10)
                {

                }
            } else if(direction.magnitude <= attackDistance)
            {
                isIdle = false;
                //attack
                isMurdering = true;
                attack();
                pursuing = true;
            }
        } else
        {
            //be idle
            isIdle = true;
            //idle anims
            anim.SetBool("isIdle", true);
            anim.SetBool("slash1", false);
            anim.SetBool("slash2", false);
            anim.SetBool("isWalking", false);
            pursuing = false;
        }
        
        if(isMurdering == true)
        {
            agent.SetDestination(bruteLocation);
        }

        if(isIdle == true)
        {
            agent.SetDestination(bruteLocation);
        }
    }

    void attack()
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("slash1", true);
        anim.SetBool("slash2", false);
        anim.SetBool("isWalking", false);
        isMurdering = true;
        StartCoroutine(waitForAttack());
        //attack anim
    }

    private IEnumerator waitForAttack()
    {
        yield return new WaitForSeconds(attackTime);
        isMurdering = false;
    }

}