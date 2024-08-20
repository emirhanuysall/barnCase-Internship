namespace BarnCase.UI.Controls
{
    partial class ProductControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGrid_Product = new DataGridView();
            label_Price = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Product).BeginInit();
            SuspendLayout();
            // 
            // dataGrid_Product
            // 
            dataGrid_Product.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Product.Location = new Point(95, 177);
            dataGrid_Product.Name = "dataGrid_Product";
            dataGrid_Product.Size = new Size(521, 150);
            dataGrid_Product.TabIndex = 0;
            // 
            // label_Price
            // 
            label_Price.AutoSize = true;
            label_Price.Location = new Point(95, 411);
            label_Price.Name = "label_Price";
            label_Price.Size = new Size(0, 15);
            label_Price.TabIndex = 1;
            // 
            // ProductControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label_Price);
            Controls.Add(dataGrid_Product);
            Name = "ProductControl";
            Size = new Size(708, 588);
            ((System.ComponentModel.ISupportInitialize)dataGrid_Product).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGrid_Product;
        private Label label_Price;
    }
}
