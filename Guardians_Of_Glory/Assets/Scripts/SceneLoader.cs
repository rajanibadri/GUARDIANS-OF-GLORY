using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{    public static SceneLoader instance;
     [SerializeField] InputField nameOfthePlayer;
     [SerializeField] GameObject SettingsPanel;
      [SerializeField] GameObject MainMenuPanel;
     public string playerName;
    // Start is called before the first frame update
    void Awake(){
        if(instance==null)
        {  
            instance=this;
            DontDestroyOnLoad(gameObject);

        }
        else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
       if (PlayerPrefs.HasKey("PlayerName"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameOfthePlayer.text = playerName;
        }
        
    }
     public void OnNameInputClicked()
    {
        nameOfthePlayer.Select();
        nameOfthePlayer.ActivateInputField();
       
    }
    

    public void SaveName()
    {
        playerName = nameOfthePlayer.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void OpenSettings()
    {
         SettingsPanel.SetActive(true);
         MainMenuPanel.SetActive(false);
    }
    public void CloseSettingsPanel()
    {
       MainMenuPanel.SetActive(true);
       SettingsPanel.SetActive(false);
    }
}
