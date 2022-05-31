using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private void Update()
    {
        if (PlayerPrefs.GetString("control") == "Mouse")
        {
            FindObjectOfType<DelegateTest>().buttKeysEvent += onPlayerKeys;
            FindObjectOfType<DelegateTest>().buttMouseEvent -= onPlayerMouse;
        }
        else
        {
            FindObjectOfType<DelegateTest>().buttMouseEvent += onPlayerMouse;
            FindObjectOfType<DelegateTest>().buttKeysEvent -= onPlayerKeys;
        }
    }

    public void onPlayerKeys(DelegateTest player)
    {
        // StartKeys();
        print("key");
    }

    public void onPlayerMouse(DelegateTest player)
    {
        // StartKeys();
        print("mous");
    }
}
