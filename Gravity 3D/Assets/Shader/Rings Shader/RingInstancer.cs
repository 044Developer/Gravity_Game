using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingInstancer : MonoBehaviour
{
    [SerializeField] private GameObject _ringInstance;
    [SerializeField] private float _time;
    [SerializeField] private List<GameObject> _rings;
    [SerializeField] private List<RingRadiusController> _controllers;

    private int _currentIndex = 0;
    
    private void Start()
    {
        StartCoroutine(SpawnRing(_time));
    }

    private void InstantiateRings()
    {
        _rings[_currentIndex].SetActive(true);
        //_controllers[_currentIndex].Init();
        if (_currentIndex != _rings.Count - 1)
        {
            _currentIndex++;
        }
        else
        {
            _currentIndex = 0;
        }
    }

    private IEnumerator SpawnRing(float time)
    {
        InstantiateRings();
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnRing(_time));
    }
}
