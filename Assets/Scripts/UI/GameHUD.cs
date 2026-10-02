using UnityEngine;

public class GameHUD : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnGUI()
    {
        if (player == null) return;

        GUI.Box(new Rect(20, 20, 220, 100), "MMORPG");
        GUI.Label(new Rect(30, 40, 200, 20), "Salud: " + player.salud + "/" + player.maxSalud);
        GUI.Label(new Rect(30, 60, 200, 20), "Energía: " + player.energia);
        GUI.Label(new Rect(30, 80, 200, 20), "Inventario: " + string.Join(", ", player.GetInventory()));
    }
}
