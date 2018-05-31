using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

    public Fade fade;
    public Level level;
    Button button;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        if (level.isLocked)
            button.interactable = false;
        else
            button.interactable = true;
    }
}
