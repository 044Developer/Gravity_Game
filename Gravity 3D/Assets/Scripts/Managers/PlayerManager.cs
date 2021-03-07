using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private const string PlayerIndex = "PlayerModelIndex";
    [HideInInspector] public int CurrentPlayerIndex;

    [Header("Player Models")]
    [SerializeField] private List<GameObject> _playerModels;

    private int _previousPlayerIndex;

    private void Start()
    {
        LoadPlayer();
    }

    public void ChangePlayerSkin()
    {
        _playerModels[_previousPlayerIndex].SetActive(false);
        _playerModels[CurrentPlayerIndex].SetActive(true);
    }

    public void ChangeIndex()
    {
        _previousPlayerIndex = CurrentPlayerIndex;
    }

    public void Save(string path)
    {
        ES3.Save(PlayerIndex, CurrentPlayerIndex, path);
    }

    public void Load(string path)
    {
        CurrentPlayerIndex = ES3.Load<int>(PlayerIndex, path);
    }

    private void LoadPlayer()
    {
        _playerModels[CurrentPlayerIndex].SetActive(true);
    }
}
