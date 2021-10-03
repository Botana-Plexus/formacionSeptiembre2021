Incluye una solución con dos proyectos + xml de SoapUI.

Botanapoly.xml - xml de SoapUI
BotanapolyAPI/ - API REST
BotanapolyVista/ - WPF

Los métodos de la API devuelven un entero. El significado del entero se encuentra comentado encima de cada método en el fichero BotanapolyController.cs.

En BotanapolyVista hace falta agregar BotanapolyAPI como referencia del proyecto.

Lo único que hace falta cambiar para que funcione BotanapolyVista/ es el atributo idPartida en la linea 24 del archivo MainWindow.xaml.cs - Substituirlo por el id de la partida que queremos ver.

BotanapolyVista carga el tablero y actualiza la posicion de los jugadores y el nivel de edificacion de las propiedades. cada cierto tiempo aparecerá un dialogo que si aceptamos y se ha modificado algo, se cargará en la vista.
