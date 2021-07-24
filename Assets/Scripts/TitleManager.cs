using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip buttonSE;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string sceneName)
    {
        audioSource.PlayOneShot(buttonSE);
        GameObject.FindWithTag("FadeManager").SendMessage("LoadLevelWithFade", sceneName);
    }
}
