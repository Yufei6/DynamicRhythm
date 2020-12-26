﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Score
{
    public float increase;
    public int[] all_score;
    public int lastscore;

    public Score( )
    {
       this.all_score=new int[0];
       this.lastscore =-1;
       this.increase =1;
    }
    public void updatescore(Trace trace){

    	int score=trace.scoreActuelle;
        if (lastscore != -1){
            increase=score/lastscore*100-100;
        }else{
            increase=1;
        }
    	lastscore=score;
    	all_score=all_score.Append(score).ToArray();
    }
}
