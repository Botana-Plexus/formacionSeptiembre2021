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

--esta tabla contiene los modelos de partida que puede haber, con todos sus par�metros de 
create table tableros
(
  id int primary key,
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
insert into tiposCasillas values (7,'castigar') --no se define la casilla donde se sufre el castigo, ser� un estado del jugador
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
  costeEdificacion int null,
  precioVentaEdificacion int null,
  Coste1 int null,
  Coste2 int null,
  Coste3 int null,
  Coste4 int null,
  Coste5 int null,
  Coste6 int null,
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
  estado int not null, --estado de la partida, indica si est� creada(1) o iniciada (2). No s eespecifica el 3 - finalizada, porque se eliminara
  tablero int not null references tableros(id)
)

create table jugadores
(
  id int identity(1,1) primary key,
  idUsuario int null references usuarios(id),
  idPartida int not null references partidas(id), 
  saldo int not null,
  orden int not null, -- el orden en el turno. orden 0 = no tiene orden, por lo que es observador
  posicion int null references casillas(id), -- casilla sobre la que esta situado el jugador. el numero de casilla esta en casilla
  dobles int not null, --cantidad de dobles consecutivos sacados por el jugador. Al tercer doble, deber�a ser castigado
  turnosDeCastigo int not null, --cantidad de turnos que le quedan de castigo. comienza en 0
  deuda int not null, --cantidad qeu debe un jugador. No podra hacer nada hasta que la pague. comienza con 0
  acreedor int null references jugadores(id) --a quien le debe el jugador. Si tiene deuda y acreedor es nulo, entonces es con la banca
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
  texto varchar(500) not null,
  valor int not null --debe ser interpretado en base al tipo
)

go
/*
Autor: Alberto Botana
fecha: 20210927
registra un usuario, se asume que la contrase�a ya viene encriptada
*/

create procedure registrar
  @email varchar(255), @nick varchar(255), @pass varchar(255), @fechaNac datetime
as 
	insert into usuarios (email, nick, pass, fechaNacimiento) values (@email, @nick, @pass,@fechaNac)



go
/*
Autor: Alberto Botana
fecha: 20210927
autentica un usuario. Simplemente valida que el usuario es v�lido o no. Ser�a responsabilidad de la aplicaci�n 
garantizar que el usuario sigue siendo el mismo durante toda la sesi�n, pero no se va a implementar
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

  insert into jugadores (idUsuario, idPartida, saldo, orden,dobles,turnosDeCastigo, deuda) values (@admin, @idPartida, @saldo, 0,0,0,0)



go
/*
Autor: Alberto Botana
fecha: 20210928
descripcion: a�ade un jugador a la partida. Si el idusuario es ulo, entonces ser� un bot
*/

create procedure anadirJugador
  @idUsuario int,
  @idPartida int,
  @pass varchar(255)
as
  declare @maxJugadores int
  declare @numJugadores int
  declare @saldo int
  declare @tablero int

  
  begin tran
    select @maxJugadores = case  when maxJugadores is null then 6 else maxJugadores end, @numJugadores = numJugadores, @tablero = tablero 
	  from partidas 
	  where id = @idPartida and (pass is null or pass = @pass)

    if (@@ROWCOUNT = 0 ) begin rollback select 1,'partida inexistente o sin permisos' return end

	select @saldo = importe from tableros where id = @tablero

    if (@numJugadores < @maxJugadores)   
      begin
	    insert into jugadores (idUsuario, idPartida, saldo, orden, dobles,turnosDeCastigo, deuda) values (@idUsuario, @idPartida, @saldo,0,0,0,0)
	    update partidas set numJugadores = numJugadores + 1 where id = @idPartida
	  end
  commit
  select 0,'ok'


go

/*
Autor: Alberto Botana
fecha: 20210928
descripcion: inicia una partida
*/
create procedure ComenzarPartida
  @idPartida int
as
  declare @orden int

  select @orden = min(id) from jugadores where idPartida = @idPartida 

  update jugadores set orden = id, posicion = 1 where idPartida = @idPartida
  update partidas set estado = 2, fechaInicio = getdate(), turno = @orden where id = @idPartida

go


/*
Autor: Alberto Botana
fecha: 20210928
descripci�n: actualiza el nivel de construccion de un determinado tipo que tiene un jugador
version 1: por simplicidad, se asume que solo va a haber un grupo por cada nivel
*/
create procedure actualizarNivelConstruccion
  @idJugador int,
  @tipo int --el tipo solo puede ser 3 o 4
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
descripci�n: compra la casilla en la que est� el jugador. Se valida que la casilla no este vendida
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
	
	if not exists (select * from propiedades where partida = @partida and casilla = @idCasilla) --entonces es que est� sin vender
	begin
      begin tran
	    insert into propiedades (jugador, partida, casilla, nivelEdificacion) values (@idJugador, @partida, @idCasilla, 0)
		update jugadores set saldo = saldo -@importe where id = @idJugador
	  commit
	
	  if(@tipoCasilla in (3,4))
	    exec actualizarNivelConstruccion @idJugador, @tipoCasilla
	  
	  select 0,'ok'
	end
	else select 1,'casilla ya comprada'
	
