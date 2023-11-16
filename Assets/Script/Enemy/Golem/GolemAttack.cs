using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : MonoBehaviour
{

    //damage
    public int damage;
    private PlayerHealth playerHealth;

    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                animator.SetTrigger("isAttackGolem");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range, 
            boxCollider.bounds.size, 0, 
            Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<PlayerHealth>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range,
            boxCollider.bounds.size);
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth.takeDamage(damage);
        }
    }
}
