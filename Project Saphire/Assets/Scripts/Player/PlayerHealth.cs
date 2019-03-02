using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maximumHealth = 100;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Damage (int damageAmount)
    {
        currentHealth = currentHealth - damageAmount;
    }

    void Die()
    {
        //disable movement, play an animation, game over screen or smth, and give the player the opportunity to retry the level

        //disable movement
        player.GetComponent<CharacterController>().enabled = false;
    }
}