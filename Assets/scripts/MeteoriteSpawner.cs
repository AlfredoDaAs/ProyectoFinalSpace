using UnityEngine;
using System.Collections;

public class MeteoriteSpawner : MonoBehaviour {
    public GameObject meteorite;
	// Use this for initialization
	void Start () {
        drawMeteorites();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void drawMeteorites()
    {
        foreach (Transform child in transform)
        {
            GameObject meteoriteClone = (GameObject)Instantiate(meteorite, child.transform.position, Quaternion.identity);
            meteoriteClone.transform.parent = child;
        }
    }

}
