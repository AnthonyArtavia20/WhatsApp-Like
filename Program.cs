namespace MyWinFormsApp
{
    static class Program
    {
        /// <summary>
        ///  Cuando se inicie la aplicacion se le ingresa el puerto despues de "-port", lo almacenará en una variable
        ///  y lo envia a Form1 donde se procesará por medio de Sockets como el "Puerto actual".
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string? port = null; // El "?" indica que la variable puede tener un valor del tipo especificado o un valor null. Esto se conoce como un "tipo nullable".

            // Analiza el texto ingresado por la línea de comandos.
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-port" && i + 1 < args.Length) //Tomaremos como port desde donde aparezca "-port" +1 osea el puerto en números enteros.
                {
                    port = args[i + 1];
                }
            }
            if (port == null) //Incorporé esta linea para evitar el aviso: (Possible null reference srgument for parameter "port" in "whatsAppLikeChat.WhatsAppLikeChat(string port)".)
            {
                throw new ArgumentNullException("El puerto debe ser especificado con el argumento -port.");
            }

            ApplicationConfiguration.Initialize();
            //Enviar el puerto actual al Form1 para poder tomarlo como identificador del cliente e Inicializamos la apliación.
            Application.Run(new WhatsAppLikeChat(port));
        }
    }
}
