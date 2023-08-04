using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

// Start is called before the first frame update
void Start() {
        player = GameObject.FindGameObjectWithTag("Player");  // The player
    }

    // Update is called once per frame
    void Update() {
        if (!player) player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z - 20);
    }
}
