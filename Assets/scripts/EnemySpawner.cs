using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
	// Use this for initialization
	void Start () {
        drawEnemies();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void drawEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemyClone = (GameObject)Instantiate(enemy, child.transform.position, Quaternion.identity);
            enemyClone.transform.parent = child;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}
