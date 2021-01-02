using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using TMPro;

public class ChooseSong : MonoBehaviour
{
	public GameObject ButtonPlay;
	public GameObject ButtonStop;
	public TextMeshProUGUI SongNameGO;
	public AudioClip[] audios;
	
	TextMeshProUGUI SongName;
    private ControllerSystem cs;
    private int nbSong;
    private int idSong;
    private string nameSong;
	private AudioClip Clips;
    string pathFolder;
    string path;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        GameObject controller =  GameObject.Find("Controller(Clone)");
        cs = controller.GetComponent<ControllerSystem>();
        SongName = SongNameGO.GetComponent<TextMeshProUGUI>();
        nbSong = cs.GetLengthSong();
        idSong = 0;
        pathFolder = Application.dataPath + "/Music/";
        nameSong = cs.controller.bibioSong.GetSongName(idSong);
        SongName.text = nameSong;
        path = pathFolder + nameSong + ".mp3";
        audio = this.GetComponent<AudioSource>();
        audio.loop = true;
        audio.clip = audios[idSong];
        audio.Play();
    }


    public void Back2Menu()
    {
        cs.Back2Menu();
    }

    public void StartGame()
    {
        cs.StartPlaying();
    }

    public void NextSong()
    {
    	idSong += 1;
    	idSong = idSong % nbSong;
		nameSong = cs.controller.bibioSong.GetSongName(idSong);
		SongName.text = nameSong;
        path = pathFolder + nameSong + ".mp3";
        audio.clip = audios[idSong];
        if(ButtonStop.active)
        {
        	audio.Play();
        }
    }

    public void PreviousSong()
    {
    	idSong -= 1;
    	if (idSong<0)
    	{
    		idSong += nbSong;
    	}
    	idSong = idSong % nbSong;
		nameSong = cs.controller.bibioSong.GetSongName(idSong);
		SongName.text = nameSong;
        path = pathFolder + nameSong + ".mp3";
        audio.clip = audios[idSong];
        if(ButtonStop.active)
        {
        	audio.Play();
        }
    }

    public void StopMusic()
    {
    	audio.Stop();
    	ButtonPlay.SetActive(true);
    	ButtonStop.SetActive(false);
    }

    public void StartMusic()
    {
    	audio.Play();
    	ButtonPlay.SetActive(false);
    	ButtonStop.SetActive(true);
    }
}
