using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneLoadNumber;

    public Slider mainVolSlider;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        mainVolSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
    }

    public GameObject mainPanel;
    public GameObject optionsPanel;

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneLoadNumber);
    }

    public void openOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void closeOptions()
    {
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
