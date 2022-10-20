using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform CameraTransform;
    private Vector3 lastCameraTransform;
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private float textureSizeX;



    private void Start()
    {
        CameraTransform = Camera.main.transform;
        lastCameraTransform = CameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureSizeX = texture.width / sprite.pixelsPerUnit;

    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = CameraTransform.position - lastCameraTransform ;

        transform.position += new Vector3(deltaMovement.x*parallaxEffectMultiplier.x,deltaMovement.y*parallaxEffectMultiplier.y);
        lastCameraTransform = CameraTransform.position;


        if (Mathf.Abs(CameraTransform.position.x - transform.position.x) >= textureSizeX)
        {
            float offsetPositionX = (CameraTransform.position.x - transform.position.x) % textureSizeX;
           
            transform.position = new Vector3(CameraTransform.position.x+offsetPositionX, transform.position.y);
        }
    }



}
