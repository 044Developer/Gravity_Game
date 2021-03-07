using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string Spikes = "Spike";

    [HideInInspector] public float MinGravity;
    [HideInInspector] public float MaxGravity;

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerTimeSettings _playerTimeSettings;
    [SerializeField] private GameEventSO _playerDiedEvent;
    private Rigidbody _rigidbody;
    private Vector3 _playerTransform;
    private bool _gravitySwitch;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = transform.position;
        _playerStats.Init(this);
    }

    private void Update()
    {
        MobileInput();
        UnityTestInput();

        FixForwardTransform();
        _rigidbody.WakeUp();
    }


    public void SwitchToGameMode()
    {
        SwitchGravityOff();
        transform.DOScale(_playerStats.PlayerGameScale, _playerTimeSettings.TimeBtwStates);
    }
    public void SwitchToMenuMode()
    {
        SwitchGravityOff();
        transform.DOScale(_playerStats.PlayerMenuScale, _playerTimeSettings.TimeBtwStates);
    }

    public void SwitchGravityOff()
    {
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        transform.position = Vector3.zero;
    }
    public void CallStartGame()
    {
        StartCoroutine(TurnOnGravity());
    }

    public void CallEndGame()
    {
        StopAllCoroutines();
        SwitchGravityOff();
    }

    private void FixForwardTransform()
    {
        _playerTransform = transform.position;
        _playerTransform.z = 0f;
        transform.position = _playerTransform;
    }

    private void ChangeGravity()
    {
        _gravitySwitch = !_gravitySwitch;

        if (_gravitySwitch)
        {
            Physics.gravity = new Vector3(0, MaxGravity, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, MinGravity, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Spikes))
        {
            _playerDiedEvent.Raise();
        }
    }

    private IEnumerator TurnOnGravity()
    {
        yield return new WaitForSeconds(_playerTimeSettings.TimeBtwStates);
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
    }
    private void UnityTestInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChangeGravity();
        }
    }

    private void MobileInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                ChangeGravity();
            }
        }
    }
}
