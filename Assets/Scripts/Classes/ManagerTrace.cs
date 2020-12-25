using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ManagerTrace
{
	public Trace[] TraceList;
	public int NbTraces;
    public ManagerTrace()
    {
        
    }
    public void AddTrace(Trace t){
    	NbTraces +=1;
    	TraceList =TraceList.Append(t).ToArray();
    }
}
