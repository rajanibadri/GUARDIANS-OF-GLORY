using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{  [SerializeField] public int startingBalance;
    [SerializeField]public int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;
     [SerializeField] TextMeshProUGUI displayBalanceONShopUI;
    [SerializeField] Slider castleHealthBar;
    
   
     
     void Awake()
     {   
         currentBalance=startingBalance;
         UpdateDisplayBalance();
     }
     void Start()
     {
        
     }
     void Update()
     {
        
     }
   public void Deposit(int amount)
   {
       currentBalance+=Mathf.Abs(amount);
       
       UpdateDisplayBalance();
   }
   public void WithDraw(int amount)
   { 
       
       currentBalance -= Mathf.Abs(amount);
        
      
       UpdateDisplayBalance();
       if(currentBalance<0)
       {
          GameManager.instance.GameOver();
        // ReloadScene();
       }
   }
   void ReloadScene()
   {
       Scene currentScene=SceneManager.GetActiveScene();
       SceneManager.LoadScene(currentScene.buildIndex);
   }
   void UpdateDisplayBalance()
   {
       displayBalance.text="Gold: "+currentBalance;
       displayBalanceONShopUI.text=currentBalance.ToString();
       UpdateHealthBar(currentBalance,startingBalance);
   }
   void UpdateHealthBar(int cur,int max)
   {
      castleHealthBar.value=(float)currentBalance/startingBalance;
     
   }
}
