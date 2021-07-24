using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    private static FadeManager m_instance;
    public static FadeManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = (FadeManager)FindObjectOfType(typeof(FadeManager));
                if (m_instance == null)
                {
                    Debug.LogError(typeof(FadeManager) + "is nothing");
                }

            }
            return m_instance;
        }
    }
    Fade fade;

    private void Awake()
    {
        if (this != instance)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        fade = GetComponent<Fade>();   
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  LoadLevelWithFade(string name)
    {
        fade.FadeIn(1, () =>
        {
            SceneManager.LoadScene(name);
            
        });
    }
}
