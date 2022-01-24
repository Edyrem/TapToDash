using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Finish finish;

    private string sceneNameToLoad;

    private readonly string lastScene = "Level6";
    private readonly int currentWorld = 1;
    private readonly float distanceBetweenFinishAndNextStart = 3f;

    public static Vector3 position = Vector3.zero;

    private void Start()
    {
        sceneNameToLoad = GetNextLevelName(gameObject.scene.name);

        if (sceneNameToLoad != lastScene)
        {
            StartCoroutine(LoadScene(sceneNameToLoad));
        }        
        
        if (position != Vector3.zero)
        {
            transform.position = position;            
        }
        position = finish.transform.position;
        position.z += distanceBetweenFinishAndNextStart;
    }

    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private string GetNextLevelName(string currentSceneName)
    {
        int sceneLevel = GetStringLastNumber(currentSceneName);
        sceneLevel++;
        return (currentSceneName.Remove(currentSceneName.Length - 1) + sceneLevel);
    }

    private int GetStringLastNumber(string stringWithNumber)
    {
        return int.Parse(stringWithNumber[stringWithNumber.Length - 1].ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            SceneManager.SetActiveScene(gameObject.scene);

            // Save current scene level
            var saver = new SceneHelper();
            int currentLevel = GetStringLastNumber(gameObject.scene.name);
            saver.SetLevel(currentWorld, currentLevel);
        }
    }
}
