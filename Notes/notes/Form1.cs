using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace notes
{
    public partial class Form1 : Form
    {
        static Dictionary<string, Note> notes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes = GetData();
            comboBoxHeading.SelectedIndex = 0;
            //richTextBoxNotes.AppendText(comboBoxHeading.Text);
        }

        private Dictionary<string, Note> GetData()
        {
            Dictionary<string, Note> data = new Dictionary<string, Note>();
            //using (StreamReader rdr = new StreamReader(@"\\sit.inet\sit\home\Students\2014002528\Downloads\LearnC#.txt"))
            //using (StreamReader rdr = new StreamReader(@"E:\LearnC#.txt"))
            using (StreamReader rdr = new StreamReader(@"LearnC#.txt"))
            {
                while (!rdr.EndOfStream)
                {
                    string line = rdr.ReadLine();
                    string[] parts = line.Split(' ');
                    string head = parts[0];
                    comboBoxHeading.Items.Add(head);
                    string content = "";
                    List<string> code = new List<string>();
                    while (line != "..............")
                    {
                        if (line == "-----------------")
                        {
                            line = rdr.ReadLine();
                            code.Add(line);
                        }
                        content += line;
                        line = rdr.ReadLine();
                    }
                    Note note = new Note(head, content);
                    data.Add(head, note);
                    foreach(string c in code)
                    {
                        note.code.Add(c);
                    }
                }
                rdr.Close();
            }
            return data;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            Note note = notes[comboBoxHeading.Text];
            richTextBoxNotes.Text = note.Content();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
