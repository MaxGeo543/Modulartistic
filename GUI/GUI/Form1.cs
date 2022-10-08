using System;
using System.Linq;
using System.Windows.Forms;
using Modar_F;
using System.Collections.Generic;
using System.Drawing;
using NCalc;
using System.ComponentModel;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Controls.Find("ModNumIn", true)[0].Text = "500";
            this.Controls.Find("ModLimLowIn", true)[0].Text = "0";
            this.Controls.Find("ModLimUpIn", true)[0].Text = "500";
            this.Controls.Find("X0In", true)[0].Text = "0";
            this.Controls.Find("Y0In", true)[0].Text = "0";
            this.Controls.Find("XFactIn", true)[0].Text = "1";
            this.Controls.Find("YFactIn", true)[0].Text = "1";
            this.Controls.Find("RotationIn", true)[0].Text = "0";
            this.Controls.Find("ColMinIn", true)[0].Text = "0";
            this.Controls.Find("ColSatIn", true)[0].Text = "1";
            this.Controls.Find("ColValIn", true)[0].Text = "1";
            this.Controls.Find("ColAlphaIn", true)[0].Text = "1";
            this.Controls.Find("InvalColAIn", true)[0].Text = "0";
            this.Controls.Find("InvalColRIn", true)[0].Text = "0";
            this.Controls.Find("InvalColGIn", true)[0].Text = "0";
            this.Controls.Find("InvalColBIn", true)[0].Text = "0";
            this.Controls.Find("ColFactRIn", true)[0].Text = "1";
            this.Controls.Find("ColFactGIn", true)[0].Text = "1";
            this.Controls.Find("ColFactBIn", true)[0].Text = "1";
            this.Controls.Find("DurIn", true)[0].Text = "0";
        }

        //Adds a Tab to the States Tab Control with the Add-Button
        private void AddStateButton_Click(object sender, EventArgs e)
        {
            //Initializing the new Tab
            TabPage newTab = new TabPage();
            newTab.Text = NewSceneNameIn.Text;
            newTab.Controls.Add(new SceneTabLayout("StateTabLayout"));

            //Adding the tab
            SceneTabs.TabPages.Add(newTab);
            SceneTabs.SelectedIndex = SceneTabs.TabCount-1;

            //Update the rename field
            NewSceneNameIn.Text = "State " + (SceneTabs.TabCount+1);
        }

        //Remove the currently selected Tab via Remove-Button
        private void RemoveStateButton_Click(object sender, EventArgs e)
        {
            //Remove the Tab
            int selectedIdx = SceneTabs.SelectedIndex;
            SceneTabs.TabPages.RemoveAt(selectedIdx);

            //Update the rename field
            NewSceneNameIn.Text = "State " + (SceneTabs.TabCount + 1);
        }

        //Rename the currently selected Tab via Rename-Button
        private void RenameStateButton_Click(object sender, EventArgs e)
        {
            SceneTabs.SelectedTab.Text = NewSceneNameIn.Text;
        }

        //Move Tab left via Move-Button
        private void StateMoveLeftButton_Click(object sender, EventArgs e)
        {
            int oldIdx = SceneTabs.SelectedIndex;
            if (SceneTabs.SelectedIndex != 0)
            {
                TabPage t = SceneTabs.TabPages[oldIdx];
                SceneTabs.TabPages.Remove(t);
                SceneTabs.TabPages.Insert(oldIdx-1, t);
                SceneTabs.SelectedIndex = oldIdx-1;
            }
        }

        //Move Tab right via Move-Button
        private void StateMoveRightButton_Click(object sender, EventArgs e)
        {
            int oldIdx = SceneTabs.SelectedIndex;
            if (SceneTabs.SelectedIndex != SceneTabs.TabCount - 1)
            {
                TabPage t = SceneTabs.TabPages[oldIdx];
                SceneTabs.TabPages.Remove(t);
                SceneTabs.TabPages.Insert(oldIdx + 1, t);
                SceneTabs.SelectedIndex = oldIdx + 1;
            }
        }

        //Generate All
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (SceneTabs.TabPages.Count == 0)
            {
                //Pop-Up that says you need at least 1 Tab(Scene)
            }
            else if (SceneTabs.TabPages.Count == 1 || NoAnimationCheckBox.Checked)
            {
                //Size
                int width = Int32.Parse(this.WidthIn.Text);
                int height = Int32.Parse(this.HeightIn.Text);
                Size size = new Size(width, height);

                //Function
                Expression exp = new Expression(this.FunctionIn.Text);
                Func<double, double, List<double>, double> function = (x, y, i) => Functions.Custom(exp, x, y, i);

                //Path Out
                string pathOut = this.PathIn.Text;

                DebugLabel.Text = SceneTabs.SelectedTab.Controls.Find("ModNumIn", true)[0].Text;
                //Create the image for every State
                foreach (TabPage t in SceneTabs.TabPages)
                {
                    //Modulus Number
                    double modNum = Double.Parse(t.Controls.Find("ModNumIn", true)[0].Text);
                    double modLimLow = Double.Parse(t.Controls.Find("ModLimLowIn", true)[0].Text);
                    double modLimUp = Double.Parse(t.Controls.Find("ModLimUpIn", true)[0].Text);

                    //Coordinates
                    double x0 = Double.Parse(t.Controls.Find("X0In", true)[0].Text);
                    double y0 = Double.Parse(t.Controls.Find("Y0In", true)[0].Text);
                    double xFactor = Double.Parse(t.Controls.Find("XFactIn", true)[0].Text);
                    double yFactor = Double.Parse(t.Controls.Find("YFactIn", true)[0].Text);
                    double rotationDeg = Double.Parse(t.Controls.Find("RotationIn", true)[0].Text);

                    //Color
                    double colMin = Double.Parse(t.Controls.Find("ColMinIn", true)[0].Text);
                    double colSat = Double.Parse(t.Controls.Find("ColSatIn", true)[0].Text);
                    double colVal = Double.Parse(t.Controls.Find("ColValIn", true)[0].Text);
                    double colAlpha = Double.Parse(t.Controls.Find("ColAlphaIn", true)[0].Text);
                    //Invalid Color
                    double invalColA = Double.Parse(t.Controls.Find("InvalColAIn", true)[0].Text);
                    double invalColR = Double.Parse(t.Controls.Find("InvalColRIn", true)[0].Text);
                    double invalColG = Double.Parse(t.Controls.Find("InvalColGIn", true)[0].Text);
                    double invalColB = Double.Parse(t.Controls.Find("InvalColBIn", true)[0].Text);
                    //Color Factors
                    double colFactR = Double.Parse(t.Controls.Find("ColFactRIn", true)[0].Text);
                    double colFactG = Double.Parse(t.Controls.Find("ColFactGIn", true)[0].Text);
                    double colFactB = Double.Parse(t.Controls.Find("ColFactBIn", true)[0].Text);

                    //Parameters
                    List<double> para = new List<double>();
                    string paraStr = t.Controls.Find("ParaIn", true)[0].Text;
                    if (paraStr != "")
                    {
                        foreach (string s in paraStr.Split(";", 10))
                        {
                            para.Add(Double.Parse(s));
                        }
                    }
                    

                    //Name
                    string name = t.Text;

                    State state = new State(
                        modNum, 
                        modLimLow, 
                        modLimUp, 
                        x0, 
                        y0, 
                        xFactor, 
                        yFactor, 
                        rotationDeg, 
                        colMin, 
                        colSat, 
                        colVal, 
                        colAlpha,
                        (invalColA, invalColR, invalColG, invalColB),
                        (colFactR, colFactG, colFactB),
                        para, 
                        name
                        );

                    state.GenerateImage(size, function, pathOut);
                }
            }
            else
            {
                //Size
                int width = Int32.Parse(this.WidthIn.Text);
                int height = Int32.Parse(this.HeightIn.Text);
                Size size = new Size(width, height);

                //Function
                Expression exp = new Expression(this.FunctionIn.Text);
                Func<double, double, List<double>, double> function = (x, y, i) => Functions.Custom(exp, x, y, i);

                //Framerate
                int framerate = Int32.Parse(this.FramerateIn.Text);

                //Path Out
                string pathOut = this.PathIn.Text;

                //Create StateSequence
                StateSequence stateSequence = new StateSequence(this.AnimationNameIn.Text);

                DebugLabel.Text = SceneTabs.SelectedTab.Controls.Find("ModNumIn", true)[0].Text;
                //Create the image for every State
                foreach (TabPage t in SceneTabs.TabPages)
                {
                    //Modulus Number
                    double modNum = Double.Parse(t.Controls.Find("ModNumIn", true)[0].Text);
                    double modLimLow = Double.Parse(t.Controls.Find("ModLimLowIn", true)[0].Text);
                    double modLimUp = Double.Parse(t.Controls.Find("ModLimUpIn", true)[0].Text);

                    //Coordinates
                    double x0 = Double.Parse(t.Controls.Find("X0In", true)[0].Text);
                    double y0 = Double.Parse(t.Controls.Find("Y0In", true)[0].Text);
                    double xFactor = Double.Parse(t.Controls.Find("XFactIn", true)[0].Text);
                    double yFactor = Double.Parse(t.Controls.Find("YFactIn", true)[0].Text);
                    double rotationDeg = Double.Parse(t.Controls.Find("RotationIn", true)[0].Text);

                    //Color
                    double colMin = Double.Parse(t.Controls.Find("ColMinIn", true)[0].Text);
                    double colSat = Double.Parse(t.Controls.Find("ColSatIn", true)[0].Text);
                    double colVal = Double.Parse(t.Controls.Find("ColValIn", true)[0].Text);
                    double colAlpha = Double.Parse(t.Controls.Find("ColAlphaIn", true)[0].Text);
                    //Invalid Color
                    double invalColA = Double.Parse(t.Controls.Find("InvalColAIn", true)[0].Text);
                    double invalColR = Double.Parse(t.Controls.Find("InvalColRIn", true)[0].Text);
                    double invalColG = Double.Parse(t.Controls.Find("InvalColGIn", true)[0].Text);
                    double invalColB = Double.Parse(t.Controls.Find("InvalColBIn", true)[0].Text);
                    //Color Factors
                    double colFactR = Double.Parse(t.Controls.Find("ColFactRIn", true)[0].Text);
                    double colFactG = Double.Parse(t.Controls.Find("ColFactGIn", true)[0].Text);
                    double colFactB = Double.Parse(t.Controls.Find("ColFactBIn", true)[0].Text);

                    //Parameters
                    List<double> para = new List<double>();
                    string paraStr = t.Controls.Find("ParaIn", true)[0].Text;
                    if (paraStr != "")
                    {
                        foreach (string s in paraStr.Split(";", 10))
                        {
                            para.Add(Double.Parse(s));
                        }
                    }

                    //Easing
                    Easing easing = (Easing)t.Controls.Find("EasingIn", true).OfType<ComboBox>().First().SelectedItem; //StateTabLayout.Find("EasingIn", true)[0].SelectedItem;

                    //Length
                    double length = Double.Parse(t.Controls.Find("DurIn", true)[0].Text);


                    //Name
                    string name = t.Text;

                    State state = new State(
                        modNum,
                        modLimLow,
                        modLimUp,
                        x0,
                        y0,
                        xFactor,
                        yFactor,
                        rotationDeg,
                        colMin,
                        colSat,
                        colVal,
                        colAlpha,
                        (invalColA, invalColR, invalColG, invalColB),
                        (colFactR, colFactG, colFactB),
                        para,
                        name
                        );

                    Scene scene = new Scene(state, length, easing);
                    stateSequence.Add(scene);
                }

                
                LoadingPopUp f = new LoadingPopUp();
                f.ShowDialog(stateSequence, size, function, framerate, pathOut);
                stateSequence.GenerateAnimation(size, function, framerate, pathOut);
            }
        }
    }
}
