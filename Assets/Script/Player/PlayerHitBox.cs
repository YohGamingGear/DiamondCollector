using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    public int playerDamage;

    SoundManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Golem"))
        {
            soundManager.PlaySFX(soundManager.hitGolem);

            GolemAI golemHealth =other.GetComponent<GolemAI>();
            
            if(golemHealth != null)
            {
                golemHealth.takeDamageGolem(playerDamage);
            }
        }

        if (other.CompareTag("Slime"))
        {
            soundManager.PlaySFX(soundManager.hitSlime);

            SlimeAI slimeHealth = other.GetComponent<SlimeAI>();

            if (slimeHealth != null)
            {
                slimeHealth.takeDamageGolem(playerDamage);
            }
        }

        if (other.CompareTag("Minatour"))
        {
            soundManager.PlaySFX(soundManager.hitMinotaur);

            MinotaurAI minoHealth = other.GetComponent<MinotaurAI>();

            if (minoHealth != null)
            {
                minoHealth.takeDamageGolem(playerDamage);
            }
        }
    }
}
