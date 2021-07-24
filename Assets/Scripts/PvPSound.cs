using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvPSound : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip startSE;
    [SerializeField]
    AudioClip kanseiSE;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(startSE);
    }

    public void Kansei()
    {
        audioSource.PlayOneShot(kanseiSE);
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
