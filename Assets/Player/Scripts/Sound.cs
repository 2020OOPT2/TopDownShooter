using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Death_SE;
    public AudioClip Hit_Sound;
    public AudioClip BGM;
    AudioSource Audio;
    private void Awake()
    {
        Audio = this.GetComponent<AudioSource>();
    }

    public void Death_Sound_Play()
    {
        Audio.clip = Death_SE;
        Audio.volume = 0.5f;
        Debug.Log("gg");
        Audio.Play();
    }
    public void Hit_Sound_Play()
    {
        Audio.clip = Hit_Sound;
        Audio.volume = 1f;
        Audio.Play();
    }
    public void BGM_Play()
    {
        Audio.clip = BGM;
        Audio.volume = 0.5f;
        Audio.Play();
    }
    public void BGM_Pause()
    {
        Audio.Pause();
    }
}
