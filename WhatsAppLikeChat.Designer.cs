namespace MyWinFormsApp
{
    partial class WhatsAppLikeChat
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Text = "Form1";

            // Texto fijo decorativo "Escribe tu mensaje"
            this.label1 = DesignerBuilding.CreateLabel("label1", "¡Chatea con tus amigos!", 50, 50, 210, 20);
            // Texto fijo decorativo 2 "Bandeja de mensajes"
            this.label3 = DesignerBuilding.CreateLabel("label3", "Bandeja de mensajes", 360, 50, 200, 20);
            // Etiqueta para el puerto actual
            this.label4 = DesignerBuilding.CreateLabel("label4", "Puerto actual:", 50, 75, 110, 20);
            // Cuadro de texto para mostrar el puerto actual, aquí se mostrará el puerto escogido.
            this.textBox4 = DesignerBuilding.CreateTextBoxNotEditable("textBoxLocalPort", 180, 75, 100, 20, readOnly: true);
            // Etiqueta para más texto, al igual que "Puerto actual"
            this.label2 = DesignerBuilding.CreateLabel("label2", "Puerto de destino:", 50, 100, 110, 20);
            // Cuadro de texto para ingresar el puerto de destino, aquí se introducirá el destinatario a enviar mensajes.
            this.textBox2 = DesignerBuilding.CreateTextBoxEditable("textBoxRemotePort", 180, 100, 100, 20);
            // Agregar un cuadro de texto para escribir el mensaje a enviar
            this.textBox1 = DesignerBuilding.CreateTextBoxEditable("textBoxMensajeAEnviar", 50, 130, 230, 285, multiline: true);
            // Agregar un nuevo cuadro de texto abajo de label3(Texto fijo de bandeja de mensaje), para recibir los mensajes entrantes
            this.textBox3 = DesignerBuilding.CreateTextBoxNotEditable("textBoxMensajesEntrantes", 360, 70, 200, 400, multiline: true);
            // Botón encargado de enviar el mensaje escrito
            this.button1 = DesignerBuilding.CreateButton("button1", "Enviar Mensaje", 50, 425, 230, 50, this.button1_Click);
            //Texto decorativo del creador.
            this.label5 = DesignerBuilding.CreateLabel("label5", "Creador: Anthony José Artavia Leitón", 50,480,210,20);

            // Agregar, colocar y mostrar los elementos de la interfaz en el Forms
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button1);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;

    }


    //Zona dedicada a la clase DesignerBuilding, encargada de la creación de componentes en la interfaz gráfica.
    public static class DesignerBuilding
    {
        public static Button CreateButton(string name, string text, int x, int y, int width, int height, EventHandler onClick)
        {
            //Nota: En el método del Button se crea un objeto como tal ya que necesitamos poder otorgarle el evento de clickeo, cosa que no es
            // necesario en el resto de componentes
            var button = new Button
            {
                Name = name,
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                UseVisualStyleBackColor = true
            };
            button.Click += onClick;
            return button;
        }

        public static Label CreateLabel(string name, string text, int x, int y, int width, int height)
        {
            return new Label
            {
                Name = name,
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height)
            };
        }

        public static TextBox CreateTextBoxNotEditable(string name, int x, int y, int width, int height, bool multiline = false, bool readOnly = true)
        {
            return new TextBox
            {
                Name = name,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Multiline = multiline,
                ReadOnly = readOnly
            };
        }

        public static TextBox CreateTextBoxEditable(string name, int x, int y, int width, int height, bool multiline = false, bool readOnly = false)
        {
            return new TextBox
            {
                Name = name,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Multiline = multiline,
                ReadOnly = readOnly
            };
        }
    }
}
