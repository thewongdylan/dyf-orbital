using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsloCamera : MonoBehaviour
{
    [SerializeField] private Transform oslo;
    [SerializeField] private float xOffset = 0f;
    [SerializeField] private float yOffset = 1f;
    private bool followOslo = true;

    public void UpdateFollowOslo(bool state)
    {
        followOslo = state;
    }
    // Update is called once per frame
    private void Update()
    {
        if (followOslo)
        {
            transform.position = new Vector3(
                oslo.position.x + xOffset, 
                oslo.position.y + yOffset, 
                transform.position.z);
        }
    }

}