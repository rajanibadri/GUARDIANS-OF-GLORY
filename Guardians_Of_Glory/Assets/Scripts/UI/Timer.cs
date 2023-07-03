using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    float startTime; // Time when the player starts the game


    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] EnemyHealth enemyHealth;

    void Start()
    {

        UpdateInfoText();
        enemyHealth = FindObjectOfType<EnemyHealth>();

    }

    void Update()
    {
        startTime += Time.deltaTime;
        UpdateTimerText(startTime);

    }


    void UpdateTimerText(float elapsedTime)
    {
        if (timerText != null)
        {
            // Format the time into minutes and seconds
            int minutes = (int)(elapsedTime / 60) % 60;
            int seconds = (int)(elapsedTime % 60);


            // Update the timer text
            timerText.text = string.Format("Time:{0:00}:{1:00}", minutes, seconds);
        }
    }

    void UpdateInfoText()
    {
        if (infoText != null)
        {
            infoText.gameObject.SetActive(true);
            infoText.text = "(ENEMIES BECOME STRONGER EVERY 15 SECONDS)";
        }
    }


}


