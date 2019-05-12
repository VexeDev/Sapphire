using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BruteAI : MonoBehaviour
{
    Animator anim;

    public Transform player;

    bool isMurdering;
    bool isIdle;

    public NavMeshAgent agent;

    public float attackDistance;

    public float viewDistance;

    public Transform head;

    public float viewAngle;

    bool pursuing = false;

    public float attackTime = 1.4f;

    public bool attackingShield = false;

    GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isIdle", true);
        agent = this.GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackDistance;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(attackingShield == true)
        {
            attack();
        }

        Vector3 direction = player.transform.position - this.transform.position;
        direction.y = 0;

        Vector3 target = player.transform.position;

        Vector3 bruteLocation = this.transform.position;

        float angle = Vector3.Angle(direction, head.forward);

        if (isMurdering == true)
        {
            agent.SetDestination(bruteLocation);
        }

        if (Vector3.Distance(player.position, this.transform.position) < viewDistance && (angle < viewAngle || pursuing == true))
        {
            if (anim.GetBool("isAttacking") == true)
            {
                agent.SetDestination(bruteLocation);
            }

            if (direction.magnitude > attackDistance && attackingShield == false)
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
            } else if(direction.magnitude <= attackDistance && isMurdering == false)
            {
                attack();
            }
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

    public void attack()
    {
        isIdle = false;
        isMurdering = true;
        anim.SetBool("isIdle", false);
        anim.SetBool("slash1", true);
        anim.SetBool("slash2", false);
        anim.SetBool("isWalking", false);
        pursuing = true;
        StartCoroutine(waitForAttack());
        //attack anim
    }

    public void exitShield ()
    {
        attackingShield = false;
        pursuing = false;
        isMurdering = false;
        isIdle = true;
        anim.SetBool("isIdle", true);
        anim.SetBool("slash1", false);
        anim.SetBool("slash2", false);
        anim.SetBool("isWalking", false);
    }

    private IEnumerator waitForAttack()
    {
        yield return new WaitForSeconds(attackTime);
        isMurdering = false;
    }

}