using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;

public class ManagerTrace
{
	public ArrayList listTrace;
	public int NbTraces;

    public ManagerTrace()
    {
        NbTraces = 0;
        listTrace = new ArrayList();
    }

    public void AddTrace(Trace t){
    	NbTraces +=1;
    	listTrace.Add(t);
    }

    public GetTrace(int id){
        foreach (Trace t in listTrace)
        {
            if (t.id == id)
            {
                return t;
            }
        }
        return null;
    } 

    public void Save(string filepath)
    {
        using(System.IO.StreamWriter file = new System.IO.StreamWriter(filepath))
        {
            foreach (Trace t in listTrace)
            {
                file.WriteLine(t.GetAllInformation);
            }
        }
    }

    public void Load(string filepath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filepath);
            foreach (string l in lines)
            {
                string[] words = l.Split(',');
                string song_name = words[0];
                string song_path = words[1];
                new_song = new Song(song_name);
                new_song.ReadFile(song_path);
                listSongs.Add(new_song);
                
                try
                {
                    int nbInsTotal = Convert.ToInt32(words[0]);
                    int nbInsMG = Convert.ToInt32(words[1]);
                    int nbInsMD = Convert.ToInt32(words[2]);
                    int nbInsOkMG = Convert.ToInt32(words[3]);
                    int nbInsOkMD = Convert.ToInt32(words[4]);
                    int nbGame = Convert.ToInt32(words[5]);
                    string nameSong = words[6];
                    int timeTotal = Convert.ToInt32(words[7]);
                    int lifeLost = Convert.ToInt32(words[8]);
                    int lifeRest = Convert.ToInt32(words[9]);
                    int scoreActuelle = Convert.ToInt32(words[10]);
                    int scoreTotal = Convert.ToInt32(words[11]);
                    int scoreGauche = Convert.ToInt32(words[12]);
                    Trace t = new trace(nbInsTotal, nbInsMG, nbInsMD, nbInsOkMG, nbInsOkMD, nbGame, nameSong, timeTotal, lifeLost, lifeRest, scoreActuelle, scoreTotal, scoreGauche);
                    listTrace.Add(t);
                }
                catch (System.Exception)
                {
                    Debug.Log("An exception when change String to int/float has been thrown!");
                }
        
            }
        }
        catch(IOException)
        {
            Debug.Log("An IO exception has been thrown!");
        }
    }
}
