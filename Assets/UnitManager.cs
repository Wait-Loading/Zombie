using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    public GameObject enemyPrefab;  // The enemy prefab to spawn.
    public GameObject sp;
    public int maxEnemies = 10;     // The maximum number of enemies to spawn.
    public float spawnInterval = 2.0f; // The time between enemy spawns.
    public float lowerBound;
    public float upperBound;
    public float offsetAmount = 5.0f; // Offset distance from the player for spawning enemies.
    public int wave = 1;
    private Transform spawnPoint;
    public Transform player;
    public GameObject bossMan;
    public int bossManAmount = 1;
    private bool bossSpawned = false;
    private float timer = 0.0f;
    public int waveKillCounter = 0;


    void Start()
    {
        sp = GameManager.Instance.ene; // Use the position of this GameObject as the spawn point.
        spawnPoint= sp.GetComponent<Transform>();
    }

    void Update()
    {
        if(GameManager.Instance.State == GameManager.GameState.WaveChange)
        {
            return;
        }

        if(waveKillCounter >= maxEnemies)
        {
            waveKillCounter = 0;
            maxEnemies += 5;
            spawnInterval -= 0.1f;
            wave++;
            Debug.Log("Enemy Count = " + GameManager.Instance.enemyCount);
            GameManager.Instance.enemyCount = 0;
            Debug.Log("Max Enemies = " + maxEnemies);
            Debug.Log("Spawn Interval = " + spawnInterval);
            GameManager.Instance.changeState(GameManager.GameState.WaveChange);
            bossSpawned = false;
        }

        if(wave % 5  == 0 && !bossSpawned)
        {
            maxEnemies = 0;
            for(int i = 0; i < bossManAmount; i ++)
            {
                Instantiate(bossMan, sp.transform.position ,Quaternion.identity);
                
            }
            bossManAmount++;
            bossSpawned = true;
        }

        // Check if it's time to spawn a new enemy and if we haven't reached the maximum enemy count.
        if (GameManager.Instance.enemyCount < maxEnemies && timer >= spawnInterval)
        {

            // Calculate spawn position away from the player by the specified offset.
            Vector3 offsetDirection = (Random.insideUnitCircle * Random.Range(lowerBound, upperBound)).normalized;
            Vector3 spawnPosition = spawnPoint.position + offsetDirection * offsetAmount;

            if(Mathf.Abs(spawnPosition.x - player.position.x) > 3 && Mathf.Abs(spawnPosition.y - player.position.y) > 3)
            {
                // Spawn enemy at the calculated position.
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                GameManager.Instance.enemyCount++;
                timer = 0.0f;
            }

        }

        timer += Time.deltaTime;
    }
}
