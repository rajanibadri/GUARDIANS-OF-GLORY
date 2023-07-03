using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayLoad> path = new List<WayLoad>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;
    float timer;
   
    Enemy enemy;
    float initialSpeed;
float elapsedTime = 0f;
float incrementInterval = 15f; // 15 seconds
float incrementAmount = 0.1f;
    private int incrementCounter;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FallowPath());
        initialSpeed=speed;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void Update()
    {  
        elapsedTime += Time.deltaTime;

       if (elapsedTime >= incrementInterval && incrementCounter < 6) 
        {
            // Increment the speed by 10%
            speed += initialSpeed * incrementAmount;
            elapsedTime = 0f; // Reset the timer
            incrementCounter++;
        }
    

    }
    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {   
            WayLoad wayLoad=child.GetComponent<WayLoad>();
            if(wayLoad!=null)
            {
                path.Add(wayLoad);
            }
           
        }
        // GameObject parent =GameObject.FindGameObjectWithTag("Path");
        //  foreach(Transform child in parent.transform)
        // {
        //   path.Add(child.GetComponent<WayLoad>());
        // }
    }
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    void FinishPath()
    {
         enemy.StealGold();
        gameObject.SetActive(false);
    }
    IEnumerator FallowPath()
    {
        foreach (WayLoad waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercentage = 0f;
            transform.LookAt(endPosition);
            while (travelPercentage < 1f)
            {
                travelPercentage += Time.deltaTime * speed;
                

                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercentage);

                yield return new WaitForEndOfFrame();
            }
        }
       FinishPath();
    }
    
}
