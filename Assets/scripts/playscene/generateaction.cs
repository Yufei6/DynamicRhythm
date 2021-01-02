using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class generateaction : MonoBehaviour
{
	public GameObject go;
	private Song song;
	public GameObject left,right,up ;
	private int frameA=0;
	public int framepersecond;
	private int i=0;
	public GameObject parents;
    public GameObject rightbarre;
    public GameObject leftbarre;
    public GameObject carreleft;
    public GameObject carreright;
    private ArrayList listIns=new ArrayList();
    private float pre=0f;
    public GameObject perfectleft;
    public GameObject goodleftslow;
    public GameObject goodleftfast;
    public GameObject missleft;
    public GameObject perfectright;
    public GameObject goodrightslow;
    public GameObject goodrightfast;
    public GameObject missright;
    public TMP_Text score1;
    private int countleft, countright;
    private int perfectrange = 30;
    private int goodrange = 75;
    private int missrange = 75;
    private int score=0;
    private int life=16;
    public GameObject[] lifes;




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
        float rightx= rightbarre.transform.position.x;
        //right
        float leftx=leftbarre.transform.position.x;
        float righty=carreright.transform.position.y-500;
        float lefty=carreleft.transform.position.y-500;
    	Instruction ins= (Instruction)listIns[i];
    	frameA+=1;
    	float t=ins.getTime()*framepersecond;
    	int action =ins.getAction();
        Debug.Log(t);
    	if (frameA <= t && frameA+1>t ){
            i+=1;
            if(i>=listIns.Count){
                i=0;
            }
    		//only for test
            if(pre+60<t){
                pre=t;
        		if (action ==0){
        			Instantiate(up, new Vector3(rightx, 100, 0), Quaternion.identity,parents.transform);
        		}
        		if (action ==1){
        			Instantiate(right, new Vector3(rightx, 100, 0), Quaternion.identity,parents.transform);
        		}
        		if (action ==2){
        			Instantiate(up, new Vector3(leftx, 100, 0), Quaternion.identity,parents.transform);
        			Instantiate(up, new Vector3(rightx, 100, 0), Quaternion.identity,parents.transform);
        		}
        		if (action ==3){
        			Instantiate(up, new Vector3(rightx, 100, 0), Quaternion.identity,parents.transform);
        			Instantiate(left, new Vector3(leftx, 100, 0), Quaternion.identity,parents.transform);
        		}if (action ==4){
        			Instantiate(up, new Vector3(rightx, 100, 0), Quaternion.identity,parents.transform);
        			Instantiate(left, new Vector3(leftx, 100, 0), Quaternion.identity,parents.transform);
        		}
            }
    	}
        
        GameObject[] gos=  GameObject.FindGameObjectsWithTag("up");
        foreach (GameObject go in gos)
        {
            float diff = go.transform.position.y-carreright.transform.position.y;
            
            if(go.transform.position.x ==leftx){
                if(Input.GetKeyDown(KeyCode.UpArrow)){
                    if (diff < perfectrange&&diff> -perfectrange) 
                    {
                        perfectleft.SetActive(true);
                        Destroy(go);
                        score+=2;
                    }
                    else if(diff < goodrange &&diff >= perfectrange){
                        goodleftslow.SetActive(true);
                        Destroy(go);
                        score+=1;
                    }else if(diff > -goodrange &&diff <=- perfectrange){
                        goodleftfast.SetActive(true);
                        Destroy(go);
                        score+=1;
                    }
                }
                if (diff >missrange) 
                {
                    missleft.SetActive(true);
                    Destroy(go);
                    life-=1;
                    loselife();
                }
            }
            if(go.transform.position.x ==rightx){
                if(Input.GetKeyDown(KeyCode.DownArrow)){
                    if (diff < perfectrange&&diff> -perfectrange) 
                    {
                        perfectright.SetActive(true);
                        Destroy(go);
                        score+=2;
                    }else if(diff < goodrange &&diff >= perfectrange){
                        goodrightslow.SetActive(true);
                        Destroy(go);
                        score+=1;
                    }else if(diff > -goodrange &&diff <=- perfectrange){
                        goodrightfast.SetActive(true);
                        Destroy(go);
                        score+=1;
                    }
                }
                if (diff >missrange) 
                {
                    missright.SetActive(true);
                    Destroy(go);
                    life-=1;
                    loselife();
                }
            }
        }


      
        
        GameObject[] gosright=  GameObject.FindGameObjectsWithTag("right");
        foreach (GameObject go in gosright)
        {
            float diff = go.transform.position.y-carreright.transform.position.y;
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                if (diff < perfectrange&&diff> -perfectrange){
                        perfectright.SetActive(true);
                        Destroy(go);
                        score+=2;
                }else if(diff < goodrange &&diff >= perfectrange){
                    goodrightslow.SetActive(true);
                    Destroy(go);
                    score+=1;
                }else if(diff > -goodrange &&diff <=- perfectrange){
                    goodrightfast.SetActive(true);
                    Destroy(go);
                    score+=1;
                }
            }
            if (diff >missrange) {
                    missright.SetActive(true);
                    Destroy(go);
                    life-=1;
                    loselife();
            }
            
        }

        
        GameObject[] gosleft=  GameObject.FindGameObjectsWithTag("left");
        foreach (GameObject go in gosleft)
        {
            float diff = go.transform.position.y - carreleft.transform.position.y;
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                if (diff < perfectrange&&diff> -perfectrange){
                        perfectleft.SetActive(true);
                        Destroy(go);
                        score+=2;
                }else if(diff < goodrange &&diff >= perfectrange){
                    goodleftslow.SetActive(true);
                    Destroy(go);
                    score+=1;
                }else if(diff > -goodrange &&diff <=- perfectrange){
                    goodleftfast.SetActive(true);
                    Destroy(go);
                    score+=1;
                }
            }
            if (diff >missrange) {
                    missleft.SetActive(true);
                    Destroy(go);
                    life-=1;
                    loselife();
            }
        }

        
        if (perfectleft.activeSelf ){
            countleft=countleft+1;
        }
        if (goodleftfast.activeSelf ){
            countleft=countleft+1;
        }
        if (goodleftslow.activeSelf ){
            countleft=countleft+1;
        }
        if (missleft.activeSelf ){
            countleft=countleft+1;
        }

        
        if (countleft>15){
            perfectleft.SetActive(false);
            missleft.SetActive(false);
            goodleftfast.SetActive(false);
            goodleftslow.SetActive(false);
            countleft=0;
        }

        if (perfectright.activeSelf ){
            countright +=1;
        }
        if (goodrightfast.activeSelf ){
            countright +=1;
        }
        if (goodrightslow.activeSelf ){
            countright +=1;
        }
        if (missright.activeSelf ){
            countright +=1;
        }

        
        if (countright>15){
            perfectright.SetActive(false);
            missright.SetActive(false);
            goodrightslow.SetActive(false);
            goodrightfast.SetActive(false);
            countright=0;
        }
        score1.text=score.ToString();
        

        

    }
    private void loselife(){
        if (life >=0){
            lifes[life].SetActive(false);
        }
    }
    void Update()
    {
        
    }
}
