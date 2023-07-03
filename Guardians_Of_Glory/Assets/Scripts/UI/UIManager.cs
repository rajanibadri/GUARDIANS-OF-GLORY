using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{    public int score;
     [SerializeField] public Text scoreText; 


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void Play()
    {
       
    }
    public void ScoreIncrement()
    {
        score+=1000;
        scoreText.text=score.ToString();
    }
   

}
