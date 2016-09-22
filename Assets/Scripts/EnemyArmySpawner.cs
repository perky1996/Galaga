﻿using UnityEngine;
using System.Collections;

public class EnemyArmySpawner : MonoBehaviour {

	public int enemyRows = 3;
	public int enemyColumns = 10;
	public int direction = 1;
	public float speed = 1;
	public GameObject enemyPref;
	public GameObject[] enemies;

	void Start () {
		enemies = new GameObject[enemyRows * enemyColumns];

		Spawn ();
	}

	bool NeedSpawn() {
		return enemies.Length == 0;
	}

	void Spawn() {
		Vector2 center = gameObject.transform.position;
		for (int i = 0; i < enemyRows; i++) {
			for (int j = 0; j < enemyColumns; j++) {				
				Vector2 pos = new Vector2 (j - enemyColumns / 2 + 0.5f, i);
				enemies [i] = (GameObject)Instantiate (enemyPref, pos, Quaternion.identity);
				enemies [i].transform.SetParent (this.transform);
			}
		}
	}

	void Move() {
		var pos = transform.position;
		pos.x = pos.x + direction * Time.deltaTime * speed;
		pos.x = Mathf.Clamp (pos.x, -1, 1);

		transform.position = pos;

		if (pos.x == -1 || pos.x == 1) {
			direction = -1 * direction;
		}
	}

	void Update () {
		if (NeedSpawn ()) {
			Spawn ();
		} else {
			Move ();
		}
	}
}