﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class writeFichier : MonoBehaviour
{
	public Player player;
	private ControllerSystem cs;
	void Awake(){
		GameObject controller =  GameObject.Find("Controller(Clone)");
        cs = controller.GetComponent<ControllerSystem>();
        player = cs.GetPlayer();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        write("a","b","c");
    }
    void write(ArrayList actionframe,ArrayList acclL,ArrayList acclR,)
    {
    	FileStream fs = new FileStream("Assets/scripts/test1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
        StreamWriter sw = new StreamWriter(fs); // 创建写入流
        sw.WriteLine("bob hu");
        sw.WriteLine("hello");// 写入Hello World
        sw.Close(); //关闭文件
    }
}