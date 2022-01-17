using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Finish finish;

    private string sceneNameToLoad;
    private string lastScene = "Level6";

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
        position.z += 3f;
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
        int sceneLevel = int.Parse(currentSceneName[currentSceneName.Length - 1].ToString());
        sceneLevel++;
        return (currentSceneName.Remove(currentSceneName.Length - 1) + sceneLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            SceneManager.SetActiveScene(gameObject.scene);
        }
    }
}
