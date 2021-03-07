using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    [Header("Score Interactable")]
    [SerializeField] private List<GameObject> _scoreInteractablePrefabs;

    [Header("Rotation Swap Interactable")]
    [SerializeField] private List<GameObject> _rotatorInteractablePrefabs;

    [Header("Coin Interactable")]
    [SerializeField] private GameObject _coinInteractablePrefab;

    [Header("Spikes")]
    [SerializeField] private List<GameObject> _spikes;

    [Header("Time Settings")]
    [SerializeField] private LevelTimeSettings _spawnTimeSettings;

    private int _currentScoreIndex;
    private int _currentRotatorIndex;

    public void TurnOnScoreObject()
    {
        _currentScoreIndex = SetRandomCurrentIndex(_scoreInteractablePrefabs.Count);
        Debug.Log(_currentScoreIndex);
        StartCoroutine(DelayScoreSpawn());
    }

    public void TurnOnRotatorObject()
    {
        StartCoroutine(DelayRotator(SetRandomSpawnTime(_spawnTimeSettings.MinRotatorSpawn, _spawnTimeSettings.MaxRotatorSpawn)));
    }

    public void TurnOnCoinObject()
    {
        _coinInteractablePrefab.SetActive(true);
    }

    public void StartGameCoroutine()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(StartInteractableCoroutine(_spawnTimeSettings.StartingSpawnValue)); 
        }
    }

    public void StopGameCoroutine()
    {
        PrepareForNextLevel();
    }

    private void PrepareForNextLevel()
    {
        _scoreInteractablePrefabs[_currentScoreIndex].SetActive(false);
        _rotatorInteractablePrefabs[_currentRotatorIndex].SetActive(false);
        _coinInteractablePrefab.SetActive(false);
        foreach (var spike in _spikes)
        {
            spike.SetActive(false);
        }
    }

    private IEnumerator DelayScoreSpawn()
    {
        yield return new WaitForSeconds(_spawnTimeSettings.ScoreSpawnTime);
        _scoreInteractablePrefabs[_currentScoreIndex].SetActive(true);
    }

    private IEnumerator DelayRotator(float time)
    {
        yield return new WaitForSeconds(time);
        _currentRotatorIndex = SetRandomCurrentIndex(_rotatorInteractablePrefabs.Count);
        _rotatorInteractablePrefabs[_currentRotatorIndex].SetActive(true);
    }

    private IEnumerator StartInteractableCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        TurnOnScoreObject();
        TurnOnRotatorObject();
        TurnOnSpikes();
    }

    private void TurnOnSpikes()
    {
        foreach (var spike in _spikes)
        {
            spike.SetActive(true);
        }
    }

    private float SetRandomSpawnTime(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }

    private int SetRandomCurrentIndex(int maxValueCount)
    {
        return Random.Range(0, maxValueCount);
    }
}
