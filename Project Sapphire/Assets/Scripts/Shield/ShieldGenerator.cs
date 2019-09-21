using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShieldGenerator : MonoBehaviour
{
    public GameObject shield;
    Animator anim;
    public float detonateTime;

    public float range = 2f;

    bool shieldMakeHasPlayed;

    private void Start()
    {
        anim = shield.GetComponent<Animator>();
        //audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public AudioClip shieldMake;

    private void Update()
    {
        RaycastHit leftRay;
        RaycastHit rightRay;

        detonateTime = detonateTime - Time.deltaTime;
        if(detonateTime <= 0)
        {
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.right, out rightRay, range) || Physics.Raycast(gameObject.transform.position, gameObject.transform.right * -1, out leftRay, range))
            {
                //Debug.Log("i cant expand");
            }
            else
            {
                if (!GetComponent<AudioSource>().isPlaying && shieldMakeHasPlayed == false)
                {
                    GetComponent<AudioSource>().clip = shieldMake;
                    GetComponent<AudioSource>().Play();
                    shieldMakeHasPlayed = true;
                }
                
                //Debug.Log("the sounds hould have been played");
                anim.SetBool("expand", true);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                shield.GetComponent<BoxCollider>().enabled = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}