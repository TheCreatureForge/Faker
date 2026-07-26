using TMPro;
using Unity.Mathematics;
using UnityEngine;


public class Clicker_ShopItem : MonoBehaviour
{
    [Header("Product Variables")]
    public GameObject product;
    public string productName;
    public int basePrice;
    public int purchaseNumber;

    [Header("UI objects")]
    public TextMeshProUGUI productLabel;

    void Start()
    {
        SetButtonLabel();
    }

    public float CalculatePrice()
    {
        return basePrice * math.pow(2, purchaseNumber);
    }

    public void AttemptPurchase()
    {
        if(Clicker.Instance.currentMoney < CalculatePrice())
        {
            Debug.LogWarning("You Broke Asf");
            return;
        }
        Purchase();
    }

    void Purchase()
    {
        Clicker.Instance.removeMoney((int)CalculatePrice());

        GameObject newItem = Instantiate(product);
        newItem.transform.position = new Vector3(UnityEngine.Random.Range(-7.5f,7.5f),UnityEngine.Random.Range(-3.5f,3.5f),0);
        
        purchaseNumber++;
        SetButtonLabel();

    }

    void SetButtonLabel()
    {
        string labelText = string.Empty;
        labelText = productName + "\n$" + CalculatePrice();
        productLabel.text = labelText;
    }

}
