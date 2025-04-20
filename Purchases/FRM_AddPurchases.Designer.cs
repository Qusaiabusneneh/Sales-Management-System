namespace Sales_Management.App.Purchases
{
    partial class FRM_AddPurchases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_AddPurchases));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbBasicInfo = new System.Windows.Forms.GroupBox();
            this.linkAddNewSupplier = new System.Windows.Forms.LinkLabel();
            this.linkAddNewCategory = new System.Windows.Forms.LinkLabel();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPurchasesType = new System.Windows.Forms.TextBox();
            this.txtPurchasesName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalEarnings = new System.Windows.Forms.Label();
            this.lblTotalSells = new System.Windows.Forms.Label();
            this.lblTotalBuy = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbSaleAndPurchase = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.txtSell = new System.Windows.Forms.TextBox();
            this.txtBuy = new System.Windows.Forms.TextBox();
            this.gbBasicInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbSaleAndPurchase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Gray;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(896, 726);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(141, 50);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "أضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClose.Location = new System.Drawing.Point(996, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 50);
            this.btnClose.TabIndex = 36;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbBasicInfo
            // 
            this.gbBasicInfo.Controls.Add(this.linkAddNewSupplier);
            this.gbBasicInfo.Controls.Add(this.linkAddNewCategory);
            this.gbBasicInfo.Controls.Add(this.cmbSupplier);
            this.gbBasicInfo.Controls.Add(this.cmbCategory);
            this.gbBasicInfo.Controls.Add(this.label1);
            this.gbBasicInfo.Controls.Add(this.txtDetails);
            this.gbBasicInfo.Controls.Add(this.label5);
            this.gbBasicInfo.Controls.Add(this.label4);
            this.gbBasicInfo.Controls.Add(this.txt);
            this.gbBasicInfo.Controls.Add(this.lblTitle);
            this.gbBasicInfo.Controls.Add(this.txtPurchasesType);
            this.gbBasicInfo.Controls.Add(this.txtPurchasesName);
            this.gbBasicInfo.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBasicInfo.Location = new System.Drawing.Point(465, 56);
            this.gbBasicInfo.Name = "gbBasicInfo";
            this.gbBasicInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbBasicInfo.Size = new System.Drawing.Size(581, 425);
            this.gbBasicInfo.TabIndex = 37;
            this.gbBasicInfo.TabStop = false;
            this.gbBasicInfo.Text = "معلومات اساسية";
            // 
            // linkAddNewSupplier
            // 
            this.linkAddNewSupplier.AutoSize = true;
            this.linkAddNewSupplier.Font = new System.Drawing.Font("Cairo Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAddNewSupplier.Location = new System.Drawing.Point(305, 214);
            this.linkAddNewSupplier.Name = "linkAddNewSupplier";
            this.linkAddNewSupplier.Size = new System.Drawing.Size(58, 30);
            this.linkAddNewSupplier.TabIndex = 29;
            this.linkAddNewSupplier.TabStop = true;
            this.linkAddNewSupplier.Text = "أضافة";
            this.linkAddNewSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddNewSupplier_LinkClicked);
            // 
            // linkAddNewCategory
            // 
            this.linkAddNewCategory.AutoSize = true;
            this.linkAddNewCategory.Font = new System.Drawing.Font("Cairo Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAddNewCategory.Location = new System.Drawing.Point(305, 155);
            this.linkAddNewCategory.Name = "linkAddNewCategory";
            this.linkAddNewCategory.Size = new System.Drawing.Size(58, 30);
            this.linkAddNewCategory.TabIndex = 29;
            this.linkAddNewCategory.TabStop = true;
            this.linkAddNewCategory.Text = "أضافة";
            this.linkAddNewCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddNewCategory_LinkClicked);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(6, 211);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(271, 38);
            this.cmbSupplier.TabIndex = 28;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(6, 152);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(271, 38);
            this.cmbCategory.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(469, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 45);
            this.label1.TabIndex = 27;
            this.label1.Text = "تفاصيل";
            // 
            // txtDetails
            // 
            this.txtDetails.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDetails.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetails.Location = new System.Drawing.Point(6, 283);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(444, 117);
            this.txtDetails.TabIndex = 26;
            this.txtDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(469, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 45);
            this.label5.TabIndex = 27;
            this.label5.Text = "المورد";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(466, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 45);
            this.label4.TabIndex = 27;
            this.label4.Text = "الصنف";
            // 
            // txt
            // 
            this.txt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt.AutoSize = true;
            this.txt.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.ForeColor = System.Drawing.Color.DimGray;
            this.txt.Location = new System.Drawing.Point(466, 78);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(73, 45);
            this.txt.TabIndex = 27;
            this.txt.Text = "النوع";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitle.Location = new System.Drawing.Point(417, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(140, 45);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "اسم المادة";
            // 
            // txtPurchasesType
            // 
            this.txtPurchasesType.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPurchasesType.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchasesType.Location = new System.Drawing.Point(6, 85);
            this.txtPurchasesType.Multiline = true;
            this.txtPurchasesType.Name = "txtPurchasesType";
            this.txtPurchasesType.Size = new System.Drawing.Size(271, 39);
            this.txtPurchasesType.TabIndex = 26;
            this.txtPurchasesType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPurchasesName
            // 
            this.txtPurchasesName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPurchasesName.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchasesName.Location = new System.Drawing.Point(6, 33);
            this.txtPurchasesName.Multiline = true;
            this.txtPurchasesName.Name = "txtPurchasesName";
            this.txtPurchasesName.Size = new System.Drawing.Size(271, 39);
            this.txtPurchasesName.TabIndex = 26;
            this.txtPurchasesName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalEarnings);
            this.groupBox2.Controls.Add(this.lblTotalSells);
            this.groupBox2.Controls.Add(this.lblTotalBuy);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(400, 354);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // lblTotalEarnings
            // 
            this.lblTotalEarnings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalEarnings.AutoSize = true;
            this.lblTotalEarnings.Font = new System.Drawing.Font("Cairo Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEarnings.ForeColor = System.Drawing.Color.Coral;
            this.lblTotalEarnings.Location = new System.Drawing.Point(158, 283);
            this.lblTotalEarnings.Name = "lblTotalEarnings";
            this.lblTotalEarnings.Size = new System.Drawing.Size(37, 50);
            this.lblTotalEarnings.TabIndex = 27;
            this.lblTotalEarnings.Text = "0";
            // 
            // lblTotalSells
            // 
            this.lblTotalSells.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalSells.AutoSize = true;
            this.lblTotalSells.Font = new System.Drawing.Font("Cairo Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSells.ForeColor = System.Drawing.Color.Coral;
            this.lblTotalSells.Location = new System.Drawing.Point(158, 162);
            this.lblTotalSells.Name = "lblTotalSells";
            this.lblTotalSells.Size = new System.Drawing.Size(37, 50);
            this.lblTotalSells.TabIndex = 27;
            this.lblTotalSells.Text = "0";
            // 
            // lblTotalBuy
            // 
            this.lblTotalBuy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalBuy.AutoSize = true;
            this.lblTotalBuy.Font = new System.Drawing.Font("Cairo Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBuy.ForeColor = System.Drawing.Color.Coral;
            this.lblTotalBuy.Location = new System.Drawing.Point(158, 67);
            this.lblTotalBuy.Name = "lblTotalBuy";
            this.lblTotalBuy.Size = new System.Drawing.Size(37, 50);
            this.lblTotalBuy.TabIndex = 27;
            this.lblTotalBuy.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(94, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 45);
            this.label8.TabIndex = 27;
            this.label8.Text = "الأرباح الكلية";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(52, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 45);
            this.label6.TabIndex = 27;
            this.label6.Text = "المبيعات (السعر الكلي)";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(52, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(280, 45);
            this.label10.TabIndex = 27;
            this.label10.Text = "المشتريات (السعر الكلي)";
            // 
            // gbSaleAndPurchase
            // 
            this.gbSaleAndPurchase.Controls.Add(this.numericUpDown1);
            this.gbSaleAndPurchase.Controls.Add(this.label15);
            this.gbSaleAndPurchase.Controls.Add(this.label12);
            this.gbSaleAndPurchase.Controls.Add(this.label);
            this.gbSaleAndPurchase.Controls.Add(this.txtSell);
            this.gbSaleAndPurchase.Controls.Add(this.txtBuy);
            this.gbSaleAndPurchase.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSaleAndPurchase.Location = new System.Drawing.Point(465, 490);
            this.gbSaleAndPurchase.Name = "gbSaleAndPurchase";
            this.gbSaleAndPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbSaleAndPurchase.Size = new System.Drawing.Size(575, 219);
            this.gbSaleAndPurchase.TabIndex = 39;
            this.gbSaleAndPurchase.TabStop = false;
            this.gbSaleAndPurchase.Text = "البيع والشراء";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 166);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(271, 37);
            this.numericUpDown1.TabIndex = 28;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});

            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(482, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 36);
            this.label15.TabIndex = 27;
            this.label15.Text = "الكمية";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(378, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(177, 36);
            this.label12.TabIndex = 27;
            this.label12.Text = "سعر الشراء (المفرد)";
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.DimGray;
            this.label.Location = new System.Drawing.Point(391, 99);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(164, 36);
            this.label.TabIndex = 27;
            this.label.Text = "سعر البيع (المفرد)";
            // 
            // txtSell
            // 
            this.txtSell.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSell.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSell.Location = new System.Drawing.Point(9, 96);
            this.txtSell.Multiline = true;
            this.txtSell.Name = "txtSell";
            this.txtSell.Size = new System.Drawing.Size(271, 39);
            this.txtSell.TabIndex = 26;
            this.txtSell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBuy
            // 
            this.txtBuy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtBuy.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuy.Location = new System.Drawing.Point(9, 39);
            this.txtBuy.Multiline = true;
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.Size = new System.Drawing.Size(271, 39);
            this.txtBuy.TabIndex = 26;
            this.txtBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FRM_AddPurchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1049, 788);
            this.Controls.Add(this.gbSaleAndPurchase);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbBasicInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_AddPurchases";
            this.Text = "Add Purchases";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_AddPurchases_FormClosing);
            this.Load += new System.EventHandler(this.FRM_AddPurchases_Load);
            this.gbBasicInfo.ResumeLayout(false);
            this.gbBasicInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbSaleAndPurchase.ResumeLayout(false);
            this.gbSaleAndPurchase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbBasicInfo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.TextBox txtPurchasesName;
        private System.Windows.Forms.LinkLabel linkAddNewSupplier;
        private System.Windows.Forms.LinkLabel linkAddNewCategory;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txt;
        public System.Windows.Forms.TextBox txtPurchasesType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalEarnings;
        private System.Windows.Forms.Label lblTotalSells;
        private System.Windows.Forms.Label lblTotalBuy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbSaleAndPurchase;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label;
        public System.Windows.Forms.TextBox txtSell;
        public System.Windows.Forms.TextBox txtBuy;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}