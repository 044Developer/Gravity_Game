using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu,
    Loading,
    Game,
    NextLevel,
    GameOver
}

public class RingRotationController : MonoBehaviour
{
    private const int SwapRotationValue = -1;

    public GameState CurrentState;

    [HideInInspector] public float GameRotationSpeed;
    [HideInInspector] public float SpeedIncreaseMultiplier;
    [HideInInspector] public float SpeedDecreaseMultiplier;

    [SerializeField] private LevelTimeSettings _levelTimeSettings;
    [SerializeField] private RotationFloatValue _rotationFloatValue;
    [SerializeField] private RotationSystem _rotationSystem;

    private void Awake()
    {
        _rotationFloatValue.Initialize(this);
    }

    private void Start()
    {
        CurrentState = GameState.Menu;
    }

    private void Update()
    {
        CheckGameState(CurrentState);
    }

    public void ApplySwapRotation()
    {
        GameRotationSpeed *= SwapRotationValue;
    }

    public void IncreaseRotationSpeed()
    {
        GameRotationSpeed *= SpeedIncreaseMultiplier;
    }

    public void DecreaseRotationSpeed()
    {
        GameRotationSpeed /= SpeedDecreaseMultiplier;
    }

    private void CheckGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Menu:
                _rotationSystem.MenuRotation(transform, _rotationFloatValue.MenuRotationSpeed);
                break;
            case GameState.Loading:
                StartCoroutine(LoadingState(_levelTimeSettings.TimeBtwStates));
                break;
            case GameState.Game:
                _rotationSystem.GameRotation(transform, GameRotationSpeed);
                break;
            case GameState.NextLevel:
                _rotationSystem.NextLevelRotation(transform, _rotationFloatValue.FastRotationSpeed);
                break;
            case GameState.GameOver:
                StartCoroutine(GameOverState(_levelTimeSettings.TimeBtwStates));
                break;
            default:
                break;
        }
    }

    private IEnumerator LoadingState(float time)
    {
        _rotationSystem.StartGameRotation(transform, time);
        yield return new WaitForSeconds(time);
        CurrentState = GameState.Game;
        GameManager.Instance.IsGameOn = true;
    }

    private IEnumerator GameOverState(float time)
    {
        GameManager.Instance.IsGameOn = false;
        _rotationSystem.GameOverRotation(transform, time);
        yield return new WaitForSeconds(time);
    }
}
