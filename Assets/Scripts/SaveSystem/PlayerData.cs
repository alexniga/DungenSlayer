using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{ 
    public int Money { get; set; }
    public int AttackDamage { get; set; }
    public int DamageReduction { get; set; }
    public int HighScore { get; set; }
    public int CostBonusAttack { get; set; }
    public int CostBonusArmor { get; set; }

    public PlayerData(Player player)
    {
        Money = player.Money;
        AttackDamage = player.AttackDamage;
        DamageReduction = player.DamageReduction;
        HighScore = player.HighScore;
        CostBonusArmor = player.CostBonusArmor;
        CostBonusAttack = player.CostBonusAttack;
    }
}
