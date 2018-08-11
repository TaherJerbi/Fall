using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;
public class rainManager : MonoBehaviour {
private static GameObject playerInstance;

 void Awake(){
     DontDestroyOnLoad (this);
         
     if (playerInstance == null) {
         playerInstance = this.gameObject;
     } else {
         Destroy(this.gameObject);
     }
 }
 private void Update() {
	 GetComponent<RainScript2D>().Camera = Camera.main;
 }
}
