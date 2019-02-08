using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coolTime : MonoBehaviour
{
    public Image coolFilter;

    public float cool = 3f;

    private bool canUse = true;

    void Start()
    {
        coolFilter.fillAmount = 0f;
    }

    public void UseCool()
    {
        if (canUse)
        {
            coolFilter.fillAmount = 1f;
            StartCoroutine(CoolTime());

            canUse = false;
        }
    }

    IEnumerator CoolTime()
    {
        while(coolFilter.fillAmount >0)
        {
            yield return null;
            coolFilter.fillAmount -= 1 * Time.smoothDeltaTime / cool;
        }
        canUse = true;
    }
}
