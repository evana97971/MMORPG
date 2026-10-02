using UnityEngine;

public class AbilityHUD : MonoBehaviour
{
    public AbilitySystem abilitySystem;

    private void Start()
    {
        abilitySystem = FindObjectOfType<AbilitySystem>();
    }

    private void OnGUI()
    {
        if (abilitySystem == null) return;

        GUI.Box(new Rect(Screen.width - 260, Screen.height - 140, 220, 100), "Habilidades");

        for (int i = 0; i < abilitySystem.abilities.Count; i++)
        {
            var ability = abilitySystem.abilities[i];
            GUI.Label(new Rect(Screen.width - 240, Screen.height - 110 + i * 25, 180, 20),
                (i + 1) + ". " + ability.name + " (" + Mathf.CeilToInt(ability.timer) + "s)");
        }
    }
}
