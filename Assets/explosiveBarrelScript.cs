using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveBarrelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            explode();
        }
        else if (collision.gameObject.tag == "ShotGunBullet")
        {
            explode();
        }
        else if (collision.gameObject.tag == "AKBullet")
        {
            explode();
        }
        if (collision.gameObject.tag == "SMGBullet")
        {
            explode();
        }
    }

    private void explode()
    {

    }
}
