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

    public static Trace AnalyseFromSmallTrace(String filepath){
        int idSong;
        string userName;
        string datatime;
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
    }
}
