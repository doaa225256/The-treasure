using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CurrentCheckpoint;
    public Transform enemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        FindObjectOfType<PlayerMovement>().transform.position = CurrentCheckpoint.transform.position;
    }

    public void RespawnEnemy() {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
