namespace asenecal_nasa
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.apodInfos = new System.Windows.Forms.Button();
            this.apodTxt = new System.Windows.Forms.TextBox();
            this.nearAsteroids = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.asteroidsList = new System.Windows.Forms.ListView();
            this.AsteroidName = new System.Windows.Forms.ColumnHeader();
            this.Distance = new System.Windows.Forms.ColumnHeader();
            this.asteroidDetails = new System.Windows.Forms.ListView();
            this.ApproachDate = new System.Windows.Forms.ColumnHeader();
            this.MissDistance = new System.Windows.Forms.ColumnHeader();
            this.Velocity = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // apodInfos
            // 
            this.apodInfos.Location = new System.Drawing.Point(25, 160);
            this.apodInfos.Name = "apodInfos";
            this.apodInfos.Size = new System.Drawing.Size(160, 80);
            this.apodInfos.TabIndex = 0;
            this.apodInfos.Text = "APOD Infos";
            this.apodInfos.UseVisualStyleBackColor = true;
            this.apodInfos.Click += new System.EventHandler(this.apodInfosClick);
            // 
            // apodTxt
            // 
            this.apodTxt.Location = new System.Drawing.Point(25, 440);
            this.apodTxt.Multiline = true;
            this.apodTxt.Name = "apodTxt";
            this.apodTxt.ReadOnly = true;
            this.apodTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.apodTxt.Size = new System.Drawing.Size(250, 500);
            this.apodTxt.TabIndex = 1;
            this.apodTxt.Visible = false;
            this.apodTxt.TextChanged += new System.EventHandler(this.apodTxtChanged);
            // 
            // nearAsteroids
            // 
            this.nearAsteroids.Location = new System.Drawing.Point(25, 300);
            this.nearAsteroids.Name = "nearAsteroids";
            this.nearAsteroids.Size = new System.Drawing.Size(160, 80);
            this.nearAsteroids.TabIndex = 3;
            this.nearAsteroids.Text = "Near Asteroids";
            this.nearAsteroids.UseVisualStyleBackColor = true;
            this.nearAsteroids.Click += new System.EventHandler(this.nearAsteroidsClick);
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Title.ForeColor = System.Drawing.Color.Indigo;
            this.Title.Location = new System.Drawing.Point(25, 50);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(160, 80);
            this.Title.TabIndex = 5;
            this.Title.Text = "Astronomy Project";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // asteroidsList
            // 
            this.asteroidsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AsteroidName,
            this.Distance});
            this.asteroidsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.asteroidsList.Location = new System.Drawing.Point(1550, 100);
            this.asteroidsList.Name = "asteroidsList";
            this.asteroidsList.Size = new System.Drawing.Size(300, 200);
            this.asteroidsList.TabIndex = 6;
            this.asteroidsList.UseCompatibleStateImageBehavior = false;
            this.asteroidsList.View = System.Windows.Forms.View.Details;
            this.asteroidsList.Visible = false;
            this.asteroidsList.SelectedIndexChanged += new System.EventHandler(this.asteroidsListSelected);
            // 
            // AsteroidName
            // 
            this.AsteroidName.Text = "Name";
            this.AsteroidName.Width = 120;
            // 
            // Distance
            // 
            this.Distance.Text = "Distance Min (in lunar)";
            this.Distance.Width = 200;
            // 
            // asteroidDetails
            // 
            this.asteroidDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ApproachDate,
            this.MissDistance,
            this.Velocity});
            this.asteroidDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.asteroidDetails.Location = new System.Drawing.Point(1550, 400);
            this.asteroidDetails.Name = "asteroidDetails";
            this.asteroidDetails.Size = new System.Drawing.Size(300, 200);
            this.asteroidDetails.TabIndex = 7;
            this.asteroidDetails.UseCompatibleStateImageBehavior = false;
            this.asteroidDetails.View = System.Windows.Forms.View.Details;
            this.asteroidDetails.Visible = false;
            // 
            // ApproachDate
            // 
            this.ApproachDate.Text = "ApproachDate";
            this.ApproachDate.Width = 120;
            // 
            // MissDistance
            // 
            this.MissDistance.Text = "Distance Min (in lunar)";
            this.MissDistance.Width = 161;
            // 
            // Velocity
            // 
            this.Velocity.Text = "Velocity (in km/s)";
            this.Velocity.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1400, 920);
            this.Controls.Add(this.asteroidDetails);
            this.Controls.Add(this.asteroidsList);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.nearAsteroids);
            this.Controls.Add(this.apodTxt);
            this.Controls.Add(this.apodInfos);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button apodInfos;
        private TextBox apodTxt;
        private Button nearAsteroids;
        private Label Title;
        private ListView asteroidsList;
        private ColumnHeader AsteroidName;
        private ColumnHeader Distance;
        private ListView asteroidDetails;
        private ColumnHeader ApproachDate;
        private ColumnHeader MissDistance;
        private ColumnHeader Velocity;
    }
}