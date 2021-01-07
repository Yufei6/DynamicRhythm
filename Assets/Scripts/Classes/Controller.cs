﻿using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private string pathTrace = "Assets/Trace/trace.txt";
    private string pathSong = "Assets/Music/bibio.txt";
    private string pathPlayer = "Assets/Player/player.txt";
    
    public Player player;
    public ManagerTrace managerTrace;
    public BibioSong bibioSong;

    public Controller(){
        managerTrace = new ManagerTrace(pathTrace);
        bibioSong = new BibioSong(pathSong);
        player = null;
    }

    public void UpdatePlayer(Trace t)
    {
        player.modeliser(t);
        managerTrace.AddTrace(t);
    }

    public void SaveManagerTrace()
    {
        managerTrace.Save(pathTrace);
    }


    public void StartFromBegining(string name ,int age, int sex)
    {
        player = new Player(age, sex, name);
    }

    public void Continue()
    {
        player = new Player(pathPlayer);
    }


    public int GetLengthSong()
    {
        return bibioSong.GetLengthSong();
    }

    public ArrayList GetListTrace()
    {
        return managerTrace.GetListTrace();
    }

    public void AddTrace(Trace t)
    {
        managerTrace.AddTrace(t);
    }


    public Song GetSong(int id)
    {
        return bibioSong.GetSong(id);
    }


    public void Save()
    {
        player.save(pathPlayer);
        managerTrace.Save(pathTrace);
    }
}
