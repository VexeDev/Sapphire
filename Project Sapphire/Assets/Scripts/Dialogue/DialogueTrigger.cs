using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool hasTriggered;
    public GameObject dialogueEngine;

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && hasTriggered == true)
        {
            dialogueEngine.GetComponent<DialogueEngine>().DisplayNextSentence();
        }
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueEngine>().StartDialogue(dialogue);
    }

    public void triggerDialogue ()
    {
        if (hasTriggered == false)
        {
            hasTriggered = true;
            TriggerDialogue();
        }
    }
}
