using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour {
public Weather[] weathers;
int previousWeatherIndex;
public float changeTime = 30;
private static GameObject instance;
CameraScript camScript;
LightRayManager lightRayManager;
rainManager rainManager;
private void Awake() {
	if(instance == null)
            instance = this.gameObject;
        else Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
}

private void Start() {
	StartCoroutine(changeWeather());
	
}
void SetWeather(Weather w){
	FindObjectOfType<CameraScript>().targetColor = w.colors[Random.Range(0,w.colors.Length)];
	FindObjectOfType<LightRayManager>().targetColor1 = w.lightRayColor;
	FindObjectOfType<rainManager>().rainIntensity = w.rainIntensity;

}

IEnumerator changeWeather(){
	while(true){
		int i = Mathf.RoundToInt(Random.Range(0, weathers.Length));
            while(i == previousWeatherIndex)
               {
                   i = Mathf.RoundToInt(Random.Range(0, weathers.Length));
               }
		previousWeatherIndex = i;
		Weather targetWeather = weathers[i];
		Debug.Log(targetWeather.name);
		SetWeather(targetWeather);
		yield return new WaitForSeconds(changeTime);
	}
}
public void setChangeTime(float time){
	changeTime = time;
}
}
[System.Serializable]
public class Weather{
	public string name;
	public Color[] colors;
	public float rainIntensity;
	public Color lightRayColor; 
}
