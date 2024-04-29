using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelExplosion : MonoBehaviour
{

    public bool exploded = false;
    public Collider2D collider;
    private List<Collider2D> collidersInRange = new List<Collider2D>();
    public Animator animator;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            exploded = true;
        }
        else if (collision.gameObject.tag == "ShotGunBullet")
        {
            exploded = true;
        }
        else if (collision.gameObject.tag == "AKBullet")
        {
            exploded = true;
        }
        if (collision.gameObject.tag == "SMGBullet")
        {
            exploded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            gameManager.enemyCount--;
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (exploded)
        {
            collider.enabled = true;
            animator.SetTrigger("explosion");
            StartCoroutine(DestroyAfterDelay(0.65f));
        }
    }
}
