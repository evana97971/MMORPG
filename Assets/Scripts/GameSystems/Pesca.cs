using System.Collections.Generic;
using UnityEngine;

public class Pesca
{
    public void Pescar()
    {
        float rand = Random.value;
        if (rand < 0.5f) Debug.Log("Has pescado un pez común");
        else if (rand < 0.8f) Debug.Log("Has pescado un pez raro");
        else if (rand < 0.95f) Debug.Log("Has pescado un pez legendario");
        else Debug.Log("Has pescado un pez espiritual");
    }
}

public class Caceria
{
    public void Cazar()
    {
        float rand = Random.value;
        if (rand < 0.6f) Debug.Log("Has cazado una bestia común");
        else if (rand < 0.85f) Debug.Log("Has cazado una bestia rara");
        else if (rand < 0.95f) Debug.Log("Has cazado una bestia espiritual");
        else Debug.Log("Has cazado una bestia legendaria");
    }
}

public class Cocina
{
    public void Cocinar(List<string> ingredientes)
    {
        if (ingredientes.Contains("seta_lunar")) Debug.Log("Plato con visión nocturna");
        if (ingredientes.Contains("seta_eclipse")) Debug.Log("Plato con invisibilidad temporal");
        if (ingredientes.Contains("seta_abisal")) Debug.Log("Plato con resistencia a venenos");
        if (ingredientes.Contains("seta_espiritual")) Debug.Log("Plato con fuerza mágica");
        if (ingredientes.Contains("seta_venenosa")) Debug.Log("Plato venenoso preparado");
    }
}
