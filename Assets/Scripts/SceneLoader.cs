using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private readonly int levelCount = 5;

    void Awake()
    {
        LevelManager.levelPosition = Vector3.zero;
        AllMoves.nextMove = new Queue<NextMove>();

        var saver = new SceneHelper();
        for (int i = saver.LastLevel; i < levelCount; i++)
        {
            StartCoroutine(LoadScene(i.ToString()));
        }
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return null;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public static void LoadScene(int levelNumber, int worldNumber = 1)
    {
        var saver = new SceneHelper();
        saver.SetLevel(worldNumber, levelNumber);
        SceneManager.LoadScene("SceneLoader"); 
    }
}
    