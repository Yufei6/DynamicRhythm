using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
	private string name;
	private float vdi;
	private int limit;
	private float coef;
	private Score score;
	private Feature feature;
	private float capD;
	private float capG;
	private string filename;
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

    	}

    }
    public int calcul_limit(Feature feature){
    	return 1;
    }

    public float calcul_coef(Score score){
    	return 1.0f;
    }

    public void GuessLorR(){

    }
    
}
