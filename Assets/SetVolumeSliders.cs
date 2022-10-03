using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolumeSliders : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider FxSlider;

    public void SetSliders() {

        if (PlayerPrefs.HasKey("MasterVolume")) {
            masterSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MasterVolume");
            audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        } else {
            audioMixer.GetFloat("MasterVolume", out float MasterVolume);

            audioMixer.SetFloat("MasterVolume", MasterVolume);
            masterSlider.GetComponent<Slider>().value = MasterVolume;

            PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("MusicVolume")) {
            musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
            audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        } else {
            audioMixer.GetFloat("MusicVolume", out float MusicVolume);

            audioMixer.SetFloat("MusicVolume", MusicVolume);
            musicSlider.GetComponent<Slider>().value = MusicVolume;

            PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("FXVolume")) {
            FxSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("FXVolume");
            audioMixer.SetFloat("FXVolume", PlayerPrefs.GetFloat("FXVolume"));
        } else {
            audioMixer.GetFloat("FXVolume", out float FXVolume);

            audioMixer.SetFloat("FXVolume", FXVolume);
            FxSlider.GetComponent<Slider>().value = FXVolume;

            PlayerPrefs.SetFloat("FXVolume", FXVolume);
            PlayerPrefs.Save();
        }
    }
}
