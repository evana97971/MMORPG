using UnityEngine;

public class Evento
{
    public string tipo;
    public string efecto;

    public void Activar()
    {
        if (tipo == "eclipse") Debug.Log("Boss único aparece!");
        if (tipo == "tormenta") Debug.Log("Atributos alterados!");
        if (tipo == "invasion") Debug.Log("Enemigos oscuros atacan!");
        if (tipo == "ritual") Debug.Log("Poderes especiales desbloqueados!");
    }
}
