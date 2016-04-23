using UnityEngine;
using System.Collections;

public class shotScript : MonoBehaviour
{

	public float damage = 100f;
     
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public float getDamage ()
	{
		return damage;
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		Destroy (gameObject);
	}
}
