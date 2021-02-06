using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;
using Random =System.Random;

public class generateaction : MonoBehaviour
{
    private ControllerSystem cs;
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
    private int totalAction=0;//action total de cette song
    private int NbTotal=0;// action a realise par utilisateur
    private float NbGauche=0;// action a realise guache
    private float NbDroite=0;// action a realise droite
    private Random rnd = new Random();
    private ArrayList actionframe;
    private float movespeed;
    private int preframe;
    private List<Joycon>    m_joycons;
    private Joycon          m_joyconL;
    private Joycon          m_joyconR;
    private float lastt;



    // Start is called before the first frame update
    void Start()
    {
        m_joycons = JoyconManager.Instance.j;

        if ( m_joycons == null || m_joycons.Count <= 0 ) return;

        m_joyconL = m_joycons.Find( c =>  c.isLeft );
        m_joyconR = m_joycons.Find( c => !c.isLeft );
        actionframe=new ArrayList();
        GameObject controller =  GameObject.Find("Controller(Clone)");
        cs = controller.GetComponent<ControllerSystem>();
        listIns = cs.GetSong().GetListIns();
        
        calculpreframe();
        calculnbaction();
        NbTotal=gameObject.GetComponent<calculAdaption>().NbTotal;
        NbGauche=gameObject.GetComponent<calculAdaption>().NbGauche;
        NbDroite=gameObject.GetComponent<calculAdaption>().NbDroite;
        Instruction ins= (Instruction)listIns[listIns.Count-1];
        lastt=ins.getTime()*framepersecond;

    }

