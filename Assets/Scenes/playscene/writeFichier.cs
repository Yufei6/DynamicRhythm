using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class writeFichier : MonoBehaviour
{
	public Player player;
	private ControllerSystem cs;
	private string songname="aaa";
	private int songid;
	private int movespeed;
	private Controller ct;
	void Awake(){
		GameObject controller =  GameObject.Find("Controller(Clone)");
        cs = controller.GetComponent<ControllerSystem>();
        ct=cs.controller;
        player = cs.GetPlayer();
        songname=ct.GetSongNameUsingSongId(cs.GetSongId());
        songid=cs.GetSongId();
        if(songid==0){
            movespeed=200;
        }
        if(songid==1){
            movespeed=150;
        }
        if(songid==2){
            movespeed=300;
        } 
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //write("a","b","c");
    }
    public void write(ArrayList actionframe,ArrayList acclL,ArrayList acclR,int life)
    {
    	var hour = System.DateTime.Now.Hour;
        var minute = System.DateTime.Now.Minute;
        var second = System.DateTime.Now.Second;
        var year = System.DateTime.Now.Year;
        var month = System.DateTime.Now.Month;
        var day = System.DateTime.Now.Day;
        string currentTimeText = string.Format("{0:D2}_{1:D2}_{2:D2}_" + "{3:D4}_{4:D2}_{5:D2}", hour, minute, second, year, month, day);
    	
    	string filename=player.name+"_"+currentTimeText+"_"+songname+"_trace.txt";
    	string path="Assets/Trace/New/"+filename;
    	string firstline=songid.ToString()+","+player.name+","+currentTimeText+","+"50"+","+movespeed.ToString()+","+life.ToString();
    	FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
        StreamWriter sw = new StreamWriter(fs); // 创建写入流
        sw.WriteLine(firstline);
        for( int i=0;i<acclL.Count;i++){
        	Vector3 accel=(Vector3)acclL[i];
        	Vector3 accer=(Vector3)acclR[i];
        	string xl=accel.x.ToString();
        	string yl=accel.y.ToString();
        	string zl=accel.z.ToString();
        	string xr=accer.x.ToString();
        	string yr=accer.y.ToString();
        	string zr=accer.z.ToString();
        	string acce=xl+","+yl+","+zl+","+xr+","+yr+","+zr;
        	sw.WriteLine(acce);
        }
        sw.WriteLine("*****");
        foreach (string x in actionframe){
        	sw.WriteLine(x);
        }
        // 写入Hello World
        sw.Close(); //关闭文件
    }
}
