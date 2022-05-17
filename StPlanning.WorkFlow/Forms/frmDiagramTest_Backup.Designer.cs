namespace StPlanning.WorkFlow.Forms
{
    partial class frmDiagramTest_Backup
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
            this.components = new System.ComponentModel.Container();
            Crainiate.Diagramming.Forms.Paging paging1 = new Crainiate.Diagramming.Forms.Paging();
            Crainiate.Diagramming.Forms.Margin margin1 = new Crainiate.Diagramming.Forms.Margin();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.cmbZoom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateArrow = new DevExpress.XtraEditors.SimpleButton();
            this.diagram1 = new Crainiate.Diagramming.Forms.Diagram();
            this.cpeArrow = new DevExpress.XtraEditors.ColorPickEdit();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cpeArrow.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Exit";
            // 
            // cmbZoom
            // 
            this.cmbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoom.Items.AddRange(new object[] {
            "50 %",
            "75 %",
            "100 %",
            "200 %"});
            this.cmbZoom.Location = new System.Drawing.Point(877, 24);
            this.cmbZoom.Name = "cmbZoom";
            this.cmbZoom.Size = new System.Drawing.Size(120, 21);
            this.cmbZoom.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(877, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zoom";
            // 
            // btnGenerateArrow
            // 
            this.btnGenerateArrow.Location = new System.Drawing.Point(877, 125);
            this.btnGenerateArrow.Name = "btnGenerateArrow";
            this.btnGenerateArrow.Size = new System.Drawing.Size(99, 23);
            this.btnGenerateArrow.TabIndex = 6;
            this.btnGenerateArrow.Text = "Generar Flecha";
            this.btnGenerateArrow.Click += new System.EventHandler(this.btnGenerateArrow_Click);
            // 
            // diagram1
            // 
            this.diagram1.AllowDrop = true;
            this.diagram1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.diagram1.DragElement = null;
            this.diagram1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.diagram1.GridSize = new System.Drawing.Size(20, 20);
            this.diagram1.Location = new System.Drawing.Point(0, 0);
            this.diagram1.Name = "diagram1";
            paging1.Enabled = true;
            margin1.Bottom = 0F;
            margin1.Left = 0F;
            margin1.Right = 0F;
            margin1.Top = 0F;
            paging1.Margin = margin1;
            paging1.Padding = new System.Drawing.SizeF(40F, 40F);
            paging1.Page = 1;
            paging1.PageSize = new System.Drawing.SizeF(793.7008F, 1122.52F);
            paging1.WorkspaceColor = System.Drawing.SystemColors.AppWorkspace;
            this.diagram1.Paging = paging1;
            this.diagram1.Size = new System.Drawing.Size(854, 711);
            this.diagram1.TabIndex = 0;
            this.diagram1.Zoom = 100F;
            // 
            // cpeArrow
            // 
            this.cpeArrow.EditValue = System.Drawing.Color.Empty;
            this.cpeArrow.Location = new System.Drawing.Point(877, 99);
            this.cpeArrow.Name = "cpeArrow";
            this.cpeArrow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeArrow.Size = new System.Drawing.Size(100, 20);
            this.cpeArrow.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(877, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Unión:";
            // 
            // frmDiagramTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 627);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cpeArrow);
            this.Controls.Add(this.btnGenerateArrow);
            this.Controls.Add(this.cmbZoom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diagram1);
            this.Menu = this.mainMenu1;
            this.Name = "frmDiagramTest";
            this.Text = "frmDiagram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDiagramTest_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDiagramTest_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cpeArrow.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Crainiate.Diagramming.Forms.Diagram diagram1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.ComboBox cmbZoom;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnGenerateArrow;
        private DevExpress.XtraEditors.ColorPickEdit cpeArrow;
        private System.Windows.Forms.Label label2;
    }
}