namespace GUI
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
            this.SceneTabs = new System.Windows.Forms.TabControl();
            this.InitState = new System.Windows.Forms.TabPage();
            this.sceneTabLayout = new GUI.SceneTabLayout();
            this.AddStateButton = new System.Windows.Forms.Button();
            this.RemoveStateButton = new System.Windows.Forms.Button();
            this.RenameStateButton = new System.Windows.Forms.Button();
            this.NewSceneNameIn = new System.Windows.Forms.TextBox();
            this.StateMoveRightButton = new System.Windows.Forms.Button();
            this.StateMoveLeftButton = new System.Windows.Forms.Button();
            this.PathLabel = new System.Windows.Forms.Label();
            this.PathIn = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.NoAnimationCheckBox = new System.Windows.Forms.CheckBox();
            this.AnimationNameLabel = new System.Windows.Forms.Label();
            this.AnimationNameIn = new System.Windows.Forms.TextBox();
            this.FunctionLabel = new System.Windows.Forms.Label();
            this.FunctionIn = new System.Windows.Forms.TextBox();
            this.FramerateLabel = new System.Windows.Forms.Label();
            this.FramerateIn = new System.Windows.Forms.TextBox();
            this.MoveLabel = new System.Windows.Forms.Label();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.WidthIn = new System.Windows.Forms.TextBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightIn = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.process1 = new System.Diagnostics.Process();
            this.SceneTabs.SuspendLayout();
            this.InitState.SuspendLayout();
            this.SuspendLayout();
            // 
            // SceneTabs
            // 
            this.SceneTabs.Controls.Add(this.InitState);
            this.SceneTabs.Location = new System.Drawing.Point(14, 16);
            this.SceneTabs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SceneTabs.Name = "SceneTabs";
            this.SceneTabs.SelectedIndex = 0;
            this.SceneTabs.Size = new System.Drawing.Size(806, 424);
            this.SceneTabs.TabIndex = 0;
            // 
            // InitState
            // 
            this.InitState.Controls.Add(this.sceneTabLayout);
            this.InitState.Location = new System.Drawing.Point(4, 29);
            this.InitState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InitState.Name = "InitState";
            this.InitState.Size = new System.Drawing.Size(798, 391);
            this.InitState.TabIndex = 0;
            this.InitState.Text = "State 1";
            this.InitState.Visible = false;
            // 
            // sceneTabLayout
            // 
            this.sceneTabLayout.BackColor = System.Drawing.SystemColors.Window;
            this.sceneTabLayout.Location = new System.Drawing.Point(0, 0);
            this.sceneTabLayout.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.sceneTabLayout.Name = "sceneTabLayout";
            this.sceneTabLayout.Size = new System.Drawing.Size(797, 387);
            this.sceneTabLayout.TabIndex = 0;
            // 
            // AddStateButton
            // 
            this.AddStateButton.Location = new System.Drawing.Point(14, 448);
            this.AddStateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddStateButton.Name = "AddStateButton";
            this.AddStateButton.Size = new System.Drawing.Size(114, 31);
            this.AddStateButton.TabIndex = 1;
            this.AddStateButton.Text = "Add State";
            this.AddStateButton.UseVisualStyleBackColor = true;
            this.AddStateButton.Click += new System.EventHandler(this.AddStateButton_Click);
            // 
            // RemoveStateButton
            // 
            this.RemoveStateButton.Location = new System.Drawing.Point(302, 449);
            this.RemoveStateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveStateButton.Name = "RemoveStateButton";
            this.RemoveStateButton.Size = new System.Drawing.Size(114, 31);
            this.RemoveStateButton.TabIndex = 2;
            this.RemoveStateButton.Text = "Remove State";
            this.RemoveStateButton.UseVisualStyleBackColor = true;
            this.RemoveStateButton.Click += new System.EventHandler(this.RemoveStateButton_Click);
            // 
            // RenameStateButton
            // 
            this.RenameStateButton.Location = new System.Drawing.Point(423, 449);
            this.RenameStateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RenameStateButton.Name = "RenameStateButton";
            this.RenameStateButton.Size = new System.Drawing.Size(114, 31);
            this.RenameStateButton.TabIndex = 3;
            this.RenameStateButton.Text = "Rename State";
            this.RenameStateButton.UseVisualStyleBackColor = true;
            this.RenameStateButton.Click += new System.EventHandler(this.RenameStateButton_Click);
            // 
            // NewSceneNameIn
            // 
            this.NewSceneNameIn.Location = new System.Drawing.Point(135, 449);
            this.NewSceneNameIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewSceneNameIn.Name = "NewSceneNameIn";
            this.NewSceneNameIn.Size = new System.Drawing.Size(159, 27);
            this.NewSceneNameIn.TabIndex = 4;
            this.NewSceneNameIn.Text = "State 2";
            // 
            // StateMoveRightButton
            // 
            this.StateMoveRightButton.Location = new System.Drawing.Point(777, 449);
            this.StateMoveRightButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StateMoveRightButton.Name = "StateMoveRightButton";
            this.StateMoveRightButton.Size = new System.Drawing.Size(38, 31);
            this.StateMoveRightButton.TabIndex = 5;
            this.StateMoveRightButton.Text = ">>";
            this.StateMoveRightButton.UseVisualStyleBackColor = true;
            this.StateMoveRightButton.Click += new System.EventHandler(this.StateMoveRightButton_Click);
            // 
            // StateMoveLeftButton
            // 
            this.StateMoveLeftButton.Location = new System.Drawing.Point(659, 449);
            this.StateMoveLeftButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StateMoveLeftButton.Name = "StateMoveLeftButton";
            this.StateMoveLeftButton.Size = new System.Drawing.Size(38, 31);
            this.StateMoveLeftButton.TabIndex = 6;
            this.StateMoveLeftButton.Text = "<<";
            this.StateMoveLeftButton.UseVisualStyleBackColor = true;
            this.StateMoveLeftButton.Click += new System.EventHandler(this.StateMoveLeftButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(14, 644);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(87, 20);
            this.PathLabel.TabIndex = 7;
            this.PathLabel.Text = "Output Path";
            // 
            // PathIn
            // 
            this.PathIn.Location = new System.Drawing.Point(135, 637);
            this.PathIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PathIn.Name = "PathIn";
            this.PathIn.Size = new System.Drawing.Size(598, 27);
            this.PathIn.TabIndex = 8;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(741, 637);
            this.GenerateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(86, 29);
            this.GenerateButton.TabIndex = 9;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // NoAnimationCheckBox
            // 
            this.NoAnimationCheckBox.AutoSize = true;
            this.NoAnimationCheckBox.Location = new System.Drawing.Point(659, 521);
            this.NoAnimationCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NoAnimationCheckBox.Name = "NoAnimationCheckBox";
            this.NoAnimationCheckBox.Size = new System.Drawing.Size(124, 24);
            this.NoAnimationCheckBox.TabIndex = 11;
            this.NoAnimationCheckBox.Text = "No Animation";
            this.NoAnimationCheckBox.UseVisualStyleBackColor = true;
            // 
            // AnimationNameLabel
            // 
            this.AnimationNameLabel.AutoSize = true;
            this.AnimationNameLabel.Location = new System.Drawing.Point(14, 564);
            this.AnimationNameLabel.Name = "AnimationNameLabel";
            this.AnimationNameLabel.Size = new System.Drawing.Size(122, 20);
            this.AnimationNameLabel.TabIndex = 13;
            this.AnimationNameLabel.Text = "Animation Name";
            // 
            // AnimationNameIn
            // 
            this.AnimationNameIn.Location = new System.Drawing.Point(135, 559);
            this.AnimationNameIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AnimationNameIn.Name = "AnimationNameIn";
            this.AnimationNameIn.Size = new System.Drawing.Size(598, 27);
            this.AnimationNameIn.TabIndex = 14;
            // 
            // FunctionLabel
            // 
            this.FunctionLabel.AutoSize = true;
            this.FunctionLabel.Location = new System.Drawing.Point(14, 604);
            this.FunctionLabel.Name = "FunctionLabel";
            this.FunctionLabel.Size = new System.Drawing.Size(65, 20);
            this.FunctionLabel.TabIndex = 15;
            this.FunctionLabel.Text = "Function";
            // 
            // FunctionIn
            // 
            this.FunctionIn.Location = new System.Drawing.Point(135, 599);
            this.FunctionIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FunctionIn.Name = "FunctionIn";
            this.FunctionIn.Size = new System.Drawing.Size(598, 27);
            this.FunctionIn.TabIndex = 16;
            this.FunctionIn.Text = "x*y";
            // 
            // FramerateLabel
            // 
            this.FramerateLabel.AutoSize = true;
            this.FramerateLabel.Location = new System.Drawing.Point(463, 524);
            this.FramerateLabel.Name = "FramerateLabel";
            this.FramerateLabel.Size = new System.Drawing.Size(76, 20);
            this.FramerateLabel.TabIndex = 17;
            this.FramerateLabel.Text = "Framerate";
            // 
            // FramerateIn
            // 
            this.FramerateIn.Location = new System.Drawing.Point(538, 519);
            this.FramerateIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FramerateIn.Name = "FramerateIn";
            this.FramerateIn.Size = new System.Drawing.Size(59, 27);
            this.FramerateIn.TabIndex = 18;
            // 
            // MoveLabel
            // 
            this.MoveLabel.AutoSize = true;
            this.MoveLabel.Location = new System.Drawing.Point(701, 455);
            this.MoveLabel.Name = "MoveLabel";
            this.MoveLabel.Size = new System.Drawing.Size(84, 20);
            this.MoveLabel.TabIndex = 19;
            this.MoveLabel.Text = "Move State";
            // 
            // DebugLabel
            // 
            this.DebugLabel.AutoSize = true;
            this.DebugLabel.Location = new System.Drawing.Point(14, 691);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(50, 20);
            this.DebugLabel.TabIndex = 20;
            this.DebugLabel.Text = "label1";
            // 
            // WidthIn
            // 
            this.WidthIn.Location = new System.Drawing.Point(187, 519);
            this.WidthIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WidthIn.Name = "WidthIn";
            this.WidthIn.Size = new System.Drawing.Size(68, 27);
            this.WidthIn.TabIndex = 22;
            this.WidthIn.Text = "500";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(136, 524);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(49, 20);
            this.WidthLabel.TabIndex = 21;
            this.WidthLabel.Text = "Width";
            // 
            // HeightIn
            // 
            this.HeightIn.Location = new System.Drawing.Point(319, 519);
            this.HeightIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HeightIn.Name = "HeightIn";
            this.HeightIn.Size = new System.Drawing.Size(68, 27);
            this.HeightIn.TabIndex = 23;
            this.HeightIn.Text = "500";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(263, 524);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(54, 20);
            this.HeightLabel.TabIndex = 24;
            this.HeightLabel.Text = "Height";
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardInputEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 733);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.HeightIn);
            this.Controls.Add(this.WidthIn);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.DebugLabel);
            this.Controls.Add(this.MoveLabel);
            this.Controls.Add(this.FramerateIn);
            this.Controls.Add(this.FramerateLabel);
            this.Controls.Add(this.FunctionIn);
            this.Controls.Add(this.FunctionLabel);
            this.Controls.Add(this.AnimationNameIn);
            this.Controls.Add(this.AnimationNameLabel);
            this.Controls.Add(this.NoAnimationCheckBox);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.PathIn);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.StateMoveLeftButton);
            this.Controls.Add(this.StateMoveRightButton);
            this.Controls.Add(this.NewSceneNameIn);
            this.Controls.Add(this.RenameStateButton);
            this.Controls.Add(this.RemoveStateButton);
            this.Controls.Add(this.AddStateButton);
            this.Controls.Add(this.SceneTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Modulartistic";
            this.SceneTabs.ResumeLayout(false);
            this.InitState.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl SceneTabs;
        private System.Windows.Forms.TabPage InitState;
        private System.Windows.Forms.Button AddStateButton;
        private System.Windows.Forms.Button RemoveStateButton;
        private System.Windows.Forms.Button RenameStateButton;
        private System.Windows.Forms.TextBox NewSceneNameIn;
        private System.Windows.Forms.Button StateMoveRightButton;
        private System.Windows.Forms.Button StateMoveLeftButton;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.TextBox PathIn;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.CheckBox NoAnimationCheckBox;
        private System.Windows.Forms.Label AnimationNameLabel;
        private System.Windows.Forms.TextBox AnimationNameIn;
        private System.Windows.Forms.Label FunctionLabel;
        private System.Windows.Forms.TextBox FunctionIn;
        private System.Windows.Forms.Label FramerateLabel;
        private System.Windows.Forms.TextBox FramerateIn;
        private System.Windows.Forms.Label MoveLabel;
        private SceneTabLayout sceneTabLayout;
        private System.Windows.Forms.Label DebugLabel;
        private System.Windows.Forms.TextBox WidthIn;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.TextBox HeightIn;
        private System.Windows.Forms.Label HeightLabel;
        private System.Diagnostics.Process process1;
    }
}
