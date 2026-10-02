using System.Collections.Generic;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    public static Mundo MundoActual { get; private set; }

    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        InitializeWorld();
        CreatePlayer();
    }

    private void InitializeWorld()
    {
        MundoActual = new Mundo();
        MundoActual.InicializarMundo();

        var generator = FindObjectOfType<WorldGenerator>();
        if (generator == null)
        {
            var generatorObject = new GameObject("WorldGenerator");
            generator = generatorObject.AddComponent<WorldGenerator>();
        }

        generator.Generate(MundoActual);
    }

    private void CreatePlayer()
    {
        GameObject playerObject = null;

        if (playerPrefab != null)
        {
            playerObject = Instantiate(playerPrefab);
        }
        else
        {
            playerObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            playerObject.name = "Jugador";
            playerObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        var player = playerObject.GetComponent<PlayerController>();
        if (player == null)
        {
            player = playerObject.AddComponent<PlayerController>();
        }

        player.Initialize(MundoActual);
        playerObject.transform.position = new Vector3(0f, 1f, 0f);
    }
}
