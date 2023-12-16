using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDialogue : MonoBehaviour
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
            string[] dialogue = { "Be Careful! there is a hole jack",
                "Avoid there are several spikes and enemies in the hole",
                "THE MAP IN THE HOLE" };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
