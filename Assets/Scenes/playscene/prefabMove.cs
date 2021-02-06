using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabMove : MonoBehaviour
{
	private float movespeed=250f;
    private ControllerSystem cs;
    // Start is called before the first frame update
    void Start()
    {
        GameObject controller =  GameObject.Find("Controller(Clone)");
        cs = controller.GetComponent<ControllerSystem>();
        int idSong = cs.GetSongId();
        if(idSong==0){
            movespeed=200;
        }
        if(idSong==1){
            movespeed=150;
        }
        if(idSong==2){
            movespeed=300;
        }
        
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
