using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerSystem : MonoBehaviour
{
    public const int StateMenu = 0;
    public const int StatePlaying = 1;
    public const int StateChoose = 2;
    public const int StatePause = 3;
    public const int StateWaiting = 4;
    public const int StateCreatePlayer = 5;

    public int currentState;

    private Controller controller;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
    }

    public int GetState()
    {
        return currentState;
    }

    public void StartChoose()
    {
        currentState = StateChoose;
        controller.Continue();
        SceneManager.LoadScene("ChooseScene");
    }

    public void StartCreatePlayer()
    {
        currentState = StateCreatePlayer;
        SceneManager.LoadScene("CreatePlayerScene");
    }

    public void CreatePlayer()
    {
        
        controller.StartFromBegining("name",1,1);
        SceneManager.LoadScene("ChooseScene");
    }

    public void Quit()
    {
        controller.Save();
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}