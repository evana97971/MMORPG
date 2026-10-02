using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public string nombreJugador = "Héroe";
    public int energia = 100;
    public int fuerza = 10;
    public int nivel = 1;
    public int salud = 100;
    public int maxSalud = 100;
    public int ataque = 15;
    public float rangoAtaque = 2.5f;
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;

    private CharacterController controller;
    private Mundo mundo;
    private Pesca pesca;
    private Caceria caceria;
    private Cocina cocina;
    private Herrero herrero;
    private InventorySystem inventario;
    private CombatSystem combate;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            controller = gameObject.AddComponent<CharacterController>();
            controller.height = 2f;
            controller.radius = 0.5f;
            controller.center = new Vector3(0f, 1f, 0f);
        }

        pesca = new Pesca();
        caceria = new Caceria();
        cocina = new Cocina();
        herrero = new Herrero("luz", 1);
        inventario = new InventorySystem();
        combate = gameObject.AddComponent<CombatSystem>();
        combate.Initialize(ataque, rangoAtaque, 0.5f);
    }

    public void Initialize(Mundo mundoActual)
    {
        mundo = mundoActual ?? new Mundo();
        if (mundo.regiones.Count == 0)
        {
            mundo.InicializarMundo();
        }
    }

    private void Update()
    {
        MovePlayer();
        HandleActions();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
        if (move.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(move),
                turnSpeed * Time.deltaTime
            );

            controller.Move(move * moveSpeed * Time.deltaTime);
        }
    }

    private void HandleActions()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pesca.Pescar();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            caceria.Cazar();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            var resources = new List<string> { "seta_lunar", "seta_espiritual" };
            cocina.Cocinar(resources);
            foreach (var item in resources)
            {
                inventario.AddItem(item);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            var armas = new List<string> { "lavacristalizada", "luzsagrada" };
            var arma = herrero.ForjarArma(armas);
            inventario.AddItem("Arma_" + arma.nivel);
            Debug.Log("Arma forjada: " + arma.tipo + " / nivel: " + arma.nivel);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var region in mundo.regiones)
            {
                region.Explorar();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            AttackNearestEnemy();
        }
    }

    public void Damage(int amount)
    {
        salud = Mathf.Max(0, salud - amount);
        if (salud <= 0)
        {
            Debug.Log("Jugador derrotado");
        }
    }

    public void Heal(int amount)
    {
        salud = Mathf.Min(maxSalud, salud + amount);
    }

    public void AddItem(string item)
    {
        inventario.AddItem(item);
    }

    public List<string> GetInventory()
    {
        return inventario.GetItems();
    }

    public void AttackNearestEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangoAtaque);
        EnemyAI nearest = null;
        float nearestDistance = Mathf.Infinity;

        foreach (var collider in colliders)
        {
            var enemy = collider.GetComponent<EnemyAI>();
            if (enemy == null || !enemy.enabled) continue;

            float dist = Vector3.Distance(transform.position, collider.transform.position);
            if (dist < nearestDistance)
            {
                nearest = enemy;
                nearestDistance = dist;
            }
        }

        if (nearest != null)
        {
            combate.PerformAttack(transform.position, nearest.transform.position, nearest.gameObject, ataque);
        }
    }
}
