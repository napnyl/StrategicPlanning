namespace StPlanning
{
    partial class SplashScreen1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen1));
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            resources.ApplyResources(this.marqueeProgressBarControl1, "marqueeProgressBarControl1");
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.AccessibleDescription = resources.GetString("marqueeProgressBarControl1.Properties.AccessibleDescription");
            this.marqueeProgressBarControl1.Properties.AccessibleName = resources.GetString("marqueeProgressBarControl1.Properties.AccessibleName");
            this.marqueeProgressBarControl1.Properties.AutoHeight = ((bool)(resources.GetObject("marqueeProgressBarControl1.Properties.AutoHeight")));
            this.marqueeProgressBarControl1.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.marqueeProgressBarControl1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Name = "labelControl1";
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // pictureEdit2
            // 
            resources.ApplyResources(this.pictureEdit2, "pictureEdit2");
            this.pictureEdit2.EditValue = global::StPlanning.Properties.Resources.LOGO_ESPE_NO_FONDO2;
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.AccessibleDescription = resources.GetString("pictureEdit2.Properties.AccessibleDescription");
            this.pictureEdit2.Properties.AccessibleName = resources.GetString("pictureEdit2.Properties.AccessibleName");
            this.pictureEdit2.Properties.AllowFocused = false;
            this.pictureEdit2.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pictureEdit2.Properties.Appearance.BackColor")));
            this.pictureEdit2.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("pictureEdit2.Properties.Appearance.FontSizeDelta")));
            this.pictureEdit2.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("pictureEdit2.Properties.Appearance.FontStyleDelta")));
            this.pictureEdit2.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pictureEdit2.Properties.Appearance.GradientMode")));
            this.pictureEdit2.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("pictureEdit2.Properties.Appearance.Image")));
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowMenu = false;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // pictureEdit1
            // 
            resources.ApplyResources(this.pictureEdit1, "pictureEdit1");
            this.pictureEdit1.EditValue = global::StPlanning.Properties.Resources.logo1;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AccessibleDescription = resources.GetString("pictureEdit1.Properties.AccessibleDescription");
            this.pictureEdit1.Properties.AccessibleName = resources.GetString("pictureEdit1.Properties.AccessibleName");
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pictureEdit1.Properties.Appearance.BackColor")));
            this.pictureEdit1.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("pictureEdit1.Properties.Appearance.FontSizeDelta")));
            this.pictureEdit1.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("pictureEdit1.Properties.Appearance.FontStyleDelta")));
            this.pictureEdit1.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pictureEdit1.Properties.Appearance.GradientMode")));
            this.pictureEdit1.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.Properties.Appearance.Image")));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.pictureEdit1.Properties.ShowMenu = false;
            // 
            // SplashScreen1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureEdit2);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Name = "SplashScreen1";
            this.Opacity = 0.95D;
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
    }
}
