using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    private const string NoCoinsAnim = "noCoins";

    [SerializeField] private List<ShopItem> _itemsList;
    [SerializeField] private List<GameObject> _itemViews;
    [SerializeField] private Transform _shopScrollView;
    [SerializeField] private PlayerCurrancy _playerCoins;
    [SerializeField] private Animator _noCoinsAnim;

    [Header("Player Model Manager")]
    [SerializeField] private PlayerManager _playerManager;

    [Header("Events")]
    [SerializeField] private GameEventSO _changePlayerSkinEvent;

    private Button _buyButton;
    private Button _selectButton;

    private void Start()
    {
        for (int i = 0; i < _itemsList.Count; i++)
        {
            _itemViews[i].transform.GetChild(0).GetComponent<Image>().sprite = _itemsList[i].Image;
            _itemViews[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _itemsList[i].Price.ToString();
            _buyButton = _itemViews[i].transform.GetChild(3).GetComponent<Button>();
            _buyButton.interactable = !_itemsList[i].IsPurchased;
            _buyButton.AddEventListener(i, OnShopItemBtnClicked);
            CheckIfPurchased(i);
            _selectButton = _itemViews[i].transform.GetChild(4).GetComponent<Button>();
            _selectButton.interactable = _itemsList[i].IsPurchased;
            _selectButton.AddEventListener(i, OnSelectBtnClicked);
            CheckIfSelected(i);
        }
        OnSelectBtnClicked(_playerManager.CurrentPlayerIndex);
    }

    private void OnShopItemBtnClicked(int index)
    {
        if (_playerCoins.HasEnoughtCoins(_itemsList[index].Price))
        {
            _playerCoins.SpendCoins(_itemsList[index].Price);
            _itemsList[index].IsPurchased = true;
            CheckIfPurchased(index);
            _selectButton = _shopScrollView.GetChild(index).GetChild(4).GetComponent<Button>();
            _selectButton.interactable = true;
        }
        else
        {
            _noCoinsAnim.SetTrigger(NoCoinsAnim);
        }
    }

    private void CheckIfPurchased(int index)
    {
        if (_itemsList[index].IsPurchased)
        {
            _buyButton = _shopScrollView.GetChild(index).GetChild(3).GetComponent<Button>();
            _buyButton.interactable = false;
            _buyButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "PURCHASED";
        }
    }
    
    private void CheckIfSelected(int index)
    {
        if (_itemsList[index].IsSelected)
        {
            _selectButton = _shopScrollView.GetChild(index).GetChild(4).GetComponent<Button>();
            _selectButton.interactable = false;
            _selectButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "SELECTED";
        }
    }

    private void OnSelectBtnClicked(int index)
    {
        DeselectButtons();
        _itemsList[index].IsSelected = true;
        CheckIfSelected(index);
        SelectModel(index);
    }

    private void DeselectButtons()
    {
        for (int i = 0; i < _itemsList.Count; i++)
        {
            if (_itemsList[i].IsPurchased)
            {
                _selectButton = _itemViews[i].transform.GetChild(4).GetComponent<Button>();
                _selectButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "SELECT";
                _selectButton.interactable = true;
                _itemsList[i].IsSelected = false;
            }
        }
    }

    private void SelectModel(int index)
    {
        _playerManager.ChangeIndex();
        _playerManager.CurrentPlayerIndex = index;
        _changePlayerSkinEvent.Raise();
    }
}
