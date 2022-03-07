using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdonisUI.Controls;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxButton = AdonisUI.Controls.MessageBoxButton;
using MessageBoxImage = AdonisUI.Controls.MessageBoxImage;

namespace TextTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string[] TextFile;
        string[] TextFiles = {};
        string path;
        string filename;

        private void btn_opentextfile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            TextFile = File.ReadAllLines(openFileDialog.FileName);
            txt_numberline.Text = "Number Of Lines: " + TextFile.Count().ToString();
            txt_selectedfile.Text = "Selected File: " + openFileDialog.SafeFileName;
            path = openFileDialog.FileName;
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            string[] TextFile_nodup = TextFile.Distinct().ToArray();
            File.WriteAllLines(path, TextFile_nodup);
            txt_numberline.Text = "Number Of Lines: " + TextFile_nodup.Count().ToString();
            MessageBox.Show("Done!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btn_selectfolder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    string[] temp = File.ReadAllLines(file);
                    TextFiles = TextFiles.Union(temp).ToArray();
                }
                foreach (String file in openFileDialog.SafeFileNames)
                {
                    filename += file + ", ";
                }

            }
            txt_selectedfiles.Text = "Selected Files: " + filename;
            txt_numberfiles.Text = "Number Of Files: " + openFileDialog.FileNames.Count().ToString();
        }

        private void btn_combine_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines(@"C:\Users\Ramin\Desktop\combined.txt", TextFiles);
            MessageBox.Show("Done!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
