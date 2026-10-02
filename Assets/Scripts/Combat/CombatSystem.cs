using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    private int attackDamage;
    private float attackRange;
    private float attackCooldown;
    private float nextAttackTime;

    public void Initialize(int damage, float range, float cooldown)
    {
        attackDamage = damage;
        attackRange = range;
        attackCooldown = cooldown;
        nextAttackTime = 0f;
    }

    public void PerformAttack(Vector3 origin, Vector3 targetPos, GameObject target, int damageOverride)
    {
        if (Time.time < nextAttackTime)
        {
            return;
        }

        if (target == null)
        {
            return;
        }

        float distance = Vector3.Distance(origin, targetPos);
        if (distance > attackRange)
        {
            return;
        }

        nextAttackTime = Time.time + attackCooldown;
        var enemy = target.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            enemy.TakeDamage(damageOverride > 0 ? damageOverride : attackDamage);
            Debug.Log("Ataque realizado sobre: " + target.name);
        }
    }
}
