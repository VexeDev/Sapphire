﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maximumHealth = 101;
    public GameObject player;

    float animationSpeed = 0.075f;
    public Image healthBar;

    public GameObject playerUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float bla = (float)currentHealth / 100;
        if(currentHealth <= 0)
        {
            Die();
        }

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, bla,animationSpeed);
    }

    public void Damage (int damageAmount)
    {
        currentHealth = currentHealth - damageAmount;
        Debug.Log("i should be applying damage");
    }

    void Die()
    {
        //disable movement, play an animation, game over screen or smth, and give the player the opportunity to retry the level

        //disable movement
        player.GetComponent<CharacterController>().enabled = false;
        //disable player ui
        playerUI.SetActive(false);
    }
}