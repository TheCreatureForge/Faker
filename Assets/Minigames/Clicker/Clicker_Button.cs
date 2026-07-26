using TMPro;
using UnityEngine;

public class Clicker_Button : MonoBehaviour
{
    public int power;

    [Header("Click Indicator")]
    public GameObject clickText;


    void OnMouseDown()
    {
        Clicker.Instance.addMoney(power);
        GameObject newText = Instantiate(clickText);
        newText.GetComponent<Clicker_TextLabel>().Setup(power,Camera.main.ScreenToWorldPoint(Input.mousePosition), new Color(133/255f, 119/255f, 255/255f));
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Clicker_Projectile clicker_Projectile))
        {
            Clicker.Instance.addMoney(clicker_Projectile.value);
            Destroy(collision.gameObject);

            GameObject newText = Instantiate(clickText);
            newText.GetComponent<Clicker_TextLabel>().Setup(clicker_Projectile.value, clicker_Projectile.transform.position, clicker_Projectile.GetComponent<SpriteRenderer>().color);
        }
    }

}
