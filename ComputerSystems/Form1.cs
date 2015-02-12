using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace ComputerSystems
{
   
    public partial class Main : Form
    {
        bool play = true;
        CS CSystem;
        Form _new_;
        List<Power> procPower;
        List<PictureBox> side_panel;
        public Main()
        {
            InitializeComponent();
            side_panel_init();
        }
        private void side_panel_init()
        {
            side_panel = new List<PictureBox>();
            for (int i = 0; i < 3; i++)
            {
                side_panel.Add(new PictureBox());
                side_panel[i].Location = new System.Drawing.Point(183, 19 + (6 + ComputerSystems.Properties.Resources.Button_Global.Height)*i);
                side_panel[i].Visible = true;
                side_panel[i].Enabled = true;
                side_panel[i].Size = ComputerSystems.Properties.Resources.Button_Global.Size;
                side_panel[i].Click += new System.EventHandler(side_panel_click);
                side_panel[i].BackColor = System.Drawing.Color.Transparent;
                panel1.Controls.Add(side_panel[i]);
            }
            side_panel[0].Image = ComputerSystems.Properties.Resources.Button_Global;
            side_panel[0].Enabled = false;
            side_panel[0].Tag = ComputerSystems.Properties.Resources.Button_Global;
            side_panel[1].Tag = ComputerSystems.Properties.Resources.Button_Processor;
            side_panel[2].Tag = ComputerSystems.Properties.Resources.Button_Task;
        }
        private void side_panel_click(object sender, EventArgs e)
        {
            for (int i = 0; i < side_panel.Count; i++)
            {
                side_panel[i].Image = null;
                side_panel[i].Enabled = true;
            }
            ((PictureBox)sender).Enabled = false;
            ((PictureBox)sender).Image = (Bitmap)((PictureBox)sender).Tag;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _new_ = new Form();
            _new_.StartPosition = FormStartPosition.CenterScreen;
            _new_.Size = new System.Drawing.Size(320, 550);
            _new_.FormBorderStyle = FormBorderStyle.FixedDialog;
            _new_.BackgroundImage = ComputerSystems.Properties.Resources.new_win_405x620;

            //Caption
            Label procCount = new Label();
            procCount.Location = new System.Drawing.Point(10, 20);
            procCount.Text = "Number of processors in system";
            procCount.Size = new System.Drawing.Size(160, 20);
            procCount.BackColor = System.Drawing.Color.Transparent;
            _new_.Controls.Add(procCount);

            //Exit & Accept
            Button exit = new Button();
            exit.Text = "Accept";
            exit.Click += new System.EventHandler(close_new_form);
            exit.Location = new System.Drawing.Point(0, 470);
            exit.Size = new System.Drawing.Size(305, 40);
            _new_.Controls.Add(exit);

            //checkbox
            CheckBox planner = new CheckBox();
            planner.Text = "Planning";
            planner.Location = new System.Drawing.Point(10, 410);
            planner.Width = 70;
            planner.CheckedChanged += new System.EventHandler(planner_changed);
            planner.Enabled = false;
            planner.BackColor = System.Drawing.Color.Transparent;
            _new_.Controls.Add(planner);

            //radio type of planning
            List<RadioButton> radio = new List<RadioButton>();
            radio.Add(new RadioButton());
            radio[0].Text = "Smart";
            radio.Add(new RadioButton());
            radio[1].Text = "Min";
            radio.Add(new RadioButton());
            radio[2].Text = "Max";
            for (int i = 0; i < radio.Count; i++)
            {
                radio[i].Width = 60;
                radio[i].Location = new System.Drawing.Point(100 + 70 * i, planner.Location.Y);
                radio[i].Visible = false;
                radio[i].CheckedChanged += new System.EventHandler(radio_changed);
                radio[i].Tag = radio;
                radio[i].BackColor = System.Drawing.Color.Transparent;
                _new_.Controls.Add(radio[i]);
            }
            planner.Tag = radio;

            //task complexity
            List<Power> complexity = new List<Power>();
            complexity.Add(new Power());
            complexity.Add(new Power());
            complexity[0].caption.Text = "Min: 0";
            complexity[1].caption.Text = "Max: 0";
            for (int i = 0; i < complexity.Count; i++)
            {
                complexity[i].caption.Location = new System.Drawing.Point(155 * i, 440);
                complexity[i].track.Location = new System.Drawing.Point(55 + i * 155, complexity[i].caption.Location.Y);
                complexity[i].track.ValueChanged += new System.EventHandler(complexity_value_changed);
                complexity[i].track.Maximum = 50;
                complexity[i].track.SmallChange = 1;
                complexity[i].track.LargeChange = 5;
                complexity[i].track.Tag = complexity;
                complexity[i].caption.Width = 60;
                complexity[i].caption.Tag = i;
                complexity[i].track.Width = 100;
                complexity[i].track.Enabled = false;
                complexity[i].caption.Enabled = false;
                complexity[i].track.Name = "complexity_track_" + Convert.ToString(i);
                complexity[i].caption.Name = "complexity_caption_" + Convert.ToString(i);
                complexity[i].caption.BackColor = System.Drawing.Color.Transparent;
                //complexity[i].track.BackColor = System.Drawing.Color.Transparent;
                _new_.Controls.Add(complexity[i].caption);
                _new_.Controls.Add(complexity[i].track);
            }

            //processor selection
            ComboBox numberofProc = new ComboBox();
            for (int i = 1; i <= 9; i++)
            {
                numberofProc.Items.Add(i);
            }
            numberofProc.Location = new System.Drawing.Point(180, 20);
            numberofProc.SelectedIndexChanged += new System.EventHandler(numberofProc_changed);
            numberofProc.Tag = planner;
            _new_.Controls.Add(numberofProc);

            _new_.ShowDialog();
            
        }
        private void radio_changed(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            List<RadioButton> planner_select = (List<RadioButton>)radio.Tag;
            CSystem.use_smart_planning = planner_select[0].Checked;
            CSystem.use_min_planning = planner_select[1].Checked;
            CSystem.use_max_planning = planner_select[2].Checked;
        }
        private void complexity_value_changed(object sender, EventArgs e)
        {
            TrackBar track = (TrackBar)sender;
            List<Power> complex = (List<Power>)track.Tag;
            if (complex[0].track.Value > complex[1].track.Value)
            {
                complex[1].track.Value = complex[0].track.Value;
            }
            complex[0].caption.Text = "Min: " + complex[0].track.Value * 20;
            complex[1].caption.Text = "Max: " + complex[1].track.Value * 20;
            CSystem.min_comp = complex[0].track.Value;
            CSystem.max_comp = complex[1].track.Value;
        }
        private void planner_changed(object sender, EventArgs e){
            CheckBox planner = (CheckBox)sender;
            List<RadioButton> radio = (List<RadioButton>)planner.Tag;
            for (int i = 0; i < radio.Count; i++)
            {
                radio[i].Checked = false;
                radio[i].Visible = !radio[i].Visible;
            }
            CSystem.use_plannig = planner.Checked;
        }
        private void close_new_form(object sender, EventArgs e)
        {
            _new_.Close();
        }
        private void numberofProc_changed(object sender, EventArgs e)
        {
            CheckBox planner = (CheckBox)((ComboBox)sender).Tag;
            planner.Enabled = true;
            foreach (Control c in _new_.Controls)
            {
                if (c is TrackBar || c is Label)
                {
                    c.Enabled = true;
                }
            }
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
                procPower[i].caption.BackColor = System.Drawing.Color.Transparent;
                //procPower[i].track.BackColor = System.Drawing.Color.Transparent;
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
                play_pause.Image = ComputerSystems.Properties.Resources.Button_Pause;
            }
            else
            {
                play_pause.Image = ComputerSystems.Properties.Resources.Button_Play;
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
        //public List<Task> tasks;
        public bool status; //true - job, false - free
        //private Task current;
    }
    public class CS
    {
        public CS(int proc, Panel owner)
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
                processors[i].image.Image = ComputerSystems.Properties.Resources.CPU_2;
                processors[i].image.Location = new System.Drawing.Point(80 + 158 * (i % 3), 20 + 155 * (i / 3));
                processors[i].image.BackColor = System.Drawing.Color.Transparent;
                processors[i].image.BorderStyle = BorderStyle.None;
                processors[i].image.Size = processors[i].image.Image.Size;
                processors[i].image.Visible = true;
                owner.Controls.Add(processors[i].image);
                processors[i].image.BringToFront();
                //bar
                processors[i].bar = new ProgressBar();
                processors[i].bar.Location = new System.Drawing.Point(processors[i].image.Location.X, processors[i].image.Location.Y - 30);
                processors[i].bar.Size = new System.Drawing.Size(processors[i].image.Image.Width, 20);
                processors[i].bar.Visible = false;
                owner.Controls.Add(processors[i].bar);
                //type
                processors[i].type = i + 1;
                processors[i].status = false;
            }
        }
        public int min_comp;
        public int max_comp;
        public bool use_plannig = false;
        public bool use_smart_planning = false;
        public bool use_min_planning = false;
        public bool use_max_planning = false;

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
