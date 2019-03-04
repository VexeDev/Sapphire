using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    Animator anim;

    public bool startOpenOut;
    public bool startOpenIn;
    public bool startClosedIn;
    public bool startClosedOut;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

        if(startOpenOut == true)
        {
            anim.SetBool("OpenOut", true);
        }
        if (startClosedOut == true)
        {
            anim.SetBool("ClosedOut", true);
        }
        if (startClosedIn == true)
        {
            anim.SetBool("OpenIn", true);
        }
        if (startOpenIn == true)
        {
            anim.SetBool("OpenIn", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (anim.GetBool("OpenOut") == true)
            {
                anim.SetBool("OpenOut", false);
                anim.SetBool("CloseOut", true);
            }
            else if (anim.GetBool("OpenIn") == true)
            {
                anim.SetBool("OpenIn", false);
                anim.SetBool("CloseIn", true);
            }
        }
    }

}
