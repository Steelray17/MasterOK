namespace MasterOK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonOpenClients = new System.Windows.Forms.Button();
            this.buttonOpenEmployees = new System.Windows.Forms.Button();
            this.buttonOpenProviders = new System.Windows.Forms.Button();
            this.buttonOpenProducts = new System.Windows.Forms.Button();
            this.buttonOpenWarehouse = new System.Windows.Forms.Button();
            this.buttonOpenOrders = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenClients
            // 
            this.buttonOpenClients.Location = new System.Drawing.Point(12, 157);
            this.buttonOpenClients.Name = "buttonOpenClients";
            this.buttonOpenClients.Size = new System.Drawing.Size(255, 48);
            this.buttonOpenClients.TabIndex = 0;
            this.buttonOpenClients.Text = "Клиенты";
            this.buttonOpenClients.UseVisualStyleBackColor = true;
            this.buttonOpenClients.Click += new System.EventHandler(this.buttonOpenClients_Click);
            // 
            // buttonOpenEmployees
            // 
            this.buttonOpenEmployees.Location = new System.Drawing.Point(12, 211);
            this.buttonOpenEmployees.Name = "buttonOpenEmployees";
            this.buttonOpenEmployees.Size = new System.Drawing.Size(255, 48);
            this.buttonOpenEmployees.TabIndex = 1;
            this.buttonOpenEmployees.Text = "Сотрудники";
            this.buttonOpenEmployees.UseVisualStyleBackColor = true;
            this.buttonOpenEmployees.Click += new System.EventHandler(this.buttonOpenEmployees_Click);
            // 
            // buttonOpenProviders
            // 
            this.buttonOpenProviders.Location = new System.Drawing.Point(12, 265);
            this.buttonOpenProviders.Name = "buttonOpenProviders";
            this.buttonOpenProviders.Size = new System.Drawing.Size(255, 48);
            this.buttonOpenProviders.TabIndex = 2;
            this.buttonOpenProviders.Text = "Поставщики";
            this.buttonOpenProviders.UseVisualStyleBackColor = true;
            this.buttonOpenProviders.Click += new System.EventHandler(this.buttonOpenProviders_Click);
            // 
            // buttonOpenProducts
            // 
            this.buttonOpenProducts.Location = new System.Drawing.Point(12, 319);
            this.buttonOpenProducts.Name = "buttonOpenProducts";
            this.buttonOpenProducts.Size = new System.Drawing.Size(255, 48);
            this.buttonOpenProducts.TabIndex = 3;
            this.buttonOpenProducts.Text = "Товары";
            this.buttonOpenProducts.UseVisualStyleBackColor = true;
            this.buttonOpenProducts.Click += new System.EventHandler(this.buttonOpenProducts_Click);
            // 
            // buttonOpenWarehouse
            // 
            this.buttonOpenWarehouse.Location = new System.Drawing.Point(12, 373);
            this.buttonOpenWarehouse.Name = "buttonOpenWarehouse";
            this.buttonOpenWarehouse.Size = new System.Drawing.Size(255, 48);
            this.buttonOpenWarehouse.TabIndex = 4;
            this.buttonOpenWarehouse.Text = "Склад";
            this.buttonOpenWarehouse.UseVisualStyleBackColor = true;
            this.buttonOpenWarehouse.Click += new System.EventHandler(this.buttonOpenWarehouse_Click);
            // 
            // buttonOpenOrders
            // 
            this.buttonOpenOrders.Location = new System.Drawing.Point(12, 427);
            this.buttonOpenOrders.Name = "buttonOpenOrders";
            this.buttonOpenOrders.Size = new System.Drawing.Size(255, 48);
            this.buttonOpenOrders.TabIndex = 5;
            this.buttonOpenOrders.Text = "Заказы";
            this.buttonOpenOrders.UseVisualStyleBackColor = true;
            this.buttonOpenOrders.Click += new System.EventHandler(this.buttonOpenOrders_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(279, 484);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonOpenOrders);
            this.Controls.Add(this.buttonOpenWarehouse);
            this.Controls.Add(this.buttonOpenProducts);
            this.Controls.Add(this.buttonOpenProviders);
            this.Controls.Add(this.buttonOpenEmployees);
            this.Controls.Add(this.buttonOpenClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasterOK";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenClients;
        private System.Windows.Forms.Button buttonOpenEmployees;
        private System.Windows.Forms.Button buttonOpenProviders;
        private System.Windows.Forms.Button buttonOpenProducts;
        private System.Windows.Forms.Button buttonOpenWarehouse;
        private System.Windows.Forms.Button buttonOpenOrders;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

