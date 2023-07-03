using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject ShopUiPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Text nameText;
    [SerializeField] Text scoreText;
    public bool isPaused;
    UIManager uIManager;
    


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
           
        }
        uIManager=FindObjectOfType<UIManager>();
       
    }

    void Start()
    {
      //  LoadPlayerName();
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = "Player: " + playerName;
        }
        else
        {
            nameText.text = "Player: ";
        }
    }

    public void Play()
    {
      
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {
        ShopUiPanel.SetActive(true);
        GamePause();
    }

    public void ShopBack()
    {
        ShopUiPanel.SetActive(false);
        GameResume();
    }

    public void RestartGame()
    {
        GameResume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        GamePause();
        gameOverPanel.SetActive(true);
    }
    public void GameQuit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.ExitPlaymode();
    }


    void GamePause()
    {
        Time.timeScale = 0f;
        isPaused=true;
    }

    void GameResume()
    {
        Time.timeScale = 1f;
        isPaused=false;
    }
    
}
