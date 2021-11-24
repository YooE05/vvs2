using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform rotatedObj;
    [SerializeField] Transform target;
    //int damagePoints = 10;
    [SerializeField] int rangeOfTower = 30;

    [SerializeField] ParticleSystem shootFX;

    private void Start()
    {

    }
    void Update()
    {
        SetTargetEnemy();
        if (target)
        {
            FireOnEnemy();
        }
        else { Shoot(false); }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyDamage currentEn in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(currentEn.transform, closestEnemy);

        }

        target = closestEnemy;

    }

    private Transform GetClosestEnemy(Transform currentEn, Transform closestEnemy)
    {
        float currentDistance = Vector3.Distance(transform.position, currentEn.position);
        float closestDistance = Vector3.Distance(transform.position, closestEnemy.position);
        if (currentDistance < closestDistance)
        {
            closestEnemy = currentEn;
        }
        return closestEnemy;
    }

    private void FireOnEnemy()
    {
        float distanceToEnemy = Vector3.Distance(rotatedObj.transform.position, target.transform.position);
        if (distanceToEnemy <= rangeOfTower)
        {
            rotatedObj.LookAt(target);
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = shootFX.emission;
        emissionModule.enabled = isActive;
    }
}