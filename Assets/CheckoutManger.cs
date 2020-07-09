using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckoutManger : MonoBehaviour
{


    public List<BasketItem> basketContents;

    public struct BasketItem
    {
        public string name;
        public float price;
        public float weight;
        public bool ageRestricted;
    }

    public string name;
    public float price;
    public float weight;
    public bool ageRestricted;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BasketItem tempItem = new BasketItem
            {
                name = name,
                price = price,
                weight = weight,
                ageRestricted = ageRestricted
            };
            AddItemToBasket(tempItem);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (var item in basketContents)
            {
                Debug.Log(item.name);
            }
        }


    }

    public void AddItemToBasket(BasketItem itemToAdd)
    {
        basketContents.Add(itemToAdd);
    }

    public float GetTotalWeight()
    {
        float totalWeight = 0f;

        foreach (BasketItem item in basketContents)
        {
            totalWeight += item.weight;
        }

        return totalWeight;
    }
}
