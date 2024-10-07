using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    private int collisionCount;
    public TextMeshProUGUI txtCount;

    void Start()
    {
        collisionCount = 0;
        txtCount = GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>();
        txtCount.gameObject.SetActive(false);
    }

    void Update()
    {
        if (collisionCount == 5)
        {
            txtCount.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            collisionCount++;
            Debug.Log($"Colisiones con conejito: {collisionCount}");
        }
    }
}
