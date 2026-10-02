using UnityEngine;

public class Arma
{
    public string tipo;
    public string nivel;
    public string vinculoJugador;

    public void Evolucionar()
    {
        switch (nivel)
        {
            case "básica": nivel = "rúnica"; break;
            case "rúnica": nivel = "vinculada"; break;
            case "vinculada": nivel = "legendaria"; break;
            case "legendaria": nivel = "mítica"; break;
            case "mítica": nivel = "única"; break;
        }

        Debug.Log("El arma ha evolucionado a: " + nivel);
    }
}
