using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    private void Start()
    {
        DataLoader<test> loader = new DataLoader<test>();
        test item = loader.GetItem(0);
        Debug.Log(item.id);
    }
}
