using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOne : MonoBehaviour
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
            string[] dialogue = { "Welcome to the game!", "Left arrow to move left & right arrow to move right", "Space for jump","Uparrow to yhrow knifs and kill enemies","Be Careful! there is a mine bomb jack", "Avoid the spikes!","Avoid red medcines!", "Collect the coins!" };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}