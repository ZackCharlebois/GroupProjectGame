using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadScene(string sceneName)
    {
        Debug.Log("Loading Scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "MainMenuScene") 
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            LoadScene("MainMenuScene");
        }
    }
}
