using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

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
        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        second = System.DateTime.Now.Second;
        year = System.DateTime.Now.Year;
        month = System.DateTime.Now.Month;
        day = System.DateTime.Now.Day;
        currentTimeText = string.Format("{0:D2}:{1:D2}:{2:D2} " + "{3:D4}/{4:D2}/{5:D2}", hour, minute, second, year, month, day);
    }

    public string GetAllInformation(){
        string informations = "";
        informations += nbInsTotal.ToString()+",";
        informations += nbInsMG.ToString()+",";
        informations += nbInsMD.ToString()+",";
        informations += nbInsOkMG.ToString()+",";
        informations += nbInsOkMD.ToString()+",";
        informations += nbGame.ToString()+",";
        informations += nameSong.ToString()+",";
        informations += timeTotal.ToString()+",";
        informations += healthRest.ToString()+",";
        informations += scoreActuelle.ToString()+",";
        informations += scoreTotal.ToString()+",";
        informations += scoreGauche.ToString()+","+currentTimeText;
        return informations;
    }

}
