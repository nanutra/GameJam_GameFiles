using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TextInfoTime : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;

    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        m_TextMeshProUGUI.fontSize = 24;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        string timeString = currentTime.ToString("hh:mm:ss tt");
        m_TextMeshProUGUI.text = timeString;
    }
}
