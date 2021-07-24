using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    Transform[] stagePosition;
    [SerializeField]
    GameObject itemPrefab;
    [SerializeField]
    GameObject timerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {

            GenerateItem();
        }
        if (timerPrefab != null)
        {
            for(int i = 0; i < 3; i++)
            {
                GenerateTimer();
            }
        }
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
        GameObject item = Instantiate(itemPrefab, stagePosition[index].position + offset, Quaternion.Euler(45,45,45));
        //item.transform.parent = stagePosition[index];
        item.SendMessage("SetGenerator", this);
    }

    void GenerateTimer()
    {
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        float randomRadius = Random.Range(1.5f, 8.0f);
        Vector3 offset = new Vector3(Mathf.Cos(randomAngle) * randomRadius, 1.5f, Mathf.Sin(randomAngle) * randomRadius);
        int index = Random.Range(0, stagePosition.Length);
        GameObject item = Instantiate(timerPrefab, stagePosition[index].position + offset, Quaternion.Euler(278,0,0));
        //item.transform.parent = stagePosition[index];
        item.SendMessage("SetGenerator", this);
    }
}
