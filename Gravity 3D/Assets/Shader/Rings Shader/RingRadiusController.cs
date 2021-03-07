using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRadiusController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Material _material;
    private float _time;
    private float _radius = 0;
    private float _randomValue;

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        _radius = 0;
        _time = 0;
        _material = this.gameObject.GetComponent<MeshRenderer>().material;
        _material.SetFloat("_radius_A", _radius);

        _randomValue = Random.Range(0.01f, 0.04f);
        _material.SetFloat("_radius_B", _randomValue);
    }

    private void Update()
    {
        _time += Time.deltaTime * _speed;
        if (_time < 1)
        {
            _radius = Mathf.Lerp(0, 1, _time);
            _material.SetFloat("_radius_A", _radius);
        }

        if (_radius >= 0.35f)
        {
            //Destroy(this.gameObject);
            gameObject.SetActive(false);    
        }
    }
}
