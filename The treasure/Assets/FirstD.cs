using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstD : MonoBehaviour
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
            string[] dialogue = { "Hello Jack, Welcome to Egypt!",
                "There will be some challenges you have to avoid to reach the treasure",
                "And, here is a hint for you!",
                 "THE TREASURE IN THE TEMPLE" };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
