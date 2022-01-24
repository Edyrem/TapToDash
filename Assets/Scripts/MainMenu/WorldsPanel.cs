using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldsPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject Worlds;
    [SerializeField]
    private GameObject Levels;

    private readonly int WorldNumber = 1;

    private void Start()
    {
        var sceneHelper = new SceneHelper();
        var lastScene = sceneHelper.GetLevel(WorldNumber);
        Debug.Log(lastScene);
        foreach (Transform child in Levels.transform)
        {
            string name = child.name.Remove(child.name.Length - 1);
            if (name == "Level")
            {
                int number = int.Parse(child.name[child.name.Length - 1].ToString());
                if (number > lastScene) child.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void ReturnToWorlds()
    {
        Levels.SetActive(false);
        Worlds.SetActive(true);
    }

    public void ChooseLevel()
    {
        Worlds.SetActive(false);
        Levels.SetActive(true);
    }

    public void StartGame(int level)
    {
        SceneManager.LoadScene("Scenes/World" + WorldNumber + "/Level" + level);
    }
}
