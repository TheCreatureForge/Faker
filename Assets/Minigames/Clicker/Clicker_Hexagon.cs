using UnityEngine;

public class Clicker_Hexagon : MonoBehaviour
{
    [Header("Visuals")]
    public GameObject hexagonSprite;

    [Header("Projectile")]
    public int projectileCount;
    public GameObject projectile;
    public float projectileSpeed;
    public float attackInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Random.insideUnitCircle.normalized * 3f;  
        InvokeRepeating("RandomRotation",attackInterval/2f,attackInterval/2f);
        InvokeRepeating("FireProjectile",attackInterval,attackInterval);
    }

    void RandomRotation()
    {
        hexagonSprite.transform.Rotate(0,0,Random.Range(20f,40f));
    }

    void FireProjectile()
    {
        for(int i = 0; i <projectileCount; i++)
        {
            GameObject newProj = Instantiate(projectile);
            newProj.transform.position = transform.position;
            Vector3 dir = Random.insideUnitCircle.normalized * projectileSpeed;
            newProj.GetComponent<Rigidbody2D>().linearVelocity = dir.normalized ;
        }
    }
}
