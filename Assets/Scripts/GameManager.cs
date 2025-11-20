using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Game Manager Destroyed");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeGameManager();
    }

    private void InitializeGameManager()
    {

    }

    private void Start()
    {
        AudioManager.Instance.PlayMusicClip(AudioManager.Instance.musicClip);
    }
}
