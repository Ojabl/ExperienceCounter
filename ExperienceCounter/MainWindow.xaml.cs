using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System;

namespace ExperienceCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Exp { get; set; }
        static readonly string filePath = "ExperienceCounterData.txt";

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                int result = Int32.Parse(LoadExp());
                Exp = result;
            }
            catch
            {
                Console.WriteLine("Unable to parse input!");
            }
            experienceText.Text = Exp.ToString();
        }

        /// <summary>
        /// Actions happening after clicking "+" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            Exp += 5;
            experienceText.Text = Exp.ToString();
            File.WriteAllText(filePath, Exp.ToString());
        }

        /// <summary>
        /// Actions happening after clicking "-" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            Exp -= 5;
            experienceText.Text = Exp.ToString();
            File.WriteAllText(filePath, Exp.ToString());
        }

        /// <summary>
        /// Loads experience gathered in previous sessions from file
        /// </summary>
        /// <returns>experience gathered in previous sessions</returns>
        private static string LoadExp()
        {
            string exp;

            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath)) ;
                return "0";
            }
            else
            {
                var reader = new StreamReader(filePath);
                exp = reader.ReadToEnd();
                reader.Close();
                return exp;
            }
        }
    }
}
