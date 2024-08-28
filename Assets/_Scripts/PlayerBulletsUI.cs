using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBulletsUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    [SerializeField]
    private PlayerShooting targetShooting;

   
    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        targetShooting = FindObjectOfType<PlayerShooting>();
    }

    
    void Update()
    {
        _text.text = "BULETS: "+ targetShooting.bulletsAmount;
    }
}
