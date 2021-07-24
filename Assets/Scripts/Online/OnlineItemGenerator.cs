using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineItemGenerator : MonoBehaviour
{
    [SerializeField]
    Transform[] stagePosition;
    [SerializeField]
    Transform[] playerPosition;
    [SerializeField]
    GameObject waitCanvas;
    // Start is called before the first frame update
    void GameStart()
    {
        GameObject player;
        if (PhotonNetwork.isMasterClient)
        {
            for (int i = 0; i < 10; i++)
            {

                GenerateItem();
            }

            player = PhotonNetwork.Instantiate("OnlinePlayerOne", playerPosition[0].position, Quaternion.identity, 0);

        }
        else
        {
            player=PhotonNetwork.Instantiate("OnlinePlayerTwo", playerPosition[1].position, Quaternion.identity, 0);
        }
        player.SendMessage("SetPlayerComponents");
        waitCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateItem()
    {
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        float randomRadius = Random.Range(1.5f, 8.0f);
        Vector3 offset = new Vector3(Mathf.Cos(randomAngle) * randomRadius, 1.5f, Mathf.Sin(randomAngle) * randomRadius);
        int index = Random.Range(0, stagePosition.Length);
        GameObject item = PhotonNetwork.Instantiate("OnlineItem", stagePosition[index].position + offset, Quaternion.Euler(45, 45, 45),0);
        //item.transform.parent = stagePosition[index];
        item.SendMessage("SetGenerator", this);
    }

}
