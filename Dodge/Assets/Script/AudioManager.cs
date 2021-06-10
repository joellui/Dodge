using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public sound[] Sounds;

    public static AudioManager instance;
    
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();

            s.Source.clip = s.clip;
            s.Source.volume = s.volume;
            s.Source.pitch = s.pitch;
            s.Source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Background");
    }

    public void Play(string name)
    {
        sound s =Array.Find(Sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound:"+ name+"not found!");
            return;
        }
        s.Source.Play();
    }
}

//to use audio manager in other files is 
// FindobjectType<AudioManager>().Play("Name");
