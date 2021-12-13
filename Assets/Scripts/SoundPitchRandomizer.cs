using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPitchRandomizer : MonoBehaviour
{
    public AudioSource audioSource;
    public float pitchMin = 0.9f;
    public float pitchMax = 1.3f;

    public void PlaySoundWithPitchChange(float pitch=0)
    {
        if (pitch == 0)
            audioSource.pitch = Random.Range(pitchMin, pitchMax);
        else
            audioSource.pitch = pitch;
        audioSource.Play();
    }
}
