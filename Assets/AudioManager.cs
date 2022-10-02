using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    
    public static AudioManager instance;

    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup fxMixerGroup;
    public Sound[] sounds;

    public AudioMixer audioMixer;

    public void SetMainVolume (float volume) {
        if (volume == -40) {
            volume = -80;
        }
        audioMixer.SetFloat("Volume", volume);
    }


    // Start is called before the first frame update
    void Awake() {

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return; 
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            switch (s.audioType) {
                case Sound.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = fxMixerGroup;
                    break;
                
                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }
        }
    }

    public void Play (string name) {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            return;
        }
        s.source.Play();
    }

    public void StopPlaying (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            return;
        }       
        s.source.Stop ();
    }

    void Start() {
        Play("MenuMusic");
    }

}
