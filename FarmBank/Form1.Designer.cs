namespace FarmBank
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnBarn = new Button();
            btnProduct = new Button();
            btnHome = new Button();
            contentPanel = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnBarn);
            panel1.Controls.Add(btnProduct);
            panel1.Controls.Add(btnHome);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 623);
            panel1.TabIndex = 0;
            // 
            // btnBarn
            // 
            btnBarn.BackColor = Color.Green;
            btnBarn.Dock = DockStyle.Top;
            btnBarn.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 0);
            btnBarn.FlatAppearance.BorderSize = 0;
            btnBarn.FlatStyle = FlatStyle.Flat;
            btnBarn.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnBarn.Location = new Point(0, 128);
            btnBarn.Name = "btnBarn";
            btnBarn.Size = new Size(198, 64);
            btnBarn.TabIndex = 2;
            btnBarn.Text = "Barn";
            btnBarn.UseVisualStyleBackColor = false;
            btnBarn.Click += btnBarn_Click;
            // 
            // btnProduct
            // 
            btnProduct.BackColor = SystemColors.HotTrack;
            btnProduct.Dock = DockStyle.Top;
            btnProduct.FlatAppearance.BorderColor = Color.FromArgb(128, 128, 255);
            btnProduct.FlatAppearance.BorderSize = 0;
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnProduct.Location = new Point(0, 64);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(198, 64);
            btnProduct.TabIndex = 1;
            btnProduct.Text = "Product";
            btnProduct.UseVisualStyleBackColor = false;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(128, 64, 0);
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(198, 64);
            btnHome.TabIndex = 0;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // contentPanel
            // 
            contentPanel.BorderStyle = BorderStyle.FixedSingle;
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(200, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(731, 623);
            contentPanel.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(931, 623);
            Controls.Add(contentPanel);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnBarn;
        private Button btnProduct;
        private Button btnHome;
        private Panel contentPanel;
    }
}
