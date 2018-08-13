using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;
public class rainManager : MonoBehaviour {
public static GameObject instance;

public float rainIntensity = 0.05f;
public float smooth;
RainScript2D rainScript2D;
 void Awake(){
     
     DontDestroyOnLoad (this);

     if (instance == null) {
         instance = this.gameObject;
     } else {
         Destroy(this.gameObject);
     }
    rainScript2D = GetComponent<RainScript2D>();
 }
 private void Update() {
	 rainScript2D.Camera = Camera.main;
     rainScript2D.RainIntensity = Mathf.Lerp(rainScript2D.RainIntensity,rainIntensity,Time.deltaTime * smooth);
 }

}
