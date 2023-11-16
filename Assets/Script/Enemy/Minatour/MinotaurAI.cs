using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinotaurAI : MonoBehaviour
{
    //health
    public int maxHealthMino = 3;
    public int minoHealth;

    //movement
    public GameObject player;
    public float speed;
    private float distance;

    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        minoHealth = maxHealthMino;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            if (distance < 2)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                animator.SetBool("isRunMinotaur", true);
                animator.SetFloat("xMinotaur", direction.x);
            }
            else
            {
                animator.SetBool("isRunMinotaur", false);
            }
        }
        else
        {
            animator.SetBool("isRunMinotaur", false);
        }
    }

    public void takeDamageGolem(int playerDamage)
    {
        if (this != null)
        {
            minoHealth -= playerDamage;
            if (minoHealth <= 0)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                animator.SetTrigger("isHitMinotaur");
            }
        }
    }
}
