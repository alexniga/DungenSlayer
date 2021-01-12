using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int Money { get; set; }
    public int AttackDamage { get; set; }
    public int DamageReduction { get; set; }
    public int HighScore { get; set; }

    public PlayerData(Player player)
    {
        Money = player.Money;
        AttackDamage = player.AttackDamage;
        DamageReduction = player.DamageReduction;
        HighScore = player.HighScore;
    }
}
