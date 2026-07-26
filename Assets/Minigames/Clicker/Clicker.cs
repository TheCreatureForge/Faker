using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clicker : Minigame
{
    [Header("Clicker")]
    [HideInInspector] public static Clicker Instance;
    TextMeshProUGUI scoreTextLabel;
    TextMeshProUGUI CPSTextLabel;

    public int currentMoney;
    public List<float> recentSeconds; 
    int currentSecondMoney;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CPSTextLabel = GameObject.Find("ClicksPerSecondLabel").GetComponent<TextMeshProUGUI>();
        scoreTextLabel = GameObject.Find("ScoreLabel").GetComponent<TextMeshProUGUI>();
        InvokeRepeating("snapshotSecond",1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextLabel.text = "" + currentMoney;
        CPSTextLabel.text = "" + CalculateCPS().ToString("F1");
    }

    void snapshotSecond()
    {
        recentSeconds.RemoveAt(0);
        recentSeconds.Add(currentSecondMoney);
        currentSecondMoney = 0;
    }

    float CalculateCPS()
    {
        float sum = 0;
        foreach (int n in recentSeconds)
        {
            sum += n;   
        }
        return sum / recentSeconds.Count;
    }

    public void addMoney(int amountOfMoney)
    {
        currentMoney += amountOfMoney;
        currentSecondMoney += amountOfMoney;
    }

    public void removeMoney(int amountOfMoney)
    {
        currentMoney -= amountOfMoney;
    }

}
