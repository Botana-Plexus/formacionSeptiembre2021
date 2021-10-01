/*
use master
drop database botanapoly_Botana
create database botanapoly_Botana
use botanapoly_Botana
drop login pruebas
create login pruebas with password = 'pruebas', default_database = botanapoly_Botana, check_policy = off
*/


CREATE USER pruebas FOR LOGIN pruebas WITH DEFAULT_SCHEMA=db_owner
ALTER ROLE db_owner ADD MEMBER pruebas


create table usuarios
(
  id int identity (1,1) primary key,
  email varchar(255) not null unique,
  nick varchar(255) not null unique,
  pass varchar(255) not null,
  fechaNacimiento datetime not null
)

--esta tabla contiene los modelos de partida que puede haber, con todos sus parámetros de 
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
  estado int not null, --estado de la partida, indica si está creada(1) o iniciada (2). No s eespecifica el 3 - finalizada, porque se eliminara
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
  dobles int not null, --cantidad de dobles consecutivos sacados por el jugador. Al tercer doble, debería ser castigado
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

  insert into jugadores (idUsuario, idPartida, saldo, orden,dobles,turnosDeCastigo, deuda) values (@admin, @idPartida, @saldo, 0,0,0,0)



go
/*
Autor: Alberto Botana
fecha: 20210928
descripcion: añade un jugador a la partida. Si el idusuario es ulo, entonces será un bot
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

		  select 0,'ok'
	  end
	else
		select 1,'Partida completa'
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
  declare @orden int

  select @orden = min(id) from jugadores where idPartida = @idPartida 

  update jugadores set orden = id, posicion = 1 where idPartida = @idPartida
  update partidas set estado = 2, fechaInicio = getdate(), turno = @orden where id = @idPartida

go


/*
Autor: Alberto Botana
fecha: 20210928
descripción: actualiza el nivel de construccion de un determinado tipo que tiene un jugador
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
	
	if @tipoCasilla = 2 and @tipoCasilla = 3 and @tipoCasilla = 4
		begin
			if (@saldo < @importe) begin select 1,'saldo insuficiente' return end --si no tien saldo se sale
	
			if not exists (select * from propiedades where partida = @partida and casilla = @idCasilla) --entonces es que está sin vender
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
		end
	
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
  
  if not exists (select * from propiedades where partida = @partida and jugador = @idJugador and casilla = @casilla)
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
 descripcion: Devuelve la información de las partidas existentes
*/

create procedure getPartidas
  @id int=null
as
  select id, nombre,maxJugadores,maxTiempo,datediff(mi,fechaInicio,getdate()) as tiempoTranscurrido,
    case when pass is not null then 1 else 0 end as tienePass, numJugadores,turno,estado,tablero from partidas
  where @id is null or @id = id 



/*
Autor: Alberto Botana
fecha: 20210929
descripción: devuelve un listado de los tableros disponibles
*/
go
create procedure getTableros
as
  select id, descripcion, importe, numCasillas from tableros

/*
 Autor: Pablo Costa
 fecha: 20210929
 descripcion: Devuelve la información de las plantillas existentes
*/
go
create procedure getCasillas
  @idTablero int = null,
  @idCasilla int = null
as

	if ISNULL(@idCasilla,0)!=0
		begin
			select c.id, c.tipo, c.nombre, c.orden, c.precioCompra, c.precioVenta, c.costeEdificacion, c.precioVentaEdificacion, c.Coste1,
				c.Coste2, c.Coste3, c.Coste4, c.Coste5,c.Coste6, c.conjunto, c.destino,p.jugador 
			from casillas c left join propiedades p on c.id = p.casilla
			where c.id= @idCasilla
		end
	else if ISNULL(@idTablero,0)!=0
		begin 
			select c.id, c.tipo, c.nombre, c.orden, c.precioCompra, c.precioVenta, c.costeEdificacion, c.precioVentaEdificacion, c.Coste1,
				c.Coste2, c.Coste3, c.Coste4, c.Coste5,c.Coste6, c.conjunto, c.destino,p.jugador 
			from casillas c left join propiedades p on c.id = p.casilla
			where c.tablero = @idTablero
		end


 /*
 Autor: Pablo Costa
 fecha: 20210929
 descripcion: Devuelve la información de los jugadores de una partida
*/
go
create procedure getJugadoresInfo
	@idPartida int
as
  select id, idUsuario,idPartida,saldo,orden,posicion, dobles, turnosDeCastigo,deuda,acreedor
  from jugadores where idPartida = @idPartida



/*
 Autor: Pablo Costa
 fecha: 20210929
 descripcion: Retira de la partida a un jugador
*/
go
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

	



