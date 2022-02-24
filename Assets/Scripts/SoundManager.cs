using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;

    [SerializeField] private AudioSource audioSource;

    public void PlaySound()
    {
        audioSource.PlayOneShot(coinSound, 0.7F);
    }
}
