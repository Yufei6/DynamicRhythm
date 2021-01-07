using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace{
    static int idKey=0;
    public int id;
    public int nbInsTotal;
    public int nbInsMG;
    public int nbInsMD;
    public int nbInsOkMG;
    public int nbInsOkMD;
    public int nbGame;
    public string nameSong;
    public int timeTotal;
    public int healthRest;
    public int scoreActuelle;
    public int scoreTotal;
    public int scoreGauche;


    private string currentTimeText;
    private int hour;
    private int minute;
    private int second;
    private int year;
    private int month;
    private int day;


    public Trace(int nbIT, int nbIMG, int nbIMD, int nbIOMG, int nbIOMD, int nbG, string nS, int tT,int lR, int sA, int sT, int sG, string ctt)
    {
        id = idKey;
        idKey += 1;
        nbInsTotal = nbIT;
        nbInsMG = nbIMG;
        nbInsMD = nbIMD;
        nbInsOkMG = nbIOMG;
        nbInsOkMD = nbIOMD;
        nbGame = nbG;
        nameSong = nS;
        timeTotal = tT;
        healthRest = lR;
        scoreActuelle = sA;
        scoreTotal = sT;
        scoreGauche = sG;
        currentTimeText = ctt;
    }

    // Initialization of class Trace
    public Trace(int nbIT, int nbIMG, int nbIMD, int nbIOMG, int nbIOMD, int nbG, string nS, int tT,int lR, int sA, int sT, int sG)
    {
        id = idKey;
        idKey += 1;
        nbInsTotal = nbIT;
        nbInsMG = nbIMG;
        nbInsMD = nbIMD;
        nbInsOkMG = nbIOMG;
        nbInsOkMD = nbIOMD;
        nbGame = nbG;
        nameSong = nS;
        timeTotal = tT;
        healthRest = lR;
        scoreActuelle = sA;
        scoreTotal = sT;
        scoreGauche = sG;
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;
        year = DateTime.Now.Year;
        month = DateTime.Now.Month;
        day = DateTime.Now.Day;
        currentTimeText = string.Format("{0:D2}:{1:D2}:{2:D2} " + "{3:D4}/{4:D2}/{5:D2}", hour, minute, second, year, month, day);
    }

    public string GetAllInformation(){
        string informations = "";
        res += nbInsTotal.ToString()+",";
        res += nbInsMG.ToString()+",";
        res += nbInsMD.ToString()+",";
        res += nbInsOkMG.ToString()+",";
        res += nbInsOkMD.ToString()+",";
        res += nbGame.ToString()+",";
        res += nameSong.ToString()+",";
        res += timeTotal.ToString()+",";
        res += healthRest.ToString()+",";
        res += scoreActuelle.ToString()+",";
        res += scoreTotal.ToString()+",";
        res += scoreGauche.ToString()+","+currentTimeText;
        return informations;
    }


}
