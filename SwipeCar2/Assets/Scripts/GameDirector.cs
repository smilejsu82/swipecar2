using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text text;

    public void UpdateUI(float distance)
    {
        text.text = $"{(int)distance}m";
    }

    public void UpdateUI(string message)
    {
        text.text = message;
    }
}
