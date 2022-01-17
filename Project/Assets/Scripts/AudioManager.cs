using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public void PlaySound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].name == name)
            {
                AudioSource source = gameObject.AddComponent<AudioSource>();
                source.clip = sounds[i].clip;
                source.pitch = sounds[i].pitch;
                source.volume = sounds[i].volume;

                source.Play();
            }
        }
    }

}
