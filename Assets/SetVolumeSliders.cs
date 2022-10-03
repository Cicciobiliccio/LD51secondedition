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
        } else {
            masterSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("FXVolume");
            audioMixer.GetFloat("MasterVolume", out float MasterVolume);
            PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("MusicVolume")) {
            musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
        } else {
            musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("FXVolume");
            audioMixer.GetFloat("MusicVolume", out float MusicVolume);
            PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("FXVolume")) {
            FxSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("FXVolume");
        } else {
            FxSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("FXVolume");
            audioMixer.GetFloat("FXVolume", out float FXVolume);
            PlayerPrefs.SetFloat("FXVolume", FXVolume);
            PlayerPrefs.Save();
        }
    }
}
