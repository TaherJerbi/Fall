using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KoraScript : MonoBehaviour {
    [Header("Ground Spawning")]
    [SerializeField]
    GameObject[] groundPrefabs;
    [SerializeField]
    int[] percentages;
    GameObject lastGround;
    [SerializeField]
    GameObject newGround;
    
    bool isSafe =true;
    [Header("Force")]
    public float force;
    public float forceFactor;
    public float maxForce;
    public float minForce;
    public Slider forceSlider;
    [Header("Ground Check")]
    public LayerMask ground;
    public bool grounded;
    int locker;
    [Header("Cooldown")]
    public float cd = 1.2f;
    public float mincd = .6f;
    [Header("UI")]
    
    public Text cdText;
    public Text scoreText;
    public Text endScoreText;
    public Text bestScoreText;
    int score = 0;
    public GameObject replayButton;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        grounded = GetComponent<Collider2D>().IsTouchingLayers(ground);
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
        if (cd > mincd)
        {
            cd -= Time.deltaTime * .01f;
        }

        if (Input.GetMouseButton(0) && grounded && isSafe)
        {
            if (force < maxForce)
            {
                force += 1 * forceFactor;
                locker = 1;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f,1) * force * locker);
            force = minForce;
            locker = 0;
        }
        forceSlider.value = force;
        if(lastGround)
            cdText.text = lastGround.GetComponent<groundScript>().currCountdownValue.ToString("0.00");
	}


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Safe")
        {
            isSafe = true;
            cdText.enabled = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.rotation = Quaternion.identity;
            
            
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Safe")
        {
            score += 1;
            scoreText.text = score.ToString();
            lastGround = col.gameObject.transform.parent.gameObject;
            StartCoroutine(lastGround.GetComponent<groundScript>().StartCountdown(cd));

            float randomX = Random.Range(4, 7.1f);
            
            GameObject _newGround = Instantiate(groundPrefabs[MyScript.PercentageBasedRandom(groundPrefabs.Length, percentages)], newGround.transform.position + Vector3.right * randomX, Quaternion.identity);
            newGround = _newGround;
        }
        if(col.gameObject.tag == "Bonus")
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            score += 1;
            scoreText.text = score.ToString();
        }
        if(col.gameObject.tag == "Death")
        {
            Die();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Safe")
        {
            isSafe = false;
            lastGround = null;
            cdText.enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
    void Die()
    {
        replayButton.SetActive(true);
        scoreText.gameObject.SetActive(false);
        forceSlider.gameObject.SetActive(false);
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        if(PlayerPrefs.GetFloat("BestScore",0) < score )
            PlayerPrefs.SetFloat("BestScore", score);

        endScoreText.text = "SCORE : " + score.ToString();
        bestScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetFloat("BestScore").ToString();
    }

    

    
}
