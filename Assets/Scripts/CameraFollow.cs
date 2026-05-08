using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public enum CameraMode
    {
        Follow,
        Fixed
    }
    public CameraMode mode;

    public Transform target;
    public float smoothSpeed = 5f;
    public Vector3 fixedPosition;

    void LateUpdate() // Change the mode of the camera
    {
        if (mode == CameraMode.Follow)
        {
            FollowTarget();
        }
        else if (mode == CameraMode.Fixed)
        {
            FixedCamera();
        }
    }

    void FollowTarget() // Open camera
    {
        if (!target) return;

        Vector3 desiredPosition = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp( // Smooth movement of the camera
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }

    void FixedCamera() // Static camera for bossfights
    {
        transform.position = fixedPosition;
    }

}
