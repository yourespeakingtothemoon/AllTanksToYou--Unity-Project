using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelObject{
    public string name;
    public float x;
    public float y;
    public float z;
}

[System.Serializable]
public class LevelData 
{
    public List<LevelObject> levelObjects = new List<LevelObject>();
    public List<Transform> MPSpawnPoints = new List<Transform>();

    public string levelName = "Default";
    public string levelDescription = "A Level";
    public string levelAuthor = "Computer";
    public float levelVersion = 1.0f;

    public void AddObject(string name, float x, float y, float z){
        LevelObject obj = new LevelObject();
        obj.name = name;
        obj.x = x;
        obj.y = y;
        obj.z = z;
        levelObjects.Add(obj);
    }


   
}
