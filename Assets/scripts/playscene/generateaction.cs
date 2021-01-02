using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class generateaction : MonoBehaviour
{
	public GameObject go;
	private Song song;
	public GameObject left,right,up ;
	private int frameA=0;
	public int framepersecond;
	private int i=0;
	public GameObject parents;
    private ArrayList listIns=new ArrayList();
    private float pre=0f;
    public GameObject perfect;
    private int count;


    // Start is called before the first frame update
    void Start()
    {
    	getSong("Assets/Music/Enegie1.txt");
        //song=go.GetComponent<ControllerSystem>().song;
    }
    private void getSong(string filepath){
        
    	try
        {
            string[] lines = File.ReadAllLines(filepath);
            
            foreach (string l in lines)
            {
                string[] words = l.Split(',');
                try
                {
                    Instruction ins = new Instruction(Convert.ToInt32(words[1]),Convert.ToSingle(words[0]));
                    listIns.Add(ins);
                    
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

    // Update is called once per frame
    void FixedUpdate(){
        float rightx= parents.transform.position.x+381;
        //right
        float leftx=parents.transform.position.x-445;
    	Instruction ins= (Instruction)listIns[i];
    	frameA+=1;
    	float t=ins.getTime()*framepersecond;
    	int action =ins.getAction();
        Debug.Log(t);
    	if (frameA <= t && frameA+1>t ){
            i+=1;
    		//only for test
            if(pre+60<t){
                pre=t;
        		if (action ==0){
        			Instantiate(up, new Vector3(rightx, 100, 0), Quaternion.identity,parents.transform);
        		}
        		if (action ==1){
        			Instantiate(right, new Vector3(leftx, 100, 0), Quaternion.identity,parents.transform);
        		}
        		if (action ==2){
        			Instantiate(up, new Vector3(leftx, 100, 0), Quaternion.identity,parents.transform);
        			Instantiate(up, new Vector3(rightx, 100, 0), Quaternion.identity,parents.transform);
        		}
        		if (action ==3){
        			Instantiate(up, new Vector3(leftx, 100, 0), Quaternion.identity,parents.transform);
        			Instantiate(left, new Vector3(rightx, 100, 0), Quaternion.identity,parents.transform);
        		}if (action ==4){
        			Instantiate(up, new Vector3(leftx, 100, 0), Quaternion.identity,parents.transform);
        			Instantiate(left, new Vector3(rightx, 100, 0), Quaternion.identity,parents.transform);
        		}
            }
    	}
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            GameObject[] gos=  GameObject.FindGameObjectsWithTag("up");
            foreach (GameObject go in gos)
            {
                float diff = go.transform.position.y-parents.transform.position.y-180;
                
                
                if (diff < 50&&diff> -50) 
                {
                    perfect.SetActive(true);
                    Destroy(go);
                }
            }


        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            GameObject[] gos=  GameObject.FindGameObjectsWithTag("right");
            foreach (GameObject go in gos)
            {
                float diff = go.transform.position.y-parents.transform.position.y-200;
                
                if (diff < 50) 
                {
                    perfect.SetActive(true);
                    Destroy(go);
                }
            }

        }if(Input.GetKeyDown(KeyCode.LeftArrow)){
            GameObject[] gos=  GameObject.FindGameObjectsWithTag("left");
            foreach (GameObject go in gos)
            {
                float diff = go.transform.position.y-700f;
                
                if (diff < 20) 
                {
                    perfect.SetActive(true);
                    Destroy(go);
                }
            }

        }
        if (perfect.activeSelf){
            count=count+1;
        }
        if (count>10){
            perfect.SetActive(false);
            count=0;
        }

    }
    void Update()
    {
        
    }
}
