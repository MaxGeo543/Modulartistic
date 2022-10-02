using System.Collections.Generic;

namespace GUI
{
    partial class SceneTabLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneTabLayout));
            this.ModNumLabel = new System.Windows.Forms.Label();
            this.ModNumIn = new System.Windows.Forms.TextBox();
            this.ModLimLowIn = new System.Windows.Forms.TextBox();
            this.ModLimLowLabel = new System.Windows.Forms.Label();
            this.ModLimUpIn = new System.Windows.Forms.TextBox();
            this.ModLimUpLabel = new System.Windows.Forms.Label();
            this.RotationIn = new System.Windows.Forms.TextBox();
            this.RotationLabel = new System.Windows.Forms.Label();
            this.XFactIn = new System.Windows.Forms.TextBox();
            this.XFactLabel = new System.Windows.Forms.Label();
            this.X0In = new System.Windows.Forms.TextBox();
            this.X0Label = new System.Windows.Forms.Label();
            this.YFactIn = new System.Windows.Forms.TextBox();
            this.YFactLabel = new System.Windows.Forms.Label();
            this.Y0In = new System.Windows.Forms.TextBox();
            this.Y0Label = new System.Windows.Forms.Label();
            this.ColValIn = new System.Windows.Forms.TextBox();
            this.ColValLabel = new System.Windows.Forms.Label();
            this.ColSatIn = new System.Windows.Forms.TextBox();
            this.ColSatLabel = new System.Windows.Forms.Label();
            this.ColMinIn = new System.Windows.Forms.TextBox();
            this.ColMinLabel = new System.Windows.Forms.Label();
            this.ColAlphaIn = new System.Windows.Forms.TextBox();
            this.ColAlphaLabel = new System.Windows.Forms.Label();
            this.ColFactBIn = new System.Windows.Forms.TextBox();
            this.ColFactGIn = new System.Windows.Forms.TextBox();
            this.ColFactRIn = new System.Windows.Forms.TextBox();
            this.ColFactLabel = new System.Windows.Forms.Label();
            this.InvalColGIn = new System.Windows.Forms.TextBox();
            this.InvalColRIn = new System.Windows.Forms.TextBox();
            this.InvalColAIn = new System.Windows.Forms.TextBox();
            this.InvalColLabel = new System.Windows.Forms.Label();
            this.ModGroup = new System.Windows.Forms.GroupBox();
            this.InvalColBIn = new System.Windows.Forms.TextBox();
            this.CoordGroup = new System.Windows.Forms.GroupBox();
            this.ColGroup = new System.Windows.Forms.GroupBox();
            this.ParaLabel = new System.Windows.Forms.Label();
            this.ParaIn = new System.Windows.Forms.TextBox();
            this.EasingLabel = new System.Windows.Forms.Label();
            this.EasingIn = new System.Windows.Forms.ComboBox();
            this.DurLabel = new System.Windows.Forms.Label();
            this.DurIn = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ModGroup.SuspendLayout();
            this.CoordGroup.SuspendLayout();
            this.ColGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModNumLabel
            // 
            this.ModNumLabel.AutoSize = true;
            this.ModNumLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModNumLabel.Location = new System.Drawing.Point(7, 27);
            this.ModNumLabel.Name = "ModNumLabel";
            this.ModNumLabel.Size = new System.Drawing.Size(124, 20);
            this.ModNumLabel.TabIndex = 0;
            this.ModNumLabel.Text = "Modulus Number";
            this.toolTip1.SetToolTip(this.ModNumLabel, "After the function is calculated, the result will be taken mod this number. \r\nMus" +
        "t be real number greater than zero. ");
            // 
            // ModNumIn
            // 
            this.ModNumIn.Location = new System.Drawing.Point(7, 47);
            this.ModNumIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ModNumIn.Name = "ModNumIn";
            this.ModNumIn.Size = new System.Drawing.Size(137, 27);
            this.ModNumIn.TabIndex = 1;
            // 
            // ModLimLowIn
            // 
            this.ModLimLowIn.Location = new System.Drawing.Point(7, 113);
            this.ModLimLowIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ModLimLowIn.Name = "ModLimLowIn";
            this.ModLimLowIn.Size = new System.Drawing.Size(137, 27);
            this.ModLimLowIn.TabIndex = 2;
            // 
            // ModLimLowLabel
            // 
            this.ModLimLowLabel.AutoSize = true;
            this.ModLimLowLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModLimLowLabel.Location = new System.Drawing.Point(7, 93);
            this.ModLimLowLabel.Name = "ModLimLowLabel";
            this.ModLimLowLabel.Size = new System.Drawing.Size(147, 20);
            this.ModLimLowLabel.TabIndex = 0;
            this.ModLimLowLabel.Text = "Modulus Lower Limit";
            this.toolTip1.SetToolTip(this.ModLimLowLabel, "Values lower than this will create a pixel with \"invalid color\". \r\nMust be real n" +
        "umber in range from zero to Modulus Number. ");
            // 
            // ModLimUpIn
            // 
            this.ModLimUpIn.Location = new System.Drawing.Point(7, 180);
            this.ModLimUpIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ModLimUpIn.Name = "ModLimUpIn";
            this.ModLimUpIn.Size = new System.Drawing.Size(137, 27);
            this.ModLimUpIn.TabIndex = 3;
            // 
            // ModLimUpLabel
            // 
            this.ModLimUpLabel.AutoSize = true;
            this.ModLimUpLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModLimUpLabel.Location = new System.Drawing.Point(7, 160);
            this.ModLimUpLabel.Name = "ModLimUpLabel";
            this.ModLimUpLabel.Size = new System.Drawing.Size(148, 20);
            this.ModLimUpLabel.TabIndex = 0;
            this.ModLimUpLabel.Text = "Modulus Upper Limit";
            this.toolTip1.SetToolTip(this.ModLimUpLabel, "Values higher than this will create a pixel with \"invalid color\".  \r\nMust be real" +
        " number in range from zero to Modulus Number. ");
            // 
            // RotationIn
            // 
            this.RotationIn.Location = new System.Drawing.Point(7, 247);
            this.RotationIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RotationIn.Name = "RotationIn";
            this.RotationIn.Size = new System.Drawing.Size(102, 27);
            this.RotationIn.TabIndex = 8;
            // 
            // RotationLabel
            // 
            this.RotationLabel.AutoSize = true;
            this.RotationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RotationLabel.Location = new System.Drawing.Point(7, 227);
            this.RotationLabel.Name = "RotationLabel";
            this.RotationLabel.Size = new System.Drawing.Size(66, 20);
            this.RotationLabel.TabIndex = 0;
            this.RotationLabel.Text = "Rotation";
            this.toolTip1.SetToolTip(this.RotationLabel, "The image will be rotated by this value in degrees. \r\nCan be any real number. ");
            // 
            // XFactIn
            // 
            this.XFactIn.Location = new System.Drawing.Point(7, 113);
            this.XFactIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.XFactIn.Name = "XFactIn";
            this.XFactIn.Size = new System.Drawing.Size(102, 27);
            this.XFactIn.TabIndex = 6;
            // 
            // XFactLabel
            // 
            this.XFactLabel.AutoSize = true;
            this.XFactLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.XFactLabel.Location = new System.Drawing.Point(7, 93);
            this.XFactLabel.Name = "XFactLabel";
            this.XFactLabel.Size = new System.Drawing.Size(61, 20);
            this.XFactLabel.TabIndex = 0;
            this.XFactLabel.Text = "x-factor";
            this.toolTip1.SetToolTip(this.XFactLabel, "Before x will passed into the function it will be multiplied with this value. \r\nC" +
        "an behave like zooming. Can be any real number. ");
            // 
            // X0In
            // 
            this.X0In.Location = new System.Drawing.Point(7, 47);
            this.X0In.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.X0In.Name = "X0In";
            this.X0In.Size = new System.Drawing.Size(102, 27);
            this.X0In.TabIndex = 4;
            // 
            // X0Label
            // 
            this.X0Label.AutoSize = true;
            this.X0Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.X0Label.Location = new System.Drawing.Point(7, 27);
            this.X0Label.Name = "X0Label";
            this.X0Label.Size = new System.Drawing.Size(24, 20);
            this.X0Label.TabIndex = 0;
            this.X0Label.Text = "x0";
            this.toolTip1.SetToolTip(this.X0Label, "The x-coordinate of the point that will be in the middle of the picture. \r\nCan be" +
        " any real number. ");
            // 
            // YFactIn
            // 
            this.YFactIn.Location = new System.Drawing.Point(120, 113);
            this.YFactIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.YFactIn.Name = "YFactIn";
            this.YFactIn.Size = new System.Drawing.Size(102, 27);
            this.YFactIn.TabIndex = 7;
            // 
            // YFactLabel
            // 
            this.YFactLabel.AutoSize = true;
            this.YFactLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YFactLabel.Location = new System.Drawing.Point(120, 93);
            this.YFactLabel.Name = "YFactLabel";
            this.YFactLabel.Size = new System.Drawing.Size(61, 20);
            this.YFactLabel.TabIndex = 0;
            this.YFactLabel.Text = "y-factor";
            this.toolTip1.SetToolTip(this.YFactLabel, "Before y will passed into the function it will be multiplied with this value. \r\nC" +
        "an behave like zooming. Can be any real number. ");
            // 
            // Y0In
            // 
            this.Y0In.Location = new System.Drawing.Point(120, 47);
            this.Y0In.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Y0In.Name = "Y0In";
            this.Y0In.Size = new System.Drawing.Size(102, 27);
            this.Y0In.TabIndex = 5;
            // 
            // Y0Label
            // 
            this.Y0Label.AutoSize = true;
            this.Y0Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Y0Label.Location = new System.Drawing.Point(120, 27);
            this.Y0Label.Name = "Y0Label";
            this.Y0Label.Size = new System.Drawing.Size(24, 20);
            this.Y0Label.TabIndex = 0;
            this.Y0Label.Text = "y0";
            this.toolTip1.SetToolTip(this.Y0Label, "The y-coordinate of the point that will be in the middle of the picture. \r\nCan be" +
        " any real number. ");
            // 
            // ColValIn
            // 
            this.ColValIn.Location = new System.Drawing.Point(7, 180);
            this.ColValIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColValIn.Name = "ColValIn";
            this.ColValIn.Size = new System.Drawing.Size(97, 27);
            this.ColValIn.TabIndex = 11;
            // 
            // ColValLabel
            // 
            this.ColValLabel.AutoSize = true;
            this.ColValLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ColValLabel.Location = new System.Drawing.Point(7, 160);
            this.ColValLabel.Name = "ColValLabel";
            this.ColValLabel.Size = new System.Drawing.Size(85, 20);
            this.ColValLabel.TabIndex = 0;
            this.ColValLabel.Text = "Color Value";
            this.toolTip1.SetToolTip(this.ColValLabel, "The Color Value.  Must be in range from zero to one. ");
            // 
            // ColSatIn
            // 
            this.ColSatIn.Location = new System.Drawing.Point(7, 113);
            this.ColSatIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColSatIn.Name = "ColSatIn";
            this.ColSatIn.Size = new System.Drawing.Size(97, 27);
            this.ColSatIn.TabIndex = 10;
            // 
            // ColSatLabel
            // 
            this.ColSatLabel.AutoSize = true;
            this.ColSatLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ColSatLabel.Location = new System.Drawing.Point(7, 93);
            this.ColSatLabel.Name = "ColSatLabel";
            this.ColSatLabel.Size = new System.Drawing.Size(117, 20);
            this.ColSatLabel.TabIndex = 0;
            this.ColSatLabel.Text = "Color Saturation";
            this.toolTip1.SetToolTip(this.ColSatLabel, "The Color Saturation. Must be in range from zero to one. ");
            // 
            // ColMinIn
            // 
            this.ColMinIn.Location = new System.Drawing.Point(7, 47);
            this.ColMinIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColMinIn.Name = "ColMinIn";
            this.ColMinIn.Size = new System.Drawing.Size(97, 27);
            this.ColMinIn.TabIndex = 9;
            // 
            // ColMinLabel
            // 
            this.ColMinLabel.AutoSize = true;
            this.ColMinLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ColMinLabel.Location = new System.Drawing.Point(7, 27);
            this.ColMinLabel.Name = "ColMinLabel";
            this.ColMinLabel.Size = new System.Drawing.Size(103, 20);
            this.ColMinLabel.TabIndex = 0;
            this.ColMinLabel.Text = "Minimum Hue";
            this.toolTip1.SetToolTip(this.ColMinLabel, "The hue of a pixel if it\'s value is 0 in degrees. \r\nCan be any real number. ");
            // 
            // ColAlphaIn
            // 
            this.ColAlphaIn.Location = new System.Drawing.Point(7, 247);
            this.ColAlphaIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColAlphaIn.Name = "ColAlphaIn";
            this.ColAlphaIn.Size = new System.Drawing.Size(97, 27);
            this.ColAlphaIn.TabIndex = 12;
            // 
            // ColAlphaLabel
            // 
            this.ColAlphaLabel.AutoSize = true;
            this.ColAlphaLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ColAlphaLabel.Location = new System.Drawing.Point(7, 227);
            this.ColAlphaLabel.Name = "ColAlphaLabel";
            this.ColAlphaLabel.Size = new System.Drawing.Size(88, 20);
            this.ColAlphaLabel.TabIndex = 0;
            this.ColAlphaLabel.Text = "Color Alpha";
            this.toolTip1.SetToolTip(this.ColAlphaLabel, "The Color Alpha value e.g. the transparency (0=transparent).  \r\nMust be in range " +
        "from zero to one. ");
            // 
            // ColFactBIn
            // 
            this.ColFactBIn.Location = new System.Drawing.Point(269, 113);
            this.ColFactBIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColFactBIn.Name = "ColFactBIn";
            this.ColFactBIn.Size = new System.Drawing.Size(57, 27);
            this.ColFactBIn.TabIndex = 19;
            // 
            // ColFactGIn
            // 
            this.ColFactGIn.Location = new System.Drawing.Point(206, 113);
            this.ColFactGIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColFactGIn.Name = "ColFactGIn";
            this.ColFactGIn.Size = new System.Drawing.Size(57, 27);
            this.ColFactGIn.TabIndex = 18;
            // 
            // ColFactRIn
            // 
            this.ColFactRIn.Location = new System.Drawing.Point(143, 113);
            this.ColFactRIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColFactRIn.Name = "ColFactRIn";
            this.ColFactRIn.Size = new System.Drawing.Size(57, 27);
            this.ColFactRIn.TabIndex = 17;
            // 
            // ColFactLabel
            // 
            this.ColFactLabel.AutoSize = true;
            this.ColFactLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ColFactLabel.Location = new System.Drawing.Point(143, 93);
            this.ColFactLabel.Name = "ColFactLabel";
            this.ColFactLabel.Size = new System.Drawing.Size(151, 20);
            this.ColFactLabel.TabIndex = 0;
            this.ColFactLabel.Text = "Color Factors (R, G, B)";
            this.toolTip1.SetToolTip(this.ColFactLabel, resources.GetString("ColFactLabel.ToolTip"));
            // 
            // InvalColGIn
            // 
            this.InvalColGIn.Location = new System.Drawing.Point(269, 47);
            this.InvalColGIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InvalColGIn.Name = "InvalColGIn";
            this.InvalColGIn.Size = new System.Drawing.Size(57, 27);
            this.InvalColGIn.TabIndex = 15;
            // 
            // InvalColRIn
            // 
            this.InvalColRIn.Location = new System.Drawing.Point(206, 47);
            this.InvalColRIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InvalColRIn.Name = "InvalColRIn";
            this.InvalColRIn.Size = new System.Drawing.Size(57, 27);
            this.InvalColRIn.TabIndex = 14;
            // 
            // InvalColAIn
            // 
            this.InvalColAIn.Location = new System.Drawing.Point(143, 47);
            this.InvalColAIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InvalColAIn.Name = "InvalColAIn";
            this.InvalColAIn.Size = new System.Drawing.Size(57, 27);
            this.InvalColAIn.TabIndex = 13;
            // 
            // InvalColLabel
            // 
            this.InvalColLabel.AutoSize = true;
            this.InvalColLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InvalColLabel.Location = new System.Drawing.Point(143, 27);
            this.InvalColLabel.Name = "InvalColLabel";
            this.InvalColLabel.Size = new System.Drawing.Size(166, 20);
            this.InvalColLabel.TabIndex = 0;
            this.InvalColLabel.Text = "Invalid Color (A, R, G, B)";
            this.toolTip1.SetToolTip(this.InvalColLabel, resources.GetString("InvalColLabel.ToolTip"));
            // 
            // ModGroup
            // 
            this.ModGroup.Controls.Add(this.ModNumLabel);
            this.ModGroup.Controls.Add(this.ModNumIn);
            this.ModGroup.Controls.Add(this.ModLimLowLabel);
            this.ModGroup.Controls.Add(this.ModLimLowIn);
            this.ModGroup.Controls.Add(this.ModLimUpLabel);
            this.ModGroup.Controls.Add(this.ModLimUpIn);
            this.ModGroup.Location = new System.Drawing.Point(3, 13);
            this.ModGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ModGroup.Name = "ModGroup";
            this.ModGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ModGroup.Size = new System.Drawing.Size(151, 303);
            this.ModGroup.TabIndex = 32;
            this.ModGroup.TabStop = false;
            this.ModGroup.Text = "Modulus";
            // 
            // InvalColBIn
            // 
            this.InvalColBIn.Location = new System.Drawing.Point(331, 47);
            this.InvalColBIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InvalColBIn.Name = "InvalColBIn";
            this.InvalColBIn.Size = new System.Drawing.Size(57, 27);
            this.InvalColBIn.TabIndex = 16;
            // 
            // CoordGroup
            // 
            this.CoordGroup.Controls.Add(this.X0Label);
            this.CoordGroup.Controls.Add(this.X0In);
            this.CoordGroup.Controls.Add(this.XFactLabel);
            this.CoordGroup.Controls.Add(this.XFactIn);
            this.CoordGroup.Controls.Add(this.RotationLabel);
            this.CoordGroup.Controls.Add(this.RotationIn);
            this.CoordGroup.Controls.Add(this.Y0Label);
            this.CoordGroup.Controls.Add(this.Y0In);
            this.CoordGroup.Controls.Add(this.YFactLabel);
            this.CoordGroup.Controls.Add(this.YFactIn);
            this.CoordGroup.Location = new System.Drawing.Point(161, 13);
            this.CoordGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CoordGroup.Name = "CoordGroup";
            this.CoordGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CoordGroup.Size = new System.Drawing.Size(230, 303);
            this.CoordGroup.TabIndex = 34;
            this.CoordGroup.TabStop = false;
            this.CoordGroup.Text = "Coordinates/Transformations";
            // 
            // ColGroup
            // 
            this.ColGroup.Controls.Add(this.ColMinLabel);
            this.ColGroup.Controls.Add(this.ColMinIn);
            this.ColGroup.Controls.Add(this.InvalColBIn);
            this.ColGroup.Controls.Add(this.ColFactBIn);
            this.ColGroup.Controls.Add(this.ColSatLabel);
            this.ColGroup.Controls.Add(this.ColFactGIn);
            this.ColGroup.Controls.Add(this.ColAlphaLabel);
            this.ColGroup.Controls.Add(this.ColFactRIn);
            this.ColGroup.Controls.Add(this.InvalColGIn);
            this.ColGroup.Controls.Add(this.ColFactLabel);
            this.ColGroup.Controls.Add(this.ColValLabel);
            this.ColGroup.Controls.Add(this.InvalColRIn);
            this.ColGroup.Controls.Add(this.ColSatIn);
            this.ColGroup.Controls.Add(this.InvalColLabel);
            this.ColGroup.Controls.Add(this.InvalColAIn);
            this.ColGroup.Controls.Add(this.ColValIn);
            this.ColGroup.Controls.Add(this.ColAlphaIn);
            this.ColGroup.Location = new System.Drawing.Point(398, 13);
            this.ColGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColGroup.Name = "ColGroup";
            this.ColGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColGroup.Size = new System.Drawing.Size(395, 303);
            this.ColGroup.TabIndex = 35;
            this.ColGroup.TabStop = false;
            this.ColGroup.Text = "Color Modifiers";
            // 
            // ParaLabel
            // 
            this.ParaLabel.AutoSize = true;
            this.ParaLabel.Location = new System.Drawing.Point(10, 320);
            this.ParaLabel.Name = "ParaLabel";
            this.ParaLabel.Size = new System.Drawing.Size(192, 20);
            this.ParaLabel.TabIndex = 0;
            this.ParaLabel.Text = "Parameters (seperate by \";\")";
            this.toolTip1.SetToolTip(this.ParaLabel, "Parameters i_0 to i_9 passed into the function. Seperate these by \";\"");
            // 
            // ParaIn
            // 
            this.ParaIn.Location = new System.Drawing.Point(10, 340);
            this.ParaIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ParaIn.Name = "ParaIn";
            this.ParaIn.Size = new System.Drawing.Size(373, 27);
            this.ParaIn.TabIndex = 20;
            // 
            // EasingLabel
            // 
            this.EasingLabel.AutoSize = true;
            this.EasingLabel.Location = new System.Drawing.Point(405, 320);
            this.EasingLabel.Name = "EasingLabel";
            this.EasingLabel.Size = new System.Drawing.Size(52, 20);
            this.EasingLabel.TabIndex = 0;
            this.EasingLabel.Text = "Easing";
            this.toolTip1.SetToolTip(this.EasingLabel, "The Easing Function used for transitioning between states. More will be added at " +
        "a later point. ");
            // 
            // EasingIn
            // 
            this.EasingIn.FormattingEnabled = true;
            this.EasingIn.Location = new System.Drawing.Point(405, 340);
            this.EasingIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EasingIn.Name = "EasingIn";
            this.EasingIn.Size = new System.Drawing.Size(255, 28);
            this.EasingIn.TabIndex = 21;
            // 
            // DurLabel
            // 
            this.DurLabel.AutoSize = true;
            this.DurLabel.Location = new System.Drawing.Point(666, 320);
            this.DurLabel.Name = "DurLabel";
            this.DurLabel.Size = new System.Drawing.Size(103, 20);
            this.DurLabel.TabIndex = 0;
            this.DurLabel.Text = "Duration (in s)";
            this.toolTip1.SetToolTip(this.DurLabel, "The time in seconds it takes to transition from this to the next state. ");
            // 
            // DurIn
            // 
            this.DurIn.Location = new System.Drawing.Point(666, 340);
            this.DurIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DurIn.Name = "DurIn";
            this.DurIn.Size = new System.Drawing.Size(119, 27);
            this.DurIn.TabIndex = 22;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 500000;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            // 
            // SceneTabLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.DurIn);
            this.Controls.Add(this.DurLabel);
            this.Controls.Add(this.EasingIn);
            this.Controls.Add(this.EasingLabel);
            this.Controls.Add(this.ParaIn);
            this.Controls.Add(this.ParaLabel);
            this.Controls.Add(this.ColGroup);
            this.Controls.Add(this.CoordGroup);
            this.Controls.Add(this.ModGroup);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SceneTabLayout";
            this.Size = new System.Drawing.Size(797, 387);
            this.Load += new System.EventHandler(this.SceneTabLayout_Load);
            this.ModGroup.ResumeLayout(false);
            this.ModGroup.PerformLayout();
            this.CoordGroup.ResumeLayout(false);
            this.CoordGroup.PerformLayout();
            this.ColGroup.ResumeLayout(false);
            this.ColGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ModNumLabel;
        private System.Windows.Forms.TextBox ModNumIn;
        private System.Windows.Forms.TextBox ModLimLowIn;
        private System.Windows.Forms.Label ModLimLowLabel;
        private System.Windows.Forms.TextBox ModLimUpIn;
        private System.Windows.Forms.Label ModLimUpLabel;
        private System.Windows.Forms.TextBox RotationIn;
        private System.Windows.Forms.Label RotationLabel;
        private System.Windows.Forms.TextBox XFactIn;
        private System.Windows.Forms.Label XFactLabel;
        private System.Windows.Forms.TextBox X0In;
        private System.Windows.Forms.Label X0Label;
        private System.Windows.Forms.TextBox YFactIn;
        private System.Windows.Forms.Label YFactLabel;
        private System.Windows.Forms.TextBox Y0In;
        private System.Windows.Forms.Label Y0Label;
        private System.Windows.Forms.TextBox ColValIn;
        private System.Windows.Forms.Label ColValLabel;
        private System.Windows.Forms.TextBox ColSatIn;
        private System.Windows.Forms.Label ColSatLabel;
        private System.Windows.Forms.TextBox ColMinIn;
        private System.Windows.Forms.Label ColMinLabel;
        private System.Windows.Forms.TextBox ColAlphaIn;
        private System.Windows.Forms.Label ColAlphaLabel;
        private System.Windows.Forms.TextBox ColFactBIn;
        private System.Windows.Forms.TextBox ColFactGIn;
        private System.Windows.Forms.TextBox ColFactRIn;
        private System.Windows.Forms.Label ColFactLabel;
        private System.Windows.Forms.TextBox InvalColGIn;
        private System.Windows.Forms.TextBox InvalColRIn;
        private System.Windows.Forms.TextBox InvalColAIn;
        private System.Windows.Forms.Label InvalColLabel;
        private System.Windows.Forms.GroupBox ModGroup;
        private System.Windows.Forms.TextBox InvalColBIn;
        private System.Windows.Forms.GroupBox CoordGroup;
        private System.Windows.Forms.GroupBox ColGroup;
        private System.Windows.Forms.Label ParaLabel;
        private System.Windows.Forms.TextBox ParaIn;
        private System.Windows.Forms.Label EasingLabel;
        private System.Windows.Forms.ComboBox EasingIn;
        private System.Windows.Forms.Label DurLabel;
        private System.Windows.Forms.TextBox DurIn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
