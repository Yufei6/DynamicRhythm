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
    public const int menu = 0;

    public int currentState;

    private Controller c;

    // Start is called before the first frame update
    void Start()
    {
        c = new Controller(10);
        Debug.Log("CCC"+c.i);
        DontDestroyOnLoad(gameObject);
    }

    public int getState()
    {
        return currentState;
    }

    public void startChoose(){
        currentState = StateChoose;
        SceneManager.LoadScene("ChooseScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}