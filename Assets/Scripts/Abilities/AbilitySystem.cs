using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    public class Ability
    {
        public string name;
        public float cooldown;
        public float timer;

        public Ability(string name, float cooldown)
        {
            this.name = name;
            this.cooldown = cooldown;
            this.timer = 0f;
        }
    }

    public List<Ability> abilities = new List<Ability>();
    public PlayerController owner;

    private void Start()
    {
        if (owner == null)
        {
            owner = FindObjectOfType<PlayerController>();
        }

        abilities.Add(new Ability("Golpe Rápido", 1.5f));
        abilities.Add(new Ability("Llamarada", 3f));
        abilities.Add(new Ability("Curación", 6f));
    }

    private void Update()
    {
        foreach (var ability in abilities)
        {
            if (ability.timer > 0f)
            {
                ability.timer -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseAbility("Golpe Rápido");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseAbility("Llamarada");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseAbility("Curación");
        }
    }

    public void UseAbility(string name)
    {
        foreach (var ability in abilities)
        {
            if (ability.name == name)
            {
                if (ability.timer > 0f)
                {
                    Debug.Log("Habilidad en cooldown: " + name);
                    return;
                }

                ability.timer = ability.cooldown;

                switch (name)
                {
                    case "Golpe Rápido":
                        Debug.Log("Uso Golpe Rápido");
                        if (owner != null)
                        {
                            owner.ataque += 5;
                        }
                        break;

                    case "Llamarada":
                        Debug.Log("Uso Llamarada");
                        break;

                    case "Curación":
                        Debug.Log("Uso Curación");
                        if (owner != null)
                        {
                            owner.salud = Mathf.Min(owner.maxSalud, owner.salud + 25);
                        }
                        break;
                }

                return;
            }
        }

        Debug.Log("Habilidad no encontrada: " + name);
    }
}
