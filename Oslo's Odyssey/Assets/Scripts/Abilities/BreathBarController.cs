using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathBarController : MonoBehaviour
{
    public GameObject breathBar;
    [SerializeField] private Transform breathBarPos;
    private bool isBreathBarSpawned;
    private GameObject spawnedBreathBar;
    public bool isDrowning;
    

    // Start is called before the first frame update
    void Start()
    {
        isBreathBarSpawned = false;
        isDrowning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (WaterTile.inWater)
        {
            if (!isBreathBarSpawned)
            {
                spawnedBreathBar = Instantiate(breathBar, breathBarPos.position, Quaternion.identity);
                spawnedBreathBar.gameObject.transform.SetParent(transform);
                isBreathBarSpawned = true;
                Debug.Log("spawned breath bar");
            }
            isDrowning = true;
        }
        else
        {
            // if (breathBar.GetComponent<BreathBar>().isBarFull)
            // {
            //     Invoke("DestroyBreathBar", 1f);
            // }
            isDrowning = false;
        }
    }

    private void DestroyBreathBar()
    {
        Destroy(spawnedBreathBar);
    }
}
