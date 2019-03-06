using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseGage : MonoBehaviour
{
    public Image IMG;
    public static float cool = 1f;

    void Start()
    {
        IMG = GetComponent<Image>();
    }
    void FixedUpdate()
    {
        if(cool<1f)
        {
            cool += 0.001f;
            IMG.fillAmount = cool;
        }
    }
}
