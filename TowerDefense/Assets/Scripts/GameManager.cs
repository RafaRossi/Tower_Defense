using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public Text moneyText;
    public Slider slider;
    public GameObject gameOverUI, pauseUI;

    public bool isGameOver = false;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        
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
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