go


/*
Autor: Alberto Botana
fecha: 20210928
descripci�n: vende a casilla indicada y recalcula posibles edificaciones. Se valida que se apropiedad del jugador
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
  if(@tipo in (3,4))
    exec actualizarnivelConstruccion @idJugador, @tipo

  select 0,'ok'

  go


 /*
 Autor: Pablo Costa
 fecha: 20210929
 descripcion: Devuelve la informaci�n de las partidas existentes
*/

create procedure getPartidas
  @id int=null
as
  select id, nombre,maxJugadores,maxTiempo,datediff(mi,fechaInicio,getdate()) as tiempoTranscurrido,
    case when pass is not null then 1 else 0 end as tienePass, numJugadores,turno,estado,tablero from partidas
  where @id is null or @id = id 
  select * from partidas

go

/*
Autor: Alberto Botana
fecha: 20210929
descripci�n: devuelve un listado de los tableros disponibles
*/
create procedure getTableros
as
  select id, descripcion, importe, numCasillas from tableros

go
/*
 Autor: Pablo Costa
 fecha: 20210929
 descripcion: Devuelve la informaci�n de las plantillas existentes
*/
go
alter procedure getCasillas
  @idTablero int
as
  select id, tipo, nombre, orden, precioCompra, precioVenta, costeEdificacion, precioVentaEdificacion, Coste1,
    Coste2, Coste3, Coste4, Coste5, Coste6, conjunto, destino 
  from casillas 
  where tablero = @idTablero
go 


 /*
 Autor: Pablo Costa
 fecha: 20210929
 descripcion: Devuelve la informaci�n de los jugadores de una partida
*/
create procedure getJugadoresInfo
	@idPartida int
as
  select id, idUsuario,idPartida,saldo,orden,posicion, dobles, turnosDeCastigo
  from jugadores where idPartida = @idPartida

go

/*
 Autor: Pablo Costa
 fecha: 20210929
 descripcion: Retira de la partida a un jugador
*/
create procedure retirarJugador
	@idJugador int
as
--pendiente validar deuda, si debe algo a un jugador cuando se retira, hay que abonarselo
	declare @idPartida int
	declare @deuda int
	declare @acreedor int

	update jugadores set orden = 0 where id = @idJugador
	select @deuda = deuda, @acreedor = acreedor from jugadores where id = @idJugador

	if @acreedor is not null update jugadores set saldo = saldo + @deuda where id = @acreedor

	delete from propiedades where jugador = @idJugador

	select @idPartida =idPartida from jugadores where id=@idJugador

	update partidas set numJugadores = (numJugadores-1) where id = @idPartida


go



/*
 Autor: Pablo Costa
 fecha: 20210929
 descripcion: Abandona el jugador la partida definitivamente
*/

create procedure abandonarPartida
	@idJugador int
as
	declare @orden int
	declare @idPartida int

	select  @orden = orden from jugadores where id = @idJugador

	if @orden = 0
		delete from jugadores where id = @idJugador

	--select @idPartida =idPartida from jugadores where id=@idJugador

	go



/*
autor: Alberto Botana
fecha: 20210929
descripci�n: realiza el movimiento de un jugador, calcula a que posici�n debe ir, 
se considera movimiento negativo, pero nunca de forma que pueda provocar retroceder antes de la salida
no s erealizan acciones relativas a la casilla en la que se ha caido
*/
create procedure mover
  @idJugador int,
  @tirada int
as
  declare @nuevaPosicion int
  declare @nuevaCasilla int
  declare @idCasilla int
  declare @idPartida int
  declare @numCasillas int
  declare @bonificacionVuelta int
  declare @tablero int



  select @idCasilla = posicion, @idPartida = idPartida from jugadores where id = @idJugador
  select @tablero = tablero from partidas where id = @idPartida
  select @numCasillas = numCasillas from tableros where id = @tablero
  select @nuevaPosicion = orden + @tirada from casillas where id = @idCasilla
  if ( @nuevaPosicion > @numCasillas)
  begin
    set @nuevaPosicion = @nuevaPosicion - @numCasillas --es que se ha dado una vuelta
	select @bonificacionVuelta = precioCompra from casillas where tablero = @tablero and tipo = 1 and orden = 1 --esto es incorrecto, habr�a que consultar si se pasa por encima de una casilla de tipo salida
	update jugadores set saldo = saldo + @bonificacionVuelta where id = @idJugador -- en caso de dar vuelta se suma el saldo
  end

  select @nuevaCasilla = id from casillas where orden = @nuevaPosicion and tablero = @tablero
  update jugadores set posicion = @nuevaCasilla where id = @idJugador

  select @idCasilla, 'movido a la casilla '+cast (@nuevaCasilla as varchar(255))+ ' con orden ' + cast(@nuevaPosicion as varchar(255))

