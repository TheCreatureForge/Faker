using UnityEngine;

public class Clicker_ClickUpgrade : MonoBehaviour
{
    void Awake()
    {
        GameObject.Find("Rock").GetComponent<Clicker_Button>().power *= 2;
        Destroy(gameObject);
    }
}
