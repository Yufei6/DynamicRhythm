﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class NewBehaviourScript1 : MonoBehaviour
{
	public GameObject up;
    public GameObject carre;
	public GameObject parents;
    public bool state=false;
    public TMP_Text t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state){
            string str ="tostring()"+", " +"1";
            FileStream fsOverwrite = new FileStream("Assets/scripts/test.txt", FileMode.Create);
            StreamWriter swOverwrite = new StreamWriter(fsOverwrite);
            swOverwrite.WriteLine(str);
            swOverwrite.Close();
            Debug.Log("file");
        }
        if(state){
            Instantiate(up, new Vector3(835+405, 100, 0), Quaternion.identity,parents.transform);
            GameObject d=Instantiate(up, new Vector3(405, 600, 0), Quaternion.identity,parents.transform);
            Debug.Log(d.transform.position.x);
            Debug.Log(carre.transform.position.x);
            Debug.Log(t.text);
            state= false;
        }
        
        
        
    }
}
