using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public enum SoundType {
        BAND,
        BAND_DRAW
        
    }
   
    [Serializable]
    public class Sound{
        public SoundType type;
        public AudioClip clip;
        [Range(0.0F, 1.0F)]
        public float volume = 1.0f;

        [HideInInspector]
        public AudioSource source;
    }

    public static AudioManager instance;

    public Sound[] allSounds;

    private Dictionary<SoundType, Sound> _soundDictionary = new Dictionary<SoundType, Sound>();

   
    void Awake(){
        instance = this;

        foreach(var s in allSounds) {
            _soundDictionary[s.type] = s;
        }
    }

    public SoundType selectedSound;

   public void Play(SoundType type) {
        if(!_soundDictionary.TryGetValue(type, out Sound s)) {
            Debug.LogWarning($"Sound type {type} not found");
            return;
        }

        var soundObj = new GameObject($"Sound_{type}");
        var audioSrc = soundObj.AddComponent<AudioSource>();


        audioSrc.clip = s.clip;
        audioSrc.volume = s.volume;

        audioSrc.Play();

        Destroy(soundObj,s.clip.length);
    }
}
