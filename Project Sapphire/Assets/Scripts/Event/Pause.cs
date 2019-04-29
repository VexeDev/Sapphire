using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject player;
    public GameObject weapons;
    public GameObject gameUI;

    public bool isPaused;

    public AudioMixer mainAudio;

    private void Start()
    {
        isPaused = false;
        closePause();
        mainAudio.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && isPaused == false)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            player.GetComponent<CharacterController>().enabled = false;
            weapons.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameUI.SetActive(false);
        } else if (Input.GetButtonDown("Pause") && isPaused == true)
        { 
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            player.GetComponent<CharacterController>().enabled = true;
            weapons.SetActive(true);
            player.GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            gameUI.SetActive(true);
        }

        if (isPaused == false)
        {
            Time.timeScale = 1f;
        }
    }

    public void closePause()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<CharacterController>().enabled = true;
        weapons.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameUI.SetActive(true);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
