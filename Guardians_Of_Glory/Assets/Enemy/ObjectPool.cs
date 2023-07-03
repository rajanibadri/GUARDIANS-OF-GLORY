using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   
    [SerializeField] GameObject enemy;
   [SerializeField]  [Range(0,50)]int poolSize=5;
    [SerializeField] [Range(0.1f,30f)] float spawnTimer = 1f;
   GameObject[] pool;
   GameManager gameManager;
    void Awake()
    {
        PopulatePool();
        gameManager=FindObjectOfType<GameManager>();
      
    }
    void Start()
    {  
        
             StartCoroutine(EnemySpawn()); 
         
     
    }
    void PopulatePool()
    {
        pool=new GameObject[poolSize];
        for(int i=0;i<pool.Length;i++)
        {
           pool[i]= Instantiate(enemy,transform);
           pool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EnableObjectInPool()
    {
        for(int i=0;i<pool.Length;i++)
        {
            if(pool[i].activeInHierarchy==false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator EnemySpawn()
    {
      
        while(true)

        {
             EnableObjectInPool();
             yield return new WaitForSeconds(spawnTimer);
        }
    }
    
}
