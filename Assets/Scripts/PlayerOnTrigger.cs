using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnTrigger : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip itemSE;

    bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Item"&&isPlaying)
        {
            collision.gameObject.SendMessage("DestroyItem");
            SendMessage("GetItem");
            audioSource.PlayOneShot(itemSE);
        }

        if (collision.gameObject.tag == "Timer"&&isPlaying)
        {
            collision.gameObject.SendMessage("DestroyItem");
            SendMessage("GetTimer");
            audioSource.PlayOneShot(itemSE);
        }
    }

    void GameStart()
    {
        isPlaying = true;
    }
}
