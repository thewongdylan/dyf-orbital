using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform oslo;
    [SerializeField] private float xOffset = 0f;
    [SerializeField] private float yOffset = 1f;


    // Update is called once per frame
    private void Update()
    {
        //transform here refers to the assigned oslo's transform values, accessing directly
        transform.position = new Vector3(
            oslo.position.x + xOffset, 
            oslo.position.y + yOffset, 
            transform.position.z);
    }
}
