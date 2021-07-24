using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PvPUIManager : MonoBehaviour
{

    int maxCount = 10;
    int[] itemCount= new int[2];
    [SerializeField]
    GameObject[] player;

    [SerializeField]
    GameObject resultCanvas;

    [SerializeField]
    TextMeshProUGUI[] itemText;
    [SerializeField]
    GameObject PvPAudio;


    [SerializeField]
    TextMeshProUGUI countText;
    [SerializeField]
    GameObject[] p1Point;
    [SerializeField]
    GameObject[] p2Point;

    [SerializeField]
    TextMeshProUGUI resultRoundText;
    [SerializeField]
    TextMeshProUGUI resultP1ScoreText;
    [SerializeField]
    TextMeshProUGUI resultP2ScoreText;


    bool isPlaying=true;

    PvPRoundManager roundManager;



    // Start is called before the first frame update
    void Start()
    {
        roundManager = PvPRoundManager.instance;
        WinPointUpdate();
    }
    void WinPointUpdate()
    {
        int[] point = roundManager.GetWinPoint();
        for (int i = 0; i < point[0]; i++)
        {
            p1Point[i].SetActive(true);
        }
        for (int i = 0; i < point[1]; i++)
        {
            p2Point[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            
        }
    }

    public void StartCountDown()
    {
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        countText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countText.text = "2";
        yield return new WaitForSeconds(1);
        countText.text = "1";
        yield return new WaitForSeconds(1);

        countText.gameObject.SetActive(false);
        ChangePlaying();
        PvPAudio.SendMessage("PlayBGM");

    }

    void ChangePlaying()
    {
        isPlaying = true;
        player[0].SendMessage("GameStart");
        player[1].SendMessage("GameStart");
    }

    public void PlayerOneGetItem()
    {
        itemCount[0]++;
        itemText[0].text = itemCount[0].ToString()+" / 10";
        CheckCount(0);

    }

    public void PlayerTwoGetItem()
    {
        itemCount[1]++;
        itemText[1].text =itemCount[1].ToString()+" / 10";
        CheckCount(1);
    }
    
    void CheckCount(int number)
    {
        if (itemCount[number] == maxCount)
        {
           
            isPlaying = false;
            roundManager.RoundUp(number);
            player[0].SendMessage("GameOver");
            player[1].SendMessage("GameOver");
            WinPointUpdate();
            resultCanvas.SetActive(true);
            PvPRoundManager pvpRoundManager = PvPRoundManager.instance;
            if (pvpRoundManager.FinChecker())
            {
                resultRoundText.text = "FinalResult";
            }
            else
            {
                resultRoundText.text = "Round" + pvpRoundManager.nowRound.ToString();
            }
            if (number == 1)
            {
                resultP2ScoreText.text = "Winer!!";
                resultP2ScoreText.color = new Color32(255, 241,73,255);
                resultP1ScoreText.text = "Loser...";
                resultP1ScoreText.color = new Color32(165, 69, 255, 255);
            }
            

        }
    }

    public void LoadLevel()
    {
        if (roundManager.FinChecker())
        {
            GameObject.FindWithTag("FadeManager").SendMessage("LoadLevelWithFade", "Title");
            Destroy(PvPRoundManager.instance.gameObject);
        }
        else
        {
            GameObject.FindWithTag("FadeManager").SendMessage("LoadLevelWithFade", SceneManager.GetActiveScene().name);
        }
    }
}
