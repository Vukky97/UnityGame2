using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = new Vector3(player.position.x, player.position.y, cameraTransform.position.z);
    }
}
