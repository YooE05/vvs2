using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Vector2Int gridPos;
    public WayPoint pointFrom;

    const int gridSize = 10;
    public bool isExplored = false;

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

    public void SetTopColour(Color colour)
    {
        MeshRenderer topMesh = transform.Find("Top").GetComponent<MeshRenderer>();//transform.Find("name") указывает на дочерний компонент с именем name
        topMesh.material.color = colour;
    }
}
