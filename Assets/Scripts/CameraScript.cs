using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript: MonoBehaviour {
    public GameObject kora;
    public Vector3 range;
    float smooth;
    public float inAirSmooth;
    public float fastSmooth;
    public float transition;
    public Color[] colors;
    public Color targetColor;
    int previousColorIndex = -1;
    public float changeTime;
    public static GameObject instance;
    void Awake()
    {
        if(instance == null)
            instance = this.gameObject;
        else Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
        Screen.orientation = ScreenOrientation.Portrait;
    }
    private void Start() {
        smooth = fastSmooth;
    }
    private void Update() {
        try {
            kora = FindObjectOfType<KoraScript>().gameObject;
        }catch{
            kora = null;
        }
    }
	void LateUpdate () {
        GetComponent<Camera>().backgroundColor = Color.Lerp(GetComponent<Camera>().backgroundColor, targetColor, Time.deltaTime); 
        if(kora == null)
            return;
        if (kora.GetComponent<KoraScript>().grounded)
        {
           smooth = Mathf.Lerp(smooth,fastSmooth,Time.deltaTime * transition);
        }else{
            smooth =  Mathf.Lerp(smooth,inAirSmooth,Time.deltaTime * transition);
        }
        transform.position = Vector3.Lerp(transform.position, kora.transform.position + range, Time.deltaTime * smooth);
	}
 /*   IEnumerator randomColor(float cd)
    {
        while(true){
            
            int i = Mathf.RoundToInt(Random.Range(0, colors.Length));
            while(i == previousColorIndex)
               {
                   i = Mathf.RoundToInt(Random.Range(0, colors.Length));
               }
            previousColorIndex = i;
            targetColor = colors[i];
            
            yield return new WaitForSeconds(cd);
            
            
        }
    }*/
    
}
