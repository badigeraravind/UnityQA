using NUnit.Framework;
using UnityEngine;

public class EditModeScoreTest
{

    [SetUp]
    public void Setup()
    {
        ScoreManager.ResetScore();
    }

    [Test]
    public void ResetScoreCheck()
    {
        ScoreManager.AddScore(10);
        Assert.AreEqual(10, ScoreManager.Score);
        Debug.Log("Score before reset: " + ScoreManager.Score);

        ScoreManager.ResetScore();
        Assert.AreEqual(0, ScoreManager.Score);
        Debug.Log("Score after reset: " + ScoreManager.Score);
    }

    [Test]
    public void AddScoreCheck()
    {
        ScoreManager.AddScore(5);
        Assert.AreEqual(5, ScoreManager.Score);
        Debug.Log("Score after adding 5: " + ScoreManager.Score);
        ScoreManager.AddScore(15);
        Assert.AreEqual(20, ScoreManager.Score);
        Debug.Log("Score after adding 15: " + ScoreManager.Score);
    }
}
