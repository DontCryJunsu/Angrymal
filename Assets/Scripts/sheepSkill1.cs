using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepSkill1 : MonoBehaviour
{

    public GameObject part;
    bool isheal = false;
    DefaultMove DM;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            part.SetActive(false);
            isheal = false;
            yield return new WaitForSeconds(2f);
            part.SetActive(true);
            isheal = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "redcharacter" && isheal)
        {
            DM = other.GetComponent<DefaultMove>();
            if (DM.fullhp > DM.hp)
                DM.hp += 0.09f;
        }
    }
}