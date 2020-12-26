using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feature
{
    private int sex;
    private int age;

    public Feature(int sex ,int age)
    {
        //TODO
        this.sex =sex;
        this.age =age;    
    }


    public int getSex()
    {
        return sex;
    }

    public int getAge()
    {
        return age;
    }

    public void SetQuestion()
    {
        //TODO
        //
    }

    public void GetReponse(int sex1 ,int age1)
    {
        sex=sex1;
        age=age1;
        //TODO
    }
}
