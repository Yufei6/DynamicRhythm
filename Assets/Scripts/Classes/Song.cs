using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Song 
{
    static int idKey=0;
    public int id;
    public string name;
    public ArrayList listIns;

    public Song(string n)
    {
        id = idKey;
        idKey += 1;
        name = n;
        listIns = new ArrayList();
    }

    public void AddIns(Instruction i)
    {
        listIns.Add(i);
    }

    public void ReadFile(string filepath)
    {
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

    public ArrayList getListIns()
    {
        return listIns;
    }


}

