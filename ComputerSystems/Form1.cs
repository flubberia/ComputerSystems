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
using System.Threading;
using System.Diagnostics;
using ComputerSystems.Controls;

namespace ComputerSystems
{
   
    public partial class Main : Form
    {
        Random rnd = new Random();
        Mutex mut = new Mutex();
        int TaskCount = 0;
        bool play = true;
        int genComplex = 0;
        int avgComplex = 0;
        int CommonTimeInterval = 2000; //2 sec
        int NumberOfIterations = 10;
        int maxTasks = 100;
        int finishedTasks = 0;
        int probability = 30;
        System.Windows.Forms.Timer taskTimer;
        System.Windows.Forms.Timer stopwatchTimer;
        Stopwatch stopwatch;
        CS CSystem;
        Form _new_;
        Form Options;
        List<Power> procPower;
        List<PictureBox> side_panel;

        public Main()
        {
            InitializeComponent();
            side_panel_init();
            init_task_timer();
            play_pause.Enabled = false;
            mut.WaitOne();
            logging.AppendText("System Started\n");
            mut.ReleaseMutex();
            
        }
        private void init_task_timer()
        {
            taskTimer = new System.Windows.Forms.Timer();
            taskTimer.Interval = CommonTimeInterval / 10;
            taskTimer.Tick += new System.EventHandler(createNewTask);

            stopwatchTimer = new System.Windows.Forms.Timer();
            stopwatchTimer.Interval = 100;
            stopwatchTimer.Tick += new System.EventHandler(count_timne);

        }

        private void count_timne(object sender, EventArgs e)
        {

            update_global_data();
            if (stopwatch != null)
                currentTime.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss\:ff");
            else
                currentTime.Text = "00:00:00:00";

        }
        
        private void update_global_data()
        {
            global1.textBox1.Text = TaskCount.ToString();
            global1.textBox4.Text = genComplex.ToString();
            global1.textBox5.Text = avgComplex.ToString();    
          
            for (int i = 0; i < CSystem.processors.Count; i++)
            {
                processors1.dataGridView1[2, i].Value = CSystem.processors[i].tasksTaken;
                processors1.dataGridView1[3, i].Value = CSystem.processors[i].totalComplexity;
                if (CSystem.processors[i].tasksTaken > 0)
                    processors1.dataGridView1[4, i].Value = CSystem.processors[i].totalComplexity / CSystem.processors[i].tasksTaken;
               
                // processors1.dataGridView1.Rows.Add(item.type, item.power, item.tasksTaken, item.totalComplexity, item.totalComplexity / item.tasksTaken);

            }
               
           
        }

