using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinController : MonoBehaviour
{

    public int skinNum;
    public Button buyButton;
    public Image iLock;
    public int price;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;
    public Sprite falseLock;
    public Sprite unloack;

    public Image[] skins;



    private void Start()
    {
        if (PlayerPrefs.GetInt("skin1" + "buy") == 0)
        {
            foreach (Image img in skins)
            {
                if ("skin1" == img.name)
                {
                    PlayerPrefs.GetInt("skin1" + "buy", 1);
                    PlayerPrefs.GetInt("skin1" + "equip", 1);
                }
                else
                {
                    PlayerPrefs.GetInt(GetComponent<Image>().name + "buy", 0);
                }
            }
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            iLock.GetComponent<Image>().sprite = falseLock;
            buyButton.GetComponent<Image>().sprite = buySkin;
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            iLock.GetComponent<Image>().sprite = unloack;
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 1)
            {
                buyButton.GetComponent<Image>().sprite = equipped;
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 0)
            {
                buyButton.GetComponent<Image>().sprite = equip;
            }
        }
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
    public void BuyItem()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            if (Money.money >= price)
            {
                iLock.GetComponent<Image>().sprite = unloack;
                buyButton.GetComponent<Image>().sprite = equipped;
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - price);
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);

                foreach (Image img in skins)
                {
                    if (GetComponent<Image>().name == img.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                        Debug.Log("equip");
                    }
                    else
                    {
                        PlayerPrefs.SetInt(img.name + "equip", 0);
                        Debug.Log("0");
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            iLock.GetComponent<Image>().sprite = unloack;
            buyButton.GetComponent<Image>().sprite = equipped;
            PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);

            foreach (Image img in skins)
            {
                if (GetComponent<Image>().name == img.name)
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(img.name + "equip", 0);
                }
            }
        }
    }
}


