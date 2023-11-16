using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    //health
    public int maxHealthSlime = 3;
    public int slimeHealth;

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

        slimeHealth = maxHealthSlime;
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
                animator.SetBool("isRunSlime", true);
                animator.SetFloat("xSlime", direction.x);
            }
            else
            {
                animator.SetBool("isRunSlime", false);
            }
        }
        else
        {
            animator.SetBool("isRunSlime", false);
        }
    }

    public void takeDamageGolem(int playerDamage)
    {
        if (this != null)
        {
            slimeHealth -= playerDamage;
            if (slimeHealth <= 0)
            {
                animator.SetTrigger("isDeathSlime");
                Destroy(gameObject, 0.6f);
            }
            else
            {
                animator.SetTrigger("isHitSlime");
            }
        }
    }
}
