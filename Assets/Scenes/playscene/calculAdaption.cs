using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class calculAdaption : MonoBehaviour
{
	public Player player;
	public int NbTotal;
	public float NbGauche;
	public float NbDroite;
    private ControllerSystem cs;
    // Start is called before the first frame update
    void Start()
    {
        GameObject controller =  GameObject.Find("Controller(Clone)");
        cs = controller.GetComponent<ControllerSystem>();
        player = cs.GetPlayer();
        ArrayList listIns = cs.GetSong().GetListIns();

        NbTotal=(int)(player.vdi * listIns.Count/100f);
        NbGauche= player.capG * NbTotal/100;
        NbDroite= NbTotal - NbGauche;
        ArrayList result=new ArrayList();
        if (player.capG > 65){
            if(player.vdi>65 && player.vdi <=70){
                NbGauche =(int)(NbGauche*0.8);
                NbDroite= NbTotal - NbGauche;
            }
            if(player.vdi>70 && player.vdi <=80){
                NbGauche =(int)(NbGauche*0.6);
                NbDroite= NbTotal - NbGauche;
            }
            if(player.vdi>80 && player.vdi <=90){
                NbGauche =(int)(NbGauche*0.5);
                NbDroite= NbTotal - NbGauche;
            }
            if(player.vdi>90 ){
                NbGauche =(int)(NbGauche*0.45);
                NbDroite= NbTotal - NbGauche;
            }
        }
        if(player.capG < 35){
            if(player.vdi>65 && player.vdi <=70){
                NbDroite =(int)(NbDroite*0.8);
                NbGauche= NbTotal - NbDroite;
            }
            if(player.vdi>70 && player.vdi <=80){
                NbDroite =(int)(NbDroite*0.6);
                NbGauche= NbTotal - NbDroite;
            }
            if(player.vdi>80 && player.vdi <=90){
                NbDroite =(int)(NbDroite*0.5);
                NbGauche= NbTotal - NbDroite;
            }
            if(player.vdi>90 ){
                NbDroite =(int)(NbDroite*0.45);
                NbGauche= NbTotal - NbDroite;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