/*
autor: Alberto Botana
fecha: 20210929
descripción: realiza el movimiento de un jugador, calcula a que posición debe ir, 
se considera movimiento negativo, pero nunca de forma que pueda provocar retroceder antes de la salida
no s erealizan acciones relativas a la casilla en la que se ha caido
*/
go
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
	select @bonificacionVuelta = precioCompra from casillas where tablero = @tablero and tipo = 1 and orden = 1 --esto es incorrecto, habría que consultar si se pasa por encima de una casilla de tipo salida
	update jugadores set saldo = saldo + @bonificacionVuelta where id = @idJugador -- en caso de dar vuelta se suma el saldo
  end

  select @nuevaCasilla = id from casillas where orden = @nuevaPosicion and tablero = @tablero
  update jugadores set posicion = @nuevaCasilla where id = @idJugador

  select @nuevaCasilla, 'movido a la casilla '+cast (@nuevaCasilla as varchar(255))+ ' con orden ' + cast(@nuevaPosicion as varchar(255))


/*
Autor: Alberto Botana
fecha: 20210929
descripcion: realiza la edificación de una casa. Se valida que el usuario tenga todo el conjunto de casillas en propiedad, y entonces permite subir 
un nivel de edificacion bajando el coste correspondiente
*/
go
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
  
  if @nivelActual = 5 begin select 4,'nivel máximo alcanzado' return end

  update propiedades set nivelEdificacion = nivelEdificacion + 1 where jugador = @idJugador and casilla = @idCasilla
  update jugadores set saldo = saldo - @coste where id = @idJugador

  select 0,'ok'



 /*
Autor: Alberto Botana
fecha: 20210929
descripcion: vend un nivel de edificacion recuperando el importe correspondiente
*/
go
create procedure venderEdificacion
  @idJugador int,
  @idCasilla int
as
  declare @importe int

  select @importe = precioVentaEdificacion from casillas where id = @idCasilla

  if not exists (select id from propiedades where jugador = @idJugador and nivelEdificacion > 0 and casilla = @idCasilla) 
  begin select 1,'no se puede quitar' return end

  update propiedades set nivelEdificacion = nivelEdificacion -1 where casilla = @idCasilla
  update jugadores set saldo = saldo + @importe where id = @idJugador

  select 0,'ok'

go
/*
autor: Alberto Botana
fecha: 20210930
descripcion: permite registrar cuantos dobles lleva el usuario. Se sumará 1 por cada invocacion, y si se quiere resetear hay que 
añadir 1 como sgundo parametro (reset)
*/
create procedure setDobles
  @idJugador int,
  @reset int = 0
as
	declare @dobles int
  update jugadores set dobles = case when @reset = 1 then 0 else dobles + 1 end
  where id = @idJugador

  select dobles from jugadores where id = @idJugador

  if @dobles = 3
	begin
		update jugadores set dobles = 0 where id = @idJugador
		exec castigar @idJugador
	end

  select 0, 'Número de dobles ', @dobles


/*
Autor: alberto Botana
fecha: 20210930
descripción: devuelve el listado de las propiedades de un jugador
*/
go
create procedure getPropiedades
  @idJugador int
as
  select b.id, b.tipo, b.tablero, b.nombre, b.orden, b.precioCompra, b.precioVenta, b.costeEdificacion, b.precioVentaEdificacion,
    b.Coste1, b.Coste2, b.Coste3, b.Coste4, b.Coste5, b.Coste6, b.conjunto, b.destino, a.nivelEdificacion
  from propiedades a left join casillas b on a.casilla = b.id
  where a.jugador = @idJugador

/*
Autores: Pablo Costa y Adrián García
fecha: 20210930
descripción: Actualiza la deuda de un jugador
*/
go 
create procedure actualizarDeuda
	@idJugador int,
	@idCarta int = null
as
	declare @idCasilla int
	declare @tipoCasilla int
	declare @nivelEdificacion int 
	declare @propietario int		

	select @idCasilla = posicion from jugadores where id = @idJugador
	select @tipoCasilla = tipo,@nivelEdificacion  =(p.nivelEdificacion+1),@propietario=p.jugador from casillas c left join propiedades p on p.casilla=c.id where c.id=@idCasilla

	if @idJugador != @propietario
		begin
			if ISNULL(@idCarta,0) != 0
				update jugadores set deuda = (select valor from cartas where id = @idCarta) where id = @idJugador
			else
				begin
					begin tran

						if @tipoCasilla = 2 or @tipoCasilla = 3 or @tipoCasilla = 4
							begin 
								exec('update jugadores set acreedor ='+@propietario+',deuda = (select coste'+@nivelEdificacion+' from casillas where id = '+@idCasilla+') where id = ' +@idJugador)
							end
						else if @tipoCasilla = 8
							update jugadores set deuda = (select precioCompra from casillas where id = @idCasilla) where id = @idJugador
					commit
				end
		end

