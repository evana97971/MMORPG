using UnityEngine;

public class PlayerProgressHUD : MonoBehaviour
{
    public PlayerController player;

    private void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }
    }

    private void OnGUI()
    {
        if (player == null) return;

        GUI.Box(new Rect(20, 20, 300, 120), "Jugador");

        GUI.Label(new Rect(30, 45, 100, 20), "Nivel: " + player.nivel);
        GUI.Label(new Rect(30, 70, 100, 20), "Ataque: " + player.ataque);
        GUI.Label(new Rect(30, 95, 120, 20), "Salud: " + player.salud + "/" + player.maxSalud);
    }
}
