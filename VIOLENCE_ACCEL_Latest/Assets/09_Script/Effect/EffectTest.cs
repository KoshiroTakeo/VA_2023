using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class EffectTest : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    float count;

    private void FixedUpdate()
    {
        
        if(count > 3)
        {
            Set();
            
        }    
        else if(count >= 5)
        {
            return;
        }
        count += Time.deltaTime;
    }

    void Set()
    {
        postProcessVolume.weight = count / 5;
    }
}
