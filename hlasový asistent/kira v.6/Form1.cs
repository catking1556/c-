using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Media;
using System.IO;

namespace kira_v._6
{

    public partial class Form1 : Form
    {

        private int timeLeft;
        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = true;
        Choices list = new Choices();
        int ms, sk, m, h;
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        [DllImport("user32")]
        public static extern bool LockWorkStation();
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
           UIntPtr dwExtraInfo);
        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

            list.Add(new string[] {"you right", "open siri" ,"open cortana", "tell me joke", "end", "task", "save", "back", "enter", "n","v","a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "o", "p", "r", "s", "t", "u", "w", "y", "z", "open textbox","kill textbox", "kill console", "open console", "kill timer", "open timer", "timer default", "set timer to fiveteen", "set timer to pizza", "set timer to half", "set timer to twenty", "set timer to ten", "set timer to nine", "set timer to eight", "set timer to seven", "set timer to six", "set timer to one", "set timer to two", "set timer to three", "set timer to four", "set timer to five", "timer off", "timer on", "thanks", "thank you", "mute", "down","up","i tell you joke", "that’s all", "bad bro", "not good", "im fine", "ok","good","how is life", "lock", "how are you", "sleep", "restart", "log off", "close stopwatch", "open stopwatch", "reset stopwatch", "stop stopwatch", "start stopwatch","last", "next", "stop", "play", "year", "hi", "kill count", "count", "kill spotify", "kill office", "kill chrome", "exit", "shut down", "hello", "what are you say", "wake up", "time", "day", "chrome", "go sleep", "open office", "close all", "word", "spotify", "switch", "cortana" }); ; ;
            Grammar gr = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch { return; }

            s.SelectVoiceByHints(VoiceGender.Male);
            s.Speak("hello");
            ms = 0;
            


            InitializeComponent();
        }

        public void say(string h)
        {
            
           
            s.Speak(h);
         
            textBox2.AppendText(h + Environment.NewLine);
            
             //MessageBox.Show("fi");  

        }
        string[] greet = new string[5] { "hello", "hi", " It’s nice to meet you", " Hey man", " Good to see you" };
        string[] mood = new string[5] { "Fine", "I’m fine, thanks", " I’m all right.", " Not too bad.", "I’m OK." };
        string[] jok = new string[5] { ". . . . .Hear about the new restaurant called Karma?. . . . . . . . . There’s no menu: You get what you deserve.", ". . . . .Did you hear about the claustrophobic astronaut?. . . . . . . . . He just needed a little space.", ". . . . .How do you drown a hipster?. . . . . . . . . Throw him in the mainstream.", ". . . . .What did one hat say to the other?. . . . . . . . . You wait here. I’ll go on a head. If you loved this, you’ll get a kick out of these", ". . . . .What did the shark say when he ate the clownfish?. . . . . . . . . This tastes a little funny." };
        public string greeting()
        {
            Random r = new Random();
            return greet[r.Next(5)];
            
        }
        public string mooding()
        {
            Random r = new Random();
            return mood[r.Next(5)];
        }
        public string joking()
        {
            Random r = new Random();
            return jok[r.Next(5)];
        }
        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string r = e.Result.Text;
            if (r == "wake up") { wake = true; say("hello master");pictureBox1.Visible = true; }
            if (r == "go sleep") { wake = false; say("good night"); pictureBox1.Visible = false; }
            if (wake == true)
            {

                if (r == "hello") { say(greeting()); }
                if (r == "hi") { say(greeting()); }
                if (r == "what are you say") { say("i said" + greeting()); }
                if (r == "how are you" || r == "how is life") { say(mooding() + "  and you?"); }
                if (r == "im fine" || r == "ok" || r == "good") { say("OK, Good"); }
                if (r == "bad bro" || r == "not good") { say("don't worry it'll be ok"); }
                if (r == "that’s all") {  say("hahahahaha"); }
                if (r == "i tell you joke") { say("i’m listening");  }
                if (r == "thank you"||r=="thanks") { say("You're welcome"); }
                if (r == "tell me joke") { say("ok"+joking()); }
                if (r == "open cortana") { say("hell no. You are traitor"); }
                if (r == "open siri") { say("hell no. She is not better than me"); }
                if (r == "you right") { say("i think so"); }

                //1
                if (r == "time") { say(DateTime.Now.ToString("h:mm tt")); }
                if (r == "day") { say(DateTime.Now.ToString("M/d/yyyy")); }
                if (r == "year") { say(DateTime.Now.ToString("yyyy")); }



                //2+3
                if (r == "chrome") { say("ok i open google"); Process.Start("chrome.exe", "http:\\www.google.com"); }
                if (r == "kill chrome") { say("lets hunt chrome"); chromeex(); }
                if (r == "open office") { say("ok i open word"); Process.Start("winword"); }
                if (r == "kill office") { say("lets hunt office"); officeex(); }
                if (r == "spotify") { say("ok lets listen some music"); Process.Start("spotify"); }
                if (r == "kill spotify") { say("lets hunt spotify"); spotifyex(); }
                if (r == "close all") { hell(); }
                if (r == "count") { say("ok lets count"); Process.Start("calc.exe"); }
                if (r == "kill count") { say("i hate math lets kill"); calcex(); }
                //4
                if (r == "switch") { svitch(); }
                if (r == "task") { SendKeys.Send("+(^{ESC}{LEFT})");say("task manager is opened"); }
                if (r == "end") { SendKeys.Send("(%{F4})");say ("you press alt f4. how dare you") ; }

                //10
                if (r == "a") { SendKeys.Send("a");b1.Focus(); }
                if (r == "b") { SendKeys.Send("b");b1.Focus(); }
                if (r == "c") { SendKeys.Send("c");b1.Focus(); }
                if (r == "d") { SendKeys.Send("d");b1.Focus(); }
                if (r == "e") { SendKeys.Send("e");b1.Focus(); }
                if (r == "f") { SendKeys.Send("f");b1.Focus(); }
                if (r == "g") { SendKeys.Send("g");b1.Focus(); }
                if (r == "h") { SendKeys.Send("h");b1.Focus(); }
                if (r == "i") { SendKeys.Send("i");b1.Focus(); }
                if (r == "j") { SendKeys.Send("j");b1.Focus(); }
                if (r == "k") { SendKeys.Send("k");b1.Focus(); }
                if (r == "l") { SendKeys.Send("l");b1.Focus(); }
                if (r == "m") { SendKeys.Send("m");b1.Focus(); }
                if (r == "n") { SendKeys.Send("n");b1.Focus(); }
                if (r == "o") { SendKeys.Send("o");b1.Focus(); }
                if (r == "p") { SendKeys.Send("p");b1.Focus(); }
                if (r == "r") { SendKeys.Send("r");b1.Focus(); }
                if (r == "s") { SendKeys.Send("s");b1.Focus(); }
                if (r == "t") { SendKeys.Send("t");b1.Focus(); }
                if (r == "u") { SendKeys.Send("u");b1.Focus(); }
                if (r == "v") { SendKeys.Send("v");b1.Focus(); }
                if (r == "w") { SendKeys.Send("w");b1.Focus(); }
                if (r == "y") { SendKeys.Send("y");b1.Focus(); }
                if (r == "z") { SendKeys.Send("z");b1.Focus(); }
                if (r == "enter") { SendKeys.Send("~"); b1.Focus(); }
                if (r == "back") { SendKeys.Send("{BACKSPACE}"); b1.Focus(); }
                if (r == "save") { save();say("your texbox is saved at desktop"); }


                if (r == "open textbox") { b1.Visible = true;textBox4.Visible = true; }
                if (r == "kill textbox") { b1.Visible = false; textBox4.Visible = false; }

                //5
                if (r == "shut down") { say("I turn down pc"); Application.Exit(); Process.Start("shutdown", "/s /t 0"); }
                if (r == "log off") { say("Logging off the System"); Application.Exit(); ExitWindowsEx(0, 0); }
                if (r == "restart") { say("restarting System"); Application.Exit(); Process.Start("shutdown", "/r /t 0"); }
                if (r == "sleep") { say("system going to sleep"); SetSuspendState(false, true, true); }
                if (r == "lock") { say("system are going to lock"); LockWorkStation(); }
                //6
                if (r == "exit") { say("bye ,have a nice day"); Application.Exit(); }
                //7
                if (r == "play") { SendKeys.Send(" "); }
                if (r == "stop") { SendKeys.Send(" "); }
                if (r == "next") { SendKeys.Send("^{RIGHT}"); }
                if (r == "last") { SendKeys.Send("^{LEFT}"); }
                if (r == "up") { volumeup(); }
                if (r == "down") { volumedown(); }
                if (r == "mute") { mute(); }
                
                //8
                if (r == "start stopwatch") { say("stopwatch starting"); stopwstart(); }
                if (r == "stop stopwatch") { say("stopwatch stopped"); stopwstop(); }
                if (r == "reset stopwatch") { say("stopwatch reseting"); stopwreset(); }
                if (r == "open stopwatch") { say("stopwatch opening"); stopwopen(); }
                if (r == "close stopwatch") { say("stopwatch closing"); stopwclose(); }
                //9
                if (r == "timer on") { say("timer starting"); timerstart(); }
                if (r == "timer off") { say("timer stop"); timerstop(); }
                if (r == "set timer to five") { say("timer is set to five minute"); label5.Text = "05:00"; }
                if (r == "set timer to four") { say("timer is set to four minute"); label5.Text = "04:00"; }
                if (r == "set timer to three") { say("timer is set to three minute"); label5.Text = "03:00"; }
                if (r == "set timer to two") { say("timer is set to two minute"); label5.Text = "02:00"; }
                if (r == "set timer to one") { say("timer is set to one minute"); label5.Text = "01:00"; }
                if (r == "set timer to six") { say("timer is set to six minute"); label5.Text = "06:00"; }
                if (r == "set timer to seven") { say("timer is set to seven minute"); label5.Text = "07:00"; }
                if (r == "set timer to eight") { say("timer is set to eight minute"); label5.Text = "08:00"; }
                if (r == "set timer to nine") { say("timer is set to nine minute"); label5.Text = "09:00"; }
                if (r == "set timer to ten") { say("timer is set to ten minute"); label5.Text = "10:00"; }
                if (r == "set timer to pizza") { say("timer is set to best settings for bake frozen pizza"); label5.Text = "12:00"; }
                if (r == "set timer to twenty") { say("timer is set to twenty minute"); label5.Text = "20:00"; }
                if (r == "set timer to half") { say("timer is set to thirty minute"); label5.Text = "30:00"; }
                if (r == "set timer to fiveteen") { say("timer is set to fiveteen minute"); label5.Text = "15:00"; }
                if (r == "timer default") { say("clear the timer"); label5.Text = "00:00"; }
                if (r == "open timer") { say("timer is opening"); label5.Visible = true;f6.Visible = true;}
                if (r == "kill timer") { say("lets murder timer"); label5.Visible = false;f6.Visible = false; }
                if (r == "open console") { textBox1.Visible = true;textBox2.Visible = true;f1.Visible = true;f3.Visible = true; }
                if (r == "kill console") { textBox1.Visible = false; textBox2.Visible = false; f1.Visible = false; f3.Visible = false; }







            }
            textBox1.AppendText(r + Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void svitch()
        {
            SendKeys.Send("%" + "{TAB}");

        }    
        public void hell()
        {

            try
            {
                foreach (var process in Process.GetProcessesByName("spotify"))
                {
                    process.Kill();
                }
            }
            catch { }
            try
            {
                foreach (var process in Process.GetProcessesByName("winword"))
                {
                    process.Kill();
                }
            }
            catch { }
            try
            {
                foreach (var process in Process.GetProcessesByName("chrome"))
                {
                    process.Kill();
                }
            }
            catch { }
        }
        public void chromeex()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("chrome"))
                {
                    process.Kill();
                }
            }
            catch { }
        }
        public void officeex()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("winword"))
                {
                    process.Kill();
                }
            }
            catch { }
        }
        public void spotifyex()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("spotify"))
                {
                    process.Kill();
                }
            }
            catch { }
        }
        public void calcex()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("calc.exe"))
                {
                    process.Kill();
                }
            }
            catch { }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ms = ms + 1; 
            label4.Text = ms.ToString()+" ms";
            if (ms == 9) 
            {
                ms = 0; 
                sk = sk + 1; 
                label3.Text = sk.ToString() + " s :"; 
                if (sk == 59) 
                {
                    sk = 0; 
                    m = m + 1; 
                    label2.Text = m.ToString() + " m :"; 
                    if (m == 59) 
                    {
                        m = 0; 
                        h = h + 1; 
                        label1.Text = h.ToString() + " h :"; 
                    }
                }
            }
        }
      
        public void stopwstart() {timer1.Start(); }
        public void stopwstop() {timer1.Stop(); }
        public void stopwreset()
        {
            timer1.Enabled = false;
            ms = 0;
            h = 0;
            sk = 0;
            m = 0;
            label1.Text = "00 h :";
            label2.Text = "00 m :";
            label3.Text = "00 s :";
            label4.Text = "00 ms";
            if (t1.Visible == false) { t1.Visible = true; }
            if (t2.Visible == false) { t2.Visible = true; }


        }
        public void stopwclose()
        {
            if (label1.Visible == true) { label1.Visible = false; }
            if (label2.Visible == true) { label2.Visible = false; }
            if (label3.Visible == true) { label3.Visible = false; }
            if (label4.Visible == true) { label4.Visible = false; }
            
           
        }
        public void stopwopen()
        {
            if (label1.Visible == false) { label1.Visible = true; }
            if (label2.Visible == false) { label2.Visible = true; }
            if (label3.Visible == false) { label3.Visible = true; }
            if (label4.Visible == false) { label4.Visible = true; }
            if (t1.Visible == false) { t1.Visible = true; }
            if (t2.Visible == false) { t2.Visible = true; }



        }
        public void timerstart()
        {
            string[] totalSeconds = label5.Text.Split(':');
            int minutes = Convert.ToInt32(totalSeconds[0]);
            int seconds = Convert.ToInt32(totalSeconds[1]);
            timeLeft = (minutes * 60) + seconds;
            timer2.Start();
        }
        public void timerstop() 
        {
            timer2.Stop();
            timeLeft = 0;
        }
       
       
       
        

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer2.Stop();
            timeLeft = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = "00:00";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label5.Text = "00:05";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                // Display time remaining as mm:ss
                var timespan = TimeSpan.FromSeconds(timeLeft);
                label5.Text = timespan.ToString(@"mm\:ss");

            }
            else
            {
                timer2.Stop();
                SystemSounds.Exclamation.Play();
               
                say("master timer is over");
            }

        }

       
        public void volumeup()
        {
            for (int i = 0; i < 5; i++)
            {
                keybd_event(0xAF, 0, 0x0001 | 0, (UIntPtr)0);
                keybd_event(0xAF, 0, 0x0001 | 0x0002, (UIntPtr)0);
            }
        }
        public void volumedown() {
            for (int i = 0; i < 5; i++)
            {
                keybd_event(0xAE, 0, 0x0001 | 0, (UIntPtr)0);
                keybd_event(0xAE, 0, 0x0001 | 0x0002, (UIntPtr)0);
            }
        }
        public void mute()
        {
            keybd_event(0xAD, 0, 0x0001 | 0, (UIntPtr)0);
            keybd_event(0xAD, 0, 0x0001 | 0x0002, (UIntPtr)0);
        }
        public void save() 
        {
            {
                // Get the current date and time
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

                // Define the file path with the date and time as the file name
                string filePath = @"C://Users//jindr//OneDrive//Plocha//" + dateTime + ".txt";

                // Create the text file with the given file path
                File.Create(filePath).Close();

                // Display a message to the user indicating that the file has been created
                //MessageBox.Show("Text file has been created successfully!");
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(b1.Text);

                }
            }
        }
    }

}
