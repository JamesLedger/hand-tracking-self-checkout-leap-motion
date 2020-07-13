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
    public int productCounter;
    public float totalPrice;

    Tiles currentTile;


    // Start is called before the first frame update
    void Start()
    {
        xOffset = 180;
        productCounter = 0;

        productNameList = new string[] { "12 Eggs", "Self Raising Flour", "Olive Oil", "Granny Smith", "White Zinfandel"};
        productPriceList = new float[] { 1.00f, 0.70f, 3.00f, 1.20f, 10f,  };

        AgeWarning.SetActive(false);
    }

    public void WelcomeManager()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (productCounter < 5)
            {
                TextMeshPro priceList = GameObject.Find("ProductPrices").GetComponent<TextMeshPro>();
                TextMeshPro nameList = GameObject.Find("ProductNames").GetComponent<TextMeshPro>();
                priceList.text += productPriceList[productCounter].ToString("c2") + "\n";
                nameList.text += productNameList[productCounter] + "\n";

                TextMeshPro lastPrice = GameObject.Find("LastPrice").GetComponent<TextMeshPro>();
                TextMeshPro lastName = GameObject.Find("LastName").GetComponent<TextMeshPro>();
                lastPrice.text = productPriceList[productCounter].ToString("c2");
                lastName.text = productNameList[productCounter];

                TextMeshPro totalPriceText = GameObject.Find("TotalPrice").GetComponent<TextMeshPro>();
                totalPrice += productPriceList[productCounter];
                totalPriceText.text = totalPrice.ToString("c2");

                if (productCounter == 4)
                {
                    AgeWarning.SetActive(true);
                }
            }

            if (productCounter == 5)
            {
                AgeWarning.SetActive(false);
            }
            productCounter++;
        }
    }
}
