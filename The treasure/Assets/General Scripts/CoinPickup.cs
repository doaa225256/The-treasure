//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////public class CoinPickup : MonoBehaviour
//{
//    public AudioClip coin1;
//    public AudioClip coin2;

//    //Start is called before the first frame update
//    void Start()
//    {

//    }

//    Update is called once per frame
//    void Update()
//    {

//    }
//    void OnTriggerEnter2D(Collider2D collider)
//    {

//        if (collider.tag == "Player")
//        {
//            FindObjectOfType<PlayerMovement>().totalcoin += total_value;

//            Destroy(this.gameObject);
//            .AudioManager.instance.playSingle(coin1);
//        }
//    }
//}
