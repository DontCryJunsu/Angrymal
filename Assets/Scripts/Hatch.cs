using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//병아리 부화하는 스크립트
public class Hatch : MonoBehaviour
{
    private float increase = 0.5f;
    private float count = 0;
    private float completeline = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count += increase;
        if (count >= completeline)
        {
            count = increase = 0;
            hatch();
        }
    }
    public void hatch()
    {
        if (PhotonNetwork.isMasterClient)
        {
                if (tag == "redcharacter")
                {
                    Debug.Log("레드 알");
                    GameObject.Find("BattleManager").GetComponent<BattleManager>().Hatch(this.gameObject); 
                }
                else if (tag == "bluecharacter")
                {
                    Debug.Log("블루 알");
                    GameObject.Find("BattleManager").GetComponent<BattleManager>().Hatch(this.gameObject);
                }
        }
        //PhotonNetwork.Destroy(iskilled.gameObject);
    }
}

