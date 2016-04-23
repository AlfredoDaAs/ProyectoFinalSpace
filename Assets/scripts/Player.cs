using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{

	private LevelManager levelManager;
    private Quaternion rotation;
    public GameObject shot;
    public AudioClip shotSound;

    public float speedShot = 10f;
    private float movingSpeed = 2f;
    float speed = 10f;
	float maxX, minX;

	

	// Use this for initialization
	void Start ()
	{
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		minX = leftMost.x;
		maxX = rightMost.x;
	}	
	
	void Awake ()
	{
		rotation = transform.rotation;
	}

	void Update ()
	{
		Camera.main.transform.position = (new Vector3 (gameObject.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));           
		transform.localScale = new Vector3 (1, 1, 1);
		transform.position += Vector3.right * movingSpeed * Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject shotClone = (GameObject)Instantiate (shot, new Vector3 (transform.position.x + 1, transform.position.y, 0), Quaternion.identity); 
			shotClone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speedShot, 0.0f);
			shotClone.transform.Rotate (new Vector3 (0, 0, 90));
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.localScale = new Vector3 (1, 1, 1);
			transform.position += Vector3.up * movingSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.localScale = new Vector3 (1, 1, 1);
			transform.position += Vector3.down * movingSpeed * Time.deltaTime;
		}
		transform.rotation = rotation;
	}
}
