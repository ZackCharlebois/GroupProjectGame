using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public int keysCollected;

    // Start is called before the first frame update
    void Start()
    {
        keysCollected = 0;
        UIManager.Instance.UpdateKeyCount(keysCollected);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightBracket) ) 
        { 
            keysCollected = 3;
            ExitLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerDies();
        }
        if (other.CompareTag("Key"))
        {
            CollectKey(other);
        }
        if (other.CompareTag("Exit"))
        {
            ExitLevel();
        }
    }

    private void PlayerDies()
    {
        Debug.Log("Player has died");
        //UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene("DeathScene");
        GameManager.Instance.LoadScene("DeathScene");
    }

    private void CollectKey(Collider other)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxSource);
        GameObject key = other.transform.parent.gameObject;
        keysCollected++;
        Debug.Log("Key Collected");
        UIManager.Instance.UpdateKeyCount(keysCollected);

        key.SetActive(false);
        // Enemy begins chasing player when a key is collected
        //GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>().isChasing = true;


    }

    private void ExitLevel()
    {
        if (keysCollected == 3) 
        {
            Debug.Log(SceneManager.GetActiveScene().name);

            if (SceneManager.GetActiveScene().name == "Level1") 
            {
                GameManager.Instance.LoadScene("Level2");
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                GameManager.Instance.LoadScene("Level3");
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                GameManager.Instance.LoadScene("WinScene");
            }
        }
    }
}
