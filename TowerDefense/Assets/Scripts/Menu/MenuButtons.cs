using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public void ContinueGame()
    {

    }

    public void NewGame()
    {
        //Pedir Confirmação se nao existir nenhum jogo salvo
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
