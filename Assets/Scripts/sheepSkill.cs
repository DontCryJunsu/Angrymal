using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepSkill : MonoBehaviour
{
    bool isSkill = false;
    public Material sheepMat;
    public Material palete;
    public Renderer sheepRen;
    public SphereCollider SC;
    bool isheal = false;
    DefaultMove DM;
    IEnumerator Start()
    {
        while(true)
        {
            SC.enabled = false;
            yield return new WaitForSeconds(2.5f);
            sheepRen.sharedMaterial = palete;
            isheal = false;
            SC.enabled = true;
            yield return new WaitForSeconds(2.5f);
            sheepRen.sharedMaterial = sheepMat;
            isheal = true;
        }
    }

     void OnTriggerStay(Collider other)
    {
        DM = other.GetComponent<DefaultMove>();
        if (other.tag == "bluecharacter" && PlayerPrefs.GetString("Team").Equals("B") && isheal)
        {
            if(DM.fullhp>DM.hp)
                DM.hp += 0.04f;
        }
        if (other.tag == "redcharacter" && PlayerPrefs.GetString("Team").Equals("R") && isheal)
        {
            if (DM.fullhp > DM.hp)
                DM.hp += 0.04f;
        }
    }
}
