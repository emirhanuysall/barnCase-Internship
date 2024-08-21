namespace BarnCase.UI.Controls
{
    partial class BarnControl
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
            dataGrid_Animal = new DataGridView();
            comboBox_Age = new ComboBox();
            btn_AddList = new Button();
            comboBox_Animal = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Animal).BeginInit();
            SuspendLayout();
            // 
            // dataGrid_Animal
            // 
            dataGrid_Animal.BackgroundColor = SystemColors.Control;
            dataGrid_Animal.BorderStyle = BorderStyle.None;
            dataGrid_Animal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Animal.Location = new Point(98, 137);
            dataGrid_Animal.Name = "dataGrid_Animal";
            dataGrid_Animal.Size = new Size(268, 183);
            dataGrid_Animal.TabIndex = 0;
            // 
            // comboBox_Age
            // 
            comboBox_Age.FormattingEnabled = true;
            comboBox_Age.Location = new Point(218, 71);
            comboBox_Age.Name = "comboBox_Age";
            comboBox_Age.Size = new Size(105, 23);
            comboBox_Age.TabIndex = 2;
            // 
            // btn_AddList
            // 
            btn_AddList.Location = new Point(340, 71);
            btn_AddList.Name = "btn_AddList";
            btn_AddList.Size = new Size(75, 23);
            btn_AddList.TabIndex = 3;
            btn_AddList.Text = "Buy ";
            btn_AddList.UseVisualStyleBackColor = true;
            btn_AddList.Click += btn_AddList_Click;
            // 
            // comboBox_Animal
            // 
            comboBox_Animal.FormattingEnabled = true;
            comboBox_Animal.Location = new Point(98, 71);
            comboBox_Animal.Name = "comboBox_Animal";
            comboBox_Animal.Size = new Size(114, 23);
            comboBox_Animal.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 49);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 4;
            label1.Text = "Animal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(218, 49);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 5;
            label2.Text = "Age";
            // 
            // BarnControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_AddList);
            Controls.Add(comboBox_Age);
            Controls.Add(comboBox_Animal);
            Controls.Add(dataGrid_Animal);
            Location = new Point(293, 0);
            Name = "BarnControl";
            Size = new Size(802, 561);
            Load += BarnControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Animal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGrid_Animal;
        private ComboBox comboBox_Age;
        private Button btn_AddList;
        private ComboBox comboBox_Animal;
        private Label label1;
        private Label label2;
    }
}
