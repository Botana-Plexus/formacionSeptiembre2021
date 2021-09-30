
use botanapoly

--select * from tableros
insert into tableros values (2,'Ruta del Tesoro',135000,40)
/*
select * from casillas where tablero = 2 order by orden 
select * from tiposCasillas
select * from cartas
select * from tiposcartas
*/

insert into casillas  values (1,2,'Salida',1,20000, null, null, null, null, null, null, null, null, null, null, null)

insert into casillas  values (2,2,'Mahón',2,6000, 3000, 5000, 2500, 200, 1000, 3000, 9000, 16000, 25000, 1, null)
insert into casillas  values (2,2,'Ibiza',4,6000, 3000, 5000, 2500, 400, 2000, 6000, 18000, 32000, 45000, 1, null)

insert into casillas  values (2,2,'Marsella',7,10000, 5000, 5000, 2500, 600, 3000, 9000, 27000, 40000, 55000, 2, null)
insert into casillas  values (2,2,'Génova',  9,10000, 5000, 5000, 2500, 600, 3000, 9000, 27000, 40000, 55000, 2, null)
insert into casillas  values (2,2,'Sicilia',10,10000, 5000, 5000, 2500, 800, 4000, 10000, 30000, 45000, 60000, 2, null)

insert into casillas  values (2,2,'Orán',12,14000, 7000, 10000, 5000, 1000, 5000, 15000, 45000, 62500, 75000, 3, null)
insert into casillas  values (2,2,'Argel',14,14000, 7000, 10000, 5000, 1000, 5000, 15000, 45000, 62500, 75000, 3, null)
insert into casillas  values (2,2,'Túnez',15,16000, 8000, 10000, 5000, 1200, 6000, 18000, 50000, 70000, 90000, 3, null)

insert into casillas  values (2,2,'Cerdeña',17,18000, 9000, 10000, 5000, 1400, 7000, 20000, 55000, 75000, 95000, 4, null)
insert into casillas  values (2,2,'Malta',19,18000, 9000, 10000, 5000, 1400, 7000, 20000, 55000, 75000, 95000, 4, null)
insert into casillas  values (2,2,'Trípoli',20,20000, 10000, 10000, 5000, 1600, 8000, 22000, 60000, 80000, 100000, 4, null)

insert into casillas  values (2,2,'Nápoles',22,22000, 11000, 15000, 7500, 1800, 9000, 25000, 70000, 87500, 105000, 5, null)
insert into casillas  values (2,2,'Sicilia',24,22000, 11000, 15000, 7500, 1800, 9000, 25000, 70000, 87500, 105000, 5, null)
insert into casillas  values (2,2,'Venecia',25,24000, 12000, 15000, 7500, 2000, 10000, 30000, 75000, 92500, 110000, 5, null)

insert into casillas  values (2,2,'Creta',27,26000, 13000, 15000, 7500, 2200, 11000, 33000, 80000, 97500, 115000, 6, null)
insert into casillas  values (2,2,'Rodas',28,26000, 13000, 15000, 7500, 2200, 11000, 33000, 80000, 97500, 115000, 6, null)
insert into casillas  values (2,2,'Alejandría',30,28000, 14000, 15000, 7500, 2200, 12000, 36000, 85000, 102500, 120000, 6, null)

insert into casillas  values (2,2,'Ragusa',32,30000, 15000, 20000, 10000, 2600, 13000, 39000, 90000, 110000, 127500, 7, null)
insert into casillas  values (2,2,'Chipre',33,30000, 15000, 20000, 10000, 2600, 13000, 39000, 90000, 110000, 127500, 7, null)
insert into casillas  values (2,2,'Damasco',35,32000, 16000, 20000, 10000, 2800, 15000, 45000, 100000, 120000, 140000, 7, null)

insert into casillas  values (2,2,'Crimea',38,35000, 17500, 20000, 10000, 3500, 17500, 55000, 110000, 130000, 150000, 8, null)
insert into casillas  values (2,2,'Constantinopla',40,40000, 20000, 20000, 10000, 5000, 20000, 60000, 140000, 170000, 200000, 8, null)

insert into casillas  values (3,2,'Seguros Lloyds',13,15000, 7500, null, null, 400, 1000, null, null, null, null, 9, null)
insert into casillas  values (3,2,'Reales Atarazanas',29,15000, 7500, null, null, 400, 1000, null, null, null, null, 9, null)

