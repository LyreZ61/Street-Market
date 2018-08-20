using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    private float ZielValue;
    private float ValuePerFrame;

    // Use this for initialization
    void Awake () {
		foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
	}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Play(string name, float randomNumber)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        float MyoldPitch = s.source.pitch;
        s.source.pitch = s.source.pitch + randomNumber;
        s.source.pitch = MyoldPitch;

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void PlayAndStop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        s.source.Play();
    }

    public void PlayAndStop(string name, float randomNumber)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        float MyoldPitch = s.source.pitch;
        s.source.pitch = s.source.pitch + randomNumber;
        s.source.pitch = MyoldPitch;

        s.source.Stop();
        s.source.Play();
    }

    public IEnumerator StartMusic(string name, float TimeForSmoothBegin)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

        ZielValue = s.source.volume;
        ValuePerFrame = ZielValue / TimeForSmoothBegin;
        s.source.volume = 0;

        while (s.source.volume != ZielValue)
        {
            s.source.volume += ValuePerFrame;
            yield return new WaitForSeconds(1f / TimeForSmoothBegin);
        }
        
    }

    public IEnumerator StartNewSound(string oldMusicName, string newMusicName, float TimeForSmoothBegin)
    {
        //Fade Out Music
        Sound s = Array.Find(sounds, sound => sound.name == oldMusicName);

        s.source.volume = ZielValue;
        ZielValue = s.source.volume;
        ValuePerFrame = ZielValue / TimeForSmoothBegin;

        while (s.source.volume != 0)
        {
            s.source.volume -= ValuePerFrame;
            yield return new WaitForSeconds(1f / TimeForSmoothBegin);
        }
        s.source.Stop();
        s.source.volume = ZielValue; //Reset
        //Fade In Music

        s = Array.Find(sounds, sound => sound.name == newMusicName);
        
        ZielValue = s.source.volume;
        ValuePerFrame = ZielValue / TimeForSmoothBegin;
        s.source.volume = 0;

        s.source.Play();

        while (s.source.volume != ZielValue)
        {
            s.source.volume += ValuePerFrame;
            yield return new WaitForSeconds(1f / TimeForSmoothBegin);
        }
        Debug.Log("Music volume: " + s.source.volume.ToString());
    }
}
