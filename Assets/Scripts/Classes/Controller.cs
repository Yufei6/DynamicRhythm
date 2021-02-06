using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Controller
{
    private string pathTrace = "Assets/Trace/trace.txt";
    private string pathSong = "Assets/Music/bibio.txt";
    private string pathPlayer = "Assets/Player/player.txt";
    
    public Player player;
    public ManagerTrace managerTrace;
    public BibioSong bibioSong;

    public Controller(){
        managerTrace = new ManagerTrace(pathTrace);
        bibioSong = new BibioSong(pathSong);
        player = null;
        if (File.Exists(pathPlayer)) 
        {
            Continue();
        }
    }

    public void UpdatePlayer()
    {
        Trace t = AnalyseFromSmallTrace();
        if (t==null){
            Debug.Log("Can not find new small trace file in New/");
        }
        else{
            managerTrace.AddTrace(t);
            Debug.Log("HELLOOOOO:;"+t.GetAllInformation());
            player.modeliser(managerTrace.GetListTrace());
        }
    }

    public void SaveManagerTrace()
    {
        managerTrace.Save(pathTrace);
    }


    public void StartFromBegining(string name ,int age, int sex)
    {
        player = new Player(age, sex, name);
    }

    public void Continue()
    {
        player = new Player(pathPlayer);
    }


    public int GetLengthSong()
    {
        return bibioSong.GetLengthSong();
    }

    public ArrayList GetListTrace()
    {
        return managerTrace.GetListTrace();
    }

    public void AddTrace(Trace t)
    {
        managerTrace.AddTrace(t);
    }


    public Song GetSong(int id)
    {
        return bibioSong.GetSong(id);
    }

    public string GetSongNameUsingSongId(int id)
    {
        return bibioSong.GetSongName(id);
    }


    public void Save()
    {
        player.save(pathPlayer);
        managerTrace.Save(pathTrace);
    }

    public string SearchFileName(string folder_path)
    {
        DirectoryInfo folder = new DirectoryInfo(folder_path);
        int count_file = 0;
        string file_name = "";
            
        foreach (FileInfo file in folder.GetFiles("*.txt"))
        {
            file_name = file.FullName;
            count_file += 1 ;        
        }
        if (count_file == 1){
            return file_name;
        }
        else{
            return "Error";
        }
    }

    public Trace AnalyseFromSmallTrace(){
        int idSong = 0;
        string userName;
        string datetime = "";
        int framePerSecond = 0;
        int speed = 0;
        int lR = 0;

        //Search new small trace file
        string folder_path = "Assets/Trace/New";
        string file_path = SearchFileName(folder_path);
        if (file_path != "Error")
        {

            List<List<float>> list_acc = new List<List<float>>();
            List<List<int>> list_ins = new List<List<int>>();
            try
            {
                string[] lines = File.ReadAllLines(file_path);
                int i = 0;
                bool meet_star = false;
                foreach (string l in lines)
                {
                    if ((meet_star==false) && (l.Contains("***"))){
                        meet_star = true;
                    }
                    else 
                    {
                        string[] words = l.Split(',');
                        if (meet_star){
                            int frame = Convert.ToInt32(words[0]);
                            int ins_type = Convert.ToInt32(words[1]);
                            List<int> item = new List<int>(new int[]{frame, ins_type});
                            list_ins.Add(item);
                        }
                        else{

                    
                            //the first line of file smallTrace
                            if (i==0){
                                try
                                {
                                    idSong = Convert.ToInt32(words[0]);
                                    userName = words[1];
                                    datetime = words[2];
                                    framePerSecond = Convert.ToInt32(words[3]);
                                    speed = Convert.ToInt32(words[4]);
                                    lR = Convert.ToInt32(words[5]);
                                }
                                catch(System.Exception)
                                {
                                    Debug.Log("An exception when change String to int has been thrown!");
                                }
                            }
                            else{
                                try
                                {
                                    float acc_x_left = Convert.ToSingle(words[0]);
                                    float acc_y_left = Convert.ToSingle(words[1]);
                                    float acc_z_left = Convert.ToSingle(words[2]);
                                    float acc_x_right = Convert.ToSingle(words[3]);
                                    float acc_y_right = Convert.ToSingle(words[4]);
                                    float acc_z_right = Convert.ToSingle(words[5]);
                                    List<float> item = new List<float>(new float[]{acc_x_left, acc_y_left, acc_z_left, acc_x_right, acc_y_right, acc_z_right});
                                    list_acc.Add(item);
                                }
                                catch (System.Exception)
                                {
                                    Debug.Log("An exception when change String to int has been thrown!");
                                }
                            }
                        }
                    }
                    i = i + 1;
                }
            }
            catch(IOException)
            {
                Debug.Log("An IO exception has been thrown!");
            }

            Song s = bibioSong.GetSong(idSong);
            int nbIT = list_ins.Count;
            int nbIMG = 0;
            int nbIMD = 0;
            int nbIOMG = 0;
            int nbIOMD = 0;
            int nbG = 0;
            int tT = 0;
            int sA = 0;
            int sT = 0;
            int sG = 0;

            nbG = PlayerPrefs.GetInt("nbGame");
            tT = (int)(list_acc.Count/framePerSecond);
            

            //Compare the trace and ins
            int perfect_frame = 30;
            int good_frame = 75;

            for (int i = 0; i < list_ins.Count; i++) {
                int frame_exate = list_ins[i][0];
                int action_type = list_ins[i][1];
                int min = 0;
                int max = list_acc.Count;

                int l2 = frame_exate;
                int l1 = l2 - (int)Math.Round(perfect_frame/(0.02*speed),0);
                int l3 = l2 + (int)Math.Round(perfect_frame/(0.02*speed),0);
                int l0 = l2 - (int)Math.Round(good_frame/(0.02*speed),0);
                int l4 = l2 + (int)Math.Round(good_frame/(0.02*speed),0);
                l0 = (l0 < min)? min : l0;
                l4 = (l4 > max)? max : l4;

                switch(action_type){
                    //0:leftTop, 1:leftLeft, 2:rightTop, 3:rightRight, 4:leftTop_rightTop, 5:leftLeft_rightRight, 6:leftTop_rightRight, 7:leftLeft_rightTop
                    case 0:
                        nbIMG += 1;
                        sT += 1;
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][0]>2.5){
                                sA += 1;
                                sG += 1;
                                nbIOMG += 1;
                                break;
                            }
                        }
                        break;
                    case 1:
                        nbIMG += 1;
                        sT += 1;
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][1]<-2){
                                sA += 1;
                                sG += 1;
                                nbIOMG += 1;
                                break;
                            }
                        }
                        break;
                    case 2:
                        nbIMD += 1;
                        sT += 1;
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][3]>2.5){
                                sA += 1;
                                nbIOMD += 1;
                                break;
                            }
                        }
                        break;
                    case 3:
                        nbIMD += 1;
                        sT += 1;
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][4]>2){
                                sA += 1;
                                nbIOMD += 1;
                                break;
                            }
                        }
                        break;
                    case 4:
                        nbIMG += 1;
                        nbIMD += 1;
                        sT +=2;
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][0]>2.5){
                                sA += 1;
                                sG += 1;
                                nbIOMG += 1;
                                break;
                            }
                        }
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][3]>2.5){
                                sA += 1;
                                nbIOMD += 1;
                                break;
                            }
                        }
                        break;
                    case 5:
                        nbIMG += 1;
                        nbIMD += 1;
                        sT +=2;
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][1]<-2){
                                sA += 1;
                                sG += 1;
                                nbIOMG += 1;
                                break;
                            }
                        }
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][4]>2){
                                sA += 1;
                                nbIOMD += 1;
                                break;
                            }
                        }
                        break;
                    case 6:
                        nbIMG += 1;
                        nbIMD += 1;
                        sT +=2;
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][0]>2.5){
                                sA += 1;
                                sG += 1;
                                nbIOMG += 1;
                                break;
                            }
                        }
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][4]>2){
                                sA += 1;
                                nbIOMD += 1;
                                break;
                            }
                        }
                        break;
                    case 7:
                        nbIMG += 1;
                        nbIMD += 1;
                        sT +=2;
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][1]<-2){
                                sA += 1;
                                sG += 1;
                                nbIOMG += 1;
                                break;
                            }
                        }
                        for (int j = l0; j < l4; j++)
                        {
                            if(list_acc[j][3]>2.5){
                                sA += 1;
                                nbIOMD += 1;
                                break;
                            }
                        }
                        break;

                    default:
                        Debug.Log("Unknown type of action!(Yufei)");
                        break;
                }                
            }      

            

            string ori_path = "Assets/Trace/New/" + file_path;
            string des_path = "Assets/Trace/Old/" + file_path;
            //move the file to Old
            // Ensure that the target does not exist.
            try
            {
                //if (File.Exists(des_path)) 
                // {
                //     File.Delete(des_path);
                // }
                File.Move(ori_path, des_path);
            }
            catch (Exception e)
            {
                Debug.Log("The process failed when moving file to Old!(yufei)");
            }


            Trace t = new Trace(nbIT, nbIMG, nbIMD, nbIOMG, nbIOMD, nbG, s.name, tT, lR, sA, sT, sG, datetime);
            return t;
        }

        return null;
    }
}
