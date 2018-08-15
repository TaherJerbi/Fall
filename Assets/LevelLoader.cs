using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour {
	public int index;
	public Slider slider;
	private void Start() {
		StartCoroutine(LoadAsync(index));
	}
	IEnumerator LoadAsync(int index){
		AsyncOperation operation = SceneManager.LoadSceneAsync(index);
		while(!operation.isDone){
			float progress = Mathf.Clamp01(operation.progress / .9f);
			slider.value = progress;
			Debug.Log(progress);
			yield return null;
		}
	}
}
