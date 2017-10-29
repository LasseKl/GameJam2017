using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSound : MonoBehaviour {

	public AudioClip[] sounds;
	private AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
		if (sounds != null) {
			audioSources = new AudioSource[sounds.Length];
			for(int i = 0; i < sounds.Length; i++) {
				AudioSource newAudio = gameObject.AddComponent<AudioSource>();
				newAudio.clip = sounds[i]; 
				newAudio.loop = false; 
				newAudio.playOnAwake = false; 
				newAudio.volume = 1f; 
				audioSources[i] = newAudio;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playSound(int i) {
		if(i >= 0 && i < audioSources.Length)
			audioSources[i].Play();
	}

	public void playSound() {
		audioSources[Random.Range(0, audioSources.Length)].Play();
	}
}