/*
Autores: Pablo Costa y Adrián García
fecha: 20210930
descripción: Realiza pagos
*/

go
create procedure pagarDeuda
	@idJugador int
as

	declare @saldo int
	declare @acreedor int
	declare @deuda int

	select @saldo = saldo, @acreedor = acreedor, @deuda = deuda from jugadores where id = @idJugador

	if @saldo >= @deuda
		begin
			begin tran
				update jugadores set saldo = (saldo-@deuda),deuda = 0,acreedor = null where id = @idJugador
			
				if ISNULL(@acreedor,0) != 0
					update jugadores set saldo = (saldo + @deuda) where id = @acreedor
			commit
			select 0,'Pago realizado'
		end
	else
		select 1,'Saldo insuficiente'

/*
Autores: Pablo Costa y Adrián García
fecha: 20210930
descripción: Finalizar partida
*/
go 

create procedure finalizarPartida
	@idPartida int
as

	delete from propiedades where partida=@idPartida
	delete from jugadores where idPartida = @idPartida
	delete from partidas where id = @idPartida


/*
Autores: Pablo Costa y Adrián García
fecha: 20210930
descripción: Finalizar turno
*/
go 
create procedure finalizarTurno
	@idJugador int
as

	declare @nuevoTurno int
	declare @turnosCastigo int
	declare @idPartida int

	select @idPartida = idPartida from jugadores where id = @idJugador

	select @nuevoTurno = min(j.orden) from jugadores j left join partidas p on j.idPartida = p.id where orden > p.turno and idPartida = @idPartida

	if ISNULL(@nuevoTurno,0) = 0
		select @nuevoTurno =  min(orden) from jugadores where idPartida = @idPartida and orden !=0
	update partidas set turno = @nuevoTurno where id= @idPartida

	select @turnosCastigo = turnosDeCastigo from jugadores where id = @idJugador
	if @turnosCastigo !=0
		update jugadores set turnosDeCastigo = (turnosDeCastigo-1) where id = @idJugador


/*
Autores: Pablo Costa y Adrián García
fecha: 20210930
descripción: Devuelve el id de las cartas de cada casilla aleatoriamente
*/
go
create procedure getCartaAleatoria
	@idJugador int
as
	declare @tipo int
	declare @valor int
	declare @conjunto int
	declare @id int

	select top 1 @tipo = ct.tipo, @valor = ct.valor,@id = ct.id from jugadores j join casillas c on j.posicion = c.id join cartas ct on ct.conjunto = c.conjunto where ct.conjunto = c.conjunto order by NEWID()

	if @tipo = 1
		update jugadores set saldo = saldo + @valor where id = @idJugador

	select @id


/*
Autores: Pablo Costa y Adrián García
fecha: 20210930
descripción: Devuelve la info de una carta concreta
*/
go
create procedure getInfoCarta
	@idCarta int
as
	select id,texto,valor,tipo from cartas where id = @idCarta

/*
Autores: Pablo Costa y Adrián García
fecha: 20210930
descripción: Devuelve el turno
*/
go
create procedure getTurno
	@idJugador int
as
	declare @turnoActual int
	declare @orden int
	declare @turnosCastigo int
	declare @idPartida int


	select @orden = orden,@turnosCastigo = turnosDeCastigo,@idPartida = idPartida from jugadores where id = @idJugador
	select @turnoActual = turno from partidas where id = @idPartida

	if @orden = @turnoActual
		begin
			if @turnosCastigo != 0
				begin 
					exec finalizarTurno @idPartida, @idJugador
					select 2,'Sigues en la cárcel'
				end
			else
				select 1, 'Es tu turno'
		end
	else 
	select 0, 'No es tu turno'

/*
Autores: Pablo Costa y Adrián García
fecha: 20210930
descripción: Realiza un castigo a un jugador
*/

go 
create procedure castigar
	@idJugador int
as
	declare @idCasilla int
	declare @idPartida int
	declare @idTablero int

	select @idCasilla = posicion,@idPartida = idPartida from jugadores where id = @idJugador
	select @idTablero = p.tablero from partidas p left join (tableros t left join casillas c on t.id = c.tablero) on p.tablero = t.id where p.id = @idPartida

	update jugadores set turnosDeCastigo = 4, posicion = 
	(select id from casillas where orden = (select destino from casillas where id = @idCasilla and tablero =  @idTablero)) where id = @idJugador

/*
Segunda forma de actualizar deuda comprueba si una casilla tiene un propietario o no
*/
go
create procedure actualizarDeudaCompleta
	@idJugador int,
	@idCarta int = null
