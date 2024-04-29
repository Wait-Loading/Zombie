using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walldamage : MonoBehaviour
{
    // Start is called before the first frame update
    
   public int health = 100;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
           
            health -= 20;
            Debug.Log("WALL HEALTH: "+health);
            if (health <= 0)
            {
                Destroy(this);
            }
        }
    }
}
