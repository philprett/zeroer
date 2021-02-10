using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Zeroer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>

	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listDrives;
		private System.Windows.Forms.Button buttonCreate;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.Button buttonExpand;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonShrink;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ProgressBar progressBar;
        private Button buttonZeroFreeSpace;
        private CheckBox chkWithOnes;

		private ZeroFile zeroFile;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Form1()
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
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.listDrives = new System.Windows.Forms.ListBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonExpand = new System.Windows.Forms.Button();
            this.buttonShrink = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonZeroFreeSpace = new System.Windows.Forms.Button();
            this.chkWithOnes = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drives";
            // 
            // listDrives
            // 
            this.listDrives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDrives.Location = new System.Drawing.Point(8, 24);
            this.listDrives.Name = "listDrives";
            this.listDrives.Size = new System.Drawing.Size(280, 134);
            this.listDrives.TabIndex = 1;
            this.listDrives.SelectedIndexChanged += new System.EventHandler(this.listDrives_SelectedIndexChanged);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.Enabled = false;
            this.buttonCreate.Location = new System.Drawing.Point(296, 24);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(377, 24);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonExpand
            // 
            this.buttonExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExpand.Enabled = false;
            this.buttonExpand.Location = new System.Drawing.Point(296, 53);
            this.buttonExpand.Name = "buttonExpand";
            this.buttonExpand.Size = new System.Drawing.Size(75, 23);
            this.buttonExpand.TabIndex = 4;
            this.buttonExpand.Text = "Expand";
            this.buttonExpand.Click += new System.EventHandler(this.buttonExpand_Click);
            // 
            // buttonShrink
            // 
            this.buttonShrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShrink.Enabled = false;
            this.buttonShrink.Location = new System.Drawing.Point(377, 53);
            this.buttonShrink.Name = "buttonShrink";
            this.buttonShrink.Size = new System.Drawing.Size(75, 23);
            this.buttonShrink.TabIndex = 5;
            this.buttonShrink.Text = "Shrink";
            this.buttonShrink.Click += new System.EventHandler(this.buttonShrink_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(296, 82);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 50);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(296, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Zeroer File";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(8, 178);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(443, 23);
            this.progressBar.TabIndex = 9;
            // 
            // buttonZeroFreeSpace
            // 
            this.buttonZeroFreeSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZeroFreeSpace.Enabled = false;
            this.buttonZeroFreeSpace.Location = new System.Drawing.Point(377, 82);
            this.buttonZeroFreeSpace.Name = "buttonZeroFreeSpace";
            this.buttonZeroFreeSpace.Size = new System.Drawing.Size(75, 50);
            this.buttonZeroFreeSpace.TabIndex = 10;
            this.buttonZeroFreeSpace.Text = "Zero Free Space";
            this.buttonZeroFreeSpace.Click += new System.EventHandler(this.buttonZeroFreeSpace_Click);
            // 
            // chkWithOnes
            // 
            this.chkWithOnes.AutoSize = true;
            this.chkWithOnes.Location = new System.Drawing.Point(296, 138);
            this.chkWithOnes.Name = "chkWithOnes";
            this.chkWithOnes.Size = new System.Drawing.Size(100, 17);
            this.chkWithOnes.TabIndex = 11;
            this.chkWithOnes.Text = "Also with ones?";
            this.chkWithOnes.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(459, 213);
            this.Controls.Add(this.chkWithOnes);
            this.Controls.Add(this.buttonZeroFreeSpace);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonShrink);
            this.Controls.Add(this.buttonExpand);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.listDrives);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(475, 215);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zeroer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			buttonRefresh_Click(sender, e);
		}

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void listDrives_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			char driveLetter = listDrives.SelectedItem.ToString()[0];
			ZeroFile zf = new ZeroFile( driveLetter );
			if ( zf.Exists ) 
			{
				this.buttonCreate.Enabled = false;
				this.buttonRemove.Enabled = true;
				this.buttonExpand.Enabled = true;
				this.buttonShrink.Enabled = true;
                this.buttonZeroFreeSpace.Enabled = true;
            }
            else
			{
				this.buttonCreate.Enabled = true;
				this.buttonRemove.Enabled = false;
				this.buttonExpand.Enabled = false;
				this.buttonShrink.Enabled = false;
                this.buttonZeroFreeSpace.Enabled = true;
            }
        }

		private void buttonRefresh_Click(object sender, System.EventArgs e)
		{
			// Populate the list of drives
			this.listDrives.Items.Clear();

			string [] driveNames = System.IO.Directory.GetLogicalDrives();
			foreach ( string driveName in driveNames ) 
			{
				System.IO.DirectoryInfo drive = new System.IO.DirectoryInfo(driveName);
				if ( drive.Exists ) 
				{
					DriveInfo driveInfo = new DriveInfo(driveName[0]);
					if ( driveInfo.DriveType == DriveInfo.DriveTypeEnum.LocalDisk) 
					{
						string status =	driveName + " " + 
							DriveInfo.GetFriendlyBytes(driveInfo.FreeSpace) + " of " +
							DriveInfo.GetFriendlyBytes(driveInfo.Size) + " free";
						ZeroFile zf = new ZeroFile( driveName[0] );
						if ( zf.Exists ) 
						{
							status +=	" with " + DriveInfo.GetFriendlyBytes(zf.Size) + " zeroed";
						}
						this.listDrives.Items.Add ( status );
					}				
				}
			}
		}

		private void buttonCreate_Click(object sender, System.EventArgs e)
		{
			int selectedDrive = listDrives.SelectedIndex;
			char driveLetter = listDrives.SelectedItem.ToString()[0];
			ZeroFile zf = new ZeroFile( driveLetter );
			if ( zf.Exists ) 
			{
				MessageBox.Show("This drive already has a Zeroer File","Error");
			} 
			else 
			{
				GetAmountForm form = new GetAmountForm();
				form.Text = "Create Zeroer File with size...";
				form.Amount = 1;
				form.Units = "GigaBytes";
				if ( form.ShowDialog() != DialogResult.Cancel ) 
				{
					this.Refresh();
					long amount = form.Amount;
					if ( form.Units == "KiloBytes" ) 
						amount *= DriveInfo.KILOBYTE;
					else if ( form.Units == "MegaBytes" ) 
						amount *= DriveInfo.MEGABYTE;
					else if ( form.Units == "GigaBytes" ) 
						amount *= DriveInfo.GIGABYTE;
					this.Cursor = Cursors.WaitCursor;
					this.buttonCreate.Enabled = false;
					this.buttonRemove.Enabled = false;
					this.buttonExpand.Enabled = false;
					this.buttonShrink.Enabled = false;
                    this.buttonZeroFreeSpace.Enabled = false;
					zeroFile = new ZeroFile(driveLetter);
					zeroFile.Create(amount/DriveInfo.MEGABYTE, chkWithOnes.Checked, this.progressBar);
					zeroFile = null;
					buttonRefresh_Click(sender, e);
					listDrives.SelectedIndex = selectedDrive;
					this.Cursor = Cursors.Arrow;
				}
			}
		}

		private void buttonRemove_Click(object sender, System.EventArgs e)
		{
			int selectedDrive = listDrives.SelectedIndex;
			char driveLetter = listDrives.SelectedItem.ToString()[0];
			ZeroFile zf = new ZeroFile( driveLetter );
			if ( !zf.Exists ) 
			{
				MessageBox.Show("This drive does not have a Zeroer File","Error");
			} 
			else 
			{
				this.Cursor = Cursors.WaitCursor;
				this.buttonCreate.Enabled = false;
				this.buttonRemove.Enabled = false;
				this.buttonExpand.Enabled = false;
				this.buttonShrink.Enabled = false;
                this.buttonZeroFreeSpace.Enabled = false;
                zf.Delete();
				buttonRefresh_Click(sender, e);
				listDrives.SelectedIndex = selectedDrive;
				this.Cursor = Cursors.Arrow;
			}
		}

		private void buttonExpand_Click(object sender, System.EventArgs e)
		{
			int selectedDrive = listDrives.SelectedIndex;
			char driveLetter = listDrives.SelectedItem.ToString()[0];
			ZeroFile zf = new ZeroFile( driveLetter );
			if ( !zf.Exists ) 
			{
				MessageBox.Show("This drive does not have a Zeroer File","Error");
			} 
			else 
			{
				GetAmountForm form = new GetAmountForm();
				form.Text = "Expand Zeroer File by...";
				form.Amount = 1;
				form.Units = "GigaBytes";
				if ( form.ShowDialog() != DialogResult.Cancel ) 
				{
					this.Refresh();
					long amount = form.Amount;
					if ( form.Units == "KiloBytes" ) 
						amount *= DriveInfo.KILOBYTE;
					else if ( form.Units == "MegaBytes" ) 
						amount *= DriveInfo.MEGABYTE;
					else if ( form.Units == "GigaBytes" ) 
						amount *= DriveInfo.GIGABYTE;
					this.Cursor = Cursors.WaitCursor;
					this.buttonCreate.Enabled = false;
					this.buttonRemove.Enabled = false;
					this.buttonExpand.Enabled = false;
					this.buttonShrink.Enabled = false;
                    this.buttonZeroFreeSpace.Enabled = false;
					zeroFile = new ZeroFile(driveLetter);
                    zeroFile.Expand(amount/DriveInfo.MEGABYTE, chkWithOnes.Checked, this.progressBar);
					zeroFile = null;
					buttonRefresh_Click(sender, e);
					listDrives.SelectedIndex = selectedDrive;
					this.Cursor = Cursors.Arrow;
				}
			}
		}

		private void buttonShrink_Click(object sender, System.EventArgs e)
		{
			int selectedDrive = listDrives.SelectedIndex;
			char driveLetter = listDrives.SelectedItem.ToString()[0];
			ZeroFile zf = new ZeroFile( driveLetter );
			if ( !zf.Exists ) 
			{
				MessageBox.Show("This drive does not have a Zeroer File","Error");
			} 
			else 
			{
				GetAmountForm form = new GetAmountForm();
				form.Text = "Shrink Zeroer File by...";
				form.Amount = 1;
				form.Units = "GigaBytes";
				if ( form.ShowDialog() != DialogResult.Cancel ) 
				{
					this.Refresh();
					long amount = form.Amount;
					if ( form.Units == "KiloBytes" ) 
						amount *= DriveInfo.KILOBYTE;
					else if ( form.Units == "MegaBytes" ) 
						amount *= DriveInfo.MEGABYTE;
					else if ( form.Units == "GigaBytes" ) 
						amount *= DriveInfo.GIGABYTE;
					this.Cursor = Cursors.WaitCursor;
					this.buttonCreate.Enabled = false;
					this.buttonRemove.Enabled = false;
					this.buttonExpand.Enabled = false;
					this.buttonShrink.Enabled = false;
                    this.buttonZeroFreeSpace.Enabled = false;
                    zf.Shrink(amount/DriveInfo.MEGABYTE);
					buttonRefresh_Click(sender, e);
					listDrives.SelectedIndex = selectedDrive;
					this.Cursor = Cursors.Arrow;
				}
			}
		}

        private void buttonZeroFreeSpace_Click(object sender, EventArgs e)
        {
            int selectedDrive = listDrives.SelectedIndex;
            char driveLetter = listDrives.SelectedItem.ToString()[0];
            ZeroFile zf = new ZeroFile(driveLetter);
            this.Cursor = Cursors.WaitCursor;
            this.buttonCreate.Enabled = false;
            this.buttonRemove.Enabled = false;
            this.buttonExpand.Enabled = false;
            this.buttonShrink.Enabled = false;
            this.buttonZeroFreeSpace.Enabled = false;
			zeroFile = new ZeroFile(driveLetter);
            zeroFile.ZeroFreeSpace(chkWithOnes.Checked, this.progressBar);
			zeroFile = null;
            buttonRefresh_Click(sender, e);
            listDrives.SelectedIndex = selectedDrive;
            this.Cursor = Cursors.Arrow;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (zeroFile != null)
			{
				zeroFile.Canceled = true;
			}
        }
    }
}