go


/*
Autor: Alberto Botana
fecha: 20210929
descripcion: realiza la edificaci�n de una casa. Se valida que el usuario tenga todo el conjunto de casillas en propiedad, y entonces permite subir 
un nivel de edificacion bajando el coste correspondiente
*/
create procedure edificar
  @idJugador int,
  @idCasilla int
as
  declare @conjunto int 
  declare @tablero  int
  declare @tipo int
  declare @coste int
  declare @nivelActual int
  
  select @conjunto = conjunto, @tablero = tablero, @tipo = tipo, @coste = costeEdificacion from casillas where id = @idCasilla

  if @tipo <> 2 begin select 2,'no es edificable' return end
  if exists (select id from jugadores where id = @idJugador and saldo < @coste) begin select 3,'saldo insuficiente' return end

  if exists ( select a.id from casillas a left join propiedades b on a.id = b.casilla
  where a.tablero = @tablero and conjunto = @conjunto and (b.jugador is null or b.jugador <> @idJugador)) 
  begin
    select 1,'no es propitario de todo el conjunto'
	return
  end
  
  select @nivelActual = nivelEdificacion from propiedades where casilla = @idCasilla and jugador = @idJugador
  
  if @nivelActual = 5 begin select 4,'nivel m�ximo alcanzado' return end

  update propiedades set nivelEdificacion = nivelEdificacion + 1 where jugador = @idJugador and casilla = @idCasilla
  update jugadores set saldo = saldo - @coste where id = @idJugador

  select 0,'ok'

  go

 /*
Autor: Alberto Botana
fecha: 20210929
descripcion: vend un nivel de edificacion recuperando el importe correspondiente
*/
create procedure venderEdificacion
  @idJugador int,
  @idCasilla int
as
  declare @importe int

  select @importe = precioVentaEdificacion from casillas where id = @idCasilla

  if not exists (select id from propiedades where jugador = @idJugador and nivelEdificacion > 0) 
  begin select 1,'no se puede quitar' return end

  update propiedades set nivelEdificacion = nivelEdificacion -1 where casilla = @idCasilla
  update jugadores set saldo = saldo + @importe where id = @idJugador

  select 0,'ok'

go


/*
autor: Alberto Botana
fecha: 20210930
descripcion: permite registrar cuantos dobles lleva el usuario. Se sumar� 1 por cada invocacion, y si se quiere resetear hay que 
a�adir 1 como sgundo parametro (reset)
*/
create procedure setDobles
  @idJugador int,
  @reset int = 0
as
  update jugadores set dobles = case when @reset = 1 then 0 else dobles + 1 end
  where id = @idJugador

go


/*
Autor: alberto Botana
fecha: 20210930
descripci�n: devuelve el listado d elas propiedades de un jugador
*/
create procedure getPropiedades
  @idJugador int
as
  select b.id, b.tipo, b.tablero, b.nombre, b.orden, b.precioCompra, b.precioVenta, b.costeEdificacion, b.precioVentaEdificacion,
    b.Coste1, b.Coste2, b.Coste3, b.Coste4, b.Coste5, b.Coste6, b.conjunto, b.destino, a.nivelEdificacion
  from propiedades a left join casillas b on a.casilla = b.id
  where a.jugador = @idJugador

go

/* datos para pruebas
insert into tableros values (1,'clasico',100000,3)
insert into casillas (nombre, tipo, tablero, orden, precioCompra, precioventa) values ('salida',1,1,1,20000,10000)
insert into casillas (nombre, tipo, tablero, orden, precioCompra, precioventa) values ('estacion1',3,1,2,20000,10000)
insert into casillas (nombre, tipo, tablero, orden, precioCompra, precioventa) values ('estacion3',3,1,3,20000,10000)
exec registrar 'alberto.botanafidalgo@plexus.es','botana','1234','19770620'
exec registrar 'alberto@plexus.es','botana2','1234','19770620'
exec crearPartida 'partida1',1,4,null,'1234',1 
exec anadirJugador 2,1,'1234'
exec anadirJugador null,1,'1234'
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

/*Prueba de a�adir Jugador
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
select * from partidas
select * from tableros
*/

/*
exec getPartidas
exec getTableros
exec getCasillas 1
exec getJugadoresInfo 1
*/

/*
update  jugadores set deuda = 20010, acreedor = 3 where id = 1
exec retirarJugador 1
exec abandonarPartida 2
exec abandonarPartida 1

*/

/* pruebas movimiento
select * from jugadores
mover 1,1
select * from jugadores
mover 1,1
select * from jugadores

mover 1,1
select * from jugadores
*/

/*
exec getPropiedades 4
*/
jas