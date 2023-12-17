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
            string[] dialogue = { "Be Careful! there is a mine bomb jack", "Avoid the spikes!","Avoid red medcines!", "Collect the coins!" };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
