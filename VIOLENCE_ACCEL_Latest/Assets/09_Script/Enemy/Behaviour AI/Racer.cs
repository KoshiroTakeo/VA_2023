using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    public Vector3 path;
    public float lerpSpeed = 1.0f;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, path, lerpSpeed * Time.deltaTime);
    }

    public void SetSpeed(float _speed)
    {
        lerpSpeed = _speed * 1.5f;
    }
}
