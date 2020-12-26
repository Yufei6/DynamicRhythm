using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

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

    public Player(string name,int age ,int sex)
    {
        this.name = name;
        feature = new Feature(age,sex);
        limit = calcul_limit(feature);
        score = new Score();
    }

    public Player()
    
    {
        this.name = "alpha";
        feature = new Feature(100,1);
        limit = calcul_limit(feature);
        score = new Score();
    }

    public Player(string filename)
    {
        score=new Score();
        load(filename);
    }



    public void load(string filename){
        try
        {
            string[] lines = File.ReadAllLines(filepath);
            foreach (string l in lines)
            {
                string[] words = l.Split(',');
                try
                {
                    name=words[0];
                    vdi=Convert.ToFloat32(words[1]);
                    limit= Convert.ToInt32(words[2]);
                    coef=Convert.ToInt32(words[3]);
                    score.lastscore=Convert.ToInt32(words[4]);
                    score.increase=Convert.ToFloat32(words[5]);
                    capD=Convert.ToFloat32(words[6]);
                    capG=Convert.ToFloat32(words[7]);
                    alpha=Convert.ToFloat32(words[8]);
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
    	
    }
<<<<<<< Updated upstream
    public void modeliser(Trace[] traces, Score score, Feature feature){
    	limit = calcul_limit(feature);
    	coef = calcul_coef(score);
    	if (traces.Length != 0){
    		Trace lasttrace =traces[traces.Length-1];
            float coef2 = lasttrace.scoreActuelle/lasttrace.scoreTotal;
            capG = lasttrace.scoreGauche / lasttrace.scoreActuelle;
            capD = 100- capG;
            vdi = vdi*(1-alpha)+ coef2*coef*alpha;
            alpha = alpha*0.8f;
    	}else{
            capG=50;
            capD=50;
            vdi=limit;
            alpha=1;
        }
=======
>>>>>>> Stashed changes

    public void modeliser(Trace trace){
    	coef = calcul_coef(score);
        float coef2 = trace.ScoreActuelle/trace.ScoreTotal;
        capG = trace.ScoreGauche / trace.ScoreActuelle;
        capD = 100- capG;
        vdi = vdi*(1-alpha)+ coef2*coef*alpha;
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
            coef=1f;
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
