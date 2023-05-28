using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform oslo;

    // Update is called once per frame
    private void Update()
    {
        //transform here refers to the assigned oslo's transform values, accessing directly
        transform.position = new Vector3(oslo.position.x, oslo.position.y, transform.position.z);
    }
}
