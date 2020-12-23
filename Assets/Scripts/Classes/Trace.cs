using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace{
    static int idKey=0;
    private int Id;
    private int NbInsTotal;
    private int NbInsMG;
    private int NbInsMD;
    private int NbInsOkMG;
    private int NbInsOkMD;
    private int NbGame;
    private string NameSong;
    private int timeTotal;
    private int LifeLost;
    private int LifeRest;
    private int ScoreActuelle;
    private int ScoreTotal;
    private int ScoreLeft;

    // Initialization of class Trace
    public Trace(int nbIT, int nbIMG, int nbIMD, int nbIOMG, int nbIOMD, int nbG, string nS, int tT, int lL,int lR, int sA, int sT, int sG)
    {
        Id = idKey;
        idKey += 1;
        NbInsTotal = nbIT;
        NbInsMG = nbIMG;
        NbInsMD = nbIMD;
        NbInsOkMG = nbIOMG;
        NbInsOKMD = nbIOMD;
        NbGame = nbG;
        NameSong = nS;
        timeTotal = tT;
        LifeLost = lL;
        LifeRest = lR;
        ScoreActuelle = sA;
        ScoreTotal = sT;
        ScoreLeft = sL;
    }

    public getId()
    {
        return Id;
    }
}
