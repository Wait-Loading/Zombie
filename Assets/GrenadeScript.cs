using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public bool exploded = false;
    public Collider2D collider;
    private List<Collider2D> collidersInRange = new List<Collider2D>();
    public Animator animator;
    public float blowUpTime = 1.2f;
    private float timer = 0.0f;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        Update();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (animator.isActiveAndEnabled)
        {
            Destroy(other.gameObject);
            gameManager.enemyCount--;
        }

    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        collider.enabled = true;
        animator.SetTrigger("explosion");
        yield return new WaitForSeconds(delay);
        if (exploded)
        {
            Destroy(animator);
            Destroy(gameObject);
        }

    }

    private IEnumerator fuse(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= blowUpTime)
        {
            StartCoroutine(DestroyAfterDelay(0.7f));
        }


        if (exploded)
        {
            Destroy(animator);
            Destroy(this);
          }
    }
}
