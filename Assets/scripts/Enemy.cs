using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float health;
    GameObject[] enemies;
    public GameObject shot;
    public float speedShot = 6.0f;
    float shotsPerSecond = 0.3f;
    int enemyCounter;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability)
        {
            enemyShot();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log("Trigger enemy");
        enemyCounter--;
        Debug.Log(enemyCounter);

        shotScript laser = trigger.gameObject.GetComponent<shotScript>();
        if (laser != null)
        {
            health = health - laser.damage;
            if (health <= 0)
            {
                Destroy(gameObject, 0.0f);
                if (enemyCounter == 0)
                {
                    EnemySpawner spawner = gameObject.GetComponent<EnemySpawner>();
                    spawner.drawEnemies();
                }
            }
        }
    }



    void enemyShot()
    {
        GameObject shotClone = (GameObject)Instantiate(shot, new Vector3(transform.position.x+1, transform.position.y, 0), Quaternion.identity);
        shotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-speedShot, 0.0f);
        shotClone.transform.Rotate(new Vector3(0, 0, 90));
    }
}
