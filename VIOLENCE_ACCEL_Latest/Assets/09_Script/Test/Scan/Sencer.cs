using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sencer : MonoBehaviour
{
    public bool hit;

    private void Awake()
    {
        hit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        hit = true;
    }
}
