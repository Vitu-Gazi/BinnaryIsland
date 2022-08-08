using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : AbstarctMover
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed;

    private Vector3 nextPoint = new Vector3();

    private void Start()
    {
        GetPoint();
        Timer.StartPanicTime += Acceleration;
    }
    private void OnDisable()
    {
        Timer.StartPanicTime -= Acceleration;
    }

    private void GetPoint()
    {
        List<Transform> points = new List<Transform>();

        foreach (var point in this.points)
        {
            if ((point.position.x == transform.position.x || point.position.y == transform.position.y) && point.position != transform.position)
            {
                points.Add(point);
            }
        }

        nextPoint = points[Random.Range(0, points.Count)].position;

        Moving(nextPoint);
    }

    protected override void Moving(Vector3 point)
    {
        transform.DOMove(point, (transform.position - point).magnitude / speed).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.position = point;
            GetPoint();
        });
    }

    private void Acceleration ()
    {
        speed /= 2;
    }
}
