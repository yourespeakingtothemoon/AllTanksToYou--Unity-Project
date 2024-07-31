using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelObjectLiteral
{
  public string name;
    public GameObject prefab;
    public Sprite EditorIcon;
   
}


[CreateAssetMenu(fileName = "LevelObjectDB", menuName = "LevelObjectDB")]
public class LevelObjectDB : ScriptableObject
{
  public List<LevelObjectLiteral> levelObjects = new List<LevelObjectLiteral>();

  public GameObject GetLevelObject(string name)
  {
    foreach (LevelObjectLiteral obj in levelObjects)
    {
      if (obj.name == name)
      {
        return obj.prefab;
      }
    }
    return null;
  }
}
