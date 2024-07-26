## WhatsAppLike-Chat via TCP port

###¿Cómo usar?

#####Se  descargar los archivos aquí disponibles y puesterior se abre la carpeta en VisualStudioCode, luego desde la terminal, ya sea desde powershell , cmd o bien desde la misma terminal powershell de visual ejecutar la siguiente serie de comandos:

#####1) Se realiza la navegación hasta la carpeta por medio del comando:

`PS c:\users\Anthony\Desktop\> cd nombre de la carpeta`

#####2) Posterior se ejecutar el siguiente comando desde la terminal estando dentro del directorio:

`PS c:\users\Anthony\Desktop\> donet run -port <1- 65535>` Aquí importante escojer cual puerto quiere utilizar. se recomienda el 5000 y 5001 para pruebas, ya que no son ocupados por servicios comunes.

#####3) Finalmente se realiza este proceso cuantas veces sean necesarias con el fin de crear varias instancias del programa que actuaran como clientes.

##¿Cómo funciona este programa?
#####Este programa está hecho en el lenguaje de programación c# en .NET8 utilizando microsoft forms. Tiene la capacidad de comunicar puertos TCP/IP entre sí con la finalidad de enviar texto como mensajes, haciendo la ilusión de un chat de mensajería.

- Se utilizan las siguientes librerías para lograrlo:
	- using System.Net;
	- using System.Net.Sockets;

######En resumidas cuentas cada instancia del programa funciona como cliente y servidor al mismo tiempo, esto particularmente es útil para no tener que crear un archivo aparte que actue como servidor intermedio. Cuando una instancia es iniciada desde la consola de comandos mediante el comando: `PS c:\users\Anthony\Desktop\> donet run -port <1- 65535>`  el puerto a seleccionar actua como un identificador de la instancia como tal, conocido internamente como "cliente", esto nos permite posteriormente, cuando el servidor se active(el mismo es una función encargada de estar constantemente esperarando una request de conección mediante TcpClient escuchando los puertos) identifique el puerto y se inicie otra método encargado de esperar texto escrito en una textbox.
Una vez todo lo anterior se da, el método del botón "enviar mensaje" se encarga de convertir el texto en bytes para poder enviar la información, esto lo hace llamando a otro método pasándole como argumentos el mensaje, el puerto actual(puerto que se introdujo por consola) y el puerto remoto(el puerto del otro cliente),  aquí adentro mediante `await client.ConnectAsync` se le da una dirección ip-local por defecto(127.0.0.1) y el puerto que se escogió como remoto, finalmente cuando se establece conexión utilizando `await writer.WriteLineAsync($"Desde puerto <{localPort}>:{mensaje}");` y `writer.Flush();` se logra  escribir el mensaje transmitido y agregarlo a la textbox(bandeja de mensajes) del cliente final. Al mismo tiempo, cuando el botón es accionado limpiar la textbox de escritura para que quede en blanco y tambien escribe en la "bandeja de mensajes" de si mismo el mensaje que transmitió(anteriormente no se visualizaba el mensaje enviado, solo el recibido).

![](https://github.com/AnthonyArtavia20/WhatsApp-Like/blob/master/imgParaReadme/A.PNG)
