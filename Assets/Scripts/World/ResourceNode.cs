using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public string itemName = "seta_lunar";

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.AddItem(itemName);
            Destroy(gameObject);
        }
    }
}
