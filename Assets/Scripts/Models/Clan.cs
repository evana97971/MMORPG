using System.Collections.Generic;
using UnityEngine;

public class Clan
{
    public string nombre;
    public string baseTipo;
    public int reputacion;
    public List<string> miembros = new List<string>();

    public void ConstruirBase(string tipo)
    {
        baseTipo = tipo;
        Debug.Log("Clan " + nombre + " ha construido una base tipo: " + tipo);
    }
}
