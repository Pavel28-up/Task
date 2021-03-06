using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverCanvas : MonoBehaviour
{
    public GameObject panelManaging;
    public GameObject panelMause;
    public KeyCode keyManaging;
    public ExampleClass player;
    public bool openPanelManaging;

    public string _control;

    void Start()
    {
        _control = PlayerPrefs.GetString("control");
        if (PlayerPrefs.GetString("control") == "Mouse")
        {
            panelMause.SetActive(true);
            player.enabled = false;
        }
        else
        {
            panelMause.SetActive(false);
            player.enabled = true;
        }
        if (PlayerPrefs.GetString("control") == "")
        {
            PlayerPrefs.SetString("control", "Keys");
            _control = PlayerPrefs.GetString("control");
            panelMause.SetActive(false);
            player.enabled = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(keyManaging))
        {
            openPanelManaging = !openPanelManaging;
            if (openPanelManaging)
            {
                panelManaging.SetActive(true);
                panelMause.SetActive(false);
                player.enabled = false;
            }
            else
            {
                panelManaging.SetActive(false);
                panelMause.SetActive(true);
                player.enabled = true;
            }
        }
    }

    public void StartKeys()
    {
        // if (Application.platform == RuntimePlatform.WindowsEditor)
        // {
        //     Debug.Log("Do something special here!");
            PlayerPrefs.SetString("control", "Keys");
            _control = PlayerPrefs.GetString("control");
        // }
    }

    public void StartMouse()
    {
        // if (Application.platform == RuntimePlatform.Android)
        // {
            // Debug.Log("Do something special here!");
            PlayerPrefs.SetString("control", "Mouse");
            _control = PlayerPrefs.GetString("control");
        // }
    }
}
