using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEngine : MonoBehaviour
{

    private Queue<string> sentences;
    public Text nameText;
    public Text messageText;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue (Dialogue dialogue)
    {
        anim.SetBool("IsOpen", true);

        nameText.text = dialogue.Name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        messageText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            messageText.text += letter;
            yield return null;
        }
    }

    void EndDialogue ()
    {
        anim.SetBool("IsOpen", false);
    }
}
