using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRayManager : MonoBehaviour {
	public Color targetColor1;
	LightRays2D lightRays2D;
	private void Awake() {
		lightRays2D = GetComponent<LightRays2D>();
	}
	private void Update() {
		lightRays2D.color1 = Color.Lerp(GetComponent<LightRays2D>().color1,targetColor1,Time.deltaTime);
	}
}
