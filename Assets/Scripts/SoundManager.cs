﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource speaker;

	public void Play(){
		speaker.Play ();
	}
}
