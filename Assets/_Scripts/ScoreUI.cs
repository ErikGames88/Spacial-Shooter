using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        _text.text = "SCORE: "+ ScoreManager.SharedInstance.Amount;
    }
}
