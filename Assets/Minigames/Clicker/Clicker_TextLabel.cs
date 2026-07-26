using TMPro;
using UnityEngine;

public class Clicker_TextLabel : MonoBehaviour
{
    TextMeshPro textMeshPro;

    float alpha = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        
    }

    void Update()
    {
        alpha -= 2f/3f * Time.deltaTime;
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
    }

    public void Setup(int textValue, Vector3 pos, Color color)
    {
        textMeshPro.text = "$" + textValue;
        textMeshPro.color = color;

        GetComponent<Rigidbody2D>().linearVelocityY = Random.Range(0.75f,1.25f);
        
        pos.z = -1;
        transform.position = pos;

        Invoke("DestroySelf",2f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
