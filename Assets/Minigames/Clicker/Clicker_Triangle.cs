using UnityEngine;

public class Clicker_Triangle : MonoBehaviour
{
    float rotationSpeed;
    public GameObject projectile;
    public float projectileSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationSpeed = Random.Range(-360,360);      
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Random.insideUnitCircle.normalized * 5f;  
        InvokeRepeating("FireProjectile",.5f,.5f);
    }

    // Update is called once per frame
    void Update()
    {
        RotateTriangle();
    }

    void RotateTriangle()
    {
        GameObject triangleSprite = GameObject.Find("TriangleSprite");

        triangleSprite.transform.Rotate(new Vector3(0,0,rotationSpeed * Time.deltaTime));
    }

    void FireProjectile()
    {
        GameObject target = GameObject.Find("Rock");
        GameObject newProj = Instantiate(projectile);
        newProj.transform.position = transform.position;

        Vector3 dir = target.transform.position - transform.position;

        newProj.GetComponent<Rigidbody2D>().linearVelocity = dir.normalized * projectileSpeed;
    }
}
