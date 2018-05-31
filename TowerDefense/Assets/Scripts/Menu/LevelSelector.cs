using UnityEngine;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour {

    public Button[] levelsButtons;
    //public Level[] level;
    public Fade fade;
    public int stars;
    public int currentLevel;

    private void Start()
    {

        if(GameController.instance != null)
            currentLevel = GameController.instance.currentLevel;

        for (int i = 0; i < levelsButtons.Length; i++)
        {
            if (i + 1 > currentLevel)
                levelsButtons[i].interactable = false;
        }
    }


    public void LevelSelect(string level)
    {
        fade.FadeTo(level);
    }
}
