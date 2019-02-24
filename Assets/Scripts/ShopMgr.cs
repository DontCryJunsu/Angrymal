using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMgr : MonoBehaviour
{
    public Text txt;
    public static int price = 0;
    public static string name;
    public AniBtnEnable ABE;
    public AniSelectBtn ASB;
    int money;

    void Start()
    {
        money = PlayerPrefs.GetInt("Money", 10000);
    }

    public void BuyBtn0()
    {
        price = 100;
        txt.text = "100";
        name = "pigBtn";
    }
    public void BuyBtn1()
    {
        price = 100;
        txt.text = "100";
        name = "mouseBtn";
    }
    public void BuyBtn2()
    {
        price = 120;
        txt.text = "120";
        name = "sheepBtn";
    }
    public void BuyBtn3()
    {
        price = 120;
        txt.text = "120";
        name = "snakeBtn";
    }
    public void BuyBtn4()
    {
        price = 150;
        txt.text = "150";
        name = "wolfBtn";
    }
    public void BuyBtn5()
    {
        price = 150;
        txt.text = "150";
        name = "kangarooBtn";
    }
    public void BuyBtn6()
    {
        price = 200;
        txt.text = "200";
        name = "jiraffeBtn";
    }
    public void BuyBtn7()
    {
        price = 200;
        txt.text = "200";
        name = "buffaloBtn";
    }
    public void BuyBtn8()
    {
        price = 250;
        txt.text = "250";
        name = "lionBtn";
    }
    public void BuyBtn9()
    {
        price = 250;
        txt.text = "250";
        name = "elephantBtn";
    }
    public void Buy()
    {
        if (money > price)
        {
            money -= price;
            PlayerPrefs.SetInt("Money", money);
            price = 0;
            txt.text = "";
            PlayerPrefs.SetInt(name, 1);
            ABE.shopActive();
            ASB.AllDown();
        }
    }
    public void ExitBtn()
    {
        SceneManager.LoadSceneAsync("LobbyScene");
    }
}
