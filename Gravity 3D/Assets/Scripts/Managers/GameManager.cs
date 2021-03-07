using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    public bool IsGameOn;

    [Header("Managers")]
    [SerializeField] private SaveManager _saveManager;
    [SerializeField] private LevelManager _levelManager;

    [SerializeField] private float _timeBtwStates;
    [SerializeField] private GameEventSO _gamePause;

    private static GameManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public void StartGame()
    {
        _levelManager.StartGame(_timeBtwStates);
    }

    public void StartNextLevel()
    {
        _levelManager.NextLevel(_timeBtwStates);
    }

    public void GameOver()
    {
        _levelManager.GameOver(_timeBtwStates);
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
