using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject controllerGO;
    private ControllerSystem controller;

    public void startChoose(){
        controller = controllerGO.GetComponent<ControllerSystem>();
        controller.startChoose();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
