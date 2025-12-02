using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Text keyCount;
    public Text proximityText;

    public Volume volume;
    private Vignette vignette;
    [Range(0, 1)] public float vignetteValue = 0f;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);   // Prevent duplicates
            return;
        }

        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //volume.profile.TryGet(out vignette);
        VolumeProfile profile = volume.profile;

        if (!profile.TryGet(out vignette))
        {
            vignette = profile.Add<Vignette>();
            vignette.active = true;
        }
    }


    public void ShowPauseMenu(GameObject pauseMenu)
    {
        pauseMenu.SetActive(true);
    }

    public void HidePauseMenu(GameObject pauseMenu)
    {
        pauseMenu.SetActive(false);
    }

    public void UpdateKeyCount(int value)
    {
        keyCount.text = value.ToString();
    }

    public void UpdateProximity(float distance)
    {
        proximityText.text = distance.ToString();
    }

    public void UpdateVignette(float distance)
    {
        //volume.GetComponent<Vignette>().intensity.value = 1 - distance / 100;
        vignette.intensity.value = 1 - distance / 100;
    }
}
