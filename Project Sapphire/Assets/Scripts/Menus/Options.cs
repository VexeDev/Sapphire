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
    public Text mainVolText;

    private void Awake()
    {
        float savedVol = PlayerPrefs.GetFloat(parameterName, mainVolSlider.maxValue);
        SetVolume(savedVol); //Manually set value & volume before subscribing to ensure it is set even if slider.value happens to start at the same value as is saved
        mainVolSlider.value = savedVol;
        mainVolSlider.onValueChanged.AddListener((float _) => SetVolume(_)); //UI classes use unity events, requiring delegates (delegate(float _) { SetVolume(_); }) or lambda expressions ((float _) => SetVolume(_))
    }

    private void Start()
    {
        mainVolSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
    }

    void SetVolume(float _value)
    {
        audioMixer.SetFloat(parameterName, _value); //Dividing by max allows arbitrary positive slider maxValue
        PlayerPrefs.SetFloat(parameterName, _value);
        float mainValue = mainVolSlider.value;
        float newIsh = mainValue + 80;
        double newerValue = newIsh * 1.25;
        int newValue = Mathf.RoundToInt((float)newerValue);
        mainVolText.text = newValue.ToString() + "%";
    }

    public float ConvertToDecibel(float _value)
    {
        return Mathf.Log10(Mathf.Max(_value, 0.0001f)) * 20f;
    }
}