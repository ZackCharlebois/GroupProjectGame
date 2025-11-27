using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityManager : MonoBehaviour
{
    public static ProximityManager Instance { get; private set; }

    public GameObject player;
    public GameObject[] enemies;

    public float nearestDistance;

    
    void Update()
    {
        GetDistance();
        UIManager.Instance.UpdateProximity(nearestDistance);
        UIManager.Instance.UpdateVignette(nearestDistance);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    void GetDistance()
    {
        foreach (GameObject enemy in enemies) 
        {
            nearestDistance = Mathf.Infinity;

            if (enemy == null) continue;

            float dist = Vector3.Distance(player.transform.position, enemy.transform.position);

            if (dist < nearestDistance) 
            {
                nearestDistance = dist;
            }
        }

    }
}
