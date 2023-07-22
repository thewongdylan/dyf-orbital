using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

public class OsloMovementPlayModeTest
{
    

    private GameObject testObjectPrefab;
    private GameObject testObject;

    [SetUp]
    public void SetUp()
    {
        // Load the "Oslo" prefab directly from the Editor folder (replace "OsloPrefabPath" with the actual path to the prefab)
        testObjectPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Oslo.prefab");

        // Instantiate the "Oslo" prefab for each test
        testObject = GameObject.Instantiate(testObjectPrefab);
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up the instantiated prefab after each test
        GameObject.DestroyImmediate(testObject);
    }

    

    
    

    // check whether it moves up
    [UnityTest]
    public IEnumerator TestJump()
    {
        var osloMovement = testObject.GetComponent<OsloMovement>();

        // Set up any required parameters
        //osloMovement.rb = testObject.GetComponent<Rigidbody2D>();
        //osloMovement.coll = testObject.GetComponent<BoxCollider2D>();
        //osloMovement.anim = testObject.GetComponent<Animator>();
        //osloMovement.jumpForce = 15f;

        // Simulate jump by pressing the spacebar
        Input.GetKeyDown(KeyCode.Space);
        var originalPosition = testObject.transform.position.y;

        yield return new WaitForFixedUpdate();

        Assert.AreNotEqual(originalPosition, testObject.transform.position.y);


    }

    
}
