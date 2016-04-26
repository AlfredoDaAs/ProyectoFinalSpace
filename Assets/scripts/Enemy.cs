using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    GameObject[] enemies;
    public GameObject shot;
    public GameObject fire;
    public float health;
    public float speedShot = 4.0f;
    float shotsPerSecond = 0.1f;
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
                enemyExplosion();
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

    void enemyExplosion() {
        Instantiate(fire, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
