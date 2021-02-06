using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        if (File.Exists(pathPlayer)) 
        {
            Continue();
        }
    }

    public void UpdatePlayer(Trace t)
    {
        managerTrace.AddTrace(t);
        player.modeliser(managerTrace.GetListTrace());
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

    public string GetSongNameUsingSongId(int id)
    {
        return bibioSong.GetSongName(id);
    }


    public void Save()
    {
        player.save(pathPlayer);
        managerTrace.Save(pathTrace);
    }

    public Trace AnalyseFromSmallTrace(string filepath){
        int idSong = 0;
        string userName;
        string datetime = "";
        int framePerSecond;
        List<List<float>> list_acc = new List<List<float>>();
        try
        {
            string[] lines = File.ReadAllLines(filepath);
            int i = 0;
            foreach (string l in lines)
            {
                string[] words = l.Split(',');
                //the first line of file smallTrace
                if (i==0){
                    try
                    {
                        idSong = Convert.ToInt32(words[0]);
                        userName = words[1];
                        datetime = words[2];
                        framePerSecond = Convert.ToInt32(words[3]);
                    }
                    catch(System.Exception)
                    {
                        Debug.Log("An exception when change String to int has been thrown!");
                    }
                }
                else{
                    try
                    {
                        float acc_x_left = Convert.ToSingle(words[0]);
                        float acc_y_left = Convert.ToSingle(words[1]);
                        float acc_z_left = Convert.ToSingle(words[2]);
                        float acc_x_right = Convert.ToSingle(words[3]);
                        float acc_y_right = Convert.ToSingle(words[4]);
                        float acc_z_right = Convert.ToSingle(words[5]);
                        List<float> item = new List<float>(new float[]{acc_x_left, acc_y_left, acc_z_left, acc_x_right, acc_y_right, acc_z_right});
                        list_acc.Add(item);
                    }
                    catch (System.Exception)
                    {
                        Debug.Log("An exception when change String to int has been thrown!");
                    }
                }
                i = i + 1;
            }
        }
        catch(IOException)
        {
            Debug.Log("An IO exception has been thrown!");
        }

        Song s = bibioSong.GetSong(idSong);
        ArrayList ins = s.GetListIns();

        //Compare the trace and ins


        Trace t = new Trace(0, 0, 0, 0, 0, 0, s.name, 0, 0, 0, 0,0, datetime);
        return t;
    }
}
