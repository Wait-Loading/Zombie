using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrelblast : MonoBehaviour
{
    int health = 1;
    public GameObject bullet;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Instantiate(bullet);
            health -= 20;
            if (health <= 0)
            {
                Destroy(this);
            }
        }
    }
}
