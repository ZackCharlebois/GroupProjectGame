using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void LoadScene()
    {
        GameManager.Instance.LoadScene("Level1");
    }
}
