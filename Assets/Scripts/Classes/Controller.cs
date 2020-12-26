using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    public int i = 0;
    private string pathTrace = "Assets/Trace/trace.txt";
    private string pathSong = "Assets/Music/bibio.txt";
    private string pathPlayer = "Assets/Player/player.txt";

    public Controller(int k){
        managerTrace = new ManagerTrace();
        managerTrace.Load(path);
        bibioSong = new BibioSong(pathSong);
        player = new Player(pathPlyer);
    }

    public UpdatePlayer(Trace t)
    {
        
    }
}
