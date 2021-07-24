using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineItem : MonoBehaviour
{
    OnlineItemGenerator itemGenerator;

    void SetGenerator(OnlineItemGenerator generator)
    {
        itemGenerator = generator;
    }

    void DestroyItem()
    {
        itemGenerator.SendMessage("GenerateItem");
        Destroy(this.gameObject);
    }
}
