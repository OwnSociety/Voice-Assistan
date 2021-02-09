using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using SpeechLib;
using System.IO;
using WMPLib;
using System.Diagnostics;
using Microsoft.Win32;
using System.Globalization;


//This music is not by me i download on this site => its not by me
//music by https://audiotrimmer.com/tr/telifsiz-muzik
//music by https://pixabay.com/music/search/mood/relaxing/ Music by <a href="/users/hatom_music-18664388/?tab=audio&amp;utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=audio&amp;utm_content=1433">HaTom_music</a> from <a href="https://pixabay.com/music/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=1433">Pixabay</a>
//music by https://www.purple-planet.com/
namespace Kepler_Assistan__V._0._1
{
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            player.controls.play();
            InitializeComponent();
            player.controls.stop();
        }
        SpVoice sp = new SpVoice();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            label1.Text = "Firefox is opening";
            sp.Speak("firefox is opening");
            System.Diagnostics.Process.Start("firefox.exe");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar gr = new DictationGrammar();
            sr.LoadGrammar(gr);
            try
            {
                button1.Text = "SPEAK";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult rec = sr.Recognize();
                button1.Text = rec.Text;
            }
            catch (Exception)
            {
                button1.Text = "ERROR";
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            sp.Speak("chrome is opening");
            label1.Text = "chrome is opening";
            System.Diagnostics.Process.Start("chrome.exe");
        }
        private void button1_TextChanged(object sender, EventArgs e)
        {
            if (button1.Text == "Hello")
            {
                string a = "Hello sir";
                label1.Text = a;
                sp.Speak(a);
            }
            else if (button1.Text == "How are you")
            {
                string a = "I am fine sir. What about you";
                label1.Text = a;
                sp.Speak(a);
            }
            else if (button1.Text == "Who are you")
            {
                string a = "I am your virtual assistan Kepler sir";
                label1.Text = a;
                sp.Speak(a);
            }
            else if (button1.Text == "Music")
            {
                player.URL = " music1.mp3";
                label1.Text = "Music is starting";
                sp.Speak("music is starting");
                player.controls.play();
            }
            else if (button1.Text == "Relax")
            {
                label1.Text = "Relaxing will  start";
                sp.Speak("Relaxing will start");
                player.URL = "music3.mp3";
            }
            else if (button1.Text == "Exit")
            {
                label1.Text = "Good bye sir";
                sp.Speak("good bye sir");
                Application.Exit();
            }
            else if (button1.Text == "Time")
            {
                label1.Text = DateTime.Now.ToLongTimeString();
                sp.Speak(DateTime.Now.ToLongTimeString());

            }
            else if (button1.Text == "Date")
            {
                label1.Text = DateTime.Now.ToLongDateString();
                sp.Speak(DateTime.Now.ToLongDateString());
            }
            else if (button1.Text == "Command")
            {
                string show = "Command\n " + " hello\n" + "how are you\n " + "music\n " + "stop music\n " + "relax\n" + "time\n" + "date\n" + "exit\n";
                label2.Text = show;
                sp.Speak(show);
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            sp.Speak("calculator is opening");
            label1.Text = "calculator is opening";
            string path1 = @"C:\Windows\System32\calc.exe";
            if (Path.HasExtension(path1))
            {
                Process.Start(path1);
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string browserName = "*.exe";
            string a = "browserName";
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice"))
            {
                if (userChoiceKey != null)
                {
                    object progIdValue = userChoiceKey.GetValue("Progid");
                    if (progIdValue != null)
                    {
                        if (progIdValue.ToString().ToLower().Contains("chrome"))
                            a = "chrome.exe";
                        else if (progIdValue.ToString().ToLower().Contains("firefox"))
                            a = "firefox.exe";
                        else if (progIdValue.ToString().ToLower().Contains("safari"))
                            a = "safari.exe";
                        else if (progIdValue.ToString().ToLower().Contains("opera"))
                            a = "opera.exe";
                        else if (progIdValue.ToString().ToString().Contains("edge"))
                            a = "msedge.exe";
                        else if (progIdValue.ToString().ToString().Contains("explorer"))
                            a = "iexplore.exe";
                    }
                    System.Diagnostics.Process.Start(a);
                }
                sp.Speak("your explorer is opening");
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string a = "Youtube is opening";
            label1.Text = a;
            sp.Speak(a);
            Process.Start("www.youtube.com");
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(richTextBox1.Text == "hello")
            {
                string a = "Hello sir";
                sp.Speak(a);
                label1.Text = a;
            }
            if (richTextBox1.Text == "music")
            {
                string a = "Music is opening";
                label1.Text = a;
                sp.Speak(a);
                player.URL = "music1.mp3";
            }
            else if (richTextBox1.Text == "relax")
            {
                string a = "Relaxing will start";
                label1.Text = a;
                sp.Speak(a);
                player.URL = "music3.mp3";
            }
            else if (richTextBox1.Text == "stop music")
            {
                string a = "Music is stoping";
                label1.Text = a;
                sp.Speak(a);
                player.controls.stop();
            }
            else if (richTextBox1.Text == "exit")
            {
                string a = "Good bye sir";
                label1.Text = a;
                sp.Speak(a);
                Application.Exit();
            }
            else if (richTextBox1.Text == "time")
            {
                string a = DateTime.Now.ToLongTimeString();
                label1.Text = a;
                sp.Speak(a);
            }
            else if (label1.Text == "date")
            {
                string a = DateTime.Now.ToLongDateString();
                label1.Text = a;
                sp.Speak(a);
            }
            else if (richTextBox1.Text == "command")
            {
                string show = "Command\n " + " hello\n" + "how are you\n " + "music\n " + "stop music\n " + "relax\n" + "time\n" + "date\n" + "exit\n";
                label2.Text = show;
                sp.Speak(show);
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            string a = "Opera is opening";
            label1.Text = a;
            sp.Speak(a);
            Process.Start("opera.exe");
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string a = "Reddit is opening";
            label1.Text = a;
            sp.Speak(a);
            Process.Start("https://www.reddit.com/");
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            string a = "Safari is opening";
            label1.Text = a;
            sp.Speak(a);
            Process.Start("safari.exe");
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            string a = "Whatsapp is opening";
            label1.Text = a;
            sp.Speak(a);
            Process.Start("https://web.whatsapp.com/");
        }
        private void toolStripButton10_Click_1(object sender, EventArgs e)
        {
            string a = "Discord is opening";
            sp.Speak(a);
            label1.Text = a;
            var appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appdatapath = Directory.GetParent(appdatapath).FullName;
            var DiscordPath = Path.Combine(appdatapath, "Local", "Discord");
            string[] dirs = Directory.GetDirectories(DiscordPath, "app-*", SearchOption.TopDirectoryOnly);
            var actualDiscordPath = dirs.FirstOrDefault();
            if (actualDiscordPath == null)
            {
                return;
            }
            Process.Start(actualDiscordPath + Path.DirectorySeparatorChar + "Discord.exe");
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            string pathvar = @"C:\Users\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Spotify.Ink";
            System.Environment.SetEnvironmentVariable("PATH", pathvar + @"C:\Users\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Spotify.Ink");
            Process.Start(@"C:\Users\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Spotify.Ink");
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            string a = "Edge is opening";
            sp.Speak(a);
            label2.Text = a;
            Process.Start("msedge.exe");
        }
        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            string a = "Internet Explorer is opening";
            label1.Text = a;
            sp.Speak(a);
            Process.Start("iexplorer.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://" + richTextBox3.Text + ".com");
        }
    }
}

