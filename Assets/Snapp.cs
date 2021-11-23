using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] 

public class Snapp : MonoBehaviour
{
    [Range(1f, 20f)]
    public float rangePos = 1f;

    void Update()
    {


        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / rangePos) * rangePos;
        snapPos.z = Mathf.RoundToInt(transform.position.z / rangePos) * rangePos;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
