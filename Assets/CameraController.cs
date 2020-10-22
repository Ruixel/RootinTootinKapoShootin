using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    float smoothSpeed = 0.125f;
    Vector3 offset = new Vector3(10, 10, 10);

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
