namespace TNS.Win.View.Person
{
    partial class FrmPersonEdit
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textFirstName = new DevExpress.XtraEditors.TextEdit();
            this.textSecondName = new DevExpress.XtraEditors.TextEdit();
            this.textComment = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSecondName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textComment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "姓   名 :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "曾用名 :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 99);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "备   注 :";
            // 
            // textFirstName
            // 
            this.textFirstName.Location = new System.Drawing.Point(71, 12);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(169, 20);
            this.textFirstName.TabIndex = 3;
            // 
            // textSecondName
            // 
            this.textSecondName.Location = new System.Drawing.Point(71, 51);
            this.textSecondName.Name = "textSecondName";
            this.textSecondName.Size = new System.Drawing.Size(169, 20);
            this.textSecondName.TabIndex = 3;
            // 
            // textComment
            // 
            this.textComment.Location = new System.Drawing.Point(71, 95);
            this.textComment.Name = "textComment";
            this.textComment.Size = new System.Drawing.Size(169, 20);
            this.textComment.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(165, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(84, 139);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmPersonEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 181);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textComment);
            this.Controls.Add(this.textSecondName);
            this.Controls.Add(this.textFirstName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmPersonEdit";
            this.Text = "FrmPersonEdit";
            ((System.ComponentModel.ISupportInitialize)(this.textFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSecondName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textComment.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textFirstName;
        private DevExpress.XtraEditors.TextEdit textSecondName;
        private DevExpress.XtraEditors.TextEdit textComment;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;


    }
}