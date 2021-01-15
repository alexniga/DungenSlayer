using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public int Money { get; set; }
    public int AttackDamage { get; set; }
    public int DamageReduction { get; set; }
    public int HighScore { get; set; }

    public void SavePlayer()
    {
        SaveSystemPlayer.SavePlayerData(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer();
        Money = data.Money;
        AttackDamage = data.AttackDamage;
        DamageReduction = data.DamageReduction;
        HighScore = data.HighScore;
    }
}