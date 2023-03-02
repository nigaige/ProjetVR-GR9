using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSFX : MonoBehaviour
{
    
    public AudioSource source;
    public AudioClip clip;
    public float volume;

    public void PlayShootSound(){
        Debug.Log("Source : " + source.ToString() + " Clip : " + clip.ToString() + " Volume : " + volume);
        source.PlayOneShot(clip, volume);
    }
}
