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
    public int lifeLost;
    public int lifeRest;
    public int scoreActuelle;
    public int scoreTotal;
    public int scoreGauche;

    // Initialization of class Trace
    public Trace(int nbIT, int nbIMG, int nbIMD, int nbIOMG, int nbIOMD, int nbG, string nS, int tT, int lL,int lR, int sA, int sT, int sG)
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
        lifeLost = lL;
        lifeRest = lR;
        scoreActuelle = sA;
        scoreTotal = sT;
        scoreGauche = sG;
    }

    public string GetAllInformation(){
        string res = "";
        res += nbInsTotal.ToString()+",";
        res += nbInsMG.ToString()+",";
        res += nbInsMD.ToString()+",";
        res += nbInsOkMG.ToString()+",";
        res += nbInsOkMD.ToString()+",";
        res += nbGame.ToString()+",";
        res += nameSong.ToString()+",";
        res += timeTotal.ToString()+",";
        res += lifeLost.ToString()+",";
        res += lifeRest.ToString()+",";
        res += scoreActuelle.ToString()+",";
        res += scoreTotal.ToString()+",";
        res += scoreGauche.ToString();
        return res;

    }


}
