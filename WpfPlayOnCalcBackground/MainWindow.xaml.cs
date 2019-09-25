using System.Windows;
using System.Media;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfPlayOnCalcBackground
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MediaPlayer me;
        bool JustPlaying;
        public MainWindow()
        {
            InitializeComponent();
            me = new MediaPlayer();
            me.MediaEnded += (s, e) => { JustPlaying = false; };
            me.MediaOpened += (s, e) => { JustPlaying = true; };
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (JustPlaying == false)
            {
                // Create a new OpenFileDialog.
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                // Make sure the dialog checks for existence of the 
                // selected file.
                dlg.CheckFileExists = true;

                // Allow selection of .wav files only.
                dlg.Filter = "Wave files (*.wav)|*.wav";
                dlg.DefaultExt = ".wav";

                // Activate the file selection dialog.
                if (dlg.ShowDialog() == true)
                {
                    // Assign the selected file's path to 
                    // the SoundPlayer object.  

                    me.Open(new System.Uri(dlg.FileName, System.UriKind.RelativeOrAbsolute));
                }
            }
            // sp.PlaySync(); // blokuje form při synchronním spuštění
            //sp.Play();
            //sp.Tag = true;
            me.Play();

            for (int i = 0; i < 200; i++)
            {
                System.Threading.Thread.Sleep(100);
                TextBlock.Text += (char)i;
                InvalidateVisual();
            }
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            //sp.Stop();
            //sp.Tag = false;
            me.Close();
            JustPlaying = false;
        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            me.Pause();
        }
    }
}

