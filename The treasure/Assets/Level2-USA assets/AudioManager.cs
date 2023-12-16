//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.InteropServices.ComTypes;
//using UnityEngine;

//public class AudioManager : MonoBehaviour
//{

//    public AudioSource efxSource;
//    public AudioSource musicSource;
//    public static AudioManager instance=null;
//    public float lowPitchRange = 0.95f;
//    public float highPitchRange = 1.05f;


//    // Start is called before the first frame update
//    void Start()
//    {
//        void Awake()
//        {
//            if (instance == null)
//                instance = this;
//            else if (instance != this)
//                Destroy(gameObject);

//            DontDestroyOnLoad(gameObject);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//    public void playSingle(AudioClip clip)
//    {
//        efxSource.clip=clip;
//        efxSource.Play();
//    }
//    public void RandomizeSfx(params AudioClip[] clips)
//    {
//        int randomIndex=UnityEngine.Random.Range(0, clips.Length);
//        float randomPitch= UnityEngine.Random.Range(lowPitchRange, highPitchRange);
//        efxSource.pitch=randomPitch;
//        efxSource.clip = clips[randomIndex];
//        efxSource.Play();
//    }
//}
