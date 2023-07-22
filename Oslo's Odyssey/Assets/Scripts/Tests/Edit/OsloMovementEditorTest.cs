using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class OsloMovementEditorTest
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

    

    [Test]
    public void TestRunningAnimation()
    {
        var osloMovement = testObject.GetComponent<OsloMovement>();

        // Set up any required parameters
        osloMovement.rb = testObject.GetComponent<Rigidbody2D>();
        osloMovement.coll = testObject.GetComponent<BoxCollider2D>();
        osloMovement.anim = testObject.GetComponent<Animator>();

        // Set dirX to a positive value for running right animation
        osloMovement.SetDirX(1f);

        // Call UpdateAnimationState()
        osloMovement.UpdateAnimationState();

        // Assert that the animation state is set to "running" (1)
        Assert.AreEqual(1, osloMovement.anim.GetInteger("state"));
    }

    [Test]
    public void TestIdleAnimation()
    {
        var osloMovement = testObject.GetComponent<OsloMovement>();

        // Set up any required parameters
        osloMovement.rb = testObject.GetComponent<Rigidbody2D>();
        osloMovement.coll = testObject.GetComponent<BoxCollider2D>();
        osloMovement.anim = testObject.GetComponent<Animator>();

        // Set dirX to 0 for idle animation
        osloMovement.SetDirX(0f);

        // Call UpdateAnimationState()
        osloMovement.UpdateAnimationState();

        // Assert that the animation state is set to "idle" (0)
        Assert.AreEqual(0, osloMovement.anim.GetInteger("state"));
    }


    


}
