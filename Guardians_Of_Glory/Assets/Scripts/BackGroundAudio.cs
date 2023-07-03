using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudio : MonoBehaviour
{
     public static BackGroundAudio instance;  
     public AudioSource audioSource;
     public AudioClip backGroundAudio;

   // public AudioSource audioSource; 
   

    private void Awake()
    {
        
        if (instance == null)
        {
           
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
           
            Destroy(gameObject);
        }
         audioSource=GetComponent<AudioSource>();
    }
    public void MusicTurnOn()
    {
        
        audioSource.clip=backGroundAudio;
         audioSource.Play();
    }
    public void MusicTurnOFF()
    {
        audioSource.Stop();
    }
}
