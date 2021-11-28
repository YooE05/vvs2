using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Vector2Int gridPos;
    public WayPoint pointFrom;

    public bool hasEnviromental = false;

    public bool isPlaced = false;

    public bool isClikable = true;

    public int gridSize = 1;
    public bool isExplored = false;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && (isClikable) && (!isPlaced) && (!hasEnviromental))
        {
            FindObjectOfType<TowerFactory>().AddTower(this);
        }
    }
    void Start()
    {

    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }

}
