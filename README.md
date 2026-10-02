# 🌌 MMORPG - Videojuego de Mundo Abierto

Un MMORPG basado en Unity con C# que combina exploración, recursos, clanes, eventos dinámicos, producción, combate básico y una estructura jugable lista para expandirse.

## 🎮 Qué incluye esta versión

- Movimiento del personaje con WASD
- Cámara 3ª persona
- Sistema de combate básico contra enemigos
- Inventario de recursos e ítems
- Producción de objetos: pesca, caza, cocina, herrería
- Generación de regiones del mundo
- HUD de salud, energía e inventario
- Enemigos que persiguen al jugador

---

## ▶️ Cómo abrirlo en Unity

1. Abre Unity Hub.
2. Crea un proyecto 3D nuevo.
3. Clona o importa este repositorio al proyecto.
4. En la escena, crea un GameObject vacío llamado `GameBootstrap`.
5. Añade el script `GameBootstrap`.
6. En la jerarquía crea un objeto llamado `Jugador` y añade el script `PlayerController`.
7. Añade también `CameraFollow` a la cámara principal y arrastra al jugador como objetivo.
8. Pulsa `Play`.

---

## 🧩 Controles

- WASD: movimiento
- Click izquierdo: atacar
- P: pescar
- C: cazar
- K: cocinar
- H: forjar arma
- E: explorar regiones

---

## 🔧 Scripts principales

- `Assets/Scripts/GameBootstrap.cs`
- `Assets/Scripts/PlayerController.cs`
- `Assets/Scripts/CameraFollow.cs`
- `Assets/Scripts/Combat/EnemyAI.cs`
- `Assets/Scripts/Combat/CombatSystem.cs`
- `Assets/Scripts/Inventory/InventorySystem.cs`
- `Assets/Scripts/UI/GameHUD.cs`
- `Assets/Scripts/World/WorldGenerator.cs`

---

## 🧠 Estado actual

Esta versión ya es una base de juego jugable y lista para continuar ampliando con:

- NPCs
- misiones
- interfaz de menú
- sonidos
- inventario visual
- combate con habilidades
- mundo más grande
- sistema multijugador

---

## 🚀 Próximo paso recomendado

El siguiente nivel será añadir:

- minimapa
- barra de vida visual
- inventario con UI
- sistema de misiones
- Clanes y alianzas
- NPCs con diálogos
- mundo persistente

**¡La base ya está funcionando como un juego experimental en Unity!**🎮
