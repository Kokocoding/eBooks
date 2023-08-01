using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Input;

namespace eBooks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] imageFiles = { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg" };
        private int currentImageIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            SetImageSource(imageFiles[currentImageIndex]);
        }

        private void SetImageSource(string imagePath)
        {
            string destinationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", imagePath);
            eBook.Source = new BitmapImage(new Uri(destinationPath));
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % imageFiles.Length;
            SetImageSource(imageFiles[currentImageIndex]);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex = (currentImageIndex - 1 + imageFiles.Length) % imageFiles.Length;
            if (currentImageIndex < 0) return;
            SetImageSource(imageFiles[currentImageIndex]);
        }
    }
}
