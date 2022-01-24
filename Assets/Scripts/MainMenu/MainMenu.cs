using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private MainPanel mainMenuPanel;

    [SerializeField]
    private SettingsPanel settingsPanel;

    [SerializeField]
    private WorldsPanel worldsPanel;

    private Animator settingsPanelSwap;
    private Animator worldsPanelSwap;

    private bool isActiveSettings;
    private bool isActiveWorlds;

    private readonly string animationTrigger = "IsActive";

    private void Start()
    {
        var playButtonText = mainMenuPanel.playButton.GetComponentInChildren<Text>();
        var sceneHelper = new SceneHelper();
        if (sceneHelper.LastWorld > 1 || sceneHelper.LastLevel > 1) playButtonText.text = "Continue";

        settingsPanelSwap = settingsPanel.GetComponent<Animator>();
        worldsPanelSwap = worldsPanel.GetComponent<Animator>();
        isActiveSettings = false;
        isActiveWorlds = false;
    }

    public void StartGame()
    {
        var sceneHelper = new SceneHelper();
        string sceneToLoad = "Scenes/World" + sceneHelper.LastWorld + "/Level" + sceneHelper.LastLevel;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ShowSettingsPanel()
    {
        if(isActiveWorlds)
        {
            SwitchPanels(worldsPanelSwap, ref isActiveWorlds);
        }
        SwitchPanels(settingsPanelSwap, ref isActiveSettings);
    }

    public void HideSettingsPanel()
    {
        SwitchPanels(settingsPanelSwap, ref isActiveSettings);
    }

    public void ShowWorldsPanel()
    {
        SwitchPanels(worldsPanelSwap, ref isActiveWorlds);
    }

    public void HideWorldsPanel()
    {
        SwitchPanels(worldsPanelSwap, ref isActiveWorlds);
    }

    private void SwitchPanels(Animator animationPanel, ref bool isActive)
    {
        isActive = !isActive; 
        if (isActiveSettings || isActiveWorlds) 
        { 
            mainMenuPanel.gameObject.SetActive(false); 
        }
        else
        {
            mainMenuPanel.gameObject.SetActive(true);
        }        
        animationPanel.SetBool(animationTrigger, isActive);
    }
}
