using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Soundeffx;
    public AudioSource BgSource;
    public static AudioManager instance = null;
    public float lowPitchRange;
    public float highPitchRange;


    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
    }
    public void PlaySingle(AudioClip clip)
    {
        Soundeffx.clip = clip;
        Soundeffx.Play();


    }

    public void RandomSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        Soundeffx.pitch = randomPitch;
        Soundeffx.clip = clips[randomIndex];
        Soundeffx.Play();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
