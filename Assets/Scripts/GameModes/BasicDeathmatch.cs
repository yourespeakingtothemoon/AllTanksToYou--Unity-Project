using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDeathmatch : GameMode
{
    [SerializeField] int stock = 3;
void Start()
    {
      
        goalType = GameGoalType.Defeat;
        //
    }

   void Update()
    {
     
       
    }

    public override string GetRemain()
    {
        return "";
    }

    public override string GetTime()
    {
        return "";
    }

    public override void Initalize()
    {
        Player[] players = FindObjectsOfType<Player>();
        foreach (Player player in players)
        {
            this.players.Add(player);
        }
    }

    public override void RemoveEnemy(Enemydummy enemy)
    {
        throw new System.NotImplementedException();
    }


}
