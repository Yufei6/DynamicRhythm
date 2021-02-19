using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Score
{
    public float increase;
    public float[] all_score;
    public float lastscore;

    public Score( )
    {
       this.all_score=new float[0];
       this.lastscore =-1;
       this.increase =1;
    }
    public void updatescore(Trace trace){

    	float score=trace.scoreActuelle*100/trace.scoreTotal;
        if (lastscore != -1){
            increase=score/lastscore*100-100;
        }else{
            increase=1;
        }

        //avoid to have a 0 as lastScore
        if (score > 0){
            lastscore=score;
        }
    	else{
            lastscore=-1;
        }
    	all_score=all_score.Append(score).ToArray();
    }
}
