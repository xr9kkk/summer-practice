namespace summer_practice
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBoxPlanet = new PictureBox();
            btnAddTree = new Button();
            btnAddHouse = new Button();
            btnAddFlag = new Button();
            btnAddAntenna = new Button();
            btnDeleteLast = new Button();
            btnClearAll = new Button();
            btnSaveState = new Button();
            btnLoadState = new Button();
            btnChangeColor = new Button();
            lblTree = new Label();
            lblHouse = new Label();
            lblAntenna = new Label();
            lblFlag = new Label();
            colorDialog1 = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            rotationTimer = new System.Windows.Forms.Timer(components);
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlanet).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPlanet
            // 
            pictureBoxPlanet.Location = new Point(139, 107);
            pictureBoxPlanet.Name = "pictureBoxPlanet";
            pictureBoxPlanet.Size = new Size(452, 387);
            pictureBoxPlanet.TabIndex = 0;
            pictureBoxPlanet.TabStop = false;
            // 
            // btnAddTree
            // 
            btnAddTree.Location = new Point(618, 136);
            btnAddTree.Name = "btnAddTree";
            btnAddTree.Size = new Size(75, 23);
            btnAddTree.TabIndex = 1;
            btnAddTree.Text = "add tree";
            btnAddTree.UseVisualStyleBackColor = true;
            // 
            // btnAddHouse
            // 
            btnAddHouse.Location = new Point(618, 174);
            btnAddHouse.Name = "btnAddHouse";
            btnAddHouse.Size = new Size(75, 23);
            btnAddHouse.TabIndex = 2;
            btnAddHouse.Text = "add house";
            btnAddHouse.UseVisualStyleBackColor = true;
            // 
            // btnAddFlag
            // 
            btnAddFlag.Location = new Point(618, 216);
            btnAddFlag.Name = "btnAddFlag";
            btnAddFlag.Size = new Size(75, 23);
            btnAddFlag.TabIndex = 3;
            btnAddFlag.Text = "add flag";
            btnAddFlag.UseVisualStyleBackColor = true;
            // 
            // btnAddAntenna
            // 
            btnAddAntenna.Location = new Point(618, 258);
            btnAddAntenna.Name = "btnAddAntenna";
            btnAddAntenna.Size = new Size(75, 40);
            btnAddAntenna.TabIndex = 4;
            btnAddAntenna.Text = "add antenna";
            btnAddAntenna.UseVisualStyleBackColor = true;
            // 
            // btnDeleteLast
            // 
            btnDeleteLast.Location = new Point(385, 47);
            btnDeleteLast.Name = "btnDeleteLast";
            btnDeleteLast.Size = new Size(75, 23);
            btnDeleteLast.TabIndex = 5;
            btnDeleteLast.Text = "delete last";
            btnDeleteLast.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(281, 47);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(75, 23);
            btnClearAll.TabIndex = 6;
            btnClearAll.Text = "clear all";
            btnClearAll.UseVisualStyleBackColor = true;
            // 
            // btnSaveState
            // 
            btnSaveState.Location = new Point(41, 174);
            btnSaveState.Name = "btnSaveState";
            btnSaveState.Size = new Size(75, 23);
            btnSaveState.TabIndex = 7;
            btnSaveState.Text = "save state";
            btnSaveState.UseVisualStyleBackColor = true;
            // 
            // btnLoadState
            // 
            btnLoadState.Location = new Point(41, 231);
            btnLoadState.Name = "btnLoadState";
            btnLoadState.Size = new Size(75, 23);
            btnLoadState.TabIndex = 8;
            btnLoadState.Text = "load state";
            btnLoadState.UseVisualStyleBackColor = true;
            // 
            // btnChangeColor
            // 
            btnChangeColor.Location = new Point(340, 500);
            btnChangeColor.Name = "btnChangeColor";
            btnChangeColor.Size = new Size(75, 41);
            btnChangeColor.TabIndex = 9;
            btnChangeColor.Text = "change color";
            btnChangeColor.UseVisualStyleBackColor = true;
            // 
            // lblTree
            // 
            lblTree.AutoSize = true;
            lblTree.Location = new Point(611, 366);
            lblTree.Name = "lblTree";
            lblTree.Size = new Size(38, 15);
            lblTree.TabIndex = 10;
            lblTree.Text = "label1";
            // 
            // lblHouse
            // 
            lblHouse.AutoSize = true;
            lblHouse.Location = new Point(655, 366);
            lblHouse.Name = "lblHouse";
            lblHouse.Size = new Size(38, 15);
            lblHouse.TabIndex = 11;
            lblHouse.Text = "label2";
            // 
            // lblAntenna
            // 
            lblAntenna.AutoSize = true;
            lblAntenna.Location = new Point(655, 401);
            lblAntenna.Name = "lblAntenna";
            lblAntenna.Size = new Size(38, 15);
            lblAntenna.TabIndex = 12;
            lblAntenna.Text = "label3";
            // 
            // lblFlag
            // 
            lblFlag.AutoSize = true;
            lblFlag.Location = new Point(611, 401);
            lblFlag.Name = "lblFlag";
            lblFlag.Size = new Size(38, 15);
            lblFlag.TabIndex = 13;
            lblFlag.Text = "label4";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(855, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 14;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 700);
            Controls.Add(dateTimePicker1);
            Controls.Add(lblFlag);
            Controls.Add(lblAntenna);
            Controls.Add(lblHouse);
            Controls.Add(lblTree);
            Controls.Add(btnChangeColor);
            Controls.Add(btnLoadState);
            Controls.Add(btnSaveState);
            Controls.Add(btnClearAll);
            Controls.Add(btnDeleteLast);
            Controls.Add(btnAddAntenna);
            Controls.Add(btnAddFlag);
            Controls.Add(btnAddHouse);
            Controls.Add(btnAddTree);
            Controls.Add(pictureBoxPlanet);
            Name = "MainForm";
            Text = "Planet Object Drawer";
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlanet).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxPlanet;
        private Button btnAddTree;
        private Button btnAddHouse;
        private Button btnAddFlag;
        private Button btnAddAntenna;
        private Button btnDeleteLast;
        private Button btnClearAll;
        private Button btnSaveState;
        private Button btnLoadState;
        private Button btnChangeColor;
        private Label lblTree;
        private Label lblHouse;
        private Label lblAntenna;
        private Label lblFlag;
        private ColorDialog colorDialog1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer rotationTimer;
        private DateTimePicker dateTimePicker1;
    }
}