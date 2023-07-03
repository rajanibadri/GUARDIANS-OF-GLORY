using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{   [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range;
    Transform target;
   
    void Start()
    {
       // SpeedUpgrade();
    }
    void Update()
    {   FindClosestEnemy();
        AimEnemy();
    }
    void FindClosestEnemy()
    {
        Enemy[] enemies=FindObjectsOfType<Enemy>();
        Transform closestTarget=null;
        float maxDistance=Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            float targetDistance=Vector3.Distance(transform.position,enemy.transform.position);
            if(targetDistance<maxDistance)
            {
                closestTarget=enemy.transform;
                maxDistance=targetDistance;
            }
        }
        target=closestTarget;
    }

    void AimEnemy()
    {  if(target!=null)
         {
              float targetDistance=Vector3.Distance(transform.position,target.position);
              weapon.LookAt(target);
            if(targetDistance<range )
               {
                 Attack(true);
               }
        else{
            Attack(false);

            }
          }
         
        
    }
    void Attack(bool isActive)
    {
       var emissionModule=projectileParticles.emission;
       emissionModule.enabled=isActive;
      

    }
    public void PowerUpgrade()
    {

    }
   
    public void RangeUpgrade()
    {
        range+=5f;
    }
    public void SpeedUpgrade()
    {
        var mainModule = projectileParticles.main;
    
    // Increase the simulation speed of the particle system
    float newSimulationSpeed = mainModule.simulationSpeed + 0.2f; // Increase by 1 (adjust this value as needed)
    mainModule.simulationSpeed = newSimulationSpeed;
    }
   
}
