using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaytoTarget 
{
    RaycastHit hit;
    Ray ray;

    GameObject Target;

    public void SetOwner(GameObject _owner)
    {
        //ray = new Ray(_owner.transform.position, );
    }

    public GameObject WatchtoObject(GameObject _camera)
    {
        ray = new Ray(_camera.transform.position, _camera.transform.forward);


        if (Physics.Raycast(ray, out hit)) 
        {
            
            if(hit.collider.CompareTag("Enemy"))
            {
                Target = hit.collider.gameObject;
            }
            else
            {
                return null;
            }
            
        }



        Debug.DrawRay(ray.origin, ray.direction * 30, Color.red);
        Debug.Log(Target.name);

        return Target;
    }

    

}
