using UnityEngine;

public class ProductItem : MonoBehaviour
{
    public ItemData data;   // ScriptableObject reference

    private void Start()
    {
        // Apply data color to the cube
        GetComponent<Renderer>().material.color = data.itemColor;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(data.scoreValue);
            Destroy(gameObject);
        }
    }
}
