using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{

    public void LoadSceneAndData()
    {
        Player player = new Player();

        string fileName = "/PlayerData.txt";
        string path = Application.persistentDataPath + fileName;
        if (File.Exists(path))
        {
            player.LoadPlayer();
            print("FISIERUL EXISTA DEJA");
            print(player.AttackDamage + "-attack \n " + player.DamageReduction + "-armura \n " + player.Money + " bani \n");
        }
        else
        {
            LoadThePlayer();
        }
        Time.timeScale = 0f;
        SceneManager.LoadScene("UIScene");
    }

    void LoadThePlayer()
    {
        
        Player player = new Player() { AttackDamage = 10, DamageReduction = 20, Money = 0 , CostBonusAttack = 500, CostBonusArmor = 500};
        player.SavePlayer();
        print("FISIERUL A FOST CREAT");
    }


}
