//Resharp Used On - Monday, March 27, 2023 9:40:31 PM
//Filename:C:\Users\kelp\Documents\projects\GamePatcher\XboxGamePatcher\Form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tommy;

namespace XboxGamePatcher
{
    public partial class  Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 161;
        public const int HT_CAPTION = 2;
        XboxConsole Xbox = new XboxConsole();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1() => InitializeComponent();

        private void button1_Click(object sender, EventArgs e)
        {
            if (!new XboxConsole().Connect(textBox1.Text))
                return;
            MessageBox.Show("Xbox Game Patching Tool Connected!");
        }

        private void LoadPatch(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            TomlPatch.PokeType = new List<string>();
            using (StreamReader streamReader = File.OpenText(openFileDialog.FileName))
            {
                foreach (TomlNode MainNode in ((TomlNode)TOML.Parse(streamReader))["patch"])
                    CreateControl(MainNode);
            }
        }

        private void CreateControl(TomlNode MainNode)
        {
            TomlPatch tomlPatch = new TomlPatch(MainNode.AsTable.RawTable["name"].ToString(), MainNode.AsTable.RawTable["author"].ToString(), bool.Parse(MainNode.AsTable.RawTable["is_enabled"].ToString()), BeNode(MainNode));
            tomlPatch.Location = new Point((panel1.Width - tomlPatch.Width) / 2, panel1.Controls.Count * 40);
            panel1.Controls.Add(tomlPatch);
        }

        private static List<string> BeNode(TomlNode MainNode)
        {
            Dictionary<string, TomlNode> rawTable = MainNode.AsTable.RawTable;
            rawTable.Remove("name");
            rawTable.Remove("desc");
            rawTable.Remove("author");
            rawTable.Remove("is_enabled");
            TomlNode tomlNode = rawTable.Values.ToArray();
            TomlPatch.PokeType = new List<string>(rawTable.Keys.ToArray());
            List<string> stringList = new List<string>();
            for (int index = 0; index < rawTable.Values.Count; ++index)
            {
                stringList.Add(tomlNode.AsArray[index]);
            }

            return stringList;
        }

        private void button4_Click(object sender, EventArgs e) => Close();

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            ReleaseCapture();
            SendMessage(Handle, 161, 2, 0);
        }


    }
}
