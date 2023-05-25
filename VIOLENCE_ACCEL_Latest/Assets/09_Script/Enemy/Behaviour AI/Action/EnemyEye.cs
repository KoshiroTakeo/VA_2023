using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEye : MonoBehaviour
{
    public Transform eye;
    public float viewrange = 10;
    RaycastHit hit;
    Ray ray;

    // test
    int count = 0;
    int switchcount = -1;
    bool bwallhit;

    enum State
    {
        OUT,
        SCAN,
        COMP
    }

    public int YAxisCheck(Transform _owner, Transform _eye)
    {
        ray = new Ray(_eye.position, _eye.forward); // –Ú‚ÌˆÊ’u‚Æ•ûŒü
        Debug.DrawRay(_eye.position, _eye.forward * viewrange, Color.red);


        if (Physics.Raycast(ray, out hit, viewrange))
        {
            if (hit.collider.name == "Wall")
            {
                count += 5;
                _eye.Rotate(0, _owner.transform.rotation.y + (count * switchcount), 0);
                switchcount *= -1;

                bwallhit = true;
            }

            return (int)State.SCAN;
        }
        else
        {
            if (bwallhit == true)
            {
                bwallhit = false;
                return (int)State.COMP;
                
            }
            else return (int)State.OUT;

        }
    }

    public int XAxisCheck(Transform _owner, Transform _eye)
    {
        ray = new Ray(_eye.position, _eye.forward); // –Ú‚ÌˆÊ’u‚Æ•ûŒü
        Debug.DrawRay(_eye.position, _eye.forward * viewrange, Color.blue);


        if (Physics.Raycast(ray, out hit, viewrange))
        {
            if (hit.collider.name == "Wall")
            {
                count += 5;
                _eye.Rotate(_owner.transform.rotation.x + (count * switchcount), 0, 0);
                switchcount *= -1;

                bwallhit = true;
            }

            return (int)State.SCAN;
        }
        else
        {
            if (bwallhit == true)
            {
                bwallhit = false;
                return (int)State.COMP;

            }
            else return (int)State.OUT;

        }


    }
}
