using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private ControllerSystem cs;
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        controller =  GameObject.Find("Controller(Clone)");
        if (controller!=null)
        {
            cs = controller.GetComponent<ControllerSystem>();
        }
    }

    public void ButtonStart()
    {
        cs.StartChoose();
    }

    public void ButtonNewPlayer()
    {
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
                Debug.Log("WTF");
            }
            else 
            {
                Debug.Log("YES");
                cs = controller.GetComponent<ControllerSystem>();
            }
           
        }
    }
}
