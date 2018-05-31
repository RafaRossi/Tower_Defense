using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    public Fade fade;
    public Button continueButton;
    public GameObject newGamePanel;

    bool isLoaded;

    private void Start()
    {
        isLoaded = GameController.instance.Load();

        if (!isLoaded)
            continueButton.interactable = false;
    }

    public void ContinueGame()
    {
        fade.FadeTo("LevelSelect");
    }

    public void ConfirmGame()
    {
        if (isLoaded)
        {
            newGamePanel.SetActive(true);
        }
        else
            NewGame();
    }

    public void NewGame()
    {
        GameController.instance.currentLevel = 1;
        GameController.instance.Save();
        ContinueGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
