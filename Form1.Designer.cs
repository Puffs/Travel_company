namespace TurAgent
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddClinet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Location = new System.Drawing.Point(410, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 72);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выбрать путевку";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddClinet
            // 
            this.btnAddClinet.BackColor = System.Drawing.Color.Lime;
            this.btnAddClinet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAddClinet.Location = new System.Drawing.Point(135, 284);
            this.btnAddClinet.Name = "btnAddClinet";
            this.btnAddClinet.Size = new System.Drawing.Size(235, 72);
            this.btnAddClinet.TabIndex = 1;
            this.btnAddClinet.Text = "Ввести информацию о клиенте";
            this.btnAddClinet.UseVisualStyleBackColor = false;
            this.btnAddClinet.Click += new System.EventHandler(this.btnAddClinet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddClinet);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddClinet;
    }
}

