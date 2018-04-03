using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

private void LateUpdate() {
	var player = GameObject.FindGameObjectWithTag("Player");
	transform.position = player.transform.position;
}

}
