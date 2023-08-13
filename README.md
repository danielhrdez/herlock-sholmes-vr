# Prototipo de Interfaces Inteligentes

## Miembros del grupo

* Juan Guillermo Zafra Fernández _(alu0101353647)_
* Jorge Cabrera Rodríguez _(alu0101351773)_
* Daniel Hernández de León _(alu0101331720)_

## Cuestiones importantes para el uso
Se pretende el uso con gafas de realidad virtual como por ejemplo Occulus acompañadas de al menos un mando VR.
Alternativamente, se pueden usar este tipo de gafas con un mando de consola. El usuario se puede mover por la habitación usando el joystick del mando
Para evitar movimientos en la vida real, con los riesgos para con el mobiliario y para con las personas que eso implica.

## Hitos de programación logrados relacionándolos con los contenidos que se han impartido
Para empezar hemos conseguido desarrollar un sistema de diálogos que muestre si se han obtenido o no todas las pistas relativas al crimen. Si
no se han obtenido no se puede completar el juego.

Además hemos desarrollado un sistema de interacciones con objetos, de tal forma que al apuntar a una pista con la cámara esta se ilumine dando
la posibilidad de ser tomada pulsando una tecla determinada.

Por supuesto para permitir el movimiento del jugador hemos implementado un sistema de movimiento (character controller) y colisiones para que el jugador no
interfiera con los objetos y las paredes del despacho.

También debemos destacar el sistema de eventos de pistas que hemos implementado: cuando una pista es seleccionada por el jugador se lanza un evento que
analiza si la pista ya ha sido validada (atributo booleano) para sumarse al número de pistas encontradas o no.

Cuando se interactue con la puerta se lanzará un evento que comprobará si se ha alcanzado el número necesario de pistas

## Aspectos que destacarías en la aplicación. Especificar si se han incluido sensores de los que se han trabajado en interfaces multimodales.
En una habitación lo suficientemente grande y con cierta configuración del occulus sería posible moverse por el juego físicamente, para mayor inmersión.
Añadiendo a esto, el uso de las gafas de realidad virtual en este tipo de juegos permite investigar al ritmo del usuario y hacer uso completo de una cámara
con movilidad cómoda en tres dimensiones. No se han usado sensores.

## Gif animado de ejecución

## Acta de los acuerdos del grupo respecto al trabajo en equipo: reparto de tareas, tareas desarrolladas individualmente, tareas desarrolladas en grupo, etc.
|Tarea|Integrante asignado|
|-----|-------------------|
|Diseño de pistas| Guille|
|Diseño de diálogos|Guille|
|Tweaking|Todos|
|Desarrollo de scripts|Daniel y Guille|
|Testing|Daniel|
|Debugging|Todos|
|Desarrollo de entorno|Daniel y Jorge|
|Investigación sobre librerías|Daniel y Jorge|
|Investigación sobre VR|Daniel|
|Organización|Guille|
|Toma de objetivos |Guille y Daniel|
|Control de tiempo|Todos|
|Desarrollo del README|Guille y Jorge|
|Presentación|Guille y Jorge|
