using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject oslo;
    [SerializeField] private Transform osloEndpoint;
    [SerializeField] private float osloSpeed = 10f;
    private Animator anim;

    public void Start()
    {
        anim = oslo.GetComponent<Animator>();
    }


    public void StartButtonPress()
    {
        StartCoroutine(OsloAnimation());
    }

    public IEnumerator OsloAnimation()
    {
        while (oslo.transform.position != osloEndpoint.position)
        {
            oslo.transform.position = Vector3.MoveTowards(
                oslo.transform.position, 
                osloEndpoint.position, 
                osloSpeed * Time.deltaTime);
            yield return 0;
            anim.SetInteger("state", 1); // running animation
        }
    }
}
