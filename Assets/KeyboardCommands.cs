using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyboardCommands : MonoBehaviour
{
    public enum Tiles
    {
        Welcome,
        MainList,
        Verification_Scan,
        Verification_Selection,
        Product_Selection,
        Product_fruit,
        Product_Fruit_Apple,
        Payment_Methods,
        Payment_Scan,
        ThankYou
    }

    public enum SelectionDirection
    {
        Up,
        Down,
        Left,
        Right,
        Clear
    }

    public GameObject Camera;
    public GameObject AgeWarning;
    public float xOffset;

    public int textCounter = 0;
    public string[] productNameList;
    public float[] productPriceList;
    public int productCounbter;
    public float totalPrice;

    Tiles currentTile;


    // Start is called before the first frame update
    void Start()
    {
        xOffset = 180;
        productCounbter = 0;

        productNameList = new string[] { "12 Eggs", "Self Raising Flour", "Olive Oil", "Granny Smith", "White Zinfandel"};
        productPriceList = new float[] { 1.00f, 0.70f, 3.00f, 1.20f, 10f,  };

        AgeWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentTile)
        {
            case Tiles.Welcome:
                WelcomeManager();
                break;
            case Tiles.MainList:
                break;
            case Tiles.Verification_Scan:
                break;
            case Tiles.Verification_Selection:
                break;
            case Tiles.Product_Selection:
                break;
            case Tiles.Product_fruit:
                break;
            case Tiles.Product_Fruit_Apple:
                break;
            case Tiles.Payment_Methods:
                break;
            case Tiles.Payment_Scan:
                break;
            case Tiles.ThankYou:
                break;
            default:
                break;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Camera.transform.position += new Vector3(xOffset, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Camera.transform.position += new Vector3(-1 * xOffset, 0, 0);
        }
    }

    public void WelcomeManager()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (productCounbter < 5)
            {
                TextMeshPro priceList = GameObject.Find("ProductPrices").GetComponent<TextMeshPro>();
                TextMeshPro nameList = GameObject.Find("ProductNames").GetComponent<TextMeshPro>();
                priceList.text += productPriceList[productCounbter].ToString("c2") + "\n";
                nameList.text += productNameList[productCounbter] + "\n";

                TextMeshPro lastPrice = GameObject.Find("LastPrice").GetComponent<TextMeshPro>();
                TextMeshPro lastName = GameObject.Find("LastName").GetComponent<TextMeshPro>();
                lastPrice.text = productPriceList[productCounbter].ToString("c2");
                lastName.text = productNameList[productCounbter];

                TextMeshPro totalPriceText = GameObject.Find("TotalPrice").GetComponent<TextMeshPro>();
                totalPrice += productPriceList[productCounbter];
                totalPriceText.text = totalPrice.ToString("c2");

                if (productCounbter == 4)
                {
                    AgeWarning.SetActive(true);
                }
            }

            if (productCounbter == 5)
            {
                AgeWarning.SetActive(false);
            }
            productCounbter++;
        }
    }

    public void MainListManager()
    {

    }
}
