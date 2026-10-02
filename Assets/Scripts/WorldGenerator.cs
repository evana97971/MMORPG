using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public void Generate(Mundo mundo)
    {
        foreach (var region in mundo.regiones)
        {
            var regionGo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            regionGo.name = region.nombre;
            regionGo.transform.position = region.position;
            regionGo.transform.localScale = new Vector3(4f, 1f, 4f);

            var renderer = regionGo.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Standard"));

            switch (region.nombre)
            {
                case "Bosque":
                    renderer.material.color = Color.green;
                    break;
                case "Montaña":
                    renderer.material.color = Color.gray;
                    break;
                case "Desierto":
                    renderer.material.color = Color.yellow;
                    break;
                case "Mar":
                    renderer.material.color = Color.blue;
                    break;
            }

            var resourceGo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            resourceGo.name = region.nombre + "_Recurso";
            resourceGo.transform.position = region.position + new Vector3(0f, 1f, 0f);
            resourceGo.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            resourceGo.GetComponent<Renderer>().material.color = Color.magenta;
        }
    }
}
