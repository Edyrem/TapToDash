using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(gameObject.scene.name, LoadSceneMode.Single);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(0);
    }
}
