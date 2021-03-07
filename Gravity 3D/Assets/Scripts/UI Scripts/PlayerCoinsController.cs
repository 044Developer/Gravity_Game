using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCoinsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private PlayerCurrancy _playerCurrancy;

    private void Start()
    {
        SetCoinsText();
        _playerCurrancy.Init(this);
    }

    public void SetCoinsText()
    {
        _coinsText.text = _playerCurrancy.Coins.ToString();
    }
}
