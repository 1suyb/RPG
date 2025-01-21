using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : IManager
{
    public ItemFactory ItemFactory { get; private set; }

    public void InitOnCreate()
    {
        ItemFactory = new ItemFactory();
    }

    public void Release()
    {
        
    }
}
