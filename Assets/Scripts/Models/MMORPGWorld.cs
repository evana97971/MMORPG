using System.Collections.Generic;
using UnityEngine;

public class Mundo
{
    public List<Region> regiones = new List<Region>();
    public Ciclo ciclo;

    public void InicializarMundo()
    {
        regiones.Add(new Region("Bosque", "Setas comunes, bestias", new Vector3(0f, 0f, 0f)));
        regiones.Add(new Region("Montaña", "Minerales, bestias raras", new Vector3(8f, 0f, 0f)));
        regiones.Add(new Region("Desierto", "Hierbas mágicas, clanes mercenarios", new Vector3(0f, 0f, 8f)));
        regiones.Add(new Region("Mar", "Peces legendarios, rituales acuáticos", new Vector3(8f, 0f, 8f)));

        ciclo = new Ciclo();
        Debug.Log("Mundo inicializado con regiones y ciclo dinámico.");
    }
}

public class Region
{
    public string nombre;
    public string recursosDisponibles;
    public Vector3 position;

    public Region(string nombre, string recursos, Vector3 position)
    {
        this.nombre = nombre;
        this.recursosDisponibles = recursos;
        this.position = position;
    }

    public void Explorar()
    {
        Debug.Log("Explorando región: " + nombre + " con recursos: " + recursosDisponibles);
    }
}

public class Ciclo
{
    public string tiempoActual = "Día";
    public string climaActual = "Soleado";

    public void CambiarTiempo()
    {
        tiempoActual = (tiempoActual == "Día") ? "Noche" : "Día";
        Debug.Log("El ciclo ha cambiado a: " + tiempoActual);
    }

    public void CambiarClima(string nuevoClima)
    {
        climaActual = nuevoClima;
        Debug.Log("El clima ahora es: " + climaActual);
    }
}
