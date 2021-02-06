using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishButton : MonoBehaviour
{
	private ControllerSystem cs;
    private GameObject controller;
    public TMP_Text score1;
    private Controller ct;
    // Start is called before the first frame update
    void Start()
    {
        controller =  GameObject.Find("Controller(Clone)");
        if (controller!=null)
        {
            cs = controller.GetComponent<ControllerSystem>();
            ct = cs.controller;
            ct.UpdatePlayer();
        }
        score1.text=PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void backtoMenu(){
    	cs.Back2Menu();
    }
    public void Quit(){
    	cs.Quit();
    }
}
