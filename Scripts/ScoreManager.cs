using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score { get; private set; }

    public static void ResetScore()
    {
        Score = 0;
    }
    public static void AddScore(int amount)
    {
        Score += amount;
    }
    private static void OnRuntimeMethodLoad()
    {
        // Reset on domain reload / playmode start so tests are deterministic.
        Score = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
