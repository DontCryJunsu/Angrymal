using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEnd : MonoBehaviour
{
    public GameObject Fade;
    public void Btn()
    {
        Fade.GetComponent<FadeOut>().Btn();
        gameObject.SetActive(false);
    }
}
