using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : IManager
{
    public ItemDataFactory ItemDataFactory { get; private set; }

    public void InitOnCreate()
    {
        ItemDataFactory = new ItemDataFactory();
    }

    public void Release()
    {
        
    }
}
