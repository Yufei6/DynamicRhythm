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
    private Song song;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        DontDestroyOnLoad(gameObject);
        currentState = StateMenu;
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

    public void CreatePlayer(string name, int age, int sex)
    {
        controller.StartFromBegining(name, age, sex);
        SceneManager.LoadScene("ChooseScene");
    }

    public void StartPlaying()
    {
        currentState = StatePlaying;
        SceneManager.LoadScene("GameScene");
    }


    public void Quit()
    {
        controller.Save();
        Application.Quit();
    }

    public void Back2Menu()
    {
        currentState = StateMenu;
        SceneManager.LoadScene("MenuScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}