using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabMove : MonoBehaviour
{
	private float movespeed=250f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void FixedUpdate(){
        Debug.Log(movespeed* Time.deltaTime);
    	if (transform.position.y <= 900){
    		transform.Translate(0,movespeed* Time.deltaTime,0);
    	}else{
    		Destroy(gameObject);
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
