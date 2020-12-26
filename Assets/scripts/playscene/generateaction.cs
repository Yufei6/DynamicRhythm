using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateaction : MonoBehaviour
{
	public GameObject go;
	private Song song;
	public GameObject left,right,up ;
	private int frameA=0;
	public int framepersecond;
	private int i=0;
	public GameObject parents;
    // Start is called before the first frame update
    void Start()
    {
        //song=go.GetComponent<ControllerSystem>().song;
    }

    // Update is called once per frame
    /*void FixedUpdate(){
    	Instruction ins= song.listIns.get(i);
    	frameA+=1;
    	float t=ins.getTime()*framepersecond;
    	int action =ins.getAction();
    	if (frameA <= t && frameA+1>t){
    		//only for test
    		if (action ==0){
    			Instantiate(up, new Vector3(835+405, 100, 0), Quaternion.identity,parents.transform);
    		}
    		if (action ==1){
    			Instantiate(right, new Vector3(835+405, 100, 0), Quaternion.identity,parents.transform);
    		}
    		if (action ==2){
    			Instantiate(up, new Vector3(835+405, 100, 0), Quaternion.identity,parents.transform);
    			Instantiate(up, new Vector3(405, 100, 0), Quaternion.identity,parents.transform);
    		}
    		if (action ==3){
    			Instantiate(up, new Vector3(835+405, 100, 0), Quaternion.identity,parents.transform);
    			Instantiate(left, new Vector3(405, 100, 0), Quaternion.identity,parents.transform);
    		}if (action ==4){
    			Instantiate(up, new Vector3(835+405, 100, 0), Quaternion.identity,parents.transform);
    			Instantiate(left, new Vector3(405, 100, 0), Quaternion.identity,parents.transform);
    		}
    	}

    }*/
    void Update()
    {
        
    }
}
