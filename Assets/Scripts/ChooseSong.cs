using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSong : MonoBehaviour
{
    private ControllerSystem cs;
    // Start is called before the first frame update
    void Start()
    {
        GameObject controller =  GameObject.Find("Controller(Clone)");
        cs = controller.GetComponent<ControllerSystem>();
    }

    public void Back2Menu()
    {
        cs.Back2Menu();
    }

    public void StartGame()
    {
        cs.StartPlaying();
    }
}
