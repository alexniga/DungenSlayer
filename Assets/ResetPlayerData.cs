using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerData : MonoBehaviour
{
   public void ResetDataButton()
    {
        Player player = new Player() { AttackDamage = 10, DamageReduction = 20, Money = 0, CostBonusAttack = 200, CostBonusArmor = 200 };
        player.SavePlayer();
        print("AI RESETAT TOT! FELICITARI :))");
    }
}
