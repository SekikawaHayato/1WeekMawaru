using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSound : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    void PlayBGM()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
