using Sim1;
using System.Windows.Forms;

namespace cv_07
{
    public partial class Form1 : Form
    {
        TankValves Tank { get; set; }
        TankValves Tank2 { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tank = new TankValves(20000);
            Tank.OnInletValveStateChange += Tank_OnInletValveStateChange;
            Tank.OnOutletValveStateChange += Tank_OnOutletValveStateChange;
            Tank.OnTankStateChange += Tank_OnTankStateChange;

            Tank2 = new TankValves(10000);
        }
        private void Tank2_OnTankStateChange(object sender, double stateLitres, double statePercent)
        {
            changePanelBG(panel2, statePercent);
        }

        private void Tank_OnTankStateChange(object sender, double stateLitres, double statePercent)
        {
            changePanelBG(panel1, statePercent);
        }

        private void Tank_OnOutletValveStateChange(object sender, ValveState valveState)
        {
            changeValveLabel(label3, valveState);
        }

        private void Tank_OnInletValveStateChange(object sender, ValveState valveState)
        {
            changeValveLabel(label2, valveState);
        }

        public void changeValveLabel(Label label, ValveState valueState)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => changeValveLabelBG(label, valueState)));
            }
            else
            {
                changeValveLabelBG(label, valueState);
            }
        }

        public void changeValveLabelBG(Label label, ValveState valueState)
        {
            switch (valueState)
            {
                case ValveState.On:
                    label.BackColor = Color.Green;
                    break;
                case ValveState.Off:
                    label.BackColor = Color.Red;
                    break;
                default:
                    label.BackColor = Color.White;
                    break;
            }
        }

        public void changePanelBG(Panel panel, double statePercent)
        {
            panel.BackColor = Color.FromArgb((int)((statePercent / 100) * 255), 0, 0, 255);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Tank.Dispose();
            Tank2.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.BackColor = Tank2.OutletValveState == ValveState.On ? Color.Green : Color.Red;
            label4.BackColor = Tank2.InletValveState == ValveState.On ? Color.Green : Color.Red;
            double stav = Tank2.StateLitres / (Tank2.CapacityLitres);
            panel2.BackColor = Color.FromArgb((int)((stav) * 255), 0, 0, 255);
        }
    }
}
