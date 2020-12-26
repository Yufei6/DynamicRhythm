using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitController : MonoBehaviour
{
    public GameObject controllerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Controller(Clone)")==null)
        {
            Instantiate(controllerPrefab);
        }
    }

}
