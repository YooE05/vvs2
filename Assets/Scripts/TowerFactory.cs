using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 3;
    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject towerParent;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(WayPoint baseWaypoint)
    {
        if (towerQueue.Count < towerLimit)
        {
            InstantiateTower(baseWaypoint);
        }
        else
        { MoveTower(baseWaypoint); }
    }

    private void MoveTower(WayPoint baseWaypoint)
    {
        var movedTower = towerQueue.Dequeue();
        movedTower.waypoinoftower.isPlaced = false;
        movedTower.transform.position = baseWaypoint.transform.position;
        towerQueue.Enqueue(movedTower);

        movedTower.waypoinoftower = baseWaypoint;
        baseWaypoint.isPlaced = true;

    }

    private void InstantiateTower(WayPoint baseWaypoint)
    {
        baseWaypoint.isPlaced = true;
        var tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, towerParent.transform);

        tower.waypoinoftower = baseWaypoint;
        towerQueue.Enqueue(tower);
    }
}
