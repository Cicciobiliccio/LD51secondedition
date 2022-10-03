using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    
    public static AudioManager instance;

    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup fxMixerGroup;
    [SerializeField] private AudioMixerGroup MasterMixerGroup;
    
    public Sound[] sounds;

    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider FxSlider;

    public void SetMainVolume (float volume) {
        if (volume == -40) {
            volume = -80;
        }
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume (float volume) {
        if (volume == -40) {
            volume = -80;
        }
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetFxVolume (float volume) {
        if (volume == -40) {
            volume = -80;
        }
        audioMixer.SetFloat("FXVolume", volume);
        PlayerPrefs.SetFloat("FXVolume", volume);
        PlayerPrefs.Save();
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

                case Sound.AudioTypes.information:
                    s.source.outputAudioMixerGroup = MasterMixerGroup;
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
        
        if (PlayerPrefs.HasKey("MasterVolume")) {
            masterSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MasterVolume");
        } else {
            audioMixer.GetFloat("MasterVolume", out float MasterVolume);
            PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("MusicVolume")) {
            musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
        } else {
            audioMixer.GetFloat("MusicVolume", out float MusicVolume);
            PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("FXVolume")) {
            FxSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("FXVolume");
        } else {
            audioMixer.GetFloat("FXVolume", out float FXVolume);
            PlayerPrefs.SetFloat("FXVolume", FXVolume);
            PlayerPrefs.Save();
        }
    }
}
