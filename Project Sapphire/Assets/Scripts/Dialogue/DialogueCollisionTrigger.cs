using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollisionTrigger : MonoBehaviour
{
    GameObject dialogueCanvas;

    void Start()
    {
        //Debug.Log("i am alive");
        dialogueCanvas = GameObject.FindGameObjectWithTag("DialogueCanvas");
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger entered");
        if (other.tag == "Player")
        {
            //Debug.Log("player collided with me");
            dialogueCanvas.GetComponent<DialogueTrigger>().triggerDialogue();
            this.enabled = false;
        }
    }
}
