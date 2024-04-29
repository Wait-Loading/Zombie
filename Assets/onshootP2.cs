using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class onshootP2 : MonoBehaviour
{
    public Transform player;
    public float speed = 5000f;
    public GameObject bulletPrefab;
    public GameObject shotgunBulletPrefab;
    public GameObject rocketPrefab;
    public GameObject lazerPrefab;
    public GameObject akbulletPrefab;
    public GameObject smgbulletPrefab;
    public GameObject grenade;
    public GameObject Wallprefab;
    public GameObject Baralle;

    public float fixedDistance = 0.5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    GameObject shot;
    //CODE BETTER NEXT TIME

    public float bulletSpeed = 10f;
    public int numBullets = 5;
    public float spreadAngle = 30f;

    private float shootSpeed = 0.0f;
    private bool isHolding = false;

    public int index = 0;
    public int limit = 0;

    private Vector2 shootSpot = Vector2.right;
    public AudioSource ASS;
    enum guns
    {
        pistol, shotgun, RockerLauncher, Raygun, Ak47, SMG, Grenade, Walls, barallels
    }
    guns[] Inventory = { guns.pistol, guns.shotgun, guns.RockerLauncher, guns.Raygun, guns.Ak47, guns.SMG, guns.Grenade, guns.Walls, guns.barallels };

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.xp > 50 && GameManager.Instance.xp < 500)
        { limit = GameManager.Instance.xp / 50; }

        if (Input.GetKeyDown(KeyCode.E))
        {
            index++;
            if (index <= limit)
            {

            }
            else
            {
                index--;
            }
            Debug.Log(index);

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            index--;
            if (index > 0)
            {

            }
            else
            {
                index++;
            }
            Debug.Log(index);

        }


        movement.x = Input.GetAxisRaw("Horizontal2");
        movement.y = Input.GetAxisRaw("Vertical2");
        if (!movement.Equals(Vector2.zero))
        {
            shootSpot = movement;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHolding = true;
            if (index == 0)
            {
                StartCoroutine(pistolShoot());

            }
            else if (index == 1)
            {
                StartCoroutine(shotGunShoot());

            }
            else if (index == 2)
            {
                StartCoroutine(rocketShoot());
            }
            else if (index == 3)
            {
                StartCoroutine(laserShoot());
            }
            else if (index == 4)
            {
                StartCoroutine(akShoot());
            }
            else if (index == 5)
            {
                StartCoroutine(smgShoot());
            }
            else if (index == 6)
            {
                StartCoroutine(grenadeThrow());
            }
            else if (index == 7)
            {
                // Instantiate a bullet
                shot = Instantiate(Wallprefab, transform.position + (new Vector3(shootSpot.x, shootSpot.y, 0) * fixedDistance), Quaternion.identity);


                // Apply force
                // rb.AddForce(speed * shootSpot.normalized, ForceMode2D.Force);
            }
            else if (index == 8)
            {
                shot = Instantiate(Baralle, transform.position + (new Vector3(shootSpot.x, shootSpot.y, 0) * fixedDistance), Quaternion.identity);

            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
            isHolding = false;
    }

    public IEnumerator pistolShoot()
    {
        while (isHolding)
        {
            // Instantiate a bullet
            shot = Instantiate(bulletPrefab, transform.position + (new Vector3(shootSpot.x, shootSpot.y, 0) * fixedDistance), Quaternion.Euler(0, 0, Mathf.Atan2(shootSpot.x, shootSpot.y) * Mathf.Rad2Deg));
            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            ASS.Play();
            // Apply force
            rb.AddForce(speed * shootSpot.normalized, ForceMode2D.Force);

            yield return new WaitForSeconds(0.3f);
        }
    }

    public IEnumerator shotGunShoot()
    {
        while (isHolding)
        {
            for (int i = 0; i < numBullets; i++)
            {
                float angleOffset = (i - (numBullets - 1) / 2f) * spreadAngle;
                Quaternion rotation = Quaternion.Euler(0f, 0f, angleOffset);
                Vector2 bulletDirection = rotation * shootSpot;

                GameObject bullet = Instantiate(shotgunBulletPrefab, transform.position + (new Vector3(shootSpot.x, shootSpot.y, 0) * fixedDistance), Quaternion.Euler(0, 0, Mathf.Atan2(shootSpot.x, shootSpot.y) * Mathf.Rad2Deg));
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = bulletDirection * bulletSpeed;
            }
            yield return new WaitForSeconds(0.6f);
        }
    }

    public IEnumerator akShoot()
    {
        while (isHolding)
        {
            // Instantiate a bullet
            shot = Instantiate(bulletPrefab, transform.position + (new Vector3(shootSpot.x, shootSpot.y, 0) * fixedDistance), Quaternion.Euler(0, 0, Mathf.Atan2(shootSpot.x, shootSpot.y) * Mathf.Rad2Deg));
            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            // Apply force
            rb.AddForce(speed * shootSpot.normalized, ForceMode2D.Force);

            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator rocketShoot()
    {
        while (isHolding)
        {
            // Instantiate a bullet
            shot = Instantiate(bulletPrefab, transform.position + (new Vector3(shootSpot.x, shootSpot.y, 0) * fixedDistance), Quaternion.Euler(0, 0, Mathf.Atan2(shootSpot.x, shootSpot.y) * Mathf.Rad2Deg));
            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            // Apply force
            rb.AddForce(100f * shootSpot.normalized, ForceMode2D.Force);

            yield return new WaitForSeconds(1.2f);
        }
    }

    public IEnumerator laserShoot()
    {
        while (isHolding)
        {
            // Instantiate a bullet
            shot = Instantiate(bulletPrefab, transform.position + (new Vector3(shootSpot.x, shootSpot.y, 0) * fixedDistance), Quaternion.Euler(0, 0, Mathf.Atan2(shootSpot.x, shootSpot.y) * Mathf.Rad2Deg));
            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            // Apply force
            rb.AddForce(speed * shootSpot.normalized, ForceMode2D.Force);

            yield return new WaitForSeconds(0.9f);
        }
    }

    public IEnumerator smgShoot()
    {
        while (isHolding)
        {
            // Instantiate a bullet
            shot = Instantiate(bulletPrefab, transform.position + (new Vector3(shootSpot.x, shootSpot.y, 0) * fixedDistance), Quaternion.Euler(0, 0, Mathf.Atan2(shootSpot.x, shootSpot.y) * Mathf.Rad2Deg));
            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            // Apply force
            rb.AddForce(speed * shootSpot.normalized, ForceMode2D.Force);

            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator grenadeThrow()
    {
        while (isHolding)
        {
            // Instantiate a bullet
            shot = Instantiate(grenade, transform.position + (new Vector3(shootSpot.x, shootSpot.y, 0) * fixedDistance), Quaternion.Euler(0, 0, Mathf.Atan2(shootSpot.x, shootSpot.y) * Mathf.Rad2Deg));
            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            // Apply force
            rb.AddForce(80f * shootSpot.normalized, ForceMode2D.Force);

            yield return new WaitForSeconds(0.9f);
        }
    }

    // OnCollisionEnter2D is called when this object collides with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a specific tag, for example, "Enemy"

        Console.WriteLine("THIS SHOULD DESTROY");
        if (shot != null)
        {
            if (shot.gameObject.tag != "Wall")
            {
                Destroy(shot); // Destroy the bullet that belongs to this script
            }
        }

    }
}
