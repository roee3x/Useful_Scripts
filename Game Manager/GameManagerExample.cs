using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;
using UnityEngine.SceneManagement;

/// <summary>
/// Currently not destroying on load too much in Scene Dependencys
/// I will split Dependenciys and then make it global
/// </summary>
/// 

public enum GameState { NONE, Start, PlayerTurn, EnemyTurn, Win, Lost }

public class GameManager : MonoBehaviour
{
    #region Public/Private fields

    [Header(header: "instances")] public static GameManager instance;


    //you can add references to anything the gamemanager might use from here.
    [SerializeField] internal PlayerManager playerManager;
    [SerializeField] internal EnemyAI enemyAI;
    [Header("references")] internal GameplayManager _gameplayManager;
    internal ObjectsRefContainerInScene objRef;
    internal MainMenuManager _mainMenuManager;
    private BodyPartsHandler _bodyPartsHandler;
    private ShopManager _shopManager;
    private CSVreader _csvReader;
    internal BattleActions _battleActions;

    
    [Header("State Control")] public GameState gameState;
    public static event Action<GameState> onGameStateChange;

    [Header("Save&Load")] public GameData gameData; //if you have a saving system

    #endregion

    #region MonoBehaviour Routines
    private void Awake()
    {
        //register the instance, while checking there's no extras.
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }

    private void Start()
    {
        //Anything needed to run once when the game starts
    }

    private void Update()
    {
        //Do not use the update for anything bug inside checks. (if at all)

        if (gameState == GameState.Win)
            _timerCoroutine = null;
    }

    #endregion

    #region Helper Routines

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //Can use this to do stuff when a scene is loaded.
    }

    public void UpdateGameState(GameState newState)
    {
        //With this, we can use the states in events, instead of checking on update.
        gameState = newState;

        switch (newState)
        {
            case GameState.NONE:
                break;
            case GameState.Start:
                InitializeGameStart();
                break;
            case GameState.PlayerTurn:
                HandleTurns();
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.Win:
                break;
            case GameState.Lost:
                HandleLosingGame();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        onGameStateChange?.Invoke(newState);
    }


    #endregion
}
