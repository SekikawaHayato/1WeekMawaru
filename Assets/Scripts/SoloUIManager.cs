using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SoloUIManager : MonoBehaviour
{
    int minute=1;
    float second = 0;
    float oldSecond=0;

    int itemCount;
    [SerializeField]
    TextMeshProUGUI countText;

    [SerializeField]
    GameObject resultCanvas;

    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    TextMeshProUGUI itemText;

    bool isPlaying=false;
    AudioSource audioSource;
    [SerializeField]
    AudioClip startSE;
    [SerializeField]
    AudioClip kanseiSE;
    // Start is called before the first frame update
    void Start()
    {
        itemText.text = itemCount.ToString("000");
        timerText.text = minute.ToString("00") + ":" + ((int)second).ToString("00");

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(startSE);

    }
    public void Kansei()
    {
        audioSource.PlayOneShot(kanseiSE);
    }
    void ChangePlaying()
    {
        isPlaying = true;
        SendMessage("GameStart");
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
        audioSource.Play();
        ChangePlaying();
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            second -= Time.deltaTime;
            if (second < 0)
            {
                if (minute == 0)
                {
                    SendMessage("GameOver");
                    //resultCanvas.SetActive(true);
                    naichilab.RankingLoader.Instance.SendScoreAndShowRanking(itemCount);
                    isPlaying = false;
                    second = 0;
                }
                else
                {
                    minute--;
                    second += 60;
                }
            }
            if ((int)second != (int)oldSecond)
            {
                timerText.text = minute.ToString("00") + ":" + ((int)second).ToString("00");
                oldSecond = second;
            }
        }
        
    }
    void GetItem()
    {
        itemCount++;
        itemText.text =itemCount.ToString("000");

    }

    void GetTimer()
    {
        second += 5;
        if (second >= 60)
        {
            second -= 60;
            minute++;
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
