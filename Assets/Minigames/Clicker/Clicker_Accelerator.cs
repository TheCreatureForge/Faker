using UnityEngine;

public class Clicker_Accelerator : MonoBehaviour
{
    public float multiplier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Random.insideUnitCircle.normalized * 2f;  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.TryGetComponent(out Clicker_Projectile clicker_Projectile))
        {
            Debug.Log(collision.name);
            clicker_Projectile.value = (int)(clicker_Projectile.value * multiplier);
            clicker_Projectile.gameObject.transform.localScale = clicker_Projectile.gameObject.transform.localScale * Mathf.Sqrt(2);
        }
    }

}
