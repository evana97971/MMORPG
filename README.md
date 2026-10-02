# 🌌 MMORPG - Videojuego de Mundo Abierto

Un MMORPG dinámico desarrollado en **Unity** con C# que ofrece un mundo vivo lleno de clanes, eventos épicos, profesiones variadas y un sistema de armas evolucionable.

---

## 🎮 Sistema Principal

```csharp
using System.Collections.Generic;
using UnityEngine;

public class JuegoMMORPG : MonoBehaviour {
    public List<Clan> clanes = new List<Clan>();
    public List<Arma> armas = new List<Arma>();
    public List<Evento> eventos = new List<Evento>();
    public List<Profesion> profesiones = new List<Profesion>();
    public Mundo mundo;

    void Start() {
        mundo = new Mundo();
        mundo.InicializarMundo();

        Debug.Log("Juego MMORPG inicializado con clanes, armas, eventos y mundo dinámico.");
    }
}
```

---

## 🛡️ Clanes

Los jugadores pueden formar clanes, construir bases y ganar reputación juntos.

```csharp
public class Clan {
    public string nombre;
    public string baseTipo;
    public int reputacion;
    public List<string> miembros = new List<string>();

    public void ConstruirBase(string tipo) {
        baseTipo = tipo;
        Debug.Log("Clan " + nombre + " ha construido una base tipo: " + tipo);
    }
}
```

---

## ⚔️ Sistema de Armas Vinculadas

Las armas evolucionan a través de 6 niveles: Básica → Rúnica → Vinculada → Legendaria → Mítica → Única.

```csharp
public class Arma {
    public string tipo;
    public string nivel;
    public string vinculoJugador;

    public void Evolucionar() {
        switch (nivel) {
            case "básica": nivel = "rúnica"; break;
            case "rúnica": nivel = "vinculada"; break;
            case "vinculada": nivel = "legendaria"; break;
            case "legendaria": nivel = "mítica"; break;
            case "mítica": nivel = "única"; break;
        }
        Debug.Log("El arma ha evolucionado a: " + nivel);
    }
}
```

---

## 🌑 Eventos Dinámicos

El mundo está lleno de eventos que cambian el gameplay:

- **Eclipse**: Aparece un boss único
- **Tormenta**: Se alteran los atributos
- **Invasión**: Enemigos oscuros atacan
- **Ritual**: Se desbloquean poderes especiales

```csharp
public class Evento {
    public string tipo;
    public string efecto;

    public void Activar() {
        if (tipo == "eclipse") Debug.Log("Boss único aparece!");
        if (tipo == "tormenta") Debug.Log("Atributos alterados!");
        if (tipo == "invasion") Debug.Log("Enemigos oscuros atacan!");
        if (tipo == "ritual") Debug.Log("Poderes especiales desbloqueados!");
    }
}
```

---

## 🧩 Profesiones

Cada profesión ofrece habilidades y recompensas únicas:

```csharp
public class Profesion {
    public string nombre;
    public int nivel;

    public void Accion() {
        if (nombre == "Alquimista") Debug.Log("Creando pociones...");
        if (nombre == "Herrero") Debug.Log("Mejorando armas...");
        if (nombre == "Cazador") Debug.Log("Capturando bestias...");
        if (nombre == "Cartógrafo") Debug.Log("Descubriendo mapas...");
        if (nombre == "Cocinero") Debug.Log("Preparando recetas...");
    }
}
```

### Profesiones disponibles:
- 🔧 **Alquimista** - Crea pociones
- ⚒️ **Herrero** - Mejora y forja armas
- 🏹 **Cazador** - Captura bestias
- ����️ **Cartógrafo** - Descubre mapas
- 🍳 **Cocinero** - Prepara recetas mágicas

---

## ⚒️ Sistema de Herrería

Forja armas con diferentes tipos (Mágico, Rúnico, Oscuro, Luz) y mejora tu armamento con runas sagradas.

```csharp
using System.Collections.Generic;
using UnityEngine;

public class Herrero {
    public string tipo; // mágico, rúnico, oscuro, luz
    public int nivel;   // aprendiz, maestro

    public Herrero(string tipo, int nivel) {
        this.tipo = tipo;
        this.nivel = nivel;
    }

    public Arma ForjarArma(List<string> materiales) {
        Arma nuevaArma = new Arma();
        nuevaArma.tipo = "Espada";

        if (materiales.Contains("lavacristalizada") && materiales.Contains("luzsagrada")) {
            nuevaArma.nivel = "legendaria";
            Debug.Log("Has forjado una espada ígnea bendita!");
        }
        else if (materiales.Contains("metal_corrupto")) {
            nuevaArma.nivel = "maldita";
            Debug.Log("El arma está corrompida...");
        }
        else {
            nuevaArma.nivel = "básica";
            Debug.Log("Has forjado un arma básica.");
        }

        return nuevaArma;
    }

    public void GrabarRunas(Arma arma, string runa) {
        Debug.Log("El herrero " + tipo + " ha grabado la runa: " + runa + " en el arma.");
    }

    public void BendecirArma(Arma arma) {
        if (tipo == "luz") {
            arma.nivel = "sagrada";
            Debug.Log("El arma ha sido bendecida con poder divino.");
        }
    }
}
```

---

## 🐟 Pesca y 🦌 Cacería

Actividades de recolección con diferentes raridades de loot.

