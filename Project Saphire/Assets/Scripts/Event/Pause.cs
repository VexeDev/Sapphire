using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject player;
    public GameObject weapons;
    public GameObject gameUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            player.GetComponent<CharacterController>().enabled = false;
            weapons.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameUI.SetActive(false);
        }
    }

    public void closePause()
    {
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
