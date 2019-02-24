using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShopClick : MonoBehaviour
{
    public Transform house;

    public void SC()
    {
        GetComponent<CinemachineVirtualCamera>().LookAt = house;
        GetComponent<CinemachineVirtualCamera>().Priority = 11;
        Debug.Log("asd");
    }
}
