using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerData : MonoBehaviour
{
   public void ResetDataButton()
    {
        Player player = new Player() { AttackDamage = 100, DamageReduction = 80, Money = 0, CostBonusAttack = 200, CostBonusArmor = 200 };
        player.SavePlayer();
        print("AI RESETAT TOT! FELICITARI :))");
    }
}
