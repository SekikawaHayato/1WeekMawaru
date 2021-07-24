using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlinePlayerManager : MonoBehaviour
{

    GameObject uiManager;
    void SetPlayerComponents()
    {
        gameObject.GetComponent<AudioSource>().enabled = true;
        gameObject.GetComponent<OnlinePlayerController>().enabled = true;
        gameObject.GetComponent<ParentChanger>().enabled = true;
        gameObject.GetComponent<PlayerOnTrigger>().enabled = true;
 
    }
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindWithTag("GameController");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetItem()
    {
        uiManager.SendMessage("GetItem");
    }
}
