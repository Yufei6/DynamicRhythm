using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class BibioSong
{
    public ArrayList listSongs;
    
    public BibioSong()
    {
        listSongs = new ArrayList();
    }

    public BibioSong(string filepath)
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
            }
        }
        catch(IOException)
        {
            Debug.Log("An IO exception has been thrown!");
        }
    }

    public void AddSong(Song s)
    {
        listSongs.Add(s);
    }

    public Song GetSong(int id)
    {
        foreach (Song s in listSongs)
        {
            if (s.id==id)
            {
                return s;
            }
        }
        return null;
    }

    
}
