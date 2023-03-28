//Resharp Used On - Monday, March 27, 2023 9:40:31 PM

//Filename:C:\Users\kelp\Documents\projects\GamePatcher\XboxGamePatcher\TomlPatch.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace XboxGamePatcher
{
    public partial class TomlPatch : UserControl
    {
        private GroupBox groupBox1;


        public static List<string> PokeRegion { get; set; }

        public static List<string> PokeType { get; set; }

        public TomlPatch(string PatchName, string Authors, bool isOn, List<string> PokeData)
        {
            InitializeComponent();
            StoreData(PatchName, Authors, isOn, PokeData);
            foreach (Control control in (ArrangedElementCollection)Controls)
                control.ContextMenuStrip = contextMenuStrip1;
        }

        private void StoreData(string PatchName, string Authors, bool isOn, List<string> PokeData)
        {
            groupBox1.Text = PatchName + " By " + Authors;
            IsEnabled.Checked = isOn;
            PokeRegion = PokeData;
            IsEnabled.Text = isOn ? "Enabled" : "Disabled";
        }

        private void PokeButton(object sender, EventArgs e)
        {
            if (IsEnabled.Checked && XboxConsole.Connected)
            {
                if (PokeRegion.Count > 1)
                {
                    for (int i = 0; i < PokeRegion.Count; ++i)
                        Poke(i);
                }
                else
                    Poke();
            }
            else
            {
                MessageBox.Show("Console Is not Connect or Patch is not Enabled");
            }
        }

        private void Poke(int i = 0)
        {
            string[] strArray = PokeRegion[i].Split(',');
            uint Address = Convert.ToUInt32(strArray[0].Substring(strArray[0].IndexOf("=") + 4), 16);
            string Value = strArray[1].Substring(strArray[1].IndexOf("=") + 4).Replace(" } ]", "");
            BitConverter.GetBytes(Convert.ToUInt32(Value, 16)).Reverse().ToArray<byte>();
            byte[] bytes = BitConverter.GetBytes(uint.Parse(Value, NumberStyles.HexNumber));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            switch (PokeType[i])
            {
                case "f64":
                    new XboxConsole().WriteFloat(Address, float.Parse(Value));
                    break;
                case "string":
                    new XboxConsole().SetMemory(Address, Encoding.UTF8.GetBytes(Value));
                    break;
                case "be8":
                    new XboxConsole().WriteByte(Address, byte.Parse(Value));
                    break;
                case "be16"://2 bytes
                    new XboxConsole().SetMemory(Address, bytes);
                    break;
                case "be64"://4 bytes
                    new XboxConsole().SetMemory(Address, bytes);
                    break;
                case "u16string":
                    new XboxConsole().SetMemory(Address, Encoding.Unicode.GetBytes(Value));
                    break;
                case "f32":
                    new XboxConsole().WriteFloat(Address, float.Parse(Value));
                    break;
                case "array":
                    new XboxConsole().SetMemory(Address, bytes);
                    break;
                case "be32":
                    new XboxConsole().SetMemory(Address, bytes);
                    break;
            }
        }

        private void IsEnabled_CheckedChanged(object sender, EventArgs e) => IsEnabled.Text = IsEnabled.Checked ? "Enabled" : "Disabled";

    }
}
