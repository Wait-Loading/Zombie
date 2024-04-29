using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{

    // Pause Menu //
    public GameObject pauseMenu;
    public Button Continue;
    public Button Quit;
    // Wave Change //
    public GameObject waveMenu;
    public TextMeshProUGUI waveChangeText;
    // Level Menu //
    public GameObject levelMenu;
    public Button option1;
    public Button option2;
    public Button option3;
    // End Menu //
    public GameObject endMenu;

    private void Start()
    {
        GameManager.stateChanging += GameState;
        Continue.onClick.AddListener(GameManager.Instance.ResumeGame);
        Quit.onClick.AddListener(Application.Quit);
    }

    private void GameState(GameManager.GameState state)
    {
        switch (state)
        {
            case GameManager.GameState.Paused:
                pauseMenu.SetActive(true);
                Time.timeScale = 0; //Pause the game
                break;
            case GameManager.GameState.WaveChange:
                waveMenu.SetActive(true);
                waveChangeText.text = "Wave " + UnitManager.Instance.wave;
                break;
            case GameManager.GameState.Levelling:
                levelMenu.SetActive(true);
                Time.timeScale = 0; //Pause the game
                break;
            case GameManager.GameState.Won:
                endMenu.SetActive(true);
                Time.timeScale = 0; //Pause the game
                break;
            case GameManager.GameState.Lost:
                endMenu.SetActive(true);
                Time.timeScale = 0; //Pause the game
                break;
            default:
                pauseMenu.SetActive(false);
                waveMenu.SetActive(false);
                Time.timeScale = 1; //Resume the game
                break;
        }
    }



}