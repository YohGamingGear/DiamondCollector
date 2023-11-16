using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);
        AnimateMovement(direction);

        transform.position += direction * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isWalk", true);

                animator.SetFloat("X", direction.x);
                animator.SetFloat("Y", direction.y);
            }
            else
            {
                animator.SetBool("isWalk", false);
            }
        }
    }
    void OnFire()
    {
        animator.SetTrigger("isAttack");
    }
}
