using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int cantidad = 5;
    public float radio = 20f;

    private void Start()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * radio;
            randomPos.y = 1f;

            if (enemyPrefab != null)
            {
                Instantiate(enemyPrefab, randomPos, Quaternion.identity);
            }
        }
    }
}
