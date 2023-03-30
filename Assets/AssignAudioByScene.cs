using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignAudioByScene : MonoBehaviour
{

    public void ChangeMusicOnSceneChange(AudioClip clip)
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if (audio.clip.name != clip.name)
        {
            audio.Stop();
            audio.clip = clip;
            audio.Play();
        }
    }
}
