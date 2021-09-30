/*

use master
drop database botanapoly
create database botanapoly
use botanapoly
drop login pruebas
create login pruebas with password = 'pruebas', default_database = botanapoly, check_policy = off
*/


CREATE USER pruebas FOR LOGIN pruebas WITH DEFAULT_SCHEMA=db_owner
ALTER ROLE db_owner ADD MEMBER pruebas


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
  nivelEdificacion int null,
  costeEdificacion int null,
  precioVentaEdificacion int null,
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
  idUsuario int null references usuarios(id) unique,
  idPartida int not null references partidas(id), 
  saldo int not null,
  orden int not null, -- el orden en el turno. orden 0 = no tiene orden, por lo que es observador
  posicion int null references casillas(id) -- casilla sobre la que esta situado el jugador. el numero de casilla esta en casilla
)

create table propiedades
(
  id int identity(1,1) primary key,
  jugador int not null references jugadores(id),
  partida int not null references partidas(id),
  casilla int not null references casillas(id),
  nivelEdificacion int null --nivel de edificacion de la casilla si procede, si no, null
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
	values (@nombre, @admin, @maxJugadores, @maxTiempo, null, @pass, 1,0,1, @tablero)

  set @idPartida = @@IDENTITY
  select @saldo = importe from tableros where id = @tablero

  insert into jugadores (idUsuario, idPartida, saldo, orden) values (@admin, @idPartida, @saldo, 0)



go
/*
Autor: Alberto Botana
fecha: 20210928
descripcion: añade un jugador a la partida. Si el idusuario es ulo, entonces será un bot
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
  update partidas set estado = 2, fechaInicio = getdate() where id = @idPartida

go


/*
Autor: Alberto Botana
fecha: 20210928
descripción: actualiza el nivel de construccion de un determinado tipo que tiene un jugador
version 1: por simplicidad, se asume que solo va a haber un grupo por cada nivel
*/
create procedure actualizarNivelConstruccion
  @idJugador int,
  @tipo int --el tipo solo puede ser 2 o 3
as
  declare @cantidad int

  select @cantidad = count(*) from propiedades a left join casillas b on a.casilla = b.id
  where b.tipo = @tipo and a.jugador = @idJugador
  
  update propiedades set nivelEdificacion = @cantidad where casilla in ( select id from casillas where tipo = @tipo)
  and jugador = @idJugador


go
/*
Autor: Alberto Botana
fecha: 20210928
descripción: compra la casilla en la que está el jugador. Se valida que la casilla no este vendida
*/
create procedure comprar
  @idJugador int
as 
	declare @idCasilla int
	declare @partida int
	declare @saldo int
	declare @importe int
	declare @tipoCasilla int
	declare @nivelEdificacion int  

	select @partida = idPartida, @idCasilla = posicion, @saldo = saldo from jugadores where id = @idJugador
	select @importe = precioCompra, @tipoCasilla = tipo from casillas where id = @idCasilla
	--validacion del saldo
	
	if (@saldo < @importe) begin select 1,'saldo insuficiente' return end --si no tien saldo se sale
	
	if not exists (select * from propiedades where partida = @partida and casilla = @idCasilla) --entonces es que está sin vender
	begin
      begin tran
	    insert into propiedades (jugador, partida, casilla, nivelEdificacion) values (@idJugador, @partida, @idCasilla, 0)
		update jugadores set saldo = saldo -@importe where id = @idJugador
	  commit
	
	  exec actualizarNivelConstruccion @idJugador, @tipoCasilla
	  select 0,'ok'
	end
	else select 1,'casilla ya comprada'
	
go


/*
Autor: Alberto Botana
fecha: 20210928
descripción: vende a casilla indicada y recalcula posibles edificaciones. Se valida que se apropiedad del jugador
*/
create procedure vender
  @idJugador int,
  @casilla int
as
  declare @partida int
  declare @precioVenta int
  declare @tipo int
  
  select @partida= idPartida from jugadores where id = @idJugador
  
  if not exists (select * from propiedades where partida = @partida and jugador = @idJugador)
  begin select 1,'casilla no es propiedad del jugador' return end

  select @precioVenta = precioVenta, @tipo = tipo  from casillas where id = @casilla
  begin tran
    update jugadores set saldo = saldo + @precioVenta where id = @idJugador
	delete from propiedades where casilla = @casilla
  commit

  exec actualizarnivelConstruccion @idJugador, @tipo

  go

/* datos para pruebas
insert into tableros values ('clasico',100000,40)
insert into casillas (nombre, tipo, tablero, orden, precioCompra, precioventa) values ('salida',1,1,1,20000,10000)
insert into casillas (nombre, tipo, tablero, orden, precioCompra, precioventa) values ('estacion1',3,1,2,20000,10000)
insert into casillas (nombre, tipo, tablero, orden, precioCompra, precioventa) values ('stacion3',3,1,1,20000,10000)
exec registrar 'alberto.botanafidalgo@plexus.es','botana','1234','19770620'
exec registrar 'alberto@plexus.es','botana2','1234','19770620'
exec crearPartida 'partida1',1,4,null,null,1 
exec anadirJugador 2,1
exec comenzarPartida 1
*/

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

/* prueba actualizarNivelConstruccion
select * from propiedades
insert into propiedades values (1,1,2,0)
insert into propiedades values (1,1,3,0)
exec actualizarNivelConstruccion 1,3
delete from propiedades 
select * from propiedades
*/

/*
prueba para comprar
select * from jugadores
update jugadores set posicion  =2 where id = 1
exec comprar 1
update jugadores set posicion  =3 where id = 1
exec comprar 1
select * from jugadores
select * from propiedades
select * from casillas
*/

/*pruebas venta
select * from jugadores
select * from propiedades
select * from casillas
exec vender 1,2
select * from jugadores
select * from propiedades
select * from casillas
*/
VAMOS RAFA!
