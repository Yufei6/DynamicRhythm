using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabMove : MonoBehaviour
{
	public float movespeed=100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate(){
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
