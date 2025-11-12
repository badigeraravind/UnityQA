using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModePlayerScore
{
    public class ScoreOnCollision : MonoBehaviour
    {
        public int scoreAmt = 1;

        void OnCollisionEnter2D(Collision2D _)
        {
            ScoreManager.AddScore(scoreAmt);
        }
        void OnTriggerEnter2D(Collider2D _)
        {
            ScoreManager.AddScore(scoreAmt);
        }
    }

    [UnityTest]
    public IEnumerator PlayerScoreIncrementOnCollision()
    {
        ScoreManager.ResetScore();
        Assert.AreEqual(0, ScoreManager.Score, "Score must start at 0 for test.");

        var player = new GameObject("Player");
        player.transform.position = Vector3.zero;
        var playerCollider = player.AddComponent<CircleCollider2D>();
        var playerRb = player.AddComponent<Rigidbody2D>();
        playerRb.bodyType = RigidbodyType2D.Dynamic;

        var ground = new GameObject("Ground");
        ground.transform.position = new Vector3(0f, 0f, 0f);
        var groundCollider = ground.AddComponent<BoxCollider2D>();
        groundCollider.size = new Vector2(5f, 1f);
        var groundRb = ground.AddComponent<Rigidbody2D>();
        groundRb.bodyType = RigidbodyType2D.Static;
        var scoreOnCollision = ground.AddComponent<ScoreOnCollision>();
        scoreOnCollision.scoreAmt = 1;

        int framesToWait = 60;
        for (int i = 0; i < framesToWait; i++)
            yield return new WaitForFixedUpdate();

        Debug.Log("Player Score: " + ScoreManager.Score);
        Assert.AreEqual(1, ScoreManager.Score, "Score should increment by 11 when player collides with ground.");

        Object.Destroy(player);
        Object.Destroy(ground);
    }
}
