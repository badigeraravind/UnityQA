using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModePlayerCollision
{
    public class CollisionFlag : MonoBehaviour
    {
        public bool collided;
        void OnCollisionEnter2D(Collision2D _) => collided = true;
        void OnTriggerEnter2D(Collider2D _) => collided = true;
    }

    [UnityTest]
    public IEnumerator PlayerCollidesWithGroundOrEnemy()
    {
        var player = new GameObject("Player");
        var rb = player.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        var playerCollider = player.AddComponent<CircleCollider2D>();
        player.transform.position = new Vector3(0f, 1f, 0f);

        var ground = new GameObject("Ground");
        var groundRb = ground.AddComponent<Rigidbody2D>();
        groundRb.bodyType = RigidbodyType2D.Static;
        var groundCollider = ground.AddComponent<BoxCollider2D>();
        groundCollider.size = new Vector2(5f, 1f); // make ground wide
        ground.transform.position = new Vector3(0f, 0f, 0f);
        var collisionFlag = ground.AddComponent<CollisionFlag>();

        
        int framesToWait = 60; 
        for (int i = 0; i < framesToWait; i++)
            yield return new WaitForFixedUpdate();

        Debug.Log("Player collided? " + collisionFlag.collided);
        Assert.IsTrue(collisionFlag.collided, "Player should have collided with the ground.");

        // Cleanup
        Object.Destroy(player);
        Object.Destroy(ground);
    }
}
