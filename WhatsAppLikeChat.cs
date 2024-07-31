//Importamos librerias necesarias para poder controlar los mensajes por tráfico.
using System.Net;
using System.Net.Sockets;

namespace MyWinFormsApp {
    public partial class WhatsAppLikeChat : Form {
        private TcpListener? _listener; //Aquí se declara una variable de instancia (_listener) de tipo TcpListener que será utilizada para gestionar las conexiones entrantes. 
        //Revisar el método StartServer, ahí se usa esta variable.
        //Además se le agregó "?" para indicar que es una propiedad que puede ser nullable.

        public WhatsAppLikeChat(string port) //Ventana principal.
        {
            //Inicializa el Form para visualizar el contenido.
            InitializeComponent();
            this.Text = "WhatsAppLikeChat";

            // Mostrar el puerto escogido por el usuario en el TextBox correspondiente al puerto.
            if (!string.IsNullOrEmpty(port)) //Método por defecto de la clase object para ver si está null o empty
            {
                textBox4.Text = port; //Mostrar el puerto escogido como origen.

                // Iniciar el servidor si el puerto es válido, además convierte string en int.
                if (int.TryParse(port, out int portNumber))
                {
                    StartServer(portNumber);//Inicializamos la función/método para inciar la escucha en el puerto seleccionado. 
                                //Nota: En este programa como no se utiliza la opción de comunicarse entre diferentes dispositivos, se le pasa una ip por defecto que apunta al local host: 127.0.0.1
                }
            }
        }

        private async void StartServer(int port) //Encargada de crear el servidor cuuya función es estar en modo "Escucha" hasata que se acepte una conexión.
        {

            _listener = new TcpListener(IPAddress.Any, port); //Aquí se inicializa y configura _listener para que escuche en un puerto específico, es decir el que se le da por consola, y la IP va por defecto.
            _listener.Start(); //Método de la clase TcpListener encargada de empezar a escuchar en el puerto otorgado.

            while (true) //Se inicia un ciclo while encargado de esperar una conexión.
            { 
                TcpClient client = await _listener.AcceptTcpClientAsync(); //Si hay una conexión entonces se le asigna el nomre "Client".
                _ = HandleClient(client); // Y se pasa a otro método encargado de  enviar el mensaje escrito en el cliente actual al nuevo cliente que aceptó la conexión.
            }
        }

        private async Task HandleClient(TcpClient client)  //Método encargado de escribir el mensaje almacenado en la textBox3 del cliente actual.        
        {

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream)) {
                string? message = await reader.ReadLineAsync(); //Para indicar que el mensaje puede ser null
                if (message != null) 
                {
                    // Mostrar el mensaje recibido en el TextBox
                    textBox3.AppendText(message + Environment.NewLine);
                } //else: se envia un mensaje en blanco automáticamente.
            }
        }

        private async void button1_Click(object sender, EventArgs e) //Método para el botón, se encarga de recoger como variables los datos ingresados en: La textBoxDeSalida(Mensaje a enviar), el puerto remoto(Puerto al cual enviar el mensaje), y el localPort(Esto para poder enviarlo junto al mensaje en el estilo: Desde puerto <xxx>: EJEMPLO).
        {

            string message = textBox1.Text;
            string remotePortText = textBox2.Text;
            string localPortText = textBox4.Text; //--> Para poder pasar el puerto seleccionado como parámetro, esto con el fin de que en el textbox de bandeja de entrada.
                                                    //logre escribir de quien es el mensaje, es decir, el puerto de origen.
            
            //Condicionales para poder convertir el texto string a int para pasarlos por el puerto como mensajes.
            if (int.TryParse(remotePortText, out int remotePort) && int.TryParse(localPortText, out int localPort)) 
            {
                await EnviarMensajes(message, remotePort, localPort);
                textBox1.Text = "";
            }else
             { //además si no se ingresa un mensaje, entonces se avisa de que no es válido o nulo.
                MessageBox.Show("El puerto de destino no es válido o nulo.");
            }
        }

        //Método aparte dedicado solo al envio de mensajes(Se hace así para mejor la legibilidad del código del button1_click).
        private async Task EnviarMensajes(string mensaje, int remotePort, int localPort) 
        {
            /*Nota de conocimiento personal: async: El método es asíncrono, permitiendo el uso de await para realizar operaciones de manera no bloqueante.
            Task: El método devuelve un Task, lo que es típico para métodos asíncronos que no devuelven un valor (similar a void en métodos sincrónicos).*/

            using (TcpClient client = new TcpClient()) {// Creamos un nuevo objeto llamado cliente desde la clase TcpClient
                    try 
                    {
                        await client.ConnectAsync("127.0.0.1", remotePort); // Nota importante: ¿porqué se usa 127.0.0.1?, para usar este protocolo es necesario pasar una dirección de destino, como este programa no implementa la opción de comunicarse con otros dispositivos, utilizamos un aip de localhost, "127.0.0.1" que apunta a la misma PC
                        using (NetworkStream stream = client.GetStream())
                        using (StreamWriter writer = new StreamWriter(stream)) 
                        {

                            await writer.WriteLineAsync($"Desde puerto <{localPort}>:{mensaje}"); //Se modificó para que pueda enviar a la par del mensaje el puerto de origen.
                            await writer.WriteLineAsync(); //Para dar un salto de linea
                            writer.Flush(); //Nota el uso de Flush: Cuando se usa "StreamWriter" los datos no se envían inmediatamente al destino (en este caso, la red). En lugar de eso, se almacenan temporalmente en un buffer.
                                                            //"Flush" asegura que todos los datos que están en el buffer se escriban inmediatamente al flujo subyacente, importantísimo cuando se necesita enviar los mensajes inmediatamente directo al cliente conectado.

                            textBox3.AppendText($"[Tú]{$"Desde puerto <{localPort}>:{mensaje}"}{Environment.NewLine}{Environment.NewLine}"); //Solución para poder mostrar el texto enviado tanto en la text3 del origen como la del destino, esto se logra haciendo que en la función del botón  se agregue el texto en la textbox3 actual con la función "AppendText" antes de pasar el mensaje al cliente.
                            textBox1.Text = "";
                        }
                    }
                    catch (Exception error) 
                    { // En caso de que el puerto esté ocupado y se deniegue el uso del puerto. Ejemplos de errores que dió: FormatException o ArgumentOutOfRangeException si el puerto no es un número válido.
                        MessageBox.Show("Error al enviar el mensaje: " + error.Message);
                    }
                }
        }
    }
}
