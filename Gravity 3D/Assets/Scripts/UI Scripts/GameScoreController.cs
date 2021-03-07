using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreController : MonoBehaviour
{
    private const int TriggerNextCoinSpawn = 10;
    private const int TriggerNextLevelSpawn = 20;

    [HideInInspector] public int BestScore;
    [HideInInspector] public int CurrentScore;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private PlayerScore _playerScore;

    [SerializeField] private GameEventSO _spawnCoinEvent;
    [SerializeField] private GameEventSO _nextLevelEvent;

    private void Start()
    {
        _playerScore.Initialize(this);
        SetBestScore();
    }

    public void AddScore()
    {
        CurrentScore++;
        SetCurrentScore();
        SetBestScore();
        TriggerCoinSpawn(); 
        TriggerNextLevelLoading();
    }

    private void SetBestScore()
    {
        _playerScore.CheckForBestScore(CurrentScore);
        _bestScoreText.text = $"BEST: {BestScore.ToString()}";
    }

    private void SetCurrentScore()
    {
        _currentScoreText.text = CurrentScore.ToString();
    }

    private void TriggerCoinSpawn()
    {
        if (CurrentScore % TriggerNextCoinSpawn == 0)
        {
            _spawnCoinEvent.Raise();
        }
    }

    private void TriggerNextLevelLoading()
    {
        if (CurrentScore % TriggerNextLevelSpawn == 0)
        {
            _nextLevelEvent.Raise();
        }
    }
}
