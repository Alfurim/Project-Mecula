using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private AudioSource mAudioSrc;
    // Start is called before the first frame update
    void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            mAudioSrc.Play();

        }
    }
}
