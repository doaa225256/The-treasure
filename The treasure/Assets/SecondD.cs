using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondD : MonoBehaviour
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
            string[] dialogue = { "Take care!, you are going to fall into a cave",
                "you have to overcome the cave man to reach the temple",
                 };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}