using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepSkill : MonoBehaviour
{
    public Material sheepMat;
    public Material palete;
    public Renderer sheepRen;
    bool isheal = false;
    DefaultMove DM;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            sheepRen.sharedMaterial = palete;
            isheal = false;
            yield return new WaitForSeconds(2.5f);
            sheepRen.sharedMaterial = sheepMat;
            isheal = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "bluecharacter"&& isheal)
        {
            DM = other.GetComponent<DefaultMove>();
            if (DM.fullhp > DM.hp)
                DM.hp += 0.04f;
        }
    }
}