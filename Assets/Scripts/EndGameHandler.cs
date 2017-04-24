using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour {

	public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
