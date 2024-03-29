﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float score;
	public int lives;
	public AudioClip CLICK;
	public AudioClip BOOM;

	// references
	public GameObject leftArrow;
	public GameObject rightArrow;
	public GameObject upArrow;
	public GameObject downArrow;

	// camera properties
	public Camera mainCamera;
	public float width;
	public float height;

	GUIStyle largeFont;

	// Use this for initialization
	void Start () {

		largeFont = new GUIStyle ();
		largeFont.fontSize = 32;

		// get the height and width of the screen;
		height = 2f * mainCamera.orthographicSize;
		width = height * mainCamera.aspect;

		this.score = 0;
		this.lives = 5;


		//make arrow objects
		//GameObject left = Instantiate (leftArrow, transform);
		GameObject left = Instantiate (leftArrow, new Vector3(-width/6, 0, 0), Quaternion.Euler(0,0,0));
		Arrow leftA = left.GetComponent<Arrow> ();
		leftA.code = KeyCode.LeftArrow;

		//GameObject right = Instantiate (rightArrow, transform);
		GameObject right = Instantiate (rightArrow, new Vector3(width/6, 0, 0), Quaternion.Euler(0,0,0));
		Arrow rightA = right.GetComponent<Arrow> ();
		rightA.code = KeyCode.RightArrow;


		//GameObject up = Instantiate (upArrow, transform);
		GameObject up = Instantiate (upArrow, new Vector3(0, height/4, 0), Quaternion.Euler(0,0,0));
		Arrow upA = up.GetComponent<Arrow> ();
		upA.code = KeyCode.UpArrow;


		//GameObject down = Instantiate (downArrow, transform);
		GameObject down = Instantiate (downArrow,  new Vector3(0, -height/4, 0), Quaternion.Euler(0,0,0));
		Arrow downA = down.GetComponent<Arrow> ();
		downA.code = KeyCode.DownArrow;
	}

	// Update is called once per frame
	void Update ()
	{
		if (lives <= 0 && Input.GetKeyDown (KeyCode.R)) {
			lives = 5;
			score = 0;
		}
	}

	// code for displaying score and lives
	void OnGUI()
	{
		GUI.Box (new Rect (4*Screen.width / 6, 0, 100, 50), "Score: " + score);
		GUI.Box (new Rect (Screen.width/6, 0, 100, 50), "Lives: " + lives);

		if (lives <= 0) 
		{
			
			GUI.Label (new Rect (Screen.width/2 - 80, Screen.height/2 - 30, Screen.width, Screen.height), "Game Over!", largeFont);
			GUI.Label (new Rect (Screen.width/2 - 130, Screen.height/2, Screen.width, Screen.height), "Press R to Restart!", largeFont);
		}
	}
}
