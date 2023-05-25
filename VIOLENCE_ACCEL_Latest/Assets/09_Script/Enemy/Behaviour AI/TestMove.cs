using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public Transform target;
    public float speed = 10.0f;
    public float randomRange = 20.0f;
    private Vector3 nextPosition;
    private void Start()
    {
        nextPosition = target.position + new Vector3(Random.Range(-randomRange, randomRange), 0, Random.Range(-randomRange, randomRange));
    }
    private void FixedUpdate()
    {
        transform.LookAt(nextPosition);
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);


        if (Vector3.Distance(transform.position, nextPosition) < 0.5f)
        {
            nextPosition = target.position + new Vector3(Random.Range(-randomRange, randomRange), 0, Random.Range(-randomRange, randomRange));
        }

        //// ŽŽ
        //if(/* •Ç‚ª‚È‚¢*/)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
        //}
        //else if (/* •Ç‚ª‚ ‚é*/)
        //{
        //    transform.rotation.y += 5.0f;
        //}
    }
}
