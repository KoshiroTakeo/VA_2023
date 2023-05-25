using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GenerateWall : MonoBehaviour
{
    public float random = 10;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            //Instantiate(gameObject, new Vector3(Random.Range(-random, random), 0, Random.Range(-random, random)), Quaternion.identity);
        }

    }


}
