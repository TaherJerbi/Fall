using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject kora;
    Vector3 range;
    public float smooth;
    public Color[] colors;
    Color targetColor;
    void Awake()
    {
        randomColor();
        GetComponent<Camera>().backgroundColor = targetColor;
    }
    void Start()
    {
        range = transform.position - kora.transform.position;
        InvokeRepeating("randomColor",10 , 10);
    }
	void LateUpdate () {
        if (kora.GetComponent<KoraScript>().grounded)
        {
            transform.position = Vector3.Lerp(transform.position, kora.transform.position + range, Time.deltaTime * smooth);
        }
        GetComponent<Camera>().backgroundColor = Color.Lerp(GetComponent<Camera>().backgroundColor, targetColor, Time.deltaTime);
	}
    void randomColor()
    {
        targetColor = colors[Mathf.RoundToInt(Random.Range(0, colors.Length))];
    }
    
}
