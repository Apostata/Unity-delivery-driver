using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow; // car object
    // camera position will be the same as car's position

    void LateUpdate() // LateUpdate is called after Update each frame and it is used to adjust the camera's position after the car's position has been updated
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
