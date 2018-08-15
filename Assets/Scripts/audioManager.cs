using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip[] songs;

	int previousSongIndex;
	private void Awake() {
		audioSource = GetComponent<AudioSource>();
		
	}
	/* 
	private void Start() {
	
		StartCoroutine(songLoop());
		
	}
	/* 
	IEnumerator songLoop(){
		int i = Mathf.RoundToInt(Random.Range(0, songs.Length));
            while(i == previousSongIndex)
               {
                   i = Mathf.RoundToInt(Random.Range(0, songs.Length));
               }
		previousSongIndex = i;
		audioSource.clip = songs[i];
		audioSource.enabled = true;
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		audioSource.Stop();
		StartCoroutine(songLoop());
	}*/
}
