using UnityEngine;

public class Profesion
{
    public string nombre;
    public int nivel;

    public void Accion()
    {
        if (nombre == "Alquimista") Debug.Log("Creando pociones...");
        if (nombre == "Herrero") Debug.Log("Mejorando armas...");
        if (nombre == "Cazador") Debug.Log("Capturando bestias...");
        if (nombre == "Cartógrafo") Debug.Log("Descubriendo mapas...");
        if (nombre == "Cocinero") Debug.Log("Preparando recetas...");
    }
}
