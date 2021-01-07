using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

public class Player 
{
	public string name;
	public float vdi;
	public int limit;
	public float coef;
	public Score score;
	public Feature feature;
	public float capD;
	public float capG;
    public float alpha;

    public Player(int age ,int sex,string _name)
    {
        name = _name;
        feature = new Feature(age,sex);
        limit = calcul_limit(feature);
        score = new Score();
    }

    public Player(string filename)
    {
        score=new Score();
        load(filename);
    }

    public Player()
    
    {
        name = "alpha";
        feature = new Feature(100,1);
        limit = calcul_limit(feature);
        score = new Score();
    }




    public void load(string filename){
        try
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string l in lines)
            {
                string[] words = l.Split(',');
                try
                {
                    name=words[0];
                    vdi=Convert.ToSingle(words[1]);
                    limit= Convert.ToInt32(words[2]);
                    coef=Convert.ToInt32(words[3]);
                    score.lastscore=Convert.ToInt32(words[4]);
                    score.increase=Convert.ToSingle(words[5]);
                    capD=Convert.ToSingle(words[6]);
                    capG=Convert.ToSingle(words[7]);
                    alpha=Convert.ToSingle(words[8]);
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

    public void save(string filename){
        string str =tostring();
        FileStream fsOverwrite = new FileStream(filename, FileMode.Create);
        StreamWriter swOverwrite = new StreamWriter(fsOverwrite);
        swOverwrite.WriteLine(str);
        swOverwrite.Close();
    }
    
    private string tostring(){
        string str = name +","+vdi.ToString();
        str = str + ","+limit.ToString();
        str = str + ","+coef.ToString();
        str = str + ","+score.lastscore.ToString();
        str = str + ","+score.increase.ToString();
        str = str + ","+capD.ToString();
        str = str + ","+capG.ToString();
        str = str + ","+alpha.ToString();
        return str;

    }


    public void modeliser(ArrayList traces){
        Trace trace=(Trace)traces[traces.Count - 1];

        score.updatescore(trace);
    	coef = calcul_coef(score);
        int sumgauche=0;
        int sum=0;
        foreach(Trace t in traces){
            sumgauche += t.scoreGauche;
            sum +=  t.scoreActuelle;
        }
        capG = sumgauche / sum;
        capD = 100- capG;
        vdi = vdi*(1-alpha)+ vdi*coef*alpha;
        alpha = alpha*0.8f;
    }

    public int calcul_limit(Feature feature){
        int age =feature.getAge();
        if( age >= 70){
            limit=80;
        }
        else if( age < 12){
            limit=90;
        }
        else{
            limit =100;
        }
    	return limit;
    }

    public float calcul_coef(Score score){
        float inc = score.increase;
        if (inc <= 0){
            coef=0f;
        }
        else if (inc>20){
            coef =1.2f;
        }
        else{
            coef=1f+inc/100;
        }
    	return coef;
    }

    public string GuessLorR(){
        if(capG>65){
            return "Gaucher";
        }
        else if(capD>65){
            return "Droitier";
        }else{
            return "Ambidextrie";
        }
    }
    
}