as
	declare @saldo int
	declare @idCasilla int
	declare @tipoCasilla int
	declare @nivelEdificacion int 
	declare @propietario int

	select @idCasilla = posicion from jugadores where id = @idJugador
	select @tipoCasilla = tipo, @nivelEdificacion = (p.nivelEdificacion+1), @propietario = p.jugador from casillas c left join propiedades p on p.casilla=c.id where c.id = @idCasilla

	if ISNULL(@idCarta,0) != 0
		begin
			update jugadores set deuda = (select valor from cartas where id = @idCarta) where id = @idJugador
			select 2, 'Deuda actualizada'
		end
	else
		begin
			begin tran
				if @tipoCasilla = 8
					begin
						update jugadores set acreedor = @propietario, deuda = (select precioCompra from casillas where id = @idCasilla) where id = @idJugador				
						select 2, 'Deuda actualizada'
					end
				else if @tipoCasilla = 2 or @tipoCasilla = 3 or @tipoCasilla = 4
					begin
						if ISNULL(@propietario,0) != 0
							begin
								if @propietario != @idJugador
									begin 
										exec('update jugadores set acreedor ='+@propietario+',deuda = (select coste'+@nivelEdificacion+' from casillas where id = '+@idCasilla+') where id = ' +@idJugador)
										select 2, 'Deuda actualizada'
									end
								else
								select 1, 'Eres el propietario'
							end
						else
							select 0, 'La casilla se puede comprar'
					end
			commit
		end


go
create procedure getTiempo
	@idPartida int
as
	declare @fechaInicio int
	declare @tiempoMax int

	select @fechaInicio = datediff(mi,fechaInicio,getdate()), @tiempoMax = maxTiempo from partidas where id = @idPartida

	select @tiempoMax-@fechaInicio

go
create procedure getMasRico
	@idPartida int
as
	select top 1 id,idUsuario,idPartida,saldo,orden,posicion,dobles,turnosDeCastigo,deuda,acreedor from jugadores
	order by saldo DESC



/* datos para pruebas
insert into tableros values (1,'clasico',100000,3)
insert into casillas (nombre, tipo, tablero, orden, precioCompra, precioventa) values ('salida',1,1,1,20000,10000)
insert into casillas (nombre, tipo, tablero, orden, precioCompra, precioventa) values ('estacion1',3,1,2,20000,10000)
insert into casillas (nombre, tipo, tablero, orden, precioCompra, precioventa) values ('estacion3',3,1,3,20000,10000)
exec registrar 'alberto.botanafidalgo@plexus.es','botana','1234','19770620'
exec registrar 'alberto@plexus.es','botana2','1234','19770620'
exec crearPartida 'partida1',1,4,null,'1234',2
exec anadirJugador 2,2,'1234'
exec anadirJugador null,2,'1234'
exec comenzarPartida 3


exec registrar 'alberto3o@plexus.es','botana3','1234','19770620'
exec registrar 'alberto4@plexus.es','botana4','1234','19770620'
exec crearPartida 'partida2',1,4,null,'1234',2
exec anadirJugador 2,1,'1234'
exec anadirJugador null,1,'1234'
exec comenzarPartida 1

select * from partidas
update partidas set maxTiempo = 1 where id = 1
select datediff(mi,fechaInicio,getdate()) from partidas where id = 1
select * from propiedades
select * from jugadores
select * from casillas where tablero = 2
insert into propiedades values(1,1,2,0)
insert into propiedades values(1,1,3,2)
insert into propiedades values(2,1,4,0)
vender 1,4
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
exec crearPartida 'partida7',1,4,null,null,2

select * from partidas
select * from jugadores
*/

/*Prueba de añadir Jugador
select * from partidas
exec anadirJugador 2,1, null
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
update jugadores set posicion  = 2 where id = 1
exec comprar 2
update jugadores set posicion  = 3 where id = 1
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
exec getCasillas 2
exec getCasillas null,2
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
mover 1,4
select * from jugadores
mover 2,1
select * from jugadores
mover 1,1
select * from jugadores
*/
/*
exec getPropiedades 1
*/

/* prueba de actualizarDeuda

Actualizar cuando no es una carta

select * from jugadores
actualizarDeuda 1
select * from jugadores

Actualizar cuando es una carta
select * from jugadores
actualizarDeuda 1,2
select * from jugadores

*/

/* prueba de pagar

pagar 1
select * from jugadores

*/

/* prueba de finalizarTurno
finalizarTurno 1
select * from partidas
*/


/* prueba de obtenerCartas
	obtenerCartas 2
	select * from jugadores
*/

/* prueba de getTurno

	getTurno 2
	select * from partidas
	select * from jugadores

	update partidas set turno = 2
*/

/* prueba de castigar
	update jugadores set posicion = 38 where id = 1
	castigar 1
	select * from jugadores
*/

/* prueba getTiempo

	exec comenzarPartida 1

	select * from partidas
	update partidas set maxTiempo = 1 where id = 1
	getTiempo 1

*/

/* prueba getMasRico
	getMasRico 1
*/