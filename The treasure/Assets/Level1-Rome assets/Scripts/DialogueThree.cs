using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueThree : MonoBehaviour
{
    public Dialogue dialogueManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            string[] dialogue = { "Jack: Hey, old friend. I've heard you have a map. I need it to find the treasure.", "Enemy (Father's Friend): I can't just hand it over, Jack. It's a treasure.", "Jack: hmmm... then we have to Fight!" };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
