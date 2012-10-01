using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NsShell
{
     public partial class exePathSetter : Form
     {
          public exePathSetter()
          {
               InitializeComponent();
               LoadSavedFile();
          }

          private void LoadSavedFile()
          {
               string pathFull = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\ShellExeFileLocations.nss";
               if (!File.Exists(pathFull))
                    return;
               using (StreamReader sr = new StreamReader(pathFull))
               {
                    LayoutExeFullPath = sr.ReadLine();
                    LayoutIniFullPath = sr.ReadLine();
                    NhtgenExeFullPath = sr.ReadLine();
                    NsfgExeFullPath = sr.ReadLine();
                    LayoutSectionalExeFullPath = sr.ReadLine();
                    LayoutSectionalIniFullPath = sr.ReadLine();
               }

          }

          private void SaveSettingsToFile()
          {
               string pathFull = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\ShellExeFileLocations.nss";
               using (StreamWriter swr = new StreamWriter(pathFull))
               {
                    if (layoutexepath != null)
                         swr.WriteLine(LayoutExeFullPath);
                    if (layoutinipath != null)
                         swr.WriteLine(LayoutIniFullPath);
                    if (nhtgenexepath != null)
                         swr.WriteLine(NhtgenExeFullPath);
                    if (nsfgexepath != null)
                         swr.WriteLine(NsfgExeFullPath);
                    if (layoutSectexepath != null)
                         swr.WriteLine(layoutSectexepath);
                    if (layoutSectinipath != null)
                         swr.WriteLine(layoutSectinipath);
               }
          }

          string layoutexepath = null;
          string layoutinipath = null;
          string layoutSectexepath = null;
          string layoutSectinipath = null;
          string nsfgexepath = null;
          string nhtgenexepath = null;

          public string LayoutExeFullPath
          {
               get { return layoutexepath; }
               set
               {
                    if (value == null)
                         return;
                    LayoutExeTextBox.Text = value;
                    LayoutExeTextBox.ScrollToCaret();
                    if (value.ToLower().Contains("3dlayout.exe"))
                    {
                         layoutExeFoundPic.Image = NsShell.Properties.Resources.green_thumbs_up;
                         layoutexepath = value;
                    }
                    else
                         layoutExeFoundPic.Image = NsShell.Properties.Resources.thumbs_down;
               }
          }

          public string LayoutSectionalExeFullPath
          {
               get { return layoutSectexepath; }
               set
               {
                    if (value == null)
                         return;
                    LayoutSectExeTextBox.Text = value;
                    LayoutSectExeTextBox.ScrollToCaret();
                    if (value.ToLower().Contains("3dlayout.exe"))
                    {
                         layoutSectExeFoundPic.Image = NsShell.Properties.Resources.green_thumbs_up;
                         layoutSectexepath = value;
                    }
                    else
                         layoutSectExeFoundPic.Image = NsShell.Properties.Resources.thumbs_down;
               }
          }

          public string LayoutIniFullPath
          {
               get { return layoutinipath; }
               set
               {
                    if (value == null)
                         return;
                    LayoutINITextbox.Text = value;
                    LayoutINITextbox.ScrollToCaret();
                    if (value.ToLower().Contains("3dlayout.ini"))
                    {
                         layoutINIFoundPic.Image = NsShell.Properties.Resources.green_thumbs_up;
                         layoutinipath = value;
                    }else
                         layoutINIFoundPic.Image = NsShell.Properties.Resources.thumbs_down;
               }
          }

          public string LayoutSectionalIniFullPath
          {
               get { return layoutSectinipath; }
               set
               {
                    if (value == null)
                         return;
                    LayoutSectINITextbox.Text = value;
                    LayoutSectINITextbox.ScrollToCaret();
                    if (value.ToLower().Contains("3dlayout.ini"))
                    {
                         layoutSectINIFoundPic.Image = NsShell.Properties.Resources.green_thumbs_up;
                         layoutSectinipath = value;
                    }
                    else
                         layoutSectINIFoundPic.Image = NsShell.Properties.Resources.thumbs_down;
               }
          }

          public string NhtgenExeFullPath
          {
               get { return nhtgenexepath; }
               set
               {
                    if (value == null)
                         return;
                    NHTTextbox.Text = value;
                    NHTTextbox.ScrollToCaret();
                    if (value.ToLower().Contains("nhtgen.exe"))
                    {
                         NHTFoundPic.Image = NsShell.Properties.Resources.green_thumbs_up;
                         nhtgenexepath = value;
                    }else
                         NHTFoundPic.Image = NsShell.Properties.Resources.thumbs_down;
               }
          }

          public string NsfgExeFullPath
          {
               get { return nsfgexepath; }
               set 
               {
                    if (value == null)
                         return;
                    NSFGTextbox.Text = value;
                    NSFGTextbox.ScrollToCaret();
                    if (value.ToLower().Contains("nsfilegenerator.exe"))
                    {
                         NSFGFoundPic.Image = NsShell.Properties.Resources.green_thumbs_up;
                         nsfgexepath = value;
                    }else
                         NSFGFoundPic.Image = NsShell.Properties.Resources.thumbs_down;
               }
          }

          public bool AllFilesFound
          {
               get
               {
                    return (layoutexepath != null) && (layoutinipath != null) && (nhtgenexepath != null) && (nsfgexepath != null) && (layoutSectexepath != null) && (layoutSectinipath != null);
               }
          }

          public List<string> MissingPaths
          {
               get
               {
                    List<string> ret = new List<string>();
                    if (layoutexepath == null)
                         ret.Add("Layout Exe");
                    if (layoutinipath == null)
                         ret.Add("Layout Ini");
                    if (layoutSectinipath == null)
                         ret.Add("Sectional Layout Ini");
                    if (layoutSectinipath == null)
                         ret.Add("Sectional Layout Ini");
                    if (nhtgenexepath == null)
                         ret.Add("NHT Gen Exe");
                    if (nsfgexepath == null)
                         ret.Add("NSFG Exe");

                    return ret;
               }
          }

          private void layoutexeSearchBut_Click(object sender, EventArgs e)
          {
               OpenFileDialog ofd = new OpenFileDialog();
               ofd.Filter = "exe Files (.exe)|*.exe";
               ofd.Multiselect = false;
               ofd.Title = "Select 3DLayout.exe";
               if (LayoutExeFullPath != null)
                    ofd.InitialDirectory = Path.GetDirectoryName(LayoutExeFullPath);
               if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    LayoutExeFullPath = ofd.FileName;
          }

          private void layoutSectExeButton_Click(object sender, EventArgs e)
          {
               OpenFileDialog ofd = new OpenFileDialog();
               ofd.Filter = "exe Files (.exe)|*.exe";
               ofd.Multiselect = false;
               ofd.Title = "Select 3DLayout.exe";
               if (LayoutExeFullPath != null)
                    ofd.InitialDirectory = Path.GetDirectoryName(LayoutExeFullPath);
               if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    LayoutSectionalExeFullPath = ofd.FileName;
          }

          private void layoutIniSearchBut_Click(object sender, EventArgs e)
          {
               OpenFileDialog ofd = new OpenFileDialog();
               ofd.Filter = "ini Files (.ini)|*.ini";
               ofd.Multiselect = false;
               ofd.Title = "Select 3DLayout.ini file...";
               if (LayoutIniFullPath != null)
                    ofd.InitialDirectory = Path.GetDirectoryName(LayoutIniFullPath);
               if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    LayoutIniFullPath = ofd.FileName;
          }

          private void layoutSecIniButton_Click(object sender, EventArgs e)
          {
               OpenFileDialog ofd = new OpenFileDialog();
               ofd.Filter = "ini Files (.ini)|*.ini";
               ofd.Multiselect = false;
               ofd.Title = "Select 3DLayout.ini";
               if (LayoutIniFullPath != null)
                    ofd.InitialDirectory = Path.GetDirectoryName(LayoutIniFullPath);
               if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    LayoutSectionalIniFullPath = ofd.FileName;
          }

          private void NSFGSearchBut_Click(object sender, EventArgs e)
          {
               OpenFileDialog ofd = new OpenFileDialog();
               ofd.Filter = "exe Files (.exe)|*.exe";
               ofd.Multiselect = false;
               ofd.Title = "Select NSFileGenerator.exe";
               if (NsfgExeFullPath != null)
                    ofd.InitialDirectory = Path.GetDirectoryName(NsfgExeFullPath);
               if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    NsfgExeFullPath = ofd.FileName;
          }

          private void NHTSearchBut_Click(object sender, EventArgs e)
          {
               OpenFileDialog ofd = new OpenFileDialog();
               ofd.Filter = "exe Files (.exe)|*.exe";
               ofd.Multiselect = false;
               ofd.Title = "Select NHTGen.exe file...";
               if (NhtgenExeFullPath != null)
                    ofd.InitialDirectory = Path.GetDirectoryName(NhtgenExeFullPath);
               if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    NhtgenExeFullPath = ofd.FileName;
          }

          private void exePathSetter_FormClosing(object sender, FormClosingEventArgs e)
          {
               e.Cancel = true;
               Hide();
          }

          private void button2_Click(object sender, EventArgs e)
          {
               SaveSettingsToFile();
               Hide();
          }

          private void button1_Click(object sender, EventArgs e)
          {
               Hide();
          }

          

          

     }
}
