using UnityEngine;

public class EnemyHealthBarUI : MonoBehaviour
{
    public EnemyAI targetEnemy;
    public Vector3 offset = new Vector3(0f, 2.3f, 0f);

    private void Update()
    {
        if (targetEnemy == null) return;
        transform.position = targetEnemy.transform.position + offset;
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }

    private void OnGUI()
    {
        if (targetEnemy == null) return;

        float fill = (float)targetEnemy.currentHealth / (float)targetEnemy.maxHealth;
        GUI.Box(new Rect(Screen.width / 2 - 80, 40, 160, 22), "");
        GUI.Box(new Rect(Screen.width / 2 - 80, 40, 160 * fill, 22), "");
    }
}
