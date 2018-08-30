using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnr : MonoBehaviour {

    [SerializeField]
    GameObject Enemy;

    float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            timer = 0;
        }
	}
}