```csharp
using UnityEngine;

public class Pesca {
    public void Pescar() {
        float rand = Random.value;
        if (rand < 0.5f) Debug.Log("Has pescado un pez común");
        else if (rand < 0.8f) Debug.Log("Has pescado un pez raro");
        else if (rand < 0.95f) Debug.Log("Has pescado un pez legendario");
        else Debug.Log("Has pescado un pez espiritual");
    }
}

public class Caceria {
    public void Cazar() {
        float rand = Random.value;
        if (rand < 0.6f) Debug.Log("Has cazado una bestia común");
        else if (rand < 0.85f) Debug.Log("Has cazado una bestia rara");
        else if (rand < 0.95f) Debug.Log("Has cazado una bestia espiritual");
        else Debug.Log("Has cazado una bestia legendaria");
    }
}
```

---

## 🍳 Cocina Mágica

Prepara platos con setas raras que otorgan efectos especiales:

- 🌙 **Seta Lunar** - Visión nocturna
- 🌑 **Seta Eclipse** - Invisibilidad temporal
- 🌊 **Seta Abisal** - Resistencia a venenos
- ✨ **Seta Espiritual** - Fuerza mágica
- ☠️ **Seta Venenosa** - Daño al enemigo

```csharp
using System.Collections.Generic;
using UnityEngine;

public class Cocina {
    public void Cocinar(List<string> ingredientes) {
        if (ingredientes.Contains("seta_lunar")) Debug.Log("Plato con visión nocturna");
        if (ingredientes.Contains("seta_eclipse")) Debug.Log("Plato con invisibilidad temporal");
        if (ingredientes.Contains("seta_abisal")) Debug.Log("Plato con resistencia a venenos");
        if (ingredientes.Contains("seta_espiritual")) Debug.Log("Plato con fuerza mágica");
        if (ingredientes.Contains("seta_venenosa")) Debug.Log("Plato venenoso preparado");
    }
}
```

---

## 🌍 Mundo Dinámico

El mundo se divide en **4 regiones principales**, cada una con recursos y enemigos únicos:

```csharp
using System.Collections.Generic;
using UnityEngine;

public class Mundo {
    public List<Region> regiones = new List<Region>();
    public Ciclo ciclo;

    public void InicializarMundo() {
        regiones.Add(new Region("Bosque", "Setas comunes, bestias"));
        regiones.Add(new Region("Montaña", "Minerales, bestias raras"));
        regiones.Add(new Region("Desierto", "Hierbas mágicas, clanes mercenarios"));
        regiones.Add(new Region("Mar", "Peces legendarios, rituales acuáticos"));

        ciclo = new Ciclo();
        Debug.Log("Mundo inicializado con regiones y ciclo dinámico.");
    }
}

public class Region {
    public string nombre;
    public string recursosDisponibles;

    public Region(string nombre, string recursos) {
        this.nombre = nombre;
        this.recursosDisponibles = recursos;
    }

    public void Explorar() {
        Debug.Log("Explorando región: " + nombre + " con recursos: " + recursosDisponibles);
    }
}

public class Ciclo {
    public string tiempoActual = "Día";
    public string climaActual = "Soleado";

    public void CambiarTiempo() {
        tiempoActual = (tiempoActual == "Día") ? "Noche" : "Día";
        Debug.Log("El ciclo ha cambiado a: " + tiempoActual);
    }

    public void CambiarClima(string nuevoClima) {
        climaActual = nuevoClima;
        Debug.Log("El clima ahora es: " + climaActual);
    }
}
```

### Regiones:
- 🌲 **Bosque** - Setas comunes, bestias
- ⛰️ **Montaña** - Minerales, bestias raras
- 🏜️ **Desierto** - Hierbas mágicas, clanes mercenarios
- 🌊 **Mar** - Peces legendarios, rituales acuáticos

---

## 🎮 Controlador del Jugador

Sistema de movimiento e interacción para el jugador:

```csharp
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public string nombreJugador = "Heroe";
    public int energia = 100;
    public int fuerza = 10;
    public List<string> inventario = new List<string>();

    private Mundo mundo;
    private Pesca pesca;
    private Caceria caceria;
    private Cocina cocina;

    void Start() {
        mundo = new Mundo();
        mundo.InicializarMundo();

        pesca = new Pesca();
        caceria = new Caceria();
        cocina = new Cocina();

        Debug.Log("Jugador " + nombreJugador + " listo para explorar el mundo.");
    }

    void Update() {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, 0, moveZ) * Time.deltaTime * 5);

        if (Input.GetKeyDown(KeyCode.P)) pesca.Pescar();
        if (Input.GetKeyDown(KeyCode.C)) caceria.Cazar();
        if (Input.GetKeyDown(KeyCode.R)) RecolectarRecurso("seta_lunar");
        if (Input.GetKeyDown(KeyCode.O)) cocina.Cocinar(inventario);
    }
}
```

### Controles:
- **WASD** - Movimiento
- **P** - Pescar
- **C** - Cazar
- **R** - Recolectar recursos
- **O** - Cocinar

---

## 🚀 Características principales

✨ **Sistema de Clanes** - Forma alianzas y construye bases  
⚔️ **Armas Evolucionables** - 6 niveles de mejora  
🌑 **Eventos Dinámicos** - Sorpresas constantes  
🧩 **Profesiones Variadas** - 5 caminos de especialización  
🌍 **Mundo Abierto** - 4 regiones por explorar  
🎯 **Ciclo Día/Noche** - Clima dinámico  
🐟🦌🍳 - Sistemas de recolección y cocina mágica  

---

## 📋 Requisitos

- **Unity** 2020+
- **C#** 8.0+

---

## 📝 Licencia

Este proyecto está abierto para exploración y desarrollo.

---

**¡Bienvenido al mundo del MMORPG! Que comience tu aventura épica.** ⚔️✨
