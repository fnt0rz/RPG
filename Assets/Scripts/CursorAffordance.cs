using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {

	[SerializeField] Texture2D walkCursor,attackCursor,unknownCursor = null;
	[SerializeField] Vector2 cursorHotSpot = new Vector2(96f,96f);
	CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start () {
		cameraRaycaster = GetComponent<CameraRaycaster>();		
	}
	
	// Update is called once per frame
	void Update () {
		switch (cameraRaycaster.layerHit)
		{
			case Layer.Walkable:
				Cursor.SetCursor(walkCursor,cursorHotSpot,CursorMode.Auto);
				break;
			case Layer.Enemy:
				Cursor.SetCursor(attackCursor,cursorHotSpot,CursorMode.Auto);
				break;
			default:
				Cursor.SetCursor(unknownCursor,cursorHotSpot,CursorMode.Auto);
				return;
		}
		
	}
}
