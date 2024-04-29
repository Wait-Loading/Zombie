using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    public Transform player; // Useful for player position for all other scripts
    public GameObject ene;
    public TextMeshProUGUI xpTxt;
    public int xp = 0;
    public int enemyCount = 0; // Useful for the amount of enemies currently in game for all other scripts

    public GameState State;
    public static event Action<GameState> stateChanging;
    
    public Bounds mapBounds; // Bounds of the game map

    public float TimeOfWaveChangeScreen = 100f;
    private float waveChangeTime = 0.0f;

    private void Start()
    {
        State = GameState.Playing;

        // Calculate map bounds based on the size of the game world
        CalculateMapBounds();
    }

    private void FixedUpdate()
    {
        if (State == GameState.WaveChange)
        {
            waveChangeTime += Time.deltaTime;
            if (waveChangeTime >= TimeOfWaveChangeScreen)
            {
                waveChangeTime = 0;
                changeState(GameState.Playing);
            }
        }
    }

    private void Update()
    {
        //Updates current health and score
        xpTxt.text = "  : " + xp.ToString();

        //Pause and Resume Game with Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (State == GameState.Paused)
                ResumeGame();
            else
                changeState(GameState.Paused); //PauseGame
        }

        

    }

    public void ResumeGame()
    {
        changeState(GameState.Playing);
    }

    public void changeState(GameState state)
    {
        if (state == State) return;
        stateChanging?.Invoke(state);
        State = state;
    }

    private void CalculateMapBounds()
    {
        // Calculate map bounds based on the size of the game world
        GameObject[] objects = FindObjectsOfType<GameObject>();
        Vector3 min = Vector3.zero;
        Vector3 max = Vector3.zero;
        foreach (GameObject obj in objects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                if (renderer.bounds.min.x < min.x)
                    min.x = renderer.bounds.min.x;
                if (renderer.bounds.min.y < min.y)
                    min.y = renderer.bounds.min.y;
                if (renderer.bounds.min.z < min.z)
                    min.z = renderer.bounds.min.z;

                if (renderer.bounds.max.x > max.x)
                    max.x = renderer.bounds.max.x;
                if (renderer.bounds.max.y > max.y)
                    max.y = renderer.bounds.max.y;
                if (renderer.bounds.max.z > max.z)
                    max.z = renderer.bounds.max.z;
            }
        }
        mapBounds = new Bounds((min + max) / 2, max - min);
    }

    [Serializable]
    public enum GameState { Playing, WaveChange, Paused, Levelling, Won, Lost }
}
