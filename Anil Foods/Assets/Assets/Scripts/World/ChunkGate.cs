using UnityEngine;

public class ChunkGate : MonoBehaviour
{
    public Collider backBlocker;
    private bool activated = false;

    private void OnTriggerExit(Collider other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            // Activate the wall so player can’t go back
            backBlocker.enabled = true;
            activated = true;
        }
    }
}
