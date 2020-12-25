using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace{
    static int idKey=0;
    public int Id;
    public int NbInsTotal;
    public int NbInsMG;
    public int NbInsMD;
    public int NbInsOkMG;
    public int NbInsOkMD;
    public int NbGame;
    public string NameSong;
    public int timeTotal;
    public int LifeLost;
    public int LifeRest;
    public int ScoreActuelle;
    public int ScoreTotal;
    public int ScoreGauche;

    // Initialization of class Trace
    public Trace(int nbIT, int nbIMG, int nbIMD, int nbIOMG, int nbIOMD, int nbG, string nS, int tT, int lL,int lR, int sA, int sT, int sG)
    {
        Id = idKey;
        idKey += 1;
        NbInsTotal = nbIT;
        NbInsMG = nbIMG;
        NbInsMD = nbIMD;
        NbInsOkMG = nbIOMG;
        NbInsOkMD = nbIOMD;
        NbGame = nbG;
        NameSong = nS;
        timeTotal = tT;
        LifeLost = lL;
        LifeRest = lR;
        ScoreActuelle = sA;
        ScoreTotal = sT;
        ScoreGauche = sG;
    }

    public int getId()
    {
        return Id;
    }
}
