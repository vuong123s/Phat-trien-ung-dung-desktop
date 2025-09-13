namespace AppXoSO
{
    partial class FormChiTiet
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPubDate;
        private System.Windows.Forms.RichTextBox txtDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPubDate = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblTitle.Size = new System.Drawing.Size(684, 40);
            this.lblTitle.Text = "Tiêu đề";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // lblPubDate
            this.lblPubDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPubDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblPubDate.Location = new System.Drawing.Point(0, 40);
            this.lblPubDate.Name = "lblPubDate";
            this.lblPubDate.Padding = new System.Windows.Forms.Padding(5);
            this.lblPubDate.Size = new System.Drawing.Size(684, 25);
            this.lblPubDate.Text = "Ngày:";
            this.lblPubDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // txtDescription
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Location = new System.Drawing.Point(0, 65);
            this.txtDescription.Size = new System.Drawing.Size(684, 396);
            this.txtDescription.Text = "";
            // FormChiTiet
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblPubDate);
            this.Controls.Add(this.lblTitle);
            this.Text = "Chi tiết kết quả xổ số";
            this.ResumeLayout(false);
        }
    }
}
