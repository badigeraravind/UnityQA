using UnityEngine;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;

public class PlayModePlayerMovement
{
    [UnityTest]

    public IEnumerator PlayerMovementTest()
    {
        // Arrange
        var playerGameObject = new GameObject();
        var playerScript = playerGameObject.AddComponent<PlayerScript>();
        float initialXPosition = playerGameObject.transform.position.x;
        float moveAmount = 5.0f; // Simulate full right movement
        float deltaTime = 0.7f; // Simulate a frame time
        // Act
        playerScript.ApplyMovement(moveAmount, deltaTime);
        yield return null; // Wait for a frame
        // Assert
        float expectedXPosition = initialXPosition + (moveAmount * playerScript.speed * deltaTime);
        Debug.Log("Player's X Position After Movement: " + expectedXPosition);
        Assert.AreEqual(expectedXPosition, playerGameObject.transform.position.x, 0.0001f);
        // Clean up
        Object.Destroy(playerGameObject);
    }

}
