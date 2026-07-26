using UnityEngine;

public class Clicker_Button : MonoBehaviour
{
    public int power;

    void OnMouseDown()
    {
        Clicker.Instance.addMoney(power);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Clicker_Projectile clicker_Projectile))
        {
            Clicker.Instance.addMoney(clicker_Projectile.value);
            Destroy(collision.gameObject);
        }
    }

}
