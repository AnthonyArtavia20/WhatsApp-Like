namespace MyWinFormsApp
{
    partial class Form1
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Text = "Form1";

            // Agregar una etiqueta para el texto fijo
            this.label1 = new System.Windows.Forms.Label();
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escribe tu mensaje:";
            
            // Agregar una etiqueta para la bandeja de mensajes
            this.label3 = new System.Windows.Forms.Label();
            this.label3.Location = new System.Drawing.Point(360, 50); // Ajusta la posición X para estar a la izquierda de textBox3
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bandeja de mensajes";

            // Etiqueta para más texto
            this.label2 = new System.Windows.Forms.Label();
            this.label2.Location = new System.Drawing.Point(50, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puerto de destino:";

            // Cuadro de texto para ingresar el puerto
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox2.Location = new System.Drawing.Point(180, 100); // Ajusta la posición X para estar a la derecha de label2
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20); // Ajusta el tamaño según sea necesario
            this.textBox2.TabIndex = 4;

            // Agregar un cuadro de texto para escribir el mensaje a enviar
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox1.Multiline = true; // Permite múltiples líneas
            this.textBox1.Location = new System.Drawing.Point(50, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 285); // Ajusta el tamaño según sea necesario
            this.textBox1.TabIndex = 2;

            // Agregar un nuevo cuadro de texto a la derecha de label3
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox3.Multiline = true; // Permite múltiples líneas
            this.textBox3.Location = new System.Drawing.Point(360, 70); // Ajusta la posición X para estar a la derecha de label3 y la posición Y para estar debajo de label3
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 400); // Ajusta el tamaño para extender desde debajo de label3 hasta la altura del botón
            this.textBox3.TabIndex = 6;

            // Agregar un botón
            this.button1 = new System.Windows.Forms.Button();
            this.button1.Location = new System.Drawing.Point(50, 425); // Ajusta la posición Y para estar debajo del TextBox
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Click Me";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // Agregar controles al formulario
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3); // Asegúrate de agregar label3 aquí
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2); // Asegúrate de agregar textBox2 aquí
            this.Controls.Add(this.textBox3); // Agrega el nuevo TextBox aquí
            this.Controls.Add(this.button1);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3; // Nuevo TextBox
        private System.Windows.Forms.Button button1;

        #endregion
    }
}
