using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
	public AudioClip[] audios;
	public AudioSource audioSource;
	private ControllerSystem cs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controller =  GameObject.Find("Controller(Clone)");
        cs = controller.GetComponent<ControllerSystem>();
        int idSong = cs.GetSongId();
        audioSource.loop = false;
        audioSource.clip = audios[idSong];
        audioSource.Play();
    }


}
