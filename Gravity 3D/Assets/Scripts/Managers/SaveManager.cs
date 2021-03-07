using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string PlayerModelPath = "PlayerModel.es3";
    private const string SoundSettingsPath = "SoundSettings.es3";
    private const string LevelIdPath = "LevelId.es3";
    private const string PlayerCurrancyPath = "PlayerCurrancy.es3";
    private const string PlayerScorePath = "PlayerScore.es3";
    private const string ShopDataPath = "ShopData.es3";

    [Header("Managers")]
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private PlayerManager _playerManager;

    [Header("Player Data")]
    [SerializeField] private PlayerCurrancy _playerCurrancy;
    [SerializeField] private PlayerScore _playerScore;

    [Header("Shop Data")]
    [SerializeField] private List<ShopItem> _shopItems;

    private void OnEnable()
    {
        CheckPathAndLoad();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveData()
    {
        _soundManager.Save(SoundSettingsPath);
        _playerManager.Save(PlayerModelPath);
        _levelManager.Save(LevelIdPath);
        _playerCurrancy.Save(PlayerCurrancyPath);
        _playerScore.Save(PlayerScorePath);

        foreach (var shopItem in _shopItems)
        {
            shopItem.Save(ShopDataPath);
        }
    }

    private void CheckPathAndLoad()
    {
        if (!ES3.FileExists(SoundSettingsPath))
        {
            var newFile = new ES3File(SoundSettingsPath);
        }
        else
        {
            _soundManager.Load(SoundSettingsPath);
        }

        if (!ES3.FileExists(PlayerModelPath))
        {
            var newFile = new ES3File(PlayerModelPath);
        }
        else
        {
            _playerManager.Load(PlayerModelPath);
        }

        if (!ES3.FileExists(LevelIdPath))
        {
            var newFile = new ES3File(LevelIdPath);
        }
        else
        {
            _levelManager.Load(LevelIdPath);
        }

        if (!ES3.FileExists(PlayerCurrancyPath))
        {
            var newFile = new ES3File(PlayerCurrancyPath);
        }
        else
        {
            _playerCurrancy.Load(PlayerCurrancyPath);
        }
        
        if (!ES3.FileExists(PlayerScorePath))
        {
            var newFile = new ES3File(PlayerScorePath);
        }
        else
        {
            _playerScore.Load(PlayerScorePath);
        }

        if (!ES3.FileExists(ShopDataPath))
        {
            var newFile = new ES3File(ShopDataPath);
        }
        else
        {
            foreach (var shopItem in _shopItems)
            {
                shopItem.Load(ShopDataPath);
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData();
        }
    }

    private void OnDisable()
    {
        SaveData();
    }
}
