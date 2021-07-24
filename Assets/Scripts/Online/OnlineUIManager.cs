using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OnlineUIManager : MonoBehaviour
{
    int maxCount = 10;
    int myItemCount;
    bool isMasterClient;

    [SerializeField]
    GameObject resultCanvas;

    [SerializeField]
    TextMeshProUGUI[] itemText;
    [SerializeField]
    GameObject OnlineAudio;


    [SerializeField]
    TextMeshProUGUI countText;

    [SerializeField]
    TextMeshProUGUI resultP1ScoreText;
    [SerializeField]
    TextMeshProUGUI resultP2ScoreText;

    PhotonView photonView;

    bool isPlaying = true;

    [PunRPC]
    void UpdateItemOne(int num)
    {
        itemText[0].text = num.ToString() + " / 10";
    }
    [PunRPC]
    void UpdateItemTwo(int num)
    {
        itemText[1].text = num.ToString() + " / 10";
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {

        }
    }

    public void GameStart()
    {
        StartCoroutine("CountDown");
        isMasterClient = PhotonNetwork.isMasterClient;
        photonView = GetComponent<PhotonView>();
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
        OnlineAudio.SendMessage("PlayBGM");

    }

    void ChangePlaying()
    {
        isPlaying = true;
        GameObject[] player=GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < player.Length; i++) {
            player[i].SendMessage("GameStart",null, SendMessageOptions.DontRequireReceiver);
        }
        //player[0].SendMessage("GameStart");
        //player[1].SendMessage("GameStart");
    }

    public void GetItem()
    {
        myItemCount++;
        //処理
        if (isMasterClient)
        {
            photonView.RPC("UpdateItemOne", PhotonTargets.All, myItemCount);
        }
        else
        {
            photonView.RPC("UpdateItemTwo", PhotonTargets.All, myItemCount);
        }
        CheckCount();
    }




    void CheckCount()
    {
        if (myItemCount == maxCount)
        {
            int win = 1;
            if (isMasterClient) win = 0;
            photonView.RPC("GameEnd", PhotonTargets.All, win);
        }
    }

    [PunRPC]
    void GameEnd(int win)
    {
        isPlaying = false;
        resultCanvas.SetActive(true);
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < player.Length; i++)
        {
            player[i].SendMessage("GameEnd", null, SendMessageOptions.DontRequireReceiver);
        }


        if (win == 1)
        {
            resultP2ScoreText.text = "Winer!!";
            resultP2ScoreText.color = new Color32(255, 241, 73, 255);
            resultP1ScoreText.text = "Loser...";
            resultP1ScoreText.color = new Color32(165, 69, 255, 255);
        }
    }

    public void LoadLevel()
    {

        
            GameObject.FindWithTag("FadeManager").SendMessage("LoadLevelWithFade", "Title");

        
    }
}
