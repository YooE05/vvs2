using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    //Dictionary<> содержит коллекцию пар "ключ-значение". Ее метод Add принимает два параметра: один для ключа, другой — для значения. 
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();// очередь или лист FIFO first in - first out - набор объектов
    bool isRunning = true;
    WayPoint searchCenter;

    List<WayPoint> path = new List<WayPoint>();

    public List<WayPoint> GetPath()
    {
        LoadBlocks();
        FindPathPoints();
        PathBuild();
        return path;
    }

    Vector2Int[] directions =
    {
        Vector2Int.up,  Vector2Int.right, Vector2Int.down, Vector2Int.left
    };

    [Header("Key Points")]
    [SerializeField]
    WayPoint startWaypoint;
    [SerializeField]
    WayPoint endWaypoint;

    void PathBuild()
    {
        path.Add(endWaypoint);
        WayPoint previous = endWaypoint.pointFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous.SetTopColour(Color.cyan);
            previous = previous.pointFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }
    private void FindPathPoints()
    {
        queue.Enqueue(startWaypoint);//добавление объекта в очередь
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();//вытаскивание объекта из очереди
            //print("Serching from:" + searchCenter); // to do почему WayPoint равен своим координатам при печати?
            HaltIfEndFound();
            FindNeighbours();
            searchCenter.isExplored = true;

        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void FindNeighbours()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinats = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinats))
            {
                AddNeighbour(neighbourCoordinats);
            }
        }

    }

    private void AddNeighbour(Vector2Int neighbourCoordinats)
    {
        WayPoint neighbour = grid[neighbourCoordinats];
        if (!(neighbour.isExplored || queue.Contains(neighbour)))
        {
            queue.Enqueue(neighbour);
            neighbour.pointFrom = searchCenter;
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
                if (gridPos == startWaypoint.GetGridPos())
                { waypoint.SetTopColour(Color.green); }
                else if (gridPos == endWaypoint.GetGridPos())
                {
                    waypoint.SetTopColour(Color.red);
                }
                else
                {
                    waypoint.SetTopColour(Color.black);
                }
            }
        }
    }
}