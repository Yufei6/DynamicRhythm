﻿using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    public int i = 0;
    private string pathTrace = "Assets/Trace/trace.txt";
    private string pathSong = "Assets/Music/bibio.txt";
    private string pathPlayer = "Assets/Player/player.txt";
    public Player player;
    public ManagerTrace managerTrace;
    public BibioSong bibioSong;

    public Controller(int k){
        managerTrace = new ManagerTrace(pathTrace);
        bibioSong = new BibioSong(pathSong);
        player = null;
    }

    public void UpdatePlayer(Trace t)
    {
        player.modeliser(t);
        managerTrace.AddTrace(t);
    }

    public void UpdateScore(Trace t)
    {
        
    }

    public void Delete(string s)
    {

    }

    public void StartFromBegining(int age, int sex, string name)
    {
        player = new Player(age, sex, name);
    }

    public void Continue()
    {
        player = new Player(pathPlyer);
    }

    public void SendQAndA()
    {

    }

    public Song ChoiceSons()
    {

    }

    public void StartSong(Song s)
    {

    }

    public void EndSong()
    {

    }

    public void CreateAndAddTrace()
    {

    }

    public void Pausse()
    {

    }

    public void Quit()
    {

    }
}
