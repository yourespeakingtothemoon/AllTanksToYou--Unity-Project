using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : GameMode
{
    [SerializeField] protected GameGoalType goalType = GameGoalType.None;
    private List<Enemydummy> enemies = new List<Enemydummy>();
   
    void Start()
    {
        
        
        
    }

    public override void Initalize()
    {
        Enemydummy[] enemys = FindObjectsOfType<Enemydummy>();
        foreach (Enemydummy enemy in enemys)
        {
            enemies.Add(enemy);
        }
    }

    public override void RemoveEnemy(Enemydummy enemy)
    {
        enemies.Remove(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        TimeLimit -= Time.deltaTime;
    }

    public override string GetRemain()
    {
       return enemies.Count.ToString();
    }

    public override string GetTime()
    {
       return TimeLimit.ToString();
    }
}
