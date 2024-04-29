using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ZOMBIE : MonoBehaviour
{
    public int health = 100;
    [SerializeField] private Rigidbody2D rb;
    public float moveSpeed;
    public Animator animator;
    public GameObject blood;

    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    // Function to change the sprite
    public void ChangeSpriteDirection(float direction, float vertical)
    {
        // Assuming sprites[0] is for facing left and sprites[1] is for facing right
        int index = (direction > 0) ? 1 : 0; // If direction is positive, use sprites[1] (facing right), otherwise use sprites[0] (facing left)
        if (index == 1)
        { spriteRenderer.flipX = false; }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
    public float comfyDistance;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        movement = GameManager.Instance.player.position - transform.position;
        // Calculate the direction of movement
        float direction = movement.x;
        float vertical = movement.y;

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            this.animator.SetBool("walkingSide", true);
            this.animator.SetBool("walkingSouth", false);
            this.animator.SetBool("walkingNorth", false);

        }
        else if (movement.y > 0 && movement.x < 0.10)
        {
            this.animator.SetBool("walkingNorth", true);
            this.animator.SetBool("walkingSouth", false);
            this.animator.SetBool("walkingSide", false);

        }
        else if (movement.y < 0 && movement.x < 0.10)
        {
            this.animator.SetBool("walkingSouth", true);
            this.animator.SetBool("walkingNorth", false);
            this.animator.SetBool("walkingSide", false);
        }

        // Change the sprite direction based on the movement
        ChangeSpriteDirection(direction, vertical);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(movement.x) > comfyDistance && Mathf.Abs(movement.y) > comfyDistance)
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            damageMe(20, collision);
        }
        else if (collision.gameObject.tag == "ShotGunBullet")
        {
            damageMe(30, collision);
        }
        else if (collision.gameObject.tag == "AKBullet")
        {
            damageMe(40, collision);
        }
        else if (collision.gameObject.tag == "SMGBullet")
        {
            damageMe(30, collision);
        }
        else if (collision.gameObject.tag == "Laser")
        {
            damageMe(70, collision);
        }
        else if (collision.gameObject.tag == "Rocket")
        {
            damageMe(100, collision);
        }
        else if (collision.gameObject.tag == "Grenade")
        {
            damageMe(100, collision);
        }
    }

    private void damageMe(int damage, Collision2D collision)
    {
        Destroy(collision.gameObject);

        health -= damage;
        Debug.Log(health);

        if (health <= 0)
        {
            Destroy(gameObject);
            UnitManager.Instance.waveKillCounter++;
        }
        GameManager.Instance.xp += 5;
        Instantiate(blood, transform.position,Quaternion.identity) ;
    }
}
