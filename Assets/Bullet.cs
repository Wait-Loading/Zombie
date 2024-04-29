using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan = 2.0f;  // The time (in seconds) before the projectile is destroyed.
    public Animator animator;

    void Update()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag == "Rocket")
        {
            animator.SetTrigger("explosion");
        }
        if ( !(collision.gameObject.tag == "PlayerProjectile" || collision.gameObject.tag == "ShotGunBullet" || collision.gameObject.tag == "AKBullet" || collision.gameObject.tag == "SMGBullet" || collision.gameObject.tag == "Laser" || collision.gameObject.tag == "Rocket" || collision.gameObject.tag == "Grenade") )
            Destroy(gameObject);
    }
}