using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGeneratorButton : MonoBehaviour
{
    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
    }

    public void Buy(int index)
    {
        shopManager.BuyUpSelf(index, gameObject);
    }
}
