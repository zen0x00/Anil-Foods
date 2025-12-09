using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Game/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int scoreValue;

    public Color itemColor; // For your colored cubes
    public GameObject itemPrefab; // Optional if you want different shapes later
}
