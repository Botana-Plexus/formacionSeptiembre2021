# PROYECTO FINAL FORMACION PLEXUS:
## Botanapoly API v1.0.0 (como el monopoly, pero mejor).
![Texto alternativo](botanapoly.jpg)
### 
## Tecnologias usadas:
* SQL Server para la base de datos.
* ASP.Net con C# para el backend.

# Entidades y sus metodos:

## 1. Usuario:
* Modelo: UsuarioModeloDto
```
{
  "id": int,
  "email": "string",
  "nick": "string",
  "password": "string",
  "fechaNacimiento": Datetime
}
```
* Controlador Metodos: UsuarioController
    * Registro uausario.   ✅
    * Login de usuario.   ✅

## 2. Jugador:

* Modelo: JugadorModeloDto
```
{
  "id": int,
  "idUsuario": int,
  "idPartida": int,
  "saldo": int,
  "orden": int,
  "posicion": int
}
```
* Controlador Metodos: JugadorController
    * Agregar jugador a la partida.   ✅
    * Crear bot a la partida.   ✅

## 3. Partida:

* Modelo: PartidaModeloDto
```
{
  "id": int,
  "nombre": "string",
  "administrador": int,
  "maxJugadores": int,
  "maxTiempo": int,
  "fechaInicio": Datetime,
  "pass": "string",
  "numJugadores": int,
  "turno": int,
  "estado": int,
  "tablero": int
}
```
* Controlador Metodos: PartidaController
    * Crear partida.   ✅
    * Comenzar partida.   ✅


