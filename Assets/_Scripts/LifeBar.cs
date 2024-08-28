using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class LifeBar : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Target life that the bar will reflect")]
    private Life targetLife;

    private Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        _image.fillAmount = targetLife.Amount / targetLife.MaximumLife;
    }
}