    // Update is called once per frame
    void FixedUpdate(){
        Vector3 accel = m_joyconL.GetAccel();
        Vector3 accer = m_joyconR.GetAccel();
        float rightx= rightbarre.transform.position.x;
        //right
        float leftx=leftbarre.transform.position.x;
        float righty=carreright.transform.position.y-500;
        float lefty=carreleft.transform.position.y-500;
    	Instruction ins= (Instruction)listIns[i];
    	frameA+=1;
    	float t=ins.getTime()*framepersecond;
    	int action =ins.getAction();
    	if (frameA+preframe <= t && frameA+preframe+1>t ){
            i+=1;
            if(i>=listIns.Count){
                i=0;   
            }
    		//only for test
            //if(pre+60<t){
                pre=t;
                int pourcent=100*NbTotal/totalAction;
        		if (action ==0){
                    int a=rnd.Next(0,101);
                    if (a < pourcent){
                        a=rnd.Next(0,101);
                        if(a<100*NbGauche/NbTotal){
                            Instantiate(up, new Vector3(leftx, righty, 0), Quaternion.identity,parents.transform);
                            NbGauche-=1;
                            string temp=(frameA+preframe).ToString()+", 0";
                            actionframe.Add(temp);
                            //Debug.Log(temp);
                        }else{
                            Instantiate(up, new Vector3(rightx, righty, 0), Quaternion.identity,parents.transform);
                            string temp=(frameA+preframe).ToString()+", 2";
                            actionframe.Add(temp);    
                        }
                        NbTotal-=1;
                    }
                    totalAction-=1;
        		}
        		if (action ==1){
                    int a=rnd.Next(0,101);
                    if (a < pourcent){
                        a=rnd.Next(0,101);
                        if(a<100*NbGauche/NbTotal){
                            Instantiate(left, new Vector3(leftx, righty, 0), Quaternion.identity,parents.transform);
                            NbGauche-=1;
                            string temp=(frameA+preframe).ToString()+", 1";
                            actionframe.Add(temp);
                        }else{
                            Instantiate(right, new Vector3(rightx, righty, 0), Quaternion.identity,parents.transform);
                            string temp=(frameA+preframe).ToString()+", 3";
                            actionframe.Add(temp);    
                        }
                        NbTotal-=1;
                    }
                    totalAction-=1;
        		}
        		if (action ==2){
                    int a=rnd.Next(0,101);
                    if (a < pourcent){
                        Instantiate(up, new Vector3(leftx, righty, 0), Quaternion.identity,parents.transform);
                        Instantiate(up, new Vector3(rightx, righty, 0), Quaternion.identity,parents.transform);
                        NbGauche-=1;
                        NbDroite-=1;
                        NbTotal-=2;
                        string temp=(frameA+preframe).ToString()+", 4";
                        actionframe.Add(temp);           
                    }
                    totalAction-=2;
        		}
        		if (action ==3){
        			int a=rnd.Next(0,101);
                    if (a < pourcent){
                        Instantiate(left, new Vector3(leftx, righty, 0), Quaternion.identity,parents.transform);
                        Instantiate(right, new Vector3(rightx, righty, 0), Quaternion.identity,parents.transform);
                        NbGauche-=1;
                        NbDroite-=1;
                        NbTotal-=2;
                        string temp=(frameA+preframe).ToString()+", 5";
                        actionframe.Add(temp);           
                    }
                    totalAction-=2;
        		}if (action ==4){
        			int a=rnd.Next(0,101);
                    if (a < pourcent){
                        a=rnd.Next(0,101);
                        if(a< 100*NbGauche/NbTotal){
                            Instantiate(left, new Vector3(leftx, righty, 0), Quaternion.identity,parents.transform);
                            Instantiate(up, new Vector3(rightx, righty, 0), Quaternion.identity,parents.transform);
                            string temp=(frameA+preframe).ToString()+", 7";
                            actionframe.Add(temp);
                        }else{
                            Instantiate(up, new Vector3(leftx, righty, 0), Quaternion.identity,parents.transform);
                            Instantiate(right, new Vector3(rightx, righty, 0), Quaternion.identity,parents.transform);
                            string temp=(frameA+preframe).ToString()+", 6";
                            actionframe.Add(temp);
                        }
                        NbGauche-=1;
                        NbDroite-=1;
                        NbTotal-=2;           
                    }
                    totalAction-=2;
        		}
            //}
    	}
        
        GameObject[] gos=  GameObject.FindGameObjectsWithTag("up");
        foreach (GameObject go in gos)
        {
            float diff = go.transform.position.y-carreright.transform.position.y-20;
            
            if(go.transform.position.x ==leftx){
                if(Input.GetKeyDown(KeyCode.UpArrow)||accel.x>2.5){
                    if (diff < perfectrange&&diff> -perfectrange) 
                    {
                        perfectleft.SetActive(true);
                        Destroy(go);
                        score+=100;
                        m_joyconL.SetRumble (160, 320, 0.6f, 200);
                    }
                    else if(diff < goodrange &&diff >= perfectrange){
                        goodleftslow.SetActive(true);
                        Destroy(go);
                        score+=100;
                    }else if(diff > -goodrange &&diff <=- perfectrange){
                        goodleftfast.SetActive(true);
                        Destroy(go);
                        score+=100;
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
                if(Input.GetKeyDown(KeyCode.DownArrow)||accer.x>2.5){
                    if (diff < perfectrange&&diff> -perfectrange) 
                    {
                        perfectright.SetActive(true);
                        Destroy(go);
                        score+=100;
                        m_joyconR.SetRumble (160, 320, 0.6f, 200);
                    }else if(diff < goodrange &&diff >= perfectrange){
                        goodrightslow.SetActive(true);
                        Destroy(go);
                        score+=100;
                    }else if(diff > -goodrange &&diff <=- perfectrange){
                        goodrightfast.SetActive(true);
                        Destroy(go);
                        score+=100;
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
            float diff = go.transform.position.y-carreright.transform.position.y-20;
            if(Input.GetKeyDown(KeyCode.RightArrow)||accer.y>2){
                if (diff < perfectrange&&diff> -perfectrange){
                        perfectright.SetActive(true);
                        Destroy(go);
                        score+=100;
                        m_joyconR.SetRumble (160, 320, 0.6f, 200);
                }else if(diff < goodrange &&diff >= perfectrange){
                    goodrightslow.SetActive(true);
                    Destroy(go);
                    score+=100;
                }else if(diff > -goodrange &&diff <=- perfectrange){
                    goodrightfast.SetActive(true);
                    Destroy(go);
                    score+=100;
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
            float diff = go.transform.position.y - carreleft.transform.position.y-20;
            if(Input.GetKeyDown(KeyCode.LeftArrow)||accel.y<-2){
                if (diff < perfectrange&&diff> -perfectrange){
                        perfectleft.SetActive(true);
                        Destroy(go);
                        score+=100;
                        m_joyconL.SetRumble (160, 320, 0.6f, 200);
                }else if(diff < goodrange &&diff >= perfectrange){
                    goodleftslow.SetActive(true);
                    Destroy(go);
                    score+=100;
                }else if(diff > -goodrange &&diff <=- perfectrange){
                    goodleftfast.SetActive(true);
                    Destroy(go);
                    score+=100;
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
        PlayerPrefs.SetInt("score",score);
        if((frameA-preframe <= lastt && frameA-preframe+1>lastt)||(life <= 0) ){
            ArrayList acclL=gameObject.GetComponent<Joyconreader>().accllistleft;
            ArrayList acclR=gameObject.GetComponent<Joyconreader>().accllistright;
            gameObject.GetComponent<writeFichier>().write(actionframe,acclL,acclR,life);
            cs.ScoreScene();
        }

    }


    private void loselife(){
        if (life >=0){
            lifes[life].SetActive(false);
        }
    }
    private void calculnbaction(){
        foreach(Instruction ins in listIns){
            int action=ins.getAction();
            if (action ==0){
                totalAction+=1;
            }
            if (action ==1){
                totalAction+=1;
            }
            if (action ==2){
                totalAction+=2;
            }
            if (action ==3){
                totalAction+=2;
            }if (action ==4){
                totalAction+=2;
            }
        }
    }
    private void calculpreframe()
    {
       int idSong=cs.GetSongId();
       if(idSong==0){
            preframe=500*50/200;
        }
        if(idSong==1){
            preframe=500*50/150;
        }
        if(idSong==2){
            preframe=500*50/300;
        } 
    }


    void Update()
    {
        
    }
}