        private void createNewTask(object sender, EventArgs e)
        {
           
            if (rnd.Next(100) > probability && TaskCount < maxTasks)
            {
                Task task = new Task();
                TaskCount++;
                CSystem.tasks.Add(task);
                task.complexity = CSystem.min_comp + rnd.Next(CSystem.max_comp - CSystem.min_comp);
                genComplex += task.complexity;
                avgComplex = genComplex / TaskCount;
                task.name = "Task: " + TaskCount;
                for (int i = 0; i < 1 + rnd.Next(CSystem.processors.Count); i++)
                {
                    task.types.Add(1 + rnd.Next(CSystem.processors.Count));
                }
                mut.WaitOne();
                logging.AppendText(task.name + " created: "+ task.complexity + "\n");
                mut.ReleaseMutex();
                if (TaskCount == maxTasks)
                {
                    mut.WaitOne();
                    logging.AppendText("System Stoped\n");
                    mut.ReleaseMutex();
                   // MessageBox.Show("System finished creating of tasks", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ChooseProc();
        }

        private void ChooseProc()
        {
            if (CSystem.tasks.Count > 0)
            {
                Task topTask = new Task(CSystem.tasks[0]);
                MatchProcType(topTask);
            }
        }

        private void MatchProcType(Task t)
        {
            List<Proc> prols = new List<Proc>();
            foreach (Proc item in CSystem.processors)
            {
                if (t.types.Contains(item.type))
                {
                    prols.Add(item);
                }
            }
            bool isMatched = false;
            foreach (Proc item in prols)
            {
                if (!item.status)
                {
                    isMatched = true;
                    item.tasks.Add(t);
                    item.tasksTaken++;
                    item.totalComplexity += t.complexity;
                    CSystem.tasks.RemoveAt(0);
                    StartProccessor(item);
                    break;
                }
            }
            if (!isMatched)
            {
                Proc item = prols[rnd.Next(prols.Count)];
                item.tasks.Add(t);
                item.tasksTaken++;
                item.totalComplexity += t.complexity;
                CSystem.tasks.RemoveAt(0);
                StartProccessor(item);
            }

        }
        private void StartProccessor(Proc  proc)
        {
            if (!proc.status)
            {
                if (proc.tasks.Count > 0)
                {
                    double koeff = (double)proc.tasks[0].complexity / proc.power;
                    System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
                    time.Interval = (int)((CommonTimeInterval * koeff) / NumberOfIterations);
                    time.Tick += new System.EventHandler(drawProgress);
                    proc.iter = NumberOfIterations;
                    time.Tag = proc;
                    proc.timer = time;
                    proc.status = true; //job
                    int barrier = (CSystem.max_comp - CSystem.min_comp) / 3;
                    int simple = CSystem.min_comp + barrier;
                    int hard = CSystem.max_comp - barrier;
                    PictureBox innerView = (PictureBox)proc.image.Tag;
                    if (proc.tasks[0].complexity > simple)
                    {
                        if (proc.tasks[0].complexity <= hard)
                        {
                            int yellow = int.Parse(Yellow_Task.Text) + 1;
                            Yellow_Task.Text = yellow.ToString();
                            innerView.Image = ComputerSystems.Properties.Resources.Loading_Yellow_1;

                        }
                        else
                        {
                            int red = int.Parse(Red_Task.Text) + 1;
                            Red_Task.Text = red.ToString();
                            innerView.Image = ComputerSystems.Properties.Resources.Loading_Red_1;
                        }
                    }
                    else
                    {
                        int green = int.Parse(Green_Task.Text) + 1;
                        Green_Task.Text = green.ToString();
                        innerView.Image = ComputerSystems.Properties.Resources.Loading_Green_1;
                    }

                    time.Start();
                    mut.WaitOne();
                    logging.AppendText("Processor " + proc.type + " started " + proc.tasks[0].name + "\n");
                    mut.ReleaseMutex();
                }
            }
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
            side_panel[0].Tag = new SidePanelElem(ComputerSystems.Properties.Resources.Button_Global, global1);
            side_panel[1].Tag = new SidePanelElem(ComputerSystems.Properties.Resources.Button_Processor, processors1);
            side_panel[2].Tag = new SidePanelElem(ComputerSystems.Properties.Resources.Button_Task, new Control());
            foreach (PictureBox item in side_panel)
            {
                ((SidePanelElem)item.Tag).View.Visible = false;
            }
            ((SidePanelElem)side_panel[0].Tag).View.Visible = true;
        }
        private void side_panel_click(object sender, EventArgs e)
        {
            for (int i = 0; i < side_panel.Count; i++)
            {
                side_panel[i].Image = null;
                side_panel[i].Enabled = true;
                SidePanelElem sde = (SidePanelElem)side_panel[i].Tag;
                sde.View.Visible = !side_panel[i].Enabled;
            }
            ((PictureBox)sender).Enabled = false;
            ((PictureBox)sender).Image = ((SidePanelElem)((PictureBox)sender).Tag).Image;
            ((SidePanelElem)((PictureBox)sender).Tag).View.Visible = !((PictureBox)sender).Enabled;
        }
        private void clean_new()
        {
            logging.Text = "";
            taskTimer.Stop();
            TaskCount = 0;
            finishedTasks = 0;
            if (processors1.dataGridView1.Rows != null)
                processors1.dataGridView1.Rows.Clear();
            stopwatch = new Stopwatch();
            Red_Task.Text = "0";
            Yellow_Task.Text = "0";
            Green_Task.Text = "0";
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clean_new();

            play_pause.Enabled = true;
            _new_ = new Form();
            _new_.StartPosition = FormStartPosition.CenterScreen;
            _new_.Size = new System.Drawing.Size(320, 520);
            _new_.FormBorderStyle = FormBorderStyle.None;
            _new_.BackgroundImage = ComputerSystems.Properties.Resources.win_2_2;
           
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
            exit.Location = new System.Drawing.Point(7, 470);
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
                _new_.Controls.Add(complexity[i].caption);
                _new_.Controls.Add(complexity[i].track);
            }

            //processor selection
            ComboBox numberofProc = new ComboBox();
            for (int i = 1; i <= 9; i++)
            {
                numberofProc.Items.Add(i);
            }
            numberofProc.Name = "ProcessorSelection";
            numberofProc.Location = new System.Drawing.Point(180, 20);
            numberofProc.SelectedIndexChanged += new System.EventHandler(numberofProc_changed);
            numberofProc.Tag = planner;
            _new_.Controls.Add(numberofProc);

            _new_.ShowDialog();
            
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_new_ == null)
            {
                //form
                Options = new Form();
                Options.StartPosition = FormStartPosition.CenterScreen;
                Options.FormBorderStyle = FormBorderStyle.Fixed3D;
                Options.Size = new System.Drawing.Size(320, 520);

                //BaseTimeInterval
                Power time = new Power();
                time.caption.Text = "Set time period: ";
                time.caption.Location = new Point(10, 10);
                Options.Controls.Add(time.caption);
                Options.ShowDialog();
            }
            else
            {
                MessageBox.Show("You cant access options while system is running, please close the application and try again", "Options", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            bool close = false;
            finishedTasks = 0;
            foreach (Control item in _new_.Controls)
            {
                close = true;
                if (item.Name == "ProcessorSelection")
                {
                    if (((ComboBox)item).SelectedIndex < 0)
                    {
                        close = false;
                        MessageBox.Show("Select at least one processor", "Processor Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
                if (item is TrackBar)
                {
                    if (((TrackBar)item).Value == 0)
                    {
                        close = false;
                        MessageBox.Show("At least one of your sliders has zero value", "Sliders", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
                if (item is CheckBox)
                {
                    if (((CheckBox)item).Checked)
                    {
                        close = false;
                        foreach (Control i in _new_.Controls)
                        {
                            if (i is RadioButton)
                            {
                                if (((RadioButton)i).Checked)
                                {
                                    close = true;
                                    break;
                                }
                            }
                        }
                        if (!close)
                        {
                            MessageBox.Show("Please check one of radio buttons", "Planer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                }
            }
            CSystem.min_comp = ((TrackBar)(_new_.Controls.Find("complexity_track_0", false).First())).Value * 20;
            CSystem.max_comp = ((TrackBar)(_new_.Controls.Find("complexity_track_1", false).First())).Value * 20;

            if (close)
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
            int count = 0;
            while (count < _new_.Controls.Count)
            {
                if (_new_.Controls[count].Name == "_Track_" || _new_.Controls[count].Name == "_Caption_")
                {
                    _new_.Controls.RemoveAt(count);
                }
                else
                {
                    count++;
                }
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
                procPower[i].track.Name = "_Track_";
                procPower[i].track.Tag = i;
                procPower[i].caption.Location = new System.Drawing.Point(0, 50 + i * 43);
                procPower[i].caption.Visible = true;
                procPower[i].caption.Enabled = true;
                procPower[i].caption.Size = new System.Drawing.Size(150, 30);
                procPower[i].caption.Text = "Processor " + Convert.ToString(i + 1) + " power: 0";
                procPower[i].caption.BackColor = System.Drawing.Color.Transparent;
                procPower[i].caption.Name = "_Caption_";
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
                mut.WaitOne();
                logging.AppendText ("Play\n");
                mut.ReleaseMutex();
                taskTimer.Start();
                stopwatchTimer.Start();
                if (stopwatch != null)
                    stopwatch.Start();
                if (finishedTasks == 0)
                    init_global_data();
                menuStrip1.Enabled = false;
                play_pause.Image = ComputerSystems.Properties.Resources.Button_Pause;
                foreach (Proc item in CSystem.processors)
                {
                    if (item.status)
                    {
                        item.timer.Start();
                    }
                }
            }
            else
            {
                mut.WaitOne();
                logging.AppendText("Pause\n");
                mut.ReleaseMutex();
                taskTimer.Stop();
                stopwatchTimer.Stop();
                if (stopwatch != null)
                    stopwatch.Stop();
                play_pause.Image = ComputerSystems.Properties.Resources.Button_Play;
                foreach (Proc item in CSystem.processors)
                {
                    if (item.status)
                    {
                        item.timer.Stop();
                    }
                }
                menuStrip1.Enabled = true;
            }
            play = !play;
        }
        private void init_global_data()
        {
            int genPower = 0;
            foreach (Proc item in CSystem.processors)
            {
                processors1.dataGridView1.Rows.Add(item.type, item.power, 0, 0, 0);
                genPower += item.power;
            }
            global1.textBox2.Text = CSystem.processors.Count.ToString();
            global1.textBox3.Text = genPower.ToString();
            global1.textBox6.Text = (genPower / CSystem.processors.Count).ToString();


        }
        private void drawProgress(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer time = (System.Windows.Forms.Timer)sender;
            Proc proc = (Proc)time.Tag;
            PictureBox progressBar = (PictureBox)proc.image.Tag;

            if (((Proc)time.Tag).iter == 0)
            {
                progressBar.Height = 46;
                proc.status = false;
                mut.WaitOne();
                if (proc.tasks.Count > 0)
                {
                    logging.AppendText("Processor " + proc.type + " finished " + proc.tasks[0].name + "\n");
                    mut.ReleaseMutex();
                    proc.tasks.RemoveAt(0);
                }
                finishedTasks++;
                if (finishedTasks == maxTasks)
                {
                    stopwatch.Stop();
                    stopwatchTimer.Stop();
                    taskTimer.Stop();
                    play_pause.Enabled = false;
                    play = !play;
                    play_pause.Image = ComputerSystems.Properties.Resources.Button_Play;
                    stopwatch = null;
                    menuStrip1.Enabled = true;
                    MessageBox.Show("Time Elapsed " + currentTime.Text, "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                    ((System.Windows.Forms.Timer)sender).Stop();
            
                if (proc.tasks.Count > 0)
                    StartProccessor(proc);
                

            }
            else
            {
                progressBar.Height += (int)((1.0 / NumberOfIterations) * ComputerSystems.Properties.Resources.Loading_Green.Height);
                proc.iter--;
            }

        }

    }

    public class SidePanelElem
    {
        public SidePanelElem()
        {

        }
        public SidePanelElem(Bitmap _image, Control _view)
        {
            Image = _image;
            View = _view;
        }
        public Bitmap Image;
        public Control View;
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
            types = new HashSet<int>();
        }
        public Task(Task task)
        {
            complexity = task.complexity;
            types = task.types;
            name = task.name;
        }
        public int complexity;
        public HashSet<int> types;
        public string name;
    }
    public class Proc
    {
        public Proc()
        {
            power = 0;
        }
        public int power;
        public System.Windows.Forms.Timer timer;
        public PictureBox image;
        public ProgressBar bar;
        public int type;
        public List<Task> tasks;
        public bool status; //true - job, false - free
        public int iter;
        public int totalComplexity = 0;
        public int tasksTaken = 0;
    }
    public class CS
    {
        public CS(int proc, Panel owner)
        {
            processors = new List<Proc>();
            tasks = new List<Task>();
            if (proc > 9)
            {
                proc = 9;
            }
            for (int i = 0; i < proc; i++)
            {
                //processor image
                Bitmap CPU = new Bitmap(ComputerSystems.Properties.Resources.CPU_2);
                Bitmap progressBit  = new Bitmap(ComputerSystems.Properties.Resources.Loading_Green_1);
                PictureBox progress = new PictureBox();
                progress.Image = progressBit;
                processors.Add(new Proc());
                processors[i].image = new PictureBox();
                processors[i].image.Image = CPU;
                processors[i].image.Location = new System.Drawing.Point(80 + CPU.Width * (i % 3), 20 + CPU.Height * (i / 3));
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
                progress.Visible = true;
                progress.Height = 46;
                progress.Width = progressBit.Width;
                processors[i].image.Tag = progress;
                processors[i].image.Controls.Add(progress);
                //type
                processors[i].type = i + 1;
                processors[i].status = false;
                processors[i].tasks = new List<Task>();
            }
        }
        public int min_comp;
        public int max_comp;
        public bool use_plannig = false;
        public bool use_smart_planning = false;
        public bool use_min_planning = false;
        public bool use_max_planning = false;

        public List<Proc> processors;
        public List<Task> tasks;
    }
}
