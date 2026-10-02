using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public string nombreJugador = "Héroe";
    public int energia = 100;
    public int fuerza = 10;
    public int nivel = 1;

    private CharacterController controller;
    private Mundo mundo;
    private Pesca pesca;
    private Caceria caceria;
    private Cocina cocina;
    private Herrero herrero;

    public float moveSpeed = 5f;
    public float turnSpeed = 10f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        pesca = new Pesca();
        caceria = new Caceria();
        cocina = new Cocina();
        herrero = new Herrero("luz", 1);
    }

    public void Initialize(Mundo mundoActual)
    {
        mundo = mundoActual;
        if (mundo == null)
        {
            mundo = new Mundo();
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
            var resources = new System.Collections.Generic.List<string> { "seta_lunar", "seta_espiritual" };
            cocina.Cocinar(resources);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            var armas = new System.Collections.Generic.List<string> { "lavacristalizada", "luzsagrada" };
            var arma = herrero.ForjarArma(armas);
            Debug.Log("Arma forjada: " + arma.tipo + " / nivel: " + arma.nivel);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var region in mundo.regiones)
            {
                region.Explorar();
            }
        }
    }
}
