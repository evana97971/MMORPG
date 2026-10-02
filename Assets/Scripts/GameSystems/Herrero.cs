using System.Collections.Generic;
using UnityEngine;

public class Herrero
{
    public string tipo;
    public int nivel;

    public Herrero(string tipo, int nivel)
    {
        this.tipo = tipo;
        this.nivel = nivel;
    }

    public Arma ForjarArma(List<string> materiales)
    {
        Arma nuevaArma = new Arma();
        nuevaArma.tipo = "Espada";

        if (materiales.Contains("lavacristalizada") && materiales.Contains("luzsagrada"))
        {
            nuevaArma.nivel = "legendaria";
            Debug.Log("Has forjado una espada ígnea bendita!");
        }
        else if (materiales.Contains("metal_corrupto"))
        {
            nuevaArma.nivel = "maldita";
            Debug.Log("El arma está corrompida...");
        }
        else
        {
            nuevaArma.nivel = "básica";
            Debug.Log("Has forjado un arma básica.");
        }

        return nuevaArma;
    }

    public void GrabarRunas(Arma arma, string runa)
    {
        Debug.Log("El herrero " + tipo + " ha grabado la runa: " + runa + " en el arma.");
    }

    public void BendecirArma(Arma arma)
    {
        if (tipo == "luz")
        {
            arma.nivel = "sagrada";
            Debug.Log("El arma ha sido bendecida con poder divino.");
        }
    }
}
