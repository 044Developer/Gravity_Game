using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string MusicSettings = "MusicSettings";
    private const string SoundSettings = "SoundSettings";


    [HideInInspector] public bool IsSoundOn;
    [HideInInspector] public bool IsMusicOn;

    public void Save(string path)
    {
        ES3.Save(MusicSettings, IsMusicOn, path);
        ES3.Save(SoundSettings, IsSoundOn, path);
    }

    public void Load(string path)
    {
        IsSoundOn = ES3.Load<bool>(SoundSettings, path);
        IsMusicOn = ES3.Load<bool>(MusicSettings, path);
    }
}
