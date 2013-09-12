using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace CC_Helper
{
    public partial class Form1 : Form
    {
        private string dataPath = "";
        private string destinationPath = "";
        private bool isLoading = true;
        private long minecraftHandle;

        private class Comp
        {
            public int id {get;set;}
            public string name{get;set;}
            public string value
            {
                get
                {
                    var str = new StringBuilder(this.id.ToString());
                    if(!string.IsNullOrEmpty(this.name)) str.Append(string.Concat(" - ", this.name));
                    return str.ToString();
                }
            }
        }
        private List<string> selectedFiles = new List<string>();

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_RESTORE = 9;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private bool FocusProcess(string procName)
        {
            Process[] objProcesses = System.Diagnostics.Process.GetProcessesByName("javaw").Where(x => x.MainWindowTitle == procName).ToArray(); if (objProcesses.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = objProcesses[0].MainWindowHandle;
                ShowWindowAsync(new HandleRef(null, hWnd), SW_SHOWMAXIMIZED);
                SetForegroundWindow(objProcesses[0].MainWindowHandle);
                return true;
            }
            return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void SourceBrowse_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = this.Source.Text;
            this.folderBrowserDialog.ShowDialog();
            this.Source.Text = this.folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Source = this.Source.Text;
            Properties.Settings.Default.Save();
            this.ListDirectory(this.Source.Text);
        }

        private void DestinationBrowse_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = this.Destination.Text;
            this.folderBrowserDialog.ShowDialog();
            this.Destination.Text = this.folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Destination = this.Destination.Text;
            Properties.Settings.Default.Save();
        }

        private void ListDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                this.Directories.Nodes.Clear();
                var rootDirectoryInfo = new DirectoryInfo(path);
                this.Directories.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
            }
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                if(!directory.Name.StartsWith(".")) directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            return directoryNode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = string.Concat("CC-Helper   (v", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version,")");
            this.ExitOnCopy.Checked = Properties.Settings.Default.ExitOnCopy;
            this.Source.Text = Properties.Settings.Default.Source;
            this.Destination.Text = Properties.Settings.Default.Destination;
            if (string.IsNullOrEmpty(this.Destination.Text))
                this.Destination.Text = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    ".minecraft");
            this.ListDirectory(this.Source.Text);
            this.Minecraft.Text = Properties.Settings.Default.Minecraft;
            this.RunOnEntry.Text = Properties.Settings.Default.RunOnEntry;
            var w = Properties.Settings.Default.World;
            this.Worlds.SelectedIndex = this.Worlds.FindString(w);
            var c = Properties.Settings.Default.Comp;
            this.Comps.SelectedIndex = this.Comps.FindString(c.ToString());
            this.isLoading = false;
        }

        private void Directories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Directories.PathSeparator = @"\";
            var source = new DirectoryInfo(this.Source.Text);
            this.LoadFiles(Path.Combine(source.Parent.FullName, this.Directories.SelectedNode.FullPath));
        }

        private void LoadFiles(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                this.dataPath = Path.Combine(path, "data.cch");
                this.selectedFiles.Clear();
                if (File.Exists(this.dataPath))
                    this.selectedFiles = new List<string>(File.ReadAllLines(this.dataPath));
                this.Files.Items.Clear();
                var info = new DirectoryInfo(path);
                foreach (var file in info.GetFiles())
                {
                    if (!file.Name.StartsWith(".") && file.Name != "data.cch")
                        this.Files.Items.Add(file.Name, this.selectedFiles.Any(x => x == file.Name));
                }
            }
        }

        private void Files_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Files.GetItemChecked(this.Files.SelectedIndex))
            {
                if (!this.selectedFiles.Any(x => x == this.Files.SelectedItem.ToString()))
                    this.selectedFiles.Add(this.Files.SelectedItem.ToString());
            }
            else this.selectedFiles.Remove(this.Files.SelectedItem.ToString());
            File.WriteAllLines(this.dataPath, this.selectedFiles.ToArray());
        }

        private void CopyDirectory(DirectoryInfo source)
        {
            var datafile = Path.Combine(source.FullName, "data.cch");
            if (File.Exists(datafile))
            {
                var list = File.ReadAllLines(datafile);
                foreach (var file in list)
                {                    
                    var sourceFile = Path.Combine(source.FullName, file);
                    var subPath = source.FullName.Remove(0, this.Source.Text.Length);
                    if (subPath.StartsWith(@"\"))
                        subPath = subPath.Remove(0, 1);
                    var destPath = Path.Combine(this.destinationPath, subPath);
                    
                    var destFile = Path.Combine(destPath, Path.GetFileNameWithoutExtension(file));
                    if (!Directory.Exists(destPath))
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    var contents = File.ReadAllText(sourceFile);
                    File.WriteAllText(destFile, contents);
                }
            }
            foreach (var directory in source.GetDirectories().Where(x => !x.Name.StartsWith(".")))
            {
                CopyDirectory(directory);
            }
        }


        private void Copy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Source.Text) || string.IsNullOrEmpty(this.destinationPath))
            {
                MessageBox.Show("Source and Destination must be set");
                return;
            }
            CopyDirectory(new DirectoryInfo(this.Source.Text));
            if (this.Minecraft.Text != "" && this.FocusProcess(this.Minecraft.Text) && !string.IsNullOrEmpty(this.RunOnEntry.Text))
            {
                // Sometimes Minecraft doesn't respond until a mouse_click event
                Thread.Sleep(200);
                this.DoMouseClick();
                Thread.Sleep(50);
                // SendKeys giving duplicate keystrokes
                var wsh = new IWshRuntimeLibrary.WshShell();
                wsh.SendKeys(string.Concat(this.RunOnEntry.Text, "{ENTER}"));
            }
                
            if (this.ExitOnCopy.Checked)
            {
                this.Close();
            }
        }

        private void Minecraft_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Minecraft = this.Minecraft.Text;
            Properties.Settings.Default.Save();
        }

        private void ExitOnCopy_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ExitOnCopy = this.ExitOnCopy.Checked;
            Properties.Settings.Default.Save();
        }

        private void RunOnEntry_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RunOnEntry = this.RunOnEntry.Text;
            Properties.Settings.Default.Save();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Source_Enter(object sender, EventArgs e)
        {
            this.SourceBrowse.Focus();
        }

        private void Destination_Enter(object sender, EventArgs e)
        {
            this.DestinationBrowse.Focus();
        }

        private void Destination_TextChanged(object sender, EventArgs e)
        {
            this.UpdateWorlds();
        }

        private void UpdateWorlds()
        {
            this.Worlds.Items.Clear();
            var savesDir = Path.Combine(Destination.Text, "saves");
            if (Directory.Exists(savesDir))
            {
                var info = new DirectoryInfo(savesDir);
                this.Worlds.Items.AddRange(info.GetDirectories().Select(x => x.Name).ToArray());
                if (this.Worlds.Items.Count > 0)
                {
                    this.Worlds.Enabled = true;
                    this.Worlds.SelectedIndex = 0;
                }
                else
                {
                    this.Worlds.Enabled = false;
                    this.Worlds.Items.Add("<None found>");
                    this.Worlds.SelectedIndex = 0;
                }                
            }
            else
            {
                this.Worlds.Enabled = false;
                this.Comps.Enabled = false;
            }

        }
        private void Worlds_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Comps.Enabled = false;
            this.Comps.DataSource = null;
            if (Worlds.SelectedItem.ToString() != "")
            {
                var compsDir = Path.Combine(Destination.Text, "saves", Worlds.SelectedItem.ToString(), "computer");
                if (Directory.Exists(compsDir))
                {
                    var info = new DirectoryInfo(compsDir);
                    this.Comps.DataSource = null;
                    this.Comps.Items.Clear();
                    var namedComps = new Dictionary<int, string>();
                    var lines = System.IO.File.ReadAllLines(Path.Combine(compsDir, "labels.txt"));
                    foreach (var line in lines)
                    {
                        var m = System.Text.RegularExpressions.Regex.Match(line, @"^(?<id>[0-9]+) (?<name>[^\n]+)");
                        while (m.Success)
                        {
                            Console.WriteLine(string.Format("{0} - {1}", m.Groups["id"].Value, m.Groups["name"].Value));
                            namedComps.Add(Convert.ToInt32(m.Groups["id"].Value), m.Groups["name"].Value);
                            m = m.NextMatch();
                        }
                    }
                    var comps = new List<Comp>();
                    foreach (var directory in info.GetDirectories().Select(x => x.Name))
                    {
                        int id = 0;
                        if (int.TryParse(directory, out id))
                        {
                            var comp = new Comp();
                            comp.id = id;
                            if (namedComps.ContainsKey(id)) comp.name = namedComps[id];
                            comps.Add(comp);
                        }
                    }

                    this.Comps.DataSource = comps.OrderBy(x => x.id).ToList(); ;
                    this.Comps.DisplayMember = "value";
                    this.Comps.ValueMember = "id";
                    this.Comps.Enabled = true;
                }
                else
                {
                    this.Comps.Items.Add("<None found>");
                }
            }
            this.Comps.SelectedIndex = 0;
            if (!this.isLoading)
            {
                Properties.Settings.Default.World = this.Worlds.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
            this.UpdateCopy();
        }

        private void Comps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoading)
            {
                if (this.Comps.Enabled)
                    Properties.Settings.Default.Comp = (int)Comps.SelectedValue;
                else
                    Properties.Settings.Default.Comp = -1;
                
                Properties.Settings.Default.Save();
            }
            this.UpdateCopy();
        }

        private void UpdateCopy()
        {
            this.destinationPath = "";
            if (this.Worlds.SelectedIndex >= 0 && this.Comps.SelectedIndex >= 0 && this.Comps.Enabled && Directory.Exists(this.Source.Text))
            {
                var dir = Path.Combine(this.Destination.Text, "saves", this.Worlds.SelectedItem.ToString(), "computer", this.Comps.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(this.Comps.SelectedItem.ToString()) && Directory.Exists(dir))
                {
                    this.destinationPath = dir;
                    this.Copy.Enabled = true;
                    this.Open.Enabled = true;
                    return;
                }
            }
            this.Copy.Enabled = false;
            this.Open.Enabled = false;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.destinationPath))
            {
                System.Diagnostics.Process.Start(this.destinationPath);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
