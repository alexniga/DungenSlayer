using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermanentBuffsPannel : MonoBehaviour
{
    public GameObject Pannel;
    
    public Button UpgradeAttack;
    public Button UpgradeDefence;
    
    public Text CostAttack;
    public Text CostArmor;

    public Text CurrentDamage;
    public Text CurrentArmor;
    public Text CurrentMoney;

    Player player = new Player();

    public void StartButton()
    {
        Time.timeScale = 1f;
        Pannel.SetActive(false);
    }

    public void Update()
    {
        player.LoadPlayer();
        CostArmor.text = player.CostBonusArmor.ToString();
        CostAttack.text = player.CostBonusAttack.ToString();
        
        if (player.CostBonusAttack > player.Money)
        {
            UpgradeAttack.interactable = false;
        }
        else
        {
            UpgradeAttack.interactable = true;
        }

        if (player.CostBonusArmor > player.Money)
        {
            UpgradeDefence.interactable = false;
        }
        else
        {
            UpgradeDefence.interactable = true;
        }

    }

    public void UpgradeAttackButton()
    {
        player.LoadPlayer();
        player.Money -= player.CostBonusAttack;
        player.AttackDamage += 10;
        player.CostBonusAttack += (int)(player.CostBonusAttack / 2);
        CurrentDamage.text = player.AttackDamage.ToString();
        CurrentMoney.text = player.Money.ToString();
        player.SavePlayer();
    }

    public void UpgradeArmorButton()
    {
        player.LoadPlayer();
        player.Money -= player.CostBonusArmor;
        player.DamageReduction += 10;
        player.CostBonusArmor += (int)(player.CostBonusArmor / 2);
        if (player.DamageReduction == 80)
        {
            player.CostBonusArmor = 9999;
        }
        CurrentArmor.text = player.DamageReduction.ToString();
        CurrentMoney.text = player.Money.ToString();
        player.SavePlayer();
    }

}