insert into casillas  values (4,2,'Lonja de Mallorca',6,20000, 10000, null, null, 5000, 10000, 15000, 20000, null, null, 10, null)
insert into casillas  values (4,2,'Lonja de Alicante',16,20000, 10000, null, null, 5000, 10000, 15000, 20000, null, null, 10, null)
insert into casillas  values (4,2,'Lonja de Valencia',26,20000, 10000, null, null, 5000, 10000, 15000, 20000, null, null, 10, null)
insert into casillas  values (4,2,'Lonja de Barcelona',36,20000, 10000, null, null, 5000, 10000, 15000, 20000, null, null, 10, null)

insert into casillas  values (5,2,'Cofre del Tesoro',3,null, null, null, null, null, null, null, null, null, null, 11, null)
insert into casillas  values (5,2,'Cofre del Tesoro',18,null, null, null, null, null, null, null, null, null, null, 11, null)
insert into casillas  values (5,2,'Cofre del Tesoro',34,null, null, null, null, null, null, null, null, null, null, 11, null)

insert into casillas  values (5,2,'Suerte',8,null, null, null, null, null, null, null, null, null, null, 12, null)
insert into casillas  values (5,2,'Suerte',23,null, null, null, null, null, null, null, null, null, null, 12, null)
insert into casillas  values (5,2,'Suerte',37,null, null, null, null, null, null, null, null, null, null, 12, null)

insert into casillas  values (6,2,'Galeras',11,null, null, null, null, null, null, null, null, null, null, null, null)
insert into casillas  values (6,2,'Fondeadero',21,null, null, null, null, null, null, null, null, null, null, null, null)

insert into casillas  values (7,2,'Vaya a Galeras',31,null, null, null, null, null, null, null, null, null, null, null, 11)

insert into casillas  values (8,2,'Alcabalas',5,20000, null, null, null, null, null, null, null, null, null, null, null)
insert into casillas  values (8,2,'Compra de Armas',39,10000, null, null, null, null, null, null, null, null, null, null, null)

--cartas
insert into cartas values (2,11,1,'Prestamo de la corona', 20000);
insert into cartas values (2,11,1,'Venta de mercancias', 5000);
insert into cartas values (2,11,1,'Herencia', 10000);
insert into cartas values (2,11,1,'Interes', 2500);
insert into cartas values (2,11,1,'Renta', 10000);

insert into cartas values (2,11,2,'Impuestos', 5000);
insert into cartas values (2,11,2,'Póliza de seguros', 5000);

insert into cartas values (2,11,4,'Vaya a galeras', 0);


insert into cartas values (2,12,1,'Compañía de seguros', 5000);
insert into cartas values (2,12,1,'Barco abandonado', 15000);
insert into cartas values (2,12,1,'Tesoro', 40000);
insert into cartas values (2,12,1,'mercancías', 15000);

insert into cartas values (2,12,2,'Iglesia', 10000);
insert into cartas values (2,12,2,'Embriaguez', 2000);
insert into cartas values (2,12,2,'tempestad', 20000);
insert into cartas values (2,12,2,'Piratas', 20000);

insert into cartas values (2,12,3,'deriva', -4);
insert into cartas values (2,12,3,'viento', 5);
insert into cartas values (2,12,3,'viento', 2);

insert into cartas values (2,12,4,'arrecife', 2);
insert into cartas values (2,12,4,'Galeras', 3);

/*
exec registrar 'alberto3o@plexus.es','botana3','1234','19770620'
exec registrar 'alberto4@plexus.es','botana4','1234','19770620'
exec crearPartida 'partida2',3,4,null,'1234',2
exec anadirJugador 4,2,'1234'
exec anadirJugador null,2,'1234'
exec comenzarPartida 2
*/

/*
select * from partidas
update partidas set numJugadores = 2 where id = 2
select * from jugadores a left join casillas b on a.posicion = b.id where idpartida = 2
select * from propiedades a left join casillas b on a.casilla = b.id where partida = 2
delete from jugadores where id in ( 9,10)
exec mover 4,1
exec comprar 4
exec edificar 4,5
exec mover 4,2
exec comprar 4
exec edificar 4,6
exec venderEdificacion 4,6

exec setDobles 4,1

*/
