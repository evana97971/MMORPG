using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth = 50;
    public int damage = 10;
    public float moveSpeed = 2f;
    public float followRange = 6f;
    public float attackRange = 1.8f;
    public float attackCooldown = 1.2f;

    private Transform target;
    private float nextAttackTime;
    public QuestNPC questNPC;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (target == null)
        {
            target = GameObject.Find("Jugador")?.transform;
        }

        if (questNPC == null)
        {
            questNPC = FindObjectOfType<QuestNPC>();
        }
    }

    private void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= followRange)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            if (distance > attackRange)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else if (Time.time >= nextAttackTime)
            {
                PlayerController player = target.GetComponent<PlayerController>();
                if (player != null)
                {
                    player.Damage(damage);
                }
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if (questNPC != null)
            {
                questNPC.RegisterDefeat();
            }

            Destroy(gameObject);
            Debug.Log("Enemigo derrotado");
        }
    }
}
