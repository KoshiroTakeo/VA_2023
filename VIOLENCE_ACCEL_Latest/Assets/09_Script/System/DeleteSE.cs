using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSE : MonoBehaviour
{
    [SerializeField] AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        DeleteCheck(Audio);
    }

    void DeleteCheck(AudioSource _audio)
    {
        if (_audio.isPlaying == false)
        {
            Destroy(_audio);
            Destroy(this);
        }
    }
}
