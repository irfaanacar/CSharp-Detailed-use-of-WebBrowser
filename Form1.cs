using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //GEÇMİŞ İÇİN 

namespace WebBrowserDetayli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate("www.google.com");
        }

        private void yahooToolStripMenuItem_Click(object sender, EventArgs e)
        {

            webBrowser2.Navigate("www.yahoo.com");
        }

        private void yandexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate("www.yandex.com");

        }

        private void microsoftBingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate("https://www.bing.com");
        }

        private void duckDuckGoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate("https://duckduckgo.com");
        }

        private void kızılToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Crimson;
        }

        private void maviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DodgerBlue;
        }

        private void sarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor= Color.LightYellow;
        }

        private void yeşilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkSeaGreen;
        }

        private void morToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
        }

        private void griToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DimGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate(textBox1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongDateString();
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser2.GoBack();//GERİ WEB SAYFASI
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser2.GoForward();//İLERİ WEB SAYFASI
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser2.Refresh();//YENİLER
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox2.Text = webBrowser2.Url.ToString();
            string zaman=DateTime.Now.Day+"."+DateTime.Now.Month+"."+DateTime.Now.Year;
            string zaman2=DateTime.Now.Hour+":"+DateTime.Now.Minute+":"+DateTime.Now.Second;

            FileStream f = new FileStream("gecmis.txt",FileMode.Append); //File mode.append içerisine dosya eklenebilir demektir.
            StreamWriter yaz = new StreamWriter(f);
            yaz.WriteLine(zaman+"/"+zaman2+"/"+webBrowser2.Url);
            yaz.Close();
            gecmisiyukle();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gecmisiyukle();
        }
        private void gecmisiyukle()
        {
            listBox1.Items.Clear();
            StreamReader dosya = new StreamReader("gecmis.txt"); //DEBUG ADLI KLASÖRDE GEÇMİŞ ADLI METİN BELGESİNE KAYDEDECEK.
            while (!dosya.EndOfStream)//dosya açılıp okuma süresi bitene kadar 
            {
                listBox1.Items.Add(dosya.ReadLine());
            }
            dosya.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StreamWriter dosya = new StreamWriter("gecmis.txt");
            dosya.Write("");//Dosyayı temizlemiş oldum.
            dosya.Close();
            gecmisiyukle();
        }
    }
}
