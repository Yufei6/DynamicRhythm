﻿using System.Collections;
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

    public Controller controller;
    private int songId;
    private List<Joycon> joycons;

    // Start is called before the first frame update
    void Awake()
    {
        controller = new Controller();
        DontDestroyOnLoad(gameObject);
        currentState = StateMenu;
        songId = -1;
    }

    void Start()
    {
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < 2) {
            Debug.Log("NO JOYCON!!");
        }
    }

    public int GetState()
    {
        return currentState;
    }

    public void StartChoose()
    {
        currentState = StateChoose;
        SceneManager.LoadScene("ChooseScene");
    }

    public void SetSongId(int id)
    {
        songId = id;
    }

    public int GetSongId()
    {
        return songId;
    }

    public Song GetSong()
    {
        return controller.GetSong(songId);
    }


    public Song GetSong(int id)
    {
        return controller.GetSong(id);
    }

    public void StartCreatePlayer()
    {
        currentState = StateCreatePlayer;
        SceneManager.LoadScene("CreatePlayerScene");
    }

    public void CreatePlayer(string name, int age, int sex)
    {
        controller.StartFromBegining(name, age, sex);
        PlayerPrefs.SetInt("nbGame",0);
        SceneManager.LoadScene("ChooseScene");
    }

    public void StartPlaying()
    {
        currentState = StatePlaying;
        SceneManager.LoadScene("GameScene");
    }

    public void Back2Menu()
    {
        currentState = StateMenu;
        SceneManager.LoadScene("MenuScene");
    }

    public int GetLengthSong()
    {
        return controller.GetLengthSong();
    }

    public ArrayList GetListTrace()
    {
        return controller.GetListTrace();
    }

    public void SaveManagerTrace()
    {
        controller.SaveManagerTrace();
    }

    public void AddTrace(Trace t)
    {
        controller.AddTrace(t);
    }


    public Player GetPlayer()
    {
        return controller.player;
    }

    public bool CheckPlayer()
    {
        if (controller.player==null)
        {
            return false;
        }
        return true;
    }
    public void ScoreScene(){
        SceneManager.LoadScene("FinishScene");

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