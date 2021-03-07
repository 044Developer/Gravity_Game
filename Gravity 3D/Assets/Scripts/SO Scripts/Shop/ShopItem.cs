using UnityEngine;

[CreateAssetMenu(menuName = "Shop/ShopItems")]
public class ShopItem : ScriptableObject
{
    public Sprite Image;
    public int Price;
    public int Id;
    public bool IsPurchased;
    public bool IsSelected = false;

    public void Save(string path)
    {
        ES3.Save(Id.ToString(), IsPurchased, path);
    }

    public void Load(string path)
    {
        IsPurchased = ES3.Load<bool>(Id.ToString(), path);
    }
}
