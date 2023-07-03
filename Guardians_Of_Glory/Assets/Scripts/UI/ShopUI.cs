using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
  [SerializeField] private int powerUpgradeCost = 150;
    [SerializeField] private int speedUpgradeCost = 150;
    [SerializeField] private int rangeUpgradeCost = 150;
    [SerializeField] private int maxUpgrades = 10;
    [SerializeField] private Text powerUpgradeCoins ;
    [SerializeField] private Text speedUpgradeCoins ;
    [SerializeField] private Text rangeUpgradeCoins ;
    [SerializeField] private TextMeshProUGUI goldText;
    
    

    [SerializeField] private Bank bank;
   [SerializeField] GameObject[] targetLocator;
   TargetLocator targetLocatorScript;
  [SerializeField] GameObject[] enemies;
  EnemyHealth enemyHealth;

    private int powerUpgrades;
    private int speedUpgrades;
    private int rangeUpgrades;
    void Awake()
    {  
       UpgradeTexts();
        
    }

    private void Start()
    {
       // UpdateUpgradeTexts();
       UpgradeTexts();
      
    }
    void Update()
    {
        targetLocator=GameObject.FindGameObjectsWithTag("Ballista");
        enemies=GameObject.FindGameObjectsWithTag("Enemy");
         TotalTowers();
    }
    void TotalTowers()
    {
        foreach (GameObject tower in targetLocator)
        {
             targetLocatorScript = tower.GetComponent<TargetLocator>();
        }
        foreach(GameObject enemy in enemies)
        {
            enemyHealth=enemy.GetComponent<EnemyHealth>();
        }
    }

    public void UpgradePower()
    {
        if (bank.currentBalance >= powerUpgradeCost && powerUpgrades < maxUpgrades)
        { 
            bank.WithDraw(powerUpgradeCost);
             foreach(GameObject enemy in enemies)
        {
            enemyHealth=enemy.GetComponent<EnemyHealth>();
            if(enemyHealth!=null)
            {
                enemyHealth.DecreasedMaxHealth();
            }
        }
        
            powerUpgradeCost += 100;
            powerUpgrades++;
             UpgradeTexts();
        }
    }

    public void UpgradeSpeed()
    {
        if (bank.currentBalance >= speedUpgradeCost && speedUpgrades < maxUpgrades)
        { 
            bank.WithDraw(speedUpgradeCost);
        
            foreach (GameObject tower in targetLocator)
        {
             targetLocatorScript = tower.GetComponent<TargetLocator>();

            if (targetLocatorScript != null)
            {
              targetLocatorScript.SpeedUpgrade();
            }
        }
             
          
            speedUpgradeCost += 100;
            speedUpgrades++;
            UpgradeTexts();
        }
    }

    public void UpgradeRange()
    {
        if (bank.currentBalance >= rangeUpgradeCost && rangeUpgrades < maxUpgrades)
        { 
            bank.WithDraw(rangeUpgradeCost);
            
             foreach (GameObject tower in targetLocator)
        {
             targetLocatorScript = tower.GetComponent<TargetLocator>();

            if (targetLocatorScript != null)
            {
              targetLocatorScript.RangeUpgrade();
            }
        }
            rangeUpgradeCost += 100;
            rangeUpgrades++;
            UpgradeTexts();
          
        }
    }
    void UpgradeTexts()
    {    
        powerUpgradeCoins.text=powerUpgradeCost.ToString();
        speedUpgradeCoins.text=speedUpgradeCost.ToString();
        rangeUpgradeCoins.text=rangeUpgradeCost.ToString();
       // goldText.text=bank.currentBalance.ToString();


    }
  

}
