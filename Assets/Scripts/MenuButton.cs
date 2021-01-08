using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject canvasNewPlayer;
    public GameObject buttonStart;
    private ControllerSystem cs;
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        controller =  GameObject.Find("Controller(Clone)");
        if (controller!=null)
        {
            cs = controller.GetComponent<ControllerSystem>();
            if (!cs.CheckPlayer()){
                buttonStart.GetComponent<Button>().interactable = false;
            }

        }
    }

    public void ButtonStart()
    {
        cs.StartChoose();
    }

    public void ButtonNewPlayer()
    {
        canvasNewPlayer.SetActive(true);
    }

    public void ButtonCancleNewPlayer()
    {
        canvasNewPlayer.SetActive(false);
    }

    public void ButtonOkNewPlayer()
    {
        canvasNewPlayer.SetActive(false);
        cs.StartCreatePlayer();
    }

    public void ButtonQuit()
    {
        cs.Quit();
    }

    void Update()
    {
        if (controller == null){
            controller =  GameObject.Find("Controller(Clone)");
            if (controller==null)
            {
                Debug.Log("Can't find controller! (Yufei)");
            }
            else 
            {
                cs = controller.GetComponent<ControllerSystem>();
                if (!cs.CheckPlayer()){
                    buttonStart.GetComponent<Button>().interactable = false;
                }
            }
           
        }
    }
}
