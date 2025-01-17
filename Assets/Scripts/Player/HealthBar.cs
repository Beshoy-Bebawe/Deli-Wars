using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public static HealthBar instance { get; private set; }
    
    public Image fill;
    float originalSize;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalSize = fill.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {				      
        fill.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
