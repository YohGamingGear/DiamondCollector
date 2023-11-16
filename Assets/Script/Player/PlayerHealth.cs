using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;

    public HealthBarPlayer healthBarPlayer;

    SoundManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBarPlayer.SetMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        soundManager.PlaySFX(soundManager.hitPlayer);
        health -= damage;
        healthBarPlayer.SetHealth(health);
        if(health <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}
