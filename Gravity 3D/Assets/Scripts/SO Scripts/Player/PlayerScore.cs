using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Score")]
public class PlayerScore : ScriptableObject
{
    private const string BestScoreKey = "BestScore";

    public int BestScore;

    public void Initialize(GameScoreController controller)
    {
        controller.BestScore = BestScore;
    }

    public void CheckForBestScore(int currentScore)
    {
        if (currentScore > BestScore)
        {
            BestScore = currentScore;
        }
    }

    public void Save(string path)
    {
        ES3.Save(BestScoreKey, BestScore, path);
    }

    public void Load(string path)
    {
        BestScore = ES3.Load<int>(BestScoreKey, path);
    }

    private void OnEnable()
    {
        BestScore = 0;
    }
}
