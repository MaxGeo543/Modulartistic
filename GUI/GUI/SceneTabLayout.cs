using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Modar_F;

namespace GUI
{
    public partial class SceneTabLayout : UserControl
    {
        public SceneTabLayout(string name)
        {
            Name = name;
            InitializeComponent();
        }

        public SceneTabLayout()
        {
            InitializeComponent();
        }

        private void SceneTabLayout_Load(object sender, EventArgs e)
        {
            List<Easing> EasingsList = new List<Easing>();
            EasingsList.Add(Easing.SineIn());
            EasingsList.Add(Easing.SineOut());
            EasingsList.Add(Easing.SineInOut());
            EasingsList.Add(Easing.ElasticIn());
            EasingsList.Add(Easing.ElasticOut());
            EasingsList.Add(Easing.ElasticInOut());
            EasingsList.Add(Easing.BounceOut());
            this.EasingIn.DataSource = EasingsList;
        }
    }
}
