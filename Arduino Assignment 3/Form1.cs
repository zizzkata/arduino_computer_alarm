using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;



namespace Arduino_Assignment_3
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }


        //System.Timers.Timer timer = new System.Timers.Timer();
        Stopwatch timer = new Stopwatch();
        Stopwatch timer_1 = new Stopwatch();

        List<Patient> patients = new List<Patient>();

        string path = @"trsh/patents.txt";
        string path2 = @"trsh/records.txt";





        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                while (line == "-/////-" && line != null)
                {
                    patients.Add(new Patient { name = sr.ReadLine(), age = sr.ReadLine(), location = sr.ReadLine()  });
                    line = sr.ReadLine();
                }
            }

            using (StreamReader sr = new StreamReader(path2))
            {

            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbName.Text = patients[comboBox1.SelectedIndex].name;
            lbAge.Text = patients[comboBox1.SelectedIndex].age;
            lbLocation.Text = patients[comboBox1.SelectedIndex].location;

            Index_To_Port();
            
            btnPortOpen.Visible = true;
            btnPortOpen.Text = "Turn-On port";

            if(serialPort1.IsOpen)
            {
                serialPort1.WriteLine("logg_Off");
            }

            Clear();
        }

        private void Index_To_Port()
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        serialPort1.PortName = "COM1";
                        break;
                    case 1:
                        serialPort1.PortName = "COM2";
                        break;
                    case 2:
                        serialPort1.PortName = "COM3";
                        break;
                    case 3:
                        serialPort1.PortName = "COM4";
                        break;
                    case 4:
                        serialPort1.PortName = "COM5";
                        break;
                }
            }
            catch (Exception)
            {
                serialPort1.WriteLine("logg_Off");
                serialPort1.Close();
                timer1.Enabled = false;
            }
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                if (serialPort1.BytesToRead > 0)
                {
                    
                    string line = serialPort1.ReadLine().Trim();
                    
                    string[] lineComand = line.Split('/');

                    for (int i = 0; i < lineComand.Length; i++)
                    {
                        line = lineComand[i];

                        if (line == "temp:")
                        {
                            lbRoomTemp.Text = lineComand[i + 1] + "°C";

                            double x;
                            Double.TryParse(lineComand[i + 1], out x);

                            if (x < 15)
                            {

                                if (timer.ElapsedMilliseconds == 0 || timer.ElapsedMilliseconds > 3000000)
                                {
                                    timer.Start();
                                    listBox1.Items.Add(DateTime.Now.ToString("HH:mm") + "  Temperature has dropped to " + lineComand[i + 1] + "°C");
                                    if (timer.ElapsedMilliseconds > 1000)
                                    {
                                        timer.Stop();
                                        timer.Reset();
                                    }
                                }
                            }
                            else if (x > 30)
                            {
                                if (timer_1.ElapsedMilliseconds == 0 || timer_1.ElapsedMilliseconds > 3000000)
                                {
                                    timer.Start();
                                    listBox1.Items.Add(DateTime.Now.ToString("HH:mm") + "  Temperature has gone up to " + lineComand[i + 1] + "°C");
                                    if (timer_1.ElapsedMilliseconds > 1000)
                                    {
                                        timer.Stop();
                                        timer.Reset();
                                    }
                                }
                            }

                        }
                        else if (line == "humid:")
                        {
                            lbRoomHum.Text = lineComand[i + 1] + "%";
                        }
                        else if (line == "light:")
                        {
                            double x;
                            Double.TryParse(lineComand[i + 1], out x);

                            if (x < 0.100)
                            {
                                lbRoomLight.Text = "DARK";
                            }
                            else if (x >= 0.100 && x < 0.500)
                            {
                                lbRoomLight.Text = "DIM";
                            }
                            else if (x >= 0.500)
                            {
                                lbRoomLight.Text = "LIGHT";
                            }
                        }
                        else if (line == "head_s:")
                        {
                            lbHsAngle.Text = lineComand[i + 1];
                        }
                        else if (line == "alarm_s:")
                        {
                            if(lineComand[i+1] == "alarm_On")
                            {
                                lbAlarmState.Text = "Activated";
                                Check_For_AlarmEvent(lineComand[i+1], true);
                                lbAlarmState.ForeColor = Color.Red;

                            }
                            
                        }
                        else { }
                    }
                  
                }
              
                serialPort1.WriteLine('$' + DateTime.Now.ToString("HHmm"));
                //listBox1.Items.Add('$' + DateTime.Now.ToString("HHmm"));
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("The current port is not open!");
            }
        }

        

        private void Check_For_AlarmEvent(string obj, bool priority) 
        {
            //double numb;


            if (priority)
            {
                if(obj == "alarm_On")
                {
                    listBox1.Items.Add(DateTime.Now.ToString("HH:mm") + "  Alarm Activated");
                }
            }
            else
            {
                //Double.TryParse(obj, out numb);
                //{ 
                //}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(btnPortOpen.Text == "Turn-On port")
                {
                    timer1.Enabled = true;
                    serialPort1.Open();
                    pInfo.Visible = true;
                    lbAlarmState.Text = "Normal";
                    System.Threading.Thread.Sleep(200);
                    serialPort1.WriteLine("logg_On");
                    btnPortOpen.Text = "Turn-Off port";
                }
                else
                {
                    
                    serialPort1.WriteLine("logg_Off");
                    System.Threading.Thread.Sleep(200);
                    timer1.Enabled = false;
                    pInfo.Visible = false;
                    Clear();
                    serialPort1.Close();
                    btnPortOpen.Text = "Turn-On port";
                }
               
            }
            catch(Exception)
            {
                timer1.Enabled = false;
                MessageBox.Show("The port is not found!\rThere may be a problem with the connection!");
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                serialPort1.WriteLine("alarm_Off");
                lbAlarmState.Text = "Normal";
                lbAlarmState.ForeColor = Color.Black;
                listBox1.Items.Add(DateTime.Now.ToString("HH:mm") + "  Alarm Deactivated");
            }
           
            
        }

        /*NOT FINNISHED
        private void Save_History()
        {
            string theWholeMFThing = File.ReadAllText(path2);

            string[] listBoxItems = theWholeMFThing.Split('\r');

            MessageBox.Show(listBoxItems.Length.ToString());
            int capacityNew = listBoxItems.Length + listBox1.Items.Count;
            
            string[] txtFile = new string[capacityNew];

            if (capacityNew != listBoxItems.Length)
            {
                int k = 0;
                int i = 0;
                string index = comboBox1.SelectedIndex.ToString() + ":";

                int numb = 0;
                while (i < listBoxItems.Length)
                {
                    if (listBoxItems[i] == index)
                    {
                        numb = i;
                    }

                    i++;
                }
                i = 0;
                while (k < listBoxItems.Length)
                {
                    txtFile[i] = listBoxItems[k];
                    if (numb == k)
                    {
                        i++;
                        int c = 0;
                        while(c  < listBox1.Items.Count)
                        {
                            txtFile[i + c] = listBox1.Items[c].ToString();
                            c++;
                        }
                        i += c;
                        k++;
                        
                    }
                    else
                    {

                        i++;
                        k++;
                    }
                }



                //using (StreamReader sr = new StreamReader(path2))
                //{

                //}
                File.Delete(path2);
                var myFile = File.Create(path2);
                myFile.Close();
                

                using (StreamWriter rs = new StreamWriter(path2))
                {
                    i = 0;
                    
                    while(i<txtFile.Length)
                    {
                        rs.WriteLine(txtFile[i]);
                        i++;
                    }
                }

            }
           
        }
        */
        private void Clear()
        {
            lbAlarmState.Text = "";
            lbHsAngle.Text = "";
            lbRoomHum.Text = "";
            lbRoomLight.Text = "";
            lbRoomTemp.Text = "";

            listBox1.Items.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPort1.WriteLine("logg_Off");
                serialPort1.Close();
            }
            catch (Exception)
            {
                Application.Exit();
            }
           
        }
 
    }
    public class Patient
    {
        public string name { get; set; }
        public string age { get; set; }
        public string location { get; set; }

        List<string> records = new List<string>();
    }

}

