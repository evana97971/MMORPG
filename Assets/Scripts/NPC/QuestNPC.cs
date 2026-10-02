using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    public string npcName = "Guía del pueblo";
    [TextArea(2, 4)]
    public string dialogue = "¡Héroe! Derrota a 3 enemigos para ganar recompensa.";
    public bool playerNearby = false;

    public int enemiesDefeatedToComplete = 3;
    public int defeatedCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log(dialogue);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    public void RegisterDefeat()
    {
        defeatedCount++;
        if (defeatedCount >= enemiesDefeatedToComplete)
        {
            Debug.Log("Misión completada: el NPC te recompensó.");
        }
    }

    private void OnGUI()
    {
        if (!playerNearby) return;

        GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 120, 400, 80), npcName);
        GUI.Label(new Rect(Screen.width / 2 - 180, Screen.height - 95, 360, 40), dialogue);
    }
}
