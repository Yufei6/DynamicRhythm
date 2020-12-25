using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public string filename;
    public float alpha;
    public Player()
    {

    }
    public void load(){

    }
    public void save(){
    	
    }
    public void modeliser(Trace[] traces, Score score, Feature feature){
    	limit = calcul_limit(feature);
    	coef = calcul_coef(score);
    	if (traces.Length != 0){
    		Trace lasttrace =traces[traces.Length-1];
            float coef2 = lasttrace.ScoreActuelle/lasttrace.ScoreTotal;
            capG = lasttrace.ScoreGauche / lasttrace.ScoreActuelle;
            capD = 100- capG;
            vdi = vdi*(1-alpha)+ coef2*coef*alpha;
            alpha = alpha*0.8f;
    	}else{
            capG=50;
            capD=50;
            vdi=limit;
            alpha=1;
        }

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
