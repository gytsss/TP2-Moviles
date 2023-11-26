using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [System.Serializable]
    struct Item
    {
        public Sprite sprite;
        public int price;
        public bool isOwned;
        public bool isSelected;
    }

    public static ShopManager Instance { get; private set; }

    [SerializeField] private Item[] shopItems;
    [SerializeField] private Image currentItemSprite;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Sprite selectedBallSprite;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Button selectButton;
    [SerializeField] private Button selectedButton;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Counter counter;
    [SerializeField] private int currentItem = 0;

    private int maxItems;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        maxItems = shopItems.Length;
        shopItems[0].isOwned = true;
        
        LoadData();

        UpdateUI();
    }

    private void UpdateUI()
    {
        currentItemSprite.sprite = shopItems[currentItem].sprite;
        priceText.text = shopItems[currentItem].price.ToString();
        
        bool canPurchase = counter.GetCash() >= shopItems[currentItem].price;
        
        purchaseButton.gameObject.SetActive(!shopItems[currentItem].isOwned && canPurchase);
        selectButton.gameObject.SetActive(shopItems[currentItem].isOwned && !shopItems[currentItem].isSelected);
        selectedButton.gameObject.SetActive(shopItems[currentItem].isOwned && shopItems[currentItem].isSelected);
    }

    public void NextItem()
    {
        if (currentItem < maxItems - 1)
            currentItem++;

        UpdateUI();
    }

    public void PreviousItem()
    {
        if (currentItem > 0)
            currentItem--;

        UpdateUI();
    }

    public void PurchaseItem()
    {
        if (!shopItems[currentItem].isOwned && counter.GetCash() >= shopItems[currentItem].price)
        {
            counter.DecreaseCash(shopItems[currentItem].price);
            shopItems[currentItem].isOwned = true;
            SaveData();
            UpdateUI();
        }
    }

    public void SelectItem()
    {
        if (shopItems[currentItem].isOwned)
        {
            for (int i = 0; i < shopItems.Length; i++)
            {
                shopItems[i].isSelected = false;
            }

            shopItems[currentItem].isSelected = true;
            SaveData();
            UpdateUI();
        }
    }

    public Sprite GetActiveBallSprite()
    {
        foreach (Item item in shopItems)
        {
            if (item.isSelected)
            {
                return item.sprite;
            }
        }
        return null;
    }
    
    private void SaveData()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            PlayerPrefs.SetInt("IsOwned" + i, shopItems[i].isOwned ? 1 : 0);
            PlayerPrefs.SetInt("IsSelected" + i, shopItems[i].isSelected ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopItems[i].isOwned = PlayerPrefs.GetInt("IsOwned" + i, 0) == 1;
            shopItems[i].isSelected = PlayerPrefs.GetInt("IsSelected" + i, 0) == 1;
        }
    }
    private void ResetData()
    {
       PlayerPrefs.DeleteAll();
    }
}