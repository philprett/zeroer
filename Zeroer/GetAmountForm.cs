using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroer
{
	/// <summary>
	/// Summary description for GetAmountForm.
	/// </summary>
	public class GetAmountForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textSize;
		private System.Windows.Forms.ComboBox comboUnits;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public long Amount = 0;
		public string Units = "";

		public GetAmountForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textSize = new System.Windows.Forms.TextBox();
			this.comboUnits = new System.Windows.Forms.ComboBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textSize
			// 
			this.textSize.Location = new System.Drawing.Point(8, 8);
			this.textSize.Name = "textSize";
			this.textSize.Size = new System.Drawing.Size(48, 20);
			this.textSize.TabIndex = 0;
			this.textSize.Text = "1";
			// 
			// comboUnits
			// 
			this.comboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboUnits.Items.AddRange(new object[] {
															"Bytes",
															"KiloBytes",
															"MegaBytes",
															"GigaBytes",
															"TeraBytes"});
			this.comboUnits.Location = new System.Drawing.Point(64, 8);
			this.comboUnits.Name = "comboUnits";
			this.comboUnits.Size = new System.Drawing.Size(88, 21);
			this.comboUnits.TabIndex = 1;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(160, 8);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(248, 8);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			// 
			// GetAmountForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(336, 43);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.comboUnits);
			this.Controls.Add(this.textSize);
			this.Name = "GetAmountForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "How Much";
			this.Load += new System.EventHandler(this.GetAmountForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.Amount = long.Parse(this.textSize.Text);
			this.Units = this.comboUnits.SelectedItem.ToString();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void GetAmountForm_Load(object sender, System.EventArgs e)
		{
			this.textSize.Text = this.Amount.ToString();
			this.comboUnits.SelectedItem = this.Units;
		}
	}
}
