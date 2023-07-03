using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{  [SerializeField] int goldReward=25;
[SerializeField] int penalty=25;
     Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank=FindObjectOfType<Bank>();
    }
    public void Reward()
    {
        if(bank==null)
        {return;}
            bank.Deposit(goldReward);
        
    }
    public void StealGold()
    {
        if(bank==null){return;}
        bank.WithDraw(penalty);
    }

    
}
