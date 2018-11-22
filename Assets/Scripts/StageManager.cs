using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	public int score;
	public int hiScore;
	public int lives = 2;
	public GameObject rings;
	public GameObject droplets;
	public GameObject playButton;
	public Text scoreText;

	private bool playing = false;

	void Start () {
		hiScore = PlayerPrefs.GetInt ("HiScore", 0);
		scoreText.text = "BEST " + hiScore.ToString();
		Time.timeScale = 0;
	}

	void Update () {
		if (lives == 0)
			GameOver ();

		if (playing)
			scoreText.text = score.ToString();
	}

	public void AddScore(){
		score++;
	}

	public void WrongColor(){
		rings.GetComponent<Transform>().position = new Vector3 (0, -0.05f, 0);
		lives--;
	}

	public void GameOver(){
		Destroy (droplets);
		Time.timeScale = 0;
		if (score > hiScore) {
			hiScore = score;
			PlayerPrefs.SetInt ("HiScore", score);
		}
		SceneManager.LoadScene ("gameplay");
	}

	public void Play(){
		Time.timeScale = 1;
		SpawnManager.spawning = false;
		playButton.SetActive(false);
		playing = true;
	}
}
