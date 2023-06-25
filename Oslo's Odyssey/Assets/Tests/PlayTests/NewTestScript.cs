using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        GameObject gameObject = new GameObject();
        OsloMovement osloMovement = gameObject.AddComponent<OsloMovement>();
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        osloMovement.SetMoveSpeed(7f); // Use the setter method to set the move speed

        // Act
        yield return new WaitForFixedUpdate();
        osloMovement.Update();
        osloMovement.SetDirX(1f); // Simulate right input using the setter method
        yield return new WaitForFixedUpdate();
        osloMovement.Update();

        // Assert
        Vector2 expectedVelocity = new Vector2(osloMovement.GetMoveSpeed(), rb.velocity.y); // Use the getter method
        Vector2 actualVelocity = osloMovement.GetRigidbodyVelocity();
        Assert.AreEqual(expectedVelocity, actualVelocity);
    }
}
