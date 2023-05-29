using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 3f;
    private bool inMotion = true;
    // [SerializeField] private bool toFlip = true;
    private float dirX;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    } 

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (inMotion)
        {
            // if (toFlip)
            // {
            //     if (dirX > 0f)
            //     {
            //         transform.eulerAngles = new Vector3(0, 0, 0);
            //     }
            //     else if (dirX < 0f)
            //     {
            //         transform.eulerAngles = new Vector3(0, 180, 0);
            //     }
            // }

            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
            // check if distance between current waypoint (heading towards) and current position < 0.1f (basically touching)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, 
                    waypoints[currentWaypointIndex].transform.position, 
                    Time.deltaTime * speed); // moves same number of game units per second regardless of framerate
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
        
    }

    public void SetMotion(bool motion)
    {
        inMotion = motion;
    }
}
