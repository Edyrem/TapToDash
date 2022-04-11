using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneProfile
{
    public int[] WorldLevel;
    public int LastScene;
    public int LastWorld;

    public SceneProfile()
    {
        WorldLevel = new int[4];
        for (int i = 0; i < WorldLevel.Length; i++)
        {
            WorldLevel[i] = 0;
        }
        LastScene = 0;
        LastWorld = 0;
    }
}
