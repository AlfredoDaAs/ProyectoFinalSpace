using UnityEngine;
using System.Collections;

public class Meteorite : MonoBehaviour {

    public GameObject dust;
    private Player player;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Instantiate(dust, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
        Destroy(player);
    }
}
