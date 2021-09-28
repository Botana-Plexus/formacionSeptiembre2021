/*

use master
drop database botanapoly
create database botanapoly
use botanapoly
*/

create table usuarios
(
  id int identity (1,1) primary key,
  email varchar(255) not null,
  nick varchar(255) not null,
  pass varchar(255) not null,
  fechaNacimiento datetime not null
)

--esta tabla contiene los modelos de partida que puede haber, con todos sus parámetros de 
create table tableros
(
  id int identity(1,1) primary key,
  descripcion varchar(255) not null,
  importe int not null, --cantidad de dinero al iniciar
  numCasillas int not null
)

create table tiposCasillas
(
  id int primary key,
  descripcion varchar(255) not null
)

insert into tiposCasillas values (1,'salida')
insert into tiposCasillas values (2,'propiedad')
insert into tiposCasillas values (3,'compania')
insert into tiposCasillas values (4,'infraestructura')
insert into tiposCasillas values (5,'cartaSorpresa')
insert into tiposCasillas values (6,'neutra')
insert into tiposCasillas values (7,'castigar') --no se define la casilla donde se sufre el castigo, será un estado del jugador
insert into tiposCasillas values (8,'pago')

create table casillas
(
  id int identity(1,1) primary key,
  tipo int not null references tiposCasillas(id),
  tablero int not null references tableros(id),
  nombre varchar(255) not null,
  orden int not null, --orden dentro del tablero. debe comenzar en 1 y solo puede haber una 1, aunque se podria repetir algun orden
  precioCompra int null,
  precioVenta int null,
  nivelEdificación int null,
  costeEdificación int null,
  precioVentaEdificación int null,
  Coste1 int null,
  Coste2 int null,
  Coste3 int null,
  Coste4 int null,
  Coste5 int null,
  conjunto int null,
  destino int null --casilla destino para castigo, por ejemplo
)


create table partidas
(
  id int identity(1,1) primary key,
  nombre varchar(255) not null unique,
  administrador int null references usuarios (id),
  maxJugadores int null, --si no se especifica, es 6
  maxTiempo int null, --si no se especifica, no tiene ( en minutos)
  fechaInicio datetime null, --sera nulo hasta que se inicie
  pass varchar(255) null, --la clave de la partida, solo si tiene
  numJugadores int not null, --numero de jugadores actual de la partida
  turno int not null, --numero de orden del jugador que tenga el turno
  estado int not null, --estado de la partida, indica si está creada(1) o iniciada (2). No s eespecifica el 3 - finalizada, porque se eliminara
  tablero int not null references tableros(id)
)

create table jugadores
(
  id int identity(1,1) primary key,
  idUsuario int not null references usuarios(id) unique,
  idPartida int not null references partidas(id), 
  saldo int not null,
  orden int not null, -- orden 0 = no tiene orden, por lo que es observador
  posicion int null references casillas(id) -- casilla sobre la que esta situado el jugador.
)

create table propiedades
(
  id int identity(1,1) primary key,
  jugador int not null references jugadores(id),
  partida int not null references partidas(id),
)

create table tiposCartas
(
  id int primary key,
  descripcion varchar(255) not null
)

insert into tiposCartas values (1,'incremento')
insert into tiposCartas values (2,'decremento')
insert into tiposCartas values (3,'movimiento')
insert into tiposCartas values (4,'castigo')

create table cartas
(
  id int identity(1,1) primary key,
  tablero int not null references tableros(id),
  conjunto int not null, --conjunto al que pertenece
  tipo int not null references tiposCartas(id),
  valor int not null --debe ser interpretado en base al tipo
)

go
/*
Autor: Alberto Botana
fecha: 20210927
registra un usuario, se asume que la contraseña ya viene encriptada
*/

create procedure registrar
  @email varchar(255), @nick varchar(255), @pass varchar(255), @fechaNac datetime
as 
	insert into usuarios (email, nick, pass, fechaNacimiento) values (@email, @nick, @pass,@fechaNac)



go
/*
Autor: Alberto Botana
fecha: 20210927
autentica un usuario. Simplemente valida que el usuario es válido o no. Sería responsabilidad de la aplicación 
garantizar que el usuario sigue siendo el mismo durante toda la sesión, pero no se va a implementar
*/
create procedure autenticar
  @email varchar(255), @pass varchar(255)
as
	if exists (select top 1 email from usuarios where email = @email and pass = @pass) 
	select 0,'autenticado'
	else select 1,'no autenticado'

GO

/*
Autor: Alberto Botana
fecha: 20210928
descripcion: permite la generacion de una partida nueva con todos los parametros correctamaente inicializados
*/
create procedure crearPartida
  @nombre varchar(255),
  @admin int,
  @maxJugadores int,
  @maxTiempo int, --en minutos
  @pass varchar(255),
  @tablero int
as
  declare @idPartida int
  declare @saldo int
  
  insert into partidas (nombre, administrador, maxJugadores, maxTiempo, fechaInicio, pass, numJugadores, turno, estado,tablero)
	values (@nombre, @admin, @maxJugadores, @maxTiempo, getdate(), @pass, 1,0,1, @tablero)

  set @idPartida = @@IDENTITY
  select @saldo = importe from tableros where id = @tablero

  insert into jugadores (idUsuario, idPartida, saldo, orden) values (@admin, @idPartida, @saldo, 0)



go
/*
Autor: Alberto Botana
fecha: 20210928
descripcion: añade un jugador a la partida
*/

create procedure anadirJugador
  @idUsuario int,
  @idPartida int
as
  declare @maxJugadores int
  declare @numJugadores int
  declare @saldo int
  declare @tablero int

  
  begin tran
    select @maxJugadores = maxJugadores, @numJugadores = numJugadores, @tablero = tablero from partidas where id = @idPartida
	select @saldo = importe from tableros where id = @tablero

    if (@numJugadores < @maxJugadores)   
      begin
	    insert into jugadores (idUsuario, idPartida, saldo, orden) values (@idUsuario, @idPartida, @saldo,0)
	    update partidas set numJugadores = numJugadores + 1 where id = @idPartida
	  end
  commit


go

/*
Autor: Alberto Botana
fecha: 20210928
descripcion: inicia una partida
*/
create procedure ComenzarPartida
  @idPartida int
as

  update jugadores set orden = idUsuario, posicion = 1 where idPartida = @idPartida
  update partidas set estado = 2 where id = @idPartida



/* prueba de registro
exec registrar 'alberto.botanafidalgo@plexus.es','botana','1234','19770620'
exec registrar 'alberto@plexus.es','botana2','1234','19770620'
select * from usuarios
*/

/* prueba de autenticar
autenticar 'sdfdfsdf','dsfafdsf'
autenticar 'alberto.botanafidalgo@plexus.es','1234'
*/

/* prueba de crear partida
insert into tableros values ('clasico',100000,40)
insert into casillas (nombre, tipo, tablero, orden, coste1) values ('salida',1,1,1,20000)
select * from tableros
select * from casillas
exec crearPartida 'partida1',1,4,null,null,1 
select * from partidas
select * from jugadores
*/

/*Prueba de añadir Jugador
select * from partidas
exec anadirJugador 2,1
select * from partidas
select * from jugadores
*/


/* prueba de comenzarPartida
select * from partidas
exec comenzarPartida 1
select * from partidas
select * from jugadores where idpartida = 1
*/