
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    public int currentHitPoints = 0;
    [SerializeField] Text Healthtext;
    [SerializeField] GameObject ExplosionPart;
    [SerializeField] GameObject hitEffect;
    Enemy enemy;
    private float timer = 0f;
    private int interval = 15;
    UIManager uIManager;
    Vector3 tranform;
    public int previousnumber=1;
    public int currentnumber=2;
    Timer displayTime;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void Start()
    {
       
    }
    void Awake()
    {   displayTime=FindObjectOfType<Timer>();
        enemy = GetComponent<Enemy>();
        uIManager=FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {  
        
        timer += Time.deltaTime;

        if (timer >= interval)
        {   
           IncreaseEnemyHealth();
            timer = 0f;
        }
        Healthtext.text = currentHitPoints.ToString();
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    
         GameObject part = Instantiate(hitEffect, transform.position+new Vector3(0,transform.position.y+1f,0), Quaternion.identity);
         Destroy(part,1f);
    }
  public void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            enemy.Reward();   
            GameObject part = Instantiate(ExplosionPart, transform.position+new Vector3(0,transform.position.y+1,0), Quaternion.identity);
            gameObject.SetActive(false);
            uIManager.ScoreIncrement();
            Destroy(part, 1f);

        }
    }
  public void  IncreaseEnemyHealth()
  {
       maxHitPoints+=GetNextFibonacciNumber(); 
       
     
       
  }
  public void DecreasedMaxHealth()
  {
      maxHitPoints-=2;
      currentHitPoints=maxHitPoints;
  } private int GetNextFibonacciNumber()
    {
        int result = currentnumber;
        currentnumber = previousnumber + currentnumber;
        previousnumber = result;
        return result;
    }
}
