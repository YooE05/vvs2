using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] ParticleSystem endFXPrefab;
    [SerializeField] float enemySpeed = 0.6f;

    void Start()
    {
        Pathfinding pathfinder = FindObjectOfType<Pathfinding>();
        var path = pathfinder.GetPath();
        //UpdatePath(path);
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<WayPoint> path)
    {
       // print("STARTING");
        foreach (WayPoint block in path)
        {
            transform.position = block.transform.position;
            yield return new WaitForSeconds(enemySpeed);
        }
       // print("End");
        DethActions();
    }

    private void DethActions()
    {
        var endFX = Instantiate(endFXPrefab, transform.position, Quaternion.identity);
        endFX.Play();
        Destroy(gameObject);
    }


    // public AnimationCurve MoveCurve;

    // private Vector3 target;
    // private Vector3 startPoint;
    // private float animationTimePosition;

    // //набор точек по которым перемещается объект
    // // [SerializeField] GameObject[] pathPoints;

    // //время за которое шкала достигает максимума
    // [SerializeField] float moveDelay = 1f;

    // //новый ключ шкалы, чтобы изменить время достижения максимума, переместив последний существующий ключ
    // Keyframe keyDependOfSpeed;

    // int currentPoint = 0;
    // ////
    // void Update()
    // {
    //     Pathfinding pathfinder = FindObjectOfType<Pathfinding>();
    //     var path = pathfinder.GetPath();

    //     if (target != transform.position)
    //     {
    //         animationTimePosition += Time.deltaTime;

    //         //перемещение объекта
    //         transform.position = Vector3.Lerp(startPoint, target, MoveCurve.Evaluate(animationTimePosition));
    //         if (currentPoint == path.Count - 1) { currentPoint = 0; }
    //     }
    //     else
    //     {
    //         UpdatePath(path);
    //         animationTimePosition = 0;
    //     }
    // }
    // private void UpdatePath(List<WayPoint> path)
    // {
    //     if (moveDelay >= Mathf.Epsilon)
    //     {
    //         //создание ключа с заданой скоростью
    //         keyDependOfSpeed = new Keyframe(moveDelay, 1f);
    //     }

    //     //перемещение последнего ключа
    //     MoveCurve.MoveKey(1, keyDependOfSpeed);

    //     startPoint = transform.position;
    //     currentPoint++;
    //     target = path.ElementAt(currentPoint).transform.position;
    //     //target = Random.insideUnitSphere;
    // }
}
