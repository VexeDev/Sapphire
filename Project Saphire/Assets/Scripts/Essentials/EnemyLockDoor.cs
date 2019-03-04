using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLockDoor : MonoBehaviour
{
    int enemies;
    Animator anim;

    public string room;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("CloseOut", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag(room).Length <= 0)
        {
            if(anim.GetBool("CloseOut") == true)
            {
                anim.SetBool("CloseOut", false);
                anim.SetBool("OpenOut", true);
            } else if (anim.GetBool("CloseIn") == true)
            {
                anim.SetBool("CloseIn", false);
                anim.SetBool("OpenIn", true);
            }
        }
    }
}
