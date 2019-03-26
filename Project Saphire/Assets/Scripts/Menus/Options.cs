using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Text mainVolText;
    public Slider mainVolSlider;

    private void Start()
    {
        mainVolSlider.value = PlayerPrefs.GetFloat("volume");
        mainVolText.text = (1 - (PlayerPrefs.GetFloat("volume") / -80)).ToString();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        mainVolText.text = (1 - (volume / -80)).ToString();
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void Update()
    {
        Screen.fullScreen = true;
    }
}