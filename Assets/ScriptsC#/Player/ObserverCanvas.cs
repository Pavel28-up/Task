using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverCanvas : MonoBehaviour
{
    public GameObject panelManaging;
    public KeyCode keyManaging;
    public ExampleClass player;
    public bool openPanelManaging;

    private string _control;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(keyManaging))
        {
            openPanelManaging = !openPanelManaging;
            if (openPanelManaging)
            {
                panelManaging.SetActive(true);
                player.enabled = false;
            }
            else
            {
                panelManaging.SetActive(false);
                player.enabled = true;
            }
        }
    }

    public void StartKeys()
    {
        PlayerPrefs.SetString("control", "Keys");
        _control = PlayerPrefs.GetString("control");
        print(_control);
    }

    public void StartMouse()
    {
        PlayerPrefs.SetString("control", "Mouse");
        _control = PlayerPrefs.GetString("control");
        print(_control);
    }
}
