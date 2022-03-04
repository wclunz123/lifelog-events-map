using GMap.NET.WindowsForms;
using System;

namespace ICT365_Assignment1
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
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.addEventButton = new System.Windows.Forms.Button();
            this.retrieveEventButton = new System.Windows.Forms.Button();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(182, 549);
            this.splitter2.TabIndex = 0;
            this.splitter2.TabStop = false;
            // 
            // gMapControl
            // 
            this.gMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemory = 5;
            this.gMapControl.Location = new System.Drawing.Point(183, 0);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(798, 549);
            this.gMapControl.TabIndex = 1;
            this.gMapControl.Zoom = 2D;
            this.gMapControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl_OnMarkerClick);
            this.gMapControl.Load += new System.EventHandler(this.gMapControl_Load);
            this.gMapControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseClick);
            // 
            // addEventButton
            // 
            this.addEventButton.Location = new System.Drawing.Point(15, 452);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(155, 39);
            this.addEventButton.TabIndex = 2;
            this.addEventButton.Text = "Add Event";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // retrieveEventButton
            // 
            this.retrieveEventButton.Location = new System.Drawing.Point(15, 497);
            this.retrieveEventButton.Name = "retrieveEventButton";
            this.retrieveEventButton.Size = new System.Drawing.Size(155, 40);
            this.retrieveEventButton.TabIndex = 3;
            this.retrieveEventButton.Text = "Retrieve Event";
            this.retrieveEventButton.UseVisualStyleBackColor = true;
            this.retrieveEventButton.Click += new System.EventHandler(this.retrieveEventButton_Click);
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(12, 375);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(54, 16);
            this.lblLatitude.TabIndex = 4;
            this.lblLatitude.Text = "Latitude";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(12, 406);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(66, 16);
            this.lblLongitude.TabIndex = 5;
            this.lblLongitude.Text = "Longitude";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(84, 375);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(86, 22);
            this.txtLatitude.TabIndex = 6;
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(84, 406);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(86, 22);
            this.txtLongitude.TabIndex = 7;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(13, 13);
            this.lblInstruction.MaximumSize = new System.Drawing.Size(160, 160);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(160, 57);
            this.lblInstruction.TabIndex = 8;
            this.lblInstruction.Text = "Click on anywhere of the map to create an event.";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(980, 549);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.txtLongitude);
            this.Controls.Add(this.txtLatitude);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.retrieveEventButton);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.splitter2);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Name = "MainForm";
            this.Text = "ICT365_Assignment1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter2;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.Button retrieveEventButton;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Label lblInstruction;
    }
}

