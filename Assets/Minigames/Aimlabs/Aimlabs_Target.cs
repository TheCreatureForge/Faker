using UnityEngine;

public class Aimlabs_Target : MonoBehaviour
{
    public float lifespan;

    void Update()
    {
        lifespan -= Time.deltaTime;

        if(lifespan <= 0)
        {
            Expire();
        }
    }

    void OnMouseDown()
    {
        Break();
    }

    public void RegisterHit()
    {
        Break();
    }

    void Break()
    {
        Destroy(gameObject);
        GameObject.Find("Aimlabs Brain").GetComponent<Aimlabs>().score++;
        Debug.Log($"{name} was broken!");
    }

    void Expire()
    {
        Destroy(gameObject);
        Debug.Log($"{name} has expired");
    }
}
