using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;

public class SpawnProjectile : MonoBehaviour {
	public GameObject projectile;
	Vector2 startPoint;

	public void Atirar() {
		
		startPoint = transform.position;

		for (int i = -1; i <= 1; i++) {

			for(int j = -1; j <= 1; j++) { 
				if(i ==0 && j == 0) {

                } else { 
					var proj = Instantiate(projectile, startPoint, Quaternion.identity);
					proj.GetComponent<Projectile>().Direction = new Vector3(i, j, 0);

				}
			}
		}
	}
}
