namespace StPlanning.WorkFlow.Forms
{
    partial class frmDiagramTest
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
            Crainiate.Diagramming.Forms.Paging paging2 = new Crainiate.Diagramming.Forms.Paging();
            Crainiate.Diagramming.Forms.Margin margin2 = new Crainiate.Diagramming.Forms.Margin();
            this.btnGenerateArrow = new DevExpress.XtraEditors.SimpleButton();
            this.cpeArrow = new DevExpress.XtraEditors.ColorPickEdit();
            this.diagram1 = new Crainiate.Diagramming.Forms.Diagram();
            ((System.ComponentModel.ISupportInitialize)(this.cpeArrow.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateArrow
            // 
            this.btnGenerateArrow.Location = new System.Drawing.Point(3, 31);
            this.btnGenerateArrow.Name = "btnGenerateArrow";
            this.btnGenerateArrow.Size = new System.Drawing.Size(99, 23);
            this.btnGenerateArrow.TabIndex = 6;
            this.btnGenerateArrow.Text = "Generar Flecha";
            this.btnGenerateArrow.Click += new System.EventHandler(this.btnGenerateArrow_Click);
            // 
            // cpeArrow
            // 
            this.cpeArrow.EditValue = System.Drawing.Color.Empty;
            this.cpeArrow.Location = new System.Drawing.Point(3, 4);
            this.cpeArrow.Name = "cpeArrow";
            this.cpeArrow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeArrow.Size = new System.Drawing.Size(100, 20);
            this.cpeArrow.TabIndex = 7;
            // 
            // diagram1
            // 
            this.diagram1.AllowDrop = true;
            this.diagram1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.diagram1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagram1.DragElement = null;
            this.diagram1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.diagram1.GridSize = new System.Drawing.Size(20, 20);
            this.diagram1.Location = new System.Drawing.Point(0, 0);
            this.diagram1.Name = "diagram1";
            paging2.Enabled = true;
            margin2.Bottom = 0F;
            margin2.Left = 0F;
            margin2.Right = 0F;
            margin2.Top = 0F;
            paging2.Margin = margin2;
            paging2.Padding = new System.Drawing.SizeF(40F, 40F);
            paging2.Page = 1;
            paging2.PageSize = new System.Drawing.SizeF(793.7008F, 1122.52F);
            paging2.WorkspaceColor = System.Drawing.SystemColors.AppWorkspace;
            this.diagram1.Paging = paging2;
            this.diagram1.Size = new System.Drawing.Size(1008, 606);
            this.diagram1.TabIndex = 0;
            this.diagram1.Zoom = 100F;
            this.diagram1.SelectedChanged += new System.EventHandler(this.diagram1_SelectedChanged);
            this.diagram1.BeginDragSelect += new System.Windows.Forms.MouseEventHandler(this.diagram1_BeginDragSelect);
            this.diagram1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diagram1_KeyDown);
            // 
            // frmDiagramTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 606);
            this.Controls.Add(this.cpeArrow);
            this.Controls.Add(this.btnGenerateArrow);
            this.Controls.Add(this.diagram1);
            this.Name = "frmDiagramTest";
            this.Text = "frmDiagram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDiagramTest_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDiagramTest_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cpeArrow.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Crainiate.Diagramming.Forms.Diagram diagram1;
        private DevExpress.XtraEditors.SimpleButton btnGenerateArrow;
        private DevExpress.XtraEditors.ColorPickEdit cpeArrow;
    }
}