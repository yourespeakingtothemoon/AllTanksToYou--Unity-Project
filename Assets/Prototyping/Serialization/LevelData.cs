using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelObject{
    public string name;
    public int id;
    public float x;
    public float y;
    public float z;
}

[System.Serializable]
public class LevelData 
{
    public List<LevelObject> levelObjects = new List<LevelObject>();
    public List<Transform> MPSpawnPoints = new List<Transform>();

    public string levelName;
    public string levelDescription;
    public string levelAuthor;
    public float levelVersion;

    public void AddObject(string name, int id, float x, float y, float z){
        LevelObject obj = new LevelObject();
        obj.name = name;
        obj.id = id;
        obj.x = x;
        obj.y = y;
        obj.z = z;
        levelObjects.Add(obj);
    }


   
}
