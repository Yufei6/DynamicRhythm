using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joyconreader : MonoBehaviour
{
	private List<Joycon>    m_joycons;
	private Joycon          m_joyconL;
    private Joycon          m_joyconR;
    private ArrayList       accllistleft;
    private ArrayList       accllistright;
    // Start is called before the first frame update
    void Start()
    {
    	m_joycons = JoyconManager.Instance.j;

        if ( m_joycons == null || m_joycons.Count <= 0 ) return;

        m_joyconL = m_joycons.Find( c =>  c.isLeft );
        m_joyconR = m_joycons.Find( c => !c.isLeft );
        
    }

    // Update is called once per frame
    void Update()
    {
        var accel = m_joyconL.GetAccel();
        var accel1 = m_joyconR.GetAccel();
        
        //Debug.Log("R"+accel1.x);
    
    }
}
