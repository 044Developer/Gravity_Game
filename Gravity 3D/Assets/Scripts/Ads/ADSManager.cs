using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSManager : MonoBehaviour
{
    public GameObject AdsPanel;

    [SerializeField] private GameEventSO _resumeGameEvent;
    [SerializeField] private GameEventSO _gameOverEvent;
    [SerializeField] private bool IsRewardReady;

    public void TestAds()
    {
        if (IsRewardReady)
        {
            _resumeGameEvent.Raise();
            CloseAdsPanel();
        }
        else
        {
            ApplyGameOver();
        }
    }

    public void ApplyGameOver()
    {
        _gameOverEvent.Raise();
        CloseAdsPanel();
    }

    public void OpenAdsPanel()
    {
        GameManager.Instance.GamePause();
        AdsPanel.SetActive(true);
    }

    public void CloseAdsPanel()
    {
        GameManager.Instance.ResumeGame();
        AdsPanel.SetActive(false);
    }
}
