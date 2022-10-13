using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform CameraTransform;
    private Vector3 lastCameraTransform;
    [SerializeField] float parallaxEffectMultiplier = 0.05f;



    private void Start()
    {
        CameraTransform = Camera.main.transform;
        lastCameraTransform = CameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = CameraTransform.position - lastCameraTransform ;

        transform.position += deltaMovement * parallaxEffectMultiplier *-1;
        lastCameraTransform = CameraTransform.position;
    }



}
