using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour {

	private void ExitGame()
    {
        Application.Quit();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ExitGame();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            RestartGame();
        }
    }
}
