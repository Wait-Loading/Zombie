using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementscript : MonoBehaviour
{
    public int speed;
    public HealthBar healthbar;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement; //Direction of movement vector. Has 0s and 1s
    public Animator animator;
    public Sprite[] sprits;
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    int i = 0;

    // Function to change the sprite
    public void ChangeSpriteDirection(float direction)
    {
        // Assuming sprites[0] is for facing left and sprites[1] is for facing right
        int index = (direction > 0) ? 1 : 0; // If direction is positive, use sprites[1] (facing right), otherwise use sprites[0] (facing left)
        if (direction > 0)
        { spriteRenderer.flipX = false; }
        else if(direction < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.sprite = sprits[i];
        }


    }



    private void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedY", Mathf.Abs(movement.y));
        ChangeSpriteDirection(movement.x);
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            animator.SetBool("goingSide", true);
            animator.SetBool("goingDown", false);
            animator.SetBool("goingUp", false);
             i = 0;
        }
        if (Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
            if (movement.y > 0)
            {
                animator.SetBool("goingUp", true);
                animator.SetBool("goingDown", false);
                animator.SetBool("goingSide", false);
                 i = 1;
            }
            else
            {
                animator.SetBool("goingDown", true);
                animator.SetBool("goingUp", false);
                animator.SetBool("goingSide", false);
                i = 2;
            }
        }

        spriteRenderer.sprite = sprits[i];
        ChangeSpriteDirection(movement.x);


    }

    private void FixedUpdate()
    {
        //Movement

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void takeDmg(int dmg)
    {
        this.healthbar.takeDmg(dmg);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile")
        {

            this.healthbar.takeDmg(20); 
        }
        
    }
}