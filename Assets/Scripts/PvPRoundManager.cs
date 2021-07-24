using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvPRoundManager : MonoBehaviour
{
    #region singleton
    private static PvPRoundManager m_instance;
    public static PvPRoundManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = (PvPRoundManager)FindObjectOfType(typeof(PvPRoundManager));
                if (m_instance == null)
                {
                    Debug.LogError(typeof(PvPRoundManager) + "is nothing");
                }
                
            }
            return m_instance;
        }
    }
    #endregion



    int m_nowRound;
    public int nowRound
    {
        get
        {
            return m_nowRound;
        }
    }

    int[] winPoint;

    private void Awake()
    {
        if (this != instance)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        m_nowRound = 0;
        winPoint = new int[2];
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RoundUp(int win)
    {
        m_nowRound++;
        winPoint[win]++;

    }
    public int[] GetWinPoint()
    {
        return winPoint;
    }

    public bool FinChecker()
    {
        if (winPoint[0] == 2 || winPoint[1] == 2)
        {
            return true;
        }
        return false;
    }
}
