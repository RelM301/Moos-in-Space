using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnimPlay : MonoBehaviour
{
    AudioSource ufoSound;
    void Start()
    {
        ufoSound = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        ufoSound.Play();
    }
}
