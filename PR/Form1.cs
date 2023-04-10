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
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenDlg.Dispose();
        }

        private void ListBRasd1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < ListBRasd2.Items.Count; i++)
                {
                    Writer.WriteLine((string)ListBRasd2.Items[i]);
                }
                Writer.Close();
            }
            SaveDlg.Dispose();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информация о приложении и разработчике");
        }

        private void BtStart1_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            ListBRasd1.Items.Clear();
            ListBRasd2.Items.Clear();
            ListBRasd1.BeginUpdate();
            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in Strings)
            {
                string Str = s.Trim();
                if (Str == String.Empty) continue;
                if (RaBtAll.Checked) ListBRasd1.Items.Add(Str);
                if (RaBtNumeral.Checked)
                    if (SaveDlg.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                        for (int i = 0; i < ListBRasd2.Items.Count; i++)
                        {
                            Writer.WriteLine((string)ListBRasd2.Items[i]);
                        }
                        Writer.Close();
                    }
                SaveDlg.Dispose();

            }
        }

        private void BtEnd1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtSbros1_Click(object sender, EventArgs e)
        {
            ListBRasd1.Items.Clear();
            ListBRasd2.Items.Clear();
            richTextBox1.Clear();
            TxBx1.Clear();
        }

        private void BtSearch1_Click(object sender, EventArgs e)
        {
            ListB3.Items.Clear();
            string Find = TxBx1.Text;
            if (ChBxRasd1.Checked)
            {
                foreach (string String in ListBRasd1.Items)
                {
                    if (String.Contains(Find)) ListB3.Items.Add(String);
                }
            }

            if (ChBxRasd1.Checked)
            {
                foreach (string String in ListBRasd1.Items)
                {
                    if (String.Contains(Find)) ListB3.Items.Add(String);
                }
            }
            if (ChBxRasd2.Checked)
            {
                foreach (string String in ListBRasd2.Items)
                {
                    if (String.Contains(Find)) ListB3.Items.Add(String);
                }
            }

        }

        private void BtCreate1_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();
            AddRec.Owner = this;
            AddRec.ShowDialog();
        }

        private void BtDelete1_Click(object sender, EventArgs e)
        {
            for (int i = ListBRasd1.Items.Count - 1; i >= 0; i--)
            {
                if (ListBRasd1.GetSelected(i)) ListBRasd1.Items.RemoveAt(i);
            }
            for (int i = ListBRasd2.Items.Count - 1; i >= 0; i--)
            {
                if (ListBRasd2.GetSelected(i)) ListBRasd2.Items.RemoveAt(i);
            }
        }

        private void Bt1Rigth_Click(object sender, EventArgs e)
        {
            ListBRasd2.BeginUpdate();
            foreach (object Item in ListBRasd1.SelectedItems)
            {
                ListBRasd2.Items.Add(Item);
            }
            ListBRasd2.EndUpdate();
        }

        private void Bt1left_Click(object sender, EventArgs e)
        {
            ListBRasd1.BeginUpdate();
            foreach (object Item in ListBRasd2.SelectedItems)
            {
                ListBRasd1.Items.Add(Item);
            }
            ListBRasd1.EndUpdate();
        }

        private void Bt2Rigth_Click(object sender, EventArgs e)
        {
            ListBRasd2.Items.AddRange(ListBRasd1.Items);
            ListBRasd1.Items.Clear();

        }

        private void Bt2left_Click(object sender, EventArgs e)
        {
            ListBRasd1.Items.AddRange(ListBRasd2.Items);
            ListBRasd2.Items.Clear();
        }

        private void comBxRasd1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            }

        private void BtclearRasd1_Click(object sender, EventArgs e)
        {
            ListBRasd1.Items.Clear();
        }

        private void BtclearRasd2_Click(object sender, EventArgs e)
        {
            ListBRasd2.Items.Clear();
        }

        private void btCortRasd1_Click(object sender, EventArgs e)
        {
            List<string> list1 = new List<string>();
            {
                foreach (var item1 in ListBRasd1.Items)
            {
                list1.Add(item1.ToString());
            }
            };

            if (comBxRasd1.SelectedIndex == 0)
            {
                ListBRasd1.BeginUpdate();
                ListBRasd1.Sorted = true;
                ListBRasd1.Sorted = false;
                ListBRasd1.EndUpdate();
            }
            if (comBxRasd1.SelectedIndex == 1)
            {
                ListBRasd1.BeginUpdate();
                list1.Sort();
                list1.Reverse();
                ListBRasd1.Items.Clear();
                foreach (var item in list1)
                {
                    ListBRasd1.Items.Add(item);
                }
                ListBRasd1.EndUpdate();
            }
            if (comBxRasd1.SelectedIndex == 2)
            {
                string[] array1 = new string[list1.Count];
                ListBRasd1.BeginUpdate();
                int i = list1.Count;
                int j = i;
                for (i = 0; i < list1.Count; i++)
                {
                    array1[i] = list1[i];
                }
                for (i = 0; i < list1.Count; i++)
                {
                    for (j = 0; j < list1.Count ; j++)
                    {
                        if (array1[i].Length > array1[j].Length)
                        {
                            string swap = array1[i];
                            array1[i] = array1[j];
                            array1[j] = swap;
                        }
                    }
                }
                ListBRasd1.Items.Clear ();
                foreach (var item in array1)
                {
                    ListBRasd1.Items.Add(item);
                }

                int[] array2 = new int[list1.Count];
                
                for (int k = 0; k < list1.Count; k++)
                {
                    array2[k]=ListBRasd1.Items.IndexOf(list1[k]);
                }
                ListBRasd1.EndUpdate();
            }
            if (comBxRasd1.SelectedIndex == 3)
            {
                string[] array1 = new string[list1.Count];
                ListBRasd1.BeginUpdate();
                int i = list1.Count;
                int j = i;
                for (i = 0; i < list1.Count; i++)
                {
                    array1[i] = list1[i];
                }
                for (i = 0; i < list1.Count; i++)
                {
                    for (j = 0; j < list1.Count; j++)
                    {
                        if (array1[i].Length < array1[j].Length)
                        {
                            string swap = array1[i];
                            array1[i] = array1[j];
                            array1[j] = swap;
                        }
                    }
                }
                ListBRasd1.Items.Clear();
                foreach (var item in array1)
                {
                    ListBRasd1.Items.Add(item);
                }

                int[] array2 = new int[list1.Count];

                for (int k = 0; k < list1.Count; k++)
                {
                    array2[k] = ListBRasd1.Items.IndexOf(list1[k]);
                }
                ListBRasd1.EndUpdate();
            }
        }

        private void btCortRasd2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }

    }
