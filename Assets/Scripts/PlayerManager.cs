using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public int keysCollected;

    public Text keyCount;

    // Start is called before the first frame update
    void Start()
    {
        keysCollected = 0;
        keyCount.text = keysCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    private void PlayerDies()
    {
        Debug.Log("Player has died");
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    private void CollectKey(Collider other)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxSource);
        GameObject key = other.transform.parent.gameObject;
        keysCollected++;
        Debug.Log("Key Collected");
        keyCount.text = keysCollected.ToString();

        key.SetActive(false);
        // Enemy begins chasing player when a key is collected
        //GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>().isChasing = true;


    }
}
