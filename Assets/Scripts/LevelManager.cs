using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Finish finish;

    private readonly int currentWorld = 1;
    private readonly float distanceBetweenFinishAndNextStart = 3f;

    public static Vector3 levelPosition = Vector3.zero;

    private void Start()
    {
        transform.position = levelPosition;

        levelPosition = finish.transform.position;
        levelPosition.z += distanceBetweenFinishAndNextStart;        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            SceneManager.SetActiveScene(gameObject.scene);

            // Save current scene level
            var saver = new SceneHelper();
            int currentLevel = int.Parse(gameObject.scene.name);
            saver.SetLevel(currentWorld, currentLevel);
        }
    }
}
