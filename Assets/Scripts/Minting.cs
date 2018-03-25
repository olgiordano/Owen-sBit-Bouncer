using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minting : MonoBehaviour {

		public GameObject[] enemySpawn;
		public Transform enemyPrefab;
		public float creating = 0;

		void Update()
	{
		creating += 0.125f;
		if (creating == 10.0f) {
				Instantiate(enemyPrefab, transform.position, transform.rotation);
				creating = 0.0f;
//			}
		}
	}
}
