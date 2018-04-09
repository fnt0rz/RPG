using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] float walkMoveStopRadius = 0.2f;
    ThirdPersonCharacter thirdPersonCharacter;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
        
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        ProcessMouseMovement();
    }

    private void ProcessMouseMovement()
    {
        if (Input.GetMouseButton(0) && cameraRaycaster.currentLayerHit == Layer.Walkable)
        {
            print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());
            switch (cameraRaycaster.currentLayerHit)
            {
                case Layer.Walkable:
                    currentClickTarget = cameraRaycaster.hit.point;  // So not set in default case
                    thirdPersonCharacter.Move(currentClickTarget - transform.position, false, false);
                    break;
                case Layer.Enemy:
                    print("Not moving to enemy");
                    break;
                default:
                    return;
            }

        }
        var playerToClickPoint = currentClickTarget - transform.position;
        if (playerToClickPoint.magnitude >= walkMoveStopRadius)
        {
            thirdPersonCharacter.Move(playerToClickPoint, false, false);
        }
        else
        {
            thirdPersonCharacter.Move(Vector3.zero, false, false);
        }
    }
}

