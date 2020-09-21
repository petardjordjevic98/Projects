using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class  SoundManager 
{
    public static void PlaySound()
    {
        GameObject s = new GameObject("Sound", typeof(AudioSource));
        AudioSource a = s.GetComponent<AudioSource>();
        Debug.Log(GameAssets.GetInstanceOf().birdJump);
        a.PlayOneShot(GameAssets.GetInstanceOf().birdJump);
       // AudioSource as= s.GetComponent<AudioSource>();
        
    }
}
