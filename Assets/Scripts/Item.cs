using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    ItemGenerator itemGenerator;
    [SerializeField]
    string name;

    void SetGenerator(ItemGenerator generator)
    {
        itemGenerator = generator;
    }

    void DestroyItem()
    {
        itemGenerator.SendMessage(name);
        Destroy(this.gameObject);
    }
}
