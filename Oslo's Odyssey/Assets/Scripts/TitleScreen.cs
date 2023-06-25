// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class TitleScreen : MonoBehaviour
// {
//     [SerializeField] private Camera mainCamera;
//     [SerializeField] private Image titleCard;
//     [SerializeField] private GameObject oslo;
//     [SerializeField] private float speed = 3f;
//     [SerializeField] private GameObject endpoint;

//     public void TitleScreenAnimation()
//     {   
//         Debug.Log("button pressed");
//         // InvokeRepeating("MoveTitleCard", 1f, 0.1f);
//         // InvokeRepeating("MoveCamera", 1f, 0.1f);
//         // InvokeRepeating("MoveOslo", 0f, 0.1f);
//         MoveOslo();
//         // Update();
//     }


//     private void MoveCamera()
//     {
//         Debug.Log("camera starts moving");
//         Vector3 cameraPos = mainCamera.transform.position; 
//         cameraPos = Vector3.MoveTowards(
//             cameraPos, 
//             endpoint.transform.position, 
//             Time.deltaTime * speed
//         );
//         Debug.Log("camera stops moving");
//     }

//     private void MoveTitleCard()
//     {
//         Debug.Log("titleCard starts moving");
//         Vector3 titleCardPos = titleCard.GetComponent<RectTransform>().position; 
//         titleCardPos = Vector3.MoveTowards(
//             titleCardPos, 
//             endpoint.transform.position, 
//             Time.deltaTime * speed
//         );
//         // titleCardPos.x--;
//         Debug.Log("titleCard stops moving");
//     }

//     private void MoveOslo()
//     {
//         // oslo.transform.position = Vector2.MoveTowards(
//         //     oslo.transform.position,
//         //     endpoint.transform.position,
//         //     Time.deltaTime * speed
//         // );
//         oslo.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
//         Debug.Log("oslo should be moving");
//     }
// }
