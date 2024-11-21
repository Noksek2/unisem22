using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinForms
{
    public partial class Form1 : Form
    {
        bool isSave = false;
        public Form1()
        {
            InitializeComponent();

            //fontDialog1 = new FontDialog();
            fontDialog1.ShowColor = true;
            //saveFileDialog1.Filter=
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|CSV Files|*.csv";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "저장 안 함";
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wouldYouSave(sender, e))
            {
                this.Dispose(true);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
                textBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Statuslabel1.Text = DateTime.Now.ToString();
        }

        private void 만든놈ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var info = new InfoForm();
            info.ShowDialog();
        }


        private void JustSaveFile()
        {
            StreamWriter writer = new StreamWriter(this.Text);
            writer.Write(textBox1.Text);
            writer.Close();
            isSave = true;
        }
        bool saveAsFile()
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;

                this.Text = filename;
                JustSaveFile();
                return true;
            }
            return false;
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = this.Text;
            if (isSave) return;
            if (this.Text == "저장 안 함")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                JustSaveFile();
            }
        }
        private bool wouldYouSave(object sender, EventArgs e)
        {
            if (isSave) return true;
            else if (this.Text == "저장 안 함" && textBox1.Text == "") return true;

            var res = MessageBox.Show("저장안됐는데 할거임?", "??", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            {
                return saveAsFile();
            }
            else if (res == DialogResult.Cancel) return false;
            return true;
        }
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wouldYouSave(sender, e))
            {
                textBox1.Text = "";
                this.Text = "저장 안 함";
                isSave = false;
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wouldYouSave(sender, e))
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Stream strm = openFileDialog1.OpenFile();
                    StreamReader reader = new StreamReader(strm);
                    textBox1.Text = reader.ReadToEnd();
                    reader.Close();
                    strm.Close();
                    isSave = true;
                    this.Text = openFileDialog1.FileName;
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isSave = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            quitToolStripMenuItem_Click(sender, e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode) {
                    case Keys.S:
                        saveToolStripMenuItem_Click(sender,e);
                        break;
                    case Keys.N:
                        newFileToolStripMenuItem_Click(sender, e);
                        break;
                        case Keys.O:
                        openToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.F:
                        fontToolStripMenuItem_Click(sender, e);
                        break;
                }

                
            }
        }
    }
}