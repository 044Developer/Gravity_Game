using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Currancy")]
public class PlayerCurrancy : ScriptableObject
{
    private const string CoinsKey = "PlayerCoins";
    public int Coins;

    private PlayerCoinsController _controler;

    private void OnEnable()
    {
        Coins = 2000;
    }

    public void Init(PlayerCoinsController controller)
    {
        _controler = controller;
    }

    public void AddCoins(int value)
    {
        Coins += value;
    }

    public void SpendCoins(int value)
    {
        Coins -= value;
        _controler.SetCoinsText();
    }

    public bool HasEnoughtCoins(int value)
    {
        return (Coins >= value);
    }

    public void Save(string path)
    {
        ES3.Save(CoinsKey, Coins, path);
    }

    public void Load(string path)
    {
        Coins = ES3.Load<int>(CoinsKey, path);
    }
}
