using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconDemo : MonoBehaviour {
	
	private List<Joycon> joycons;

    // Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;
	private float speedX ;
	private float speedY ;
	private float speedZ ;

	private Quaternion _orientation;

    void Start ()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        // get the public Joycon array attached to the JoyconManager in scene
		speedX = 0f;
		speedY = 0f;
		speedZ = 0f;
        joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind+1) {
			Destroy(gameObject);
		}

	}

	void FixedUpdate()
	{
		if (joycons.Count > 0)
        {
			Joycon j = joycons [jc_ind];
			accel = j.GetAccel();
			gyro = j.GetGyro();
			orientation = j.GetVector();
			// Debug.Log("Accel: "+accel +" Rotation"+gameObject.transform.rotation);
			// gyro = j.GetGyro();
			float ax = accel.x;
			float ay = accel.y;
			float az = accel.z;
			float t = Time.deltaTime;
			float moveX = speedX*t + 0.5f*ax*t*t;
			float moveY = speedY*t + 0.5f*ay*t*t;
			float moveZ = speedZ*t + 0.5f*az*t*t;

			// transform.position =transform.position + new Vector3 (xSpeed*Time.deltaTime,ySpeed*Time.deltaTime,0);
			// gameObject.transform.position = gameObject.transform.position + new Vector3(moveX, moveY, moveZ);
			// transform.Translate(Vector3.forward * moveZ);
			// transform.Translate(Vector3.up * moveY);
			// transform.Translate(Vector3.right * moveX);

			speedX += ax * t;
			speedY += ay * t;
			speedZ += az * t;
			
			
		}


	}

    // Update is called once per frame
    void Update () {
		// make sure the Joycon only gets checked if attached
		if (joycons.Count > 0)
        {
			Joycon j = joycons [jc_ind];
			// GetButtonDown checks if a button has been pressed (not held)
            if (j.GetButtonDown(Joycon.Button.SHOULDER_2))
            {
				Debug.Log ("Shoulder button 2 pressed");
				// GetStick returns a 2-element vector with x/y joystick components
				Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}",j.GetStick()[0],j.GetStick()[1]));
            
				// Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
				j.Recenter ();
			}
			// GetButtonDown checks if a button has been released
			if (j.GetButtonUp (Joycon.Button.SHOULDER_2))
			{
				Debug.Log ("Shoulder button 2 released");
			}
			// GetButtonDown checks if a button is currently down (pressed or held)
			if (j.GetButton (Joycon.Button.SHOULDER_2))
			{
				Debug.Log ("Shoulder button 2 held");
			}

			if (j.GetButtonDown (Joycon.Button.DPAD_DOWN)) {
				Debug.Log ("Rumble");

				// Rumble for 200 milliseconds, with low frequency rumble at 160 Hz and high frequency rumble at 320 Hz. For more information check:
				// https://github.com/dekuNukem/Nintendo_Switch_Reverse_Engineering/blob/master/rumble_data_table.md

				j.SetRumble (160, 320, 0.6f, 200);

				// The last argument (time) in SetRumble is optional. Call it with three arguments to turn it on without telling it when to turn off.
                // (Useful for dynamically changing rumble values.)
				// Then call SetRumble(0,0,0) when you want to turn it off.
			}

            stick = j.GetStick();

            // Gyro values: x, y, z axis values (in radians per second)
            gyro = j.GetGyro();

            // Accel values:  x, y, z axis values (in Gs)
            accel = j.GetAccel();
			

            orientation = j.GetVector();
			if (orientation == _orientation){
				// orientation = ;
				int i =1;
				// Debug.Log("999");
			}
			else{
				Debug.Log("555");
				_orientation = orientation;
				gameObject.transform.rotation = orientation;
			}
			if (j.GetButton(Joycon.Button.DPAD_UP)){
				gameObject.GetComponent<Renderer>().material.color = Color.red;
			} else{
				gameObject.GetComponent<Renderer>().material.color = Color.blue;
			}
            
        }
    }
}