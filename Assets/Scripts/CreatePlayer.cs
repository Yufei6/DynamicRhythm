using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CreatePlayer : MonoBehaviour
{
    public GameObject NameGO;
    public GameObject AgeGO;
    public GameObject SexGO;

    private TMP_InputField Name;
    private TMP_InputField Age;
    private TMP_Dropdown Sex;
    private ControllerSystem cs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controller =  GameObject.Find("Controller(Clone)");
        cs = controller.GetComponent<ControllerSystem>();
        Name = NameGO.GetComponent<TMP_InputField>();
        Age = AgeGO.GetComponent<TMP_InputField>();
        Sex = SexGO.GetComponent<TMP_Dropdown>();
    }

    public void Back2Menu()
    {
        cs.Back2Menu();
    }

    public void Create()
    {
        string name = Name.text;
        int age = Convert.ToInt32(Age.text);
        int sex = Sex.options[Sex.value].text=="Female" ? 0 : 1 ;
        cs.CreatePlayer(name, age, sex);
    }


}
