namespace TNS.Win.View.RealtimeReview
{
    partial class FrmRealtimeReviewList
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
            this.gcRTRList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtHotelId = new DevExpress.XtraEditors.TextEdit();
            this.txtItemsCount = new DevExpress.XtraEditors.TextEdit();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcRTRList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHotelId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemsCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcRTRList
            // 
            this.gcRTRList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRTRList.Location = new System.Drawing.Point(0, 0);
            this.gcRTRList.MainView = this.gridView1;
            this.gcRTRList.Name = "gcRTRList";
            this.gcRTRList.Size = new System.Drawing.Size(927, 502);
            this.gcRTRList.TabIndex = 0;
            this.gcRTRList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcRTRList;
            this.gridView1.Name = "gridView1";
            // 
            // txtHotelId
            // 
            this.txtHotelId.Location = new System.Drawing.Point(82, 9);
            this.txtHotelId.Name = "txtHotelId";
            this.txtHotelId.Size = new System.Drawing.Size(130, 20);
            this.txtHotelId.TabIndex = 1;
            // 
            // txtItemsCount
            // 
            this.txtItemsCount.Location = new System.Drawing.Point(342, 9);
            this.txtItemsCount.Name = "txtItemsCount";
            this.txtItemsCount.Size = new System.Drawing.Size(119, 20);
            this.txtItemsCount.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(494, 7);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(92, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hotel Id :";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.btnLoad);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txtHotelId);
            this.panelControl1.Controls.Add(this.txtItemsCount);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(927, 37);
            this.panelControl1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Items count :";
            // 
            // FrmRealtimeReviewList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 502);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gcRTRList);
            this.Name = "FrmRealtimeReviewList";
            this.Text = "Realtime Review List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gcRTRList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHotelId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemsCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcRTRList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtHotelId;
        private DevExpress.XtraEditors.TextEdit txtItemsCount;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label2;
    }
}