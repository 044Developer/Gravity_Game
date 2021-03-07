using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private const string CurrentIndex = "CurrentIndex";
    public int CurrentLevelIndex { get; private set; }

    [SerializeField] private List<GameObject> RingLevel;
    [SerializeField] private List<RingBehaviourController> RingController;

    [Header("Game Events")]
    [SerializeField] private GameEventSO _startGameEvent;
    [SerializeField] private GameEventSO _spawnInteractableEvent;
    [SerializeField] private GameEventSO _turnGravityOnEvent;
    [SerializeField] private GameEventSO _turnGravityOffEvent;


    private int _previousIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        InitializeLevels();
    }

    public void StartGame(float time)
    {
        StartCoroutine(LoadStartGame(time));
    }

    public void NextLevel(float time)
    {
        StartCoroutine(LoadNextLevel(time));
    }

    public void GameOver(float time)
    {
        StartCoroutine(LoadGameOver(time));
    }

    public void Save(string path)
    {
        ES3.Save(CurrentIndex, CurrentLevelIndex, path);
    }
    public void Load(string path)
    {
        if (ES3.KeyExists("CurrentLevelIndex", path))
        {
            CurrentLevelIndex = ES3.Load<int>(CurrentIndex);
        }
        else
        {
            CurrentLevelIndex = 0;
        }
    }

    private IEnumerator LoadStartGame(float time)
    {
        RingController[CurrentLevelIndex].SetNewState(GameState.Loading);
        _startGameEvent.Raise();
        yield return new WaitForSeconds(time);
        _spawnInteractableEvent.Raise();
        _turnGravityOnEvent.Raise();
    }

    private IEnumerator LoadGameOver(float time)
    {
        _turnGravityOffEvent.Raise();
        RingController[CurrentLevelIndex].SetNewState(GameState.GameOver);
        yield return new WaitForSeconds(time);
        RingLevel[CurrentLevelIndex].SetActive(false);
        SetRandomCurrentIndex();
        RingLevel[CurrentLevelIndex].SetActive(true);
        RingController[CurrentLevelIndex].SetNewState(GameState.Menu);
    }

    private IEnumerator LoadNextLevel(float time)
    {
        _turnGravityOffEvent.Raise();
        RingController[CurrentLevelIndex].SetNewState(GameState.GameOver);
        yield return new WaitForSeconds(time);
        RingController[CurrentLevelIndex].SetNewState(GameState.NextLevel);
        yield return new WaitForSeconds(time);
        RingLevel[CurrentLevelIndex].SetActive(false);
        SetRandomCurrentIndex();
        RingLevel[CurrentLevelIndex].SetActive(true);
        yield return new WaitForSeconds(time);
        RingController[CurrentLevelIndex].SetNewState(GameState.Loading);
        yield return new WaitForSeconds(time);
        _spawnInteractableEvent.Raise();
        _turnGravityOnEvent.Raise();
    }

    private void InitializeLevels()
    {
        RingLevel[CurrentLevelIndex].SetActive(true);
    }

    private void SetRandomCurrentIndex()
    {
        _previousIndex = CurrentLevelIndex;
        CurrentLevelIndex = Random.Range(0, RingLevel.Count);
        CheckRandomNumber();
    }

    private void CheckRandomNumber()
    {
        if (CurrentLevelIndex == _previousIndex)
        {
            SetRandomCurrentIndex();
        }
    }
}
