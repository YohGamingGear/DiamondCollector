using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GolemAI : MonoBehaviour
{
    //health
    public int maxHealthGolem = 3;
    public int golemHealth;

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

        golemHealth = maxHealthGolem;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) 
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            if (distance < 1)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                animator.SetBool("isRunGolem", true);
                animator.SetFloat("xGolem", direction.x);
            }
            else
            {
                animator.SetBool("isRunGolem", false);
            }
        }
        else
        {
            animator.SetBool("isRunGolem", false);
        }
    }

    public void takeDamageGolem(int playerDamage)
    {
        if (this != null)
        {
            golemHealth -= playerDamage;
            if (golemHealth <= 0)
            {
                animator.SetTrigger("isDeathGolem");
                Destroy(gameObject, 0.9f);
            }
            else
            {
                animator.SetTrigger("isHitGolem");
            }
        }
    }
}
