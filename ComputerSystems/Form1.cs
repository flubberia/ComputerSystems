using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerSystems
{
   
    public partial class Main : Form
    {
        bool play = true;
        CS CSystem;
        Form _new_;
        List<Power> procPower;
        public Main()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _new_ = new Form();
            _new_.StartPosition = FormStartPosition.CenterScreen;
            _new_.Size = new System.Drawing.Size(320, 550);
            _new_.FormBorderStyle = FormBorderStyle.FixedDialog;

            //Caption
            Label procCount = new Label();
            procCount.Location = new System.Drawing.Point(10, 20);
            procCount.Text = "Number of processors in system";
            procCount.Size = new System.Drawing.Size(160, 20);
            _new_.Controls.Add(procCount);

            //processor selection
            ComboBox numberofProc = new ComboBox();
            for (int i = 1; i <= 9; i++)
            {
                numberofProc.Items.Add(i);
            }
            numberofProc.Location = new System.Drawing.Point(180, 20);
            numberofProc.SelectedIndexChanged += new System.EventHandler(numberofProc_changed);
            _new_.Controls.Add(numberofProc);

            //Exit & Accept
            Button exit = new Button();
            exit.Text = "Accept";
            exit.Click += new System.EventHandler(close_new_form);
            exit.Location = new System.Drawing.Point(0, 470);
            exit.Size = new System.Drawing.Size(305, 40);
            _new_.Controls.Add(exit);

            _new_.ShowDialog();
            
        }
        private void close_new_form(object sender, EventArgs e)
        {
            _new_.Close();
        }
        private void numberofProc_changed(object sender, EventArgs e)
        {
            if (CSystem != null)
            {
                for (int i = 0; i < CSystem.processors.Count; i++)
                {
                    CSystem.processors[i].image.Visible = false;
                    CSystem.processors[i].image.Enabled = false;
                    CSystem.processors[i].bar.Visible = false;
                    CSystem.processors[i].bar.Enabled = false;
                }
                CSystem.processors.Clear();
            }
            int selected;
            ComboBox combo = (ComboBox)sender;
            selected = combo.SelectedIndex;
            CSystem = new CS(++selected, groupBox2);
            if (procPower == null)
            {
                procPower = new List<Power>();
            }
            if (procPower.Count > 0)
            {
                for (int i = 0; i < procPower.Count; i++)
                {
                    procPower[i].track.Visible = false;
                    procPower[i].track.Enabled = false;
                    procPower[i].caption.Visible = false;
                    procPower[i].caption.Enabled = false;
                }
                procPower.Clear();

            }
            for (int i = 0; i < selected; i++)
            {
                procPower.Add(new Power());
                procPower[i].track.Location = new System.Drawing.Point(140, 40 + i * 43);
                procPower[i].track.Visible = true;
                procPower[i].track.Enabled = true;
                procPower[i].track.Maximum = 20;
                procPower[i].track.SmallChange = 1;
                procPower[i].track.LargeChange = 5;
                procPower[i].track.Size = new System.Drawing.Size(170, 30);
                procPower[i].track.ValueChanged += new System.EventHandler(track_value_change);
                procPower[i].track.Tag = i;
                procPower[i].caption.Location = new System.Drawing.Point(0, 50 + i * 43);
                procPower[i].caption.Visible = true;
                procPower[i].caption.Enabled = true;
                procPower[i].caption.Size = new System.Drawing.Size(150, 30);
                procPower[i].caption.Text = "Processor " + Convert.ToString(i + 1) + " power: 0";
                _new_.Controls.Add(procPower[i].track);
                _new_.Controls.Add(procPower[i].caption);
            }
        }
        private void track_value_change(object sender, EventArgs e)
        {
            TrackBar bar = (TrackBar)sender;
            int index = (int)bar.Tag;
            procPower[index].caption.Text = "Processor " + Convert.ToString(index + 1) + " power: " + Convert.ToString(bar.Value * 50);
            CSystem.processors[index].power = bar.Value * 50;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Task_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void play_pause_Click(object sender, EventArgs e)
        {
            if (play)
            {
                play_pause.BackgroundImage = ComputerSystems.Properties.Resources.pause;
            }
            else
            {
                play_pause.BackgroundImage = ComputerSystems.Properties.Resources.play;
            }
            play = !play;
        }

        private void processor_Click(object sender, EventArgs e)
        {

        }

        private void add_proc_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
    public class Power
    {
        public Power()
        {
            track = new TrackBar();
            caption = new Label();
        }
        public TrackBar track;
        public Label caption;
    }
    public class Task
    {
        public Task()
        {

        }
        public int complexity;
        public int[] types;
        public PictureBox image;
        public string name;
    }
    public class Proc
    {
        public Proc()
        {
            power = 0;
        }
        public int power;
        public PictureBox image;
        public ProgressBar bar;
        public int type;
        public bool status; //true - job, false - free
        //private Task current;
    }
    public class CS
    {
        public CS(int proc, GroupBox owner)
        {
            processors = new List<Proc>();
            if (proc > 9)
            {
                proc = 9;
            }
            for (int i = 0; i < proc; i++)
            {
                //processor image
                processors.Add(new Proc());
                processors[i].image = new PictureBox();
                processors[i].image.Image = ComputerSystems.Properties.Resources.Proc;
                processors[i].image.Location = new System.Drawing.Point(100 + 200 * (i % 3), 70 + 140 * (i / 3));
                processors[i].image.Size = processors[i].image.Image.Size;
                processors[i].image.Visible = true;
                owner.Controls.Add(processors[i].image);
                //bar
                processors[i].bar = new ProgressBar();
                processors[i].bar.Location = new System.Drawing.Point(processors[i].image.Location.X, processors[i].image.Location.Y - 30);
                processors[i].bar.Size = new System.Drawing.Size(88, 20);
                processors[i].bar.Visible = false;
                owner.Controls.Add(processors[i].bar);
                //type
                processors[i].type = i + 1;
                processors[i].status = false;
            }
        }
        public List<Proc> processors;
        //public Task[] tasks;
        public void accept(Task current)
        {
        }
        public void planer()
        {
        }
    }
}
