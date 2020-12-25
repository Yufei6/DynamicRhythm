using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Score
{
    public float increase;
    public int[] all_score;
    public int lastscore;

    public Score(int[] score ,int lastscore, float increase )
    {
       this.all_score=score;
       this.lastscore =lastscore;
       this.increase =increase;
    }
    public void updatescore(Trace trace){
    	int score=trace.ScoreActuelle;
    	increase=score/lastscore*100-100;
    	lastscore=score;
    	all_score=all_score.Append(score).ToArray();
    }
}
