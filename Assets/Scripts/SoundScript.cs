using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip switchSound;
    public static AudioClip ghostSound;
    static AudioSource audioSrc;

    // Loading the soundfiles from the "Resources" folder
    void Start()
    {
        switchSound = Resources.Load<AudioClip>("Light Switch Click On Sfx");
        ghostSound = Resources.Load<AudioClip>("Mario ghost boo laugh sound effect");
        audioSrc = GetComponent<AudioSource>();
    }

    // Public voids that get called from other scripts to play the sounds
    public static void PlaySound()
    {
        audioSrc.PlayOneShot(switchSound);
    }

    public static void PlaySound2()
    {
        audioSrc.PlayOneShot(ghostSound);
    }
}
