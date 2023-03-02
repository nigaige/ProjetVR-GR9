using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSFX : MonoBehaviour
{
    
    public AudioSource source;
    public AudioClip clip;
    public float volume;

    public void PlayShootSound(){
        source.PlayOneShot(clip, volume);
    }
}
