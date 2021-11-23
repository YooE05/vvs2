using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]//действия скрипта работают без запуска игры
[SelectionBase] //объект со скриптом выбирается первым при нажатии на дерево объектов
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{
    WayPoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<WayPoint>();
    }

    void Update()
    {
        SnapToGrid();
        SetLable();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }

    private void SetLable()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string textCoordinate = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = textCoordinate;
        gameObject.name = textCoordinate;
    }

}
