using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public Text moneyText;
    public Slider slider;
    public GameObject gameOverUI, pauseUI, winUI;
    public Fade fade;

    public int levelToUnlock;

    public bool isGameOver = false;

    public int maximum, current;

    Dictionary<string, int> level = new Dictionary<string, int>();

    int stars, lifes;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        lifes = PlayerStats.Lifes;
    }

    // Update is called once per frame
    void Update () {
        moneyText.text = "$ " + PlayerStats.Money;
        slider.value = PlayerStats.Lifes;

        if (isGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape)){
            Toggle();
        }

        if (PlayerStats.Lifes <= 0)
            GameOver();
	}

    void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }

    public void Toggle()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);

        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1;
        fade.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        fade.FadeTo("Menu");
    }

    public void WinLevel()
    {
        winUI.SetActive(true);
        isGameOver = true;

        stars++;

        if (PlayerStats.Lifes == lifes)
            stars++;

        if (current <= maximum)
            stars++;

        if (levelToUnlock > GameController.instance.currentLevel)
            GameController.instance.currentLevel = levelToUnlock;

        level.Add(SceneManager.GetActiveScene().name, stars);
        GameController.instance.GetDicitonary(level, SceneManager.GetActiveScene().name);

        GameController.instance.Save();
    }

    public void Continue()
    {
        fade.FadeTo("LevelSelect");
    }

}
