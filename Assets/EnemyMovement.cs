using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    void Start()
    {
        Pathfinding pathfinder = FindObjectOfType<Pathfinding>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<WayPoint> path)
    {
        print("STARTING");
        foreach (WayPoint block in path)
        {
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("End");
    }

    void Update()
    {
    }
}
