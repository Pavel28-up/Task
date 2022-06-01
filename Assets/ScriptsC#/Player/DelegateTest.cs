using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTest : MonoBehaviour 
{
    public delegate void DelegateTestButts(DelegateTest p);
    public event DelegateTestButts buttKeysEvent;
    public event DelegateTestButts buttMouseEvent;
    public GameObject panelManaging;
    public GameObject panelMause;
    public KeyCode keyManaging;
    public ExampleClass player;
    public Button keys;
    public Button mous;
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
        Button btn2 = mous.GetComponent<Button>();
        btn2.onClick.AddListener(StartMouse);
        Button btn1 = keys.GetComponent<Button>();
        btn1.onClick.AddListener(StartKeys);
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
            }
        }
    }

    public void StartKeys()
    {
        buttKeysEvent(this);
        print("Keys");
        PlayerPrefs.SetString("control", "Keys");
        _control = PlayerPrefs.GetString("control");
    }

    public void StartMouse()
    {
        buttMouseEvent(this);
        print("Mouse");
        PlayerPrefs.SetString("control", "Mouse");
        _control = PlayerPrefs.GetString("control");
    }
}
