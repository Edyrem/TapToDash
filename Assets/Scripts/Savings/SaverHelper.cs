using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHelper
{

    private readonly string key = "somekey";
    public int LastLevel
    {
        get
        {
            var data = SaveManager.Load<SceneProfile>(key);
            return data.LastScene;
        }
        private set { }
    }

    public int LastWorld
    {
        get
        {
            var data = SaveManager.Load<SceneProfile>(key);
            return data.LastWorld;
        }
        private set { } 
    }

    public int GetLevel(int worldLevel)
    {
        var data = SaveManager.Load<SceneProfile>(key);
        return worldLevel <= data.WorldLevel.Length ? data.WorldLevel[worldLevel - 1] : 1;
    }

    public void SetLevel(int worldLevel, int sceneLevel)
    {
        var loadData = SaveManager.Load<SceneProfile>(key);
        if (worldLevel <= loadData.WorldLevel.Length)
        {
            if (sceneLevel > loadData.WorldLevel[worldLevel - 1])  loadData.WorldLevel[worldLevel - 1] = sceneLevel;
            
            var data = new SceneProfile()
            {
                LastScene = sceneLevel,
                LastWorld = worldLevel,  
                WorldLevel = loadData.WorldLevel
            };
            SaveManager.Save(key, data);
        }
    }

    

    
}
