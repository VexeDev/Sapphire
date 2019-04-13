using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider mainVolSlider;
    public string parameterName;

    private void Awake()
    {
        float savedVol = PlayerPrefs.GetFloat(parameterName, mainVolSlider.maxValue);
        SetVolume(savedVol); //Manually set value & volume before subscribing to ensure it is set even if slider.value happens to start at the same value as is saved
        mainVolSlider.value = savedVol;
        mainVolSlider.onValueChanged.AddListener((float _) => SetVolume(_)); //UI classes use unity events, requiring delegates (delegate(float _) { SetVolume(_); }) or lambda expressions ((float _) => SetVolume(_))
    }

    void SetVolume(float _value)
    {
        audioMixer.SetFloat(parameterName, ConvertToDecibel(_value / mainVolSlider.maxValue)); //Dividing by max allows arbitrary positive slider maxValue
        PlayerPrefs.SetFloat(parameterName, _value);
    }

    public float ConvertToDecibel(float _value)
    {
        return Mathf.Log10(Mathf.Max(_value, 0.0001f)) * 20f;
    }
}