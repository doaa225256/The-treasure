using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckPoint;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        FindObjectOfType<PlayerMovement>().transform.position = CurrentCheckPoint.transform.position;
    }
    public void RespawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
