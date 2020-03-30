using System;
using System.Collections.Generic;
using System.IO;
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

namespace Druzynav2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            for (int i = 15; i < 70; i++)
            {
                cbAge.Items.Add(i);
            }
        }

        private bool isNoEmpty(TextBox tb)
        {
            if (tb.Text.Trim() == "")
            {
                
                return false;
            }
           
            return true;
        }


        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (isNoEmpty(tbName) & isNoEmpty(tbSurname))
            {
                var currentFootballer = new Player(tbName.Text.Trim(), tbSurname.Text.Trim(), Convert.ToByte(cbAge.Text), (float)slweight.Value);
                bool isOnList = false;
                foreach (var p in lb_LisOfPlayers.Items)
                {
                    var pilkarz = p as Player;
                    if (pilkarz.isInList(currentFootballer))
                    {
                        isOnList = true;
                        break;
                    }
                }
                if (isOnList == false)
                {
                    lb_LisOfPlayers.Items.Add(currentFootballer);
                    ResetValues();
                }
                else
                {
                    var dialog = MessageBox.Show("Piłkarz którego chcesz dodać jest już na liście!", "Uwaga", MessageBoxButton.OK);
                    ResetValues();
                }
            }

        }

        private void slweight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender != null)
            {
                tbweight.Text = Math.Round(slweight.Value, 1).ToString() + " kg";
            }
        }

        private void RemoveFootballer(object sender, RoutedEventArgs e)
        {
            if (lb_LisOfPlayers.SelectedIndex == -1)
            {
                var dialog = MessageBox.Show("Nie wybrales nikogo do usuniecia", "Uwaga", MessageBoxButton.OK);
            }
            else
            {
                var dialog = MessageBox.Show("Czy na pewno usunać piłkarza?", "Uwaga", MessageBoxButton.OKCancel);
                if (dialog == MessageBoxResult.OK)
                {
                    lb_LisOfPlayers.Items.Remove(lb_LisOfPlayers.SelectedItem);
                    ResetValues();
                }
            }
        }

        private void ModifyFootballer(object sender, RoutedEventArgs e)
        {
            if (lb_LisOfPlayers.SelectedIndex != -1)
            {
                var dialog = MessageBox.Show("Czy na pewno chcesz modyfikować dane piłkarza?", "Uwaga", MessageBoxButton.OKCancel);
                int index = 0;
                if (dialog == MessageBoxResult.OK)
                {

                    index = lb_LisOfPlayers.SelectedIndex;
                    // lb_LisOfPlayers.SelectedIndex = -1;
                    if (index != -1 && isNoEmpty(tbName) & isNoEmpty(tbSurname))
                    {
                        var currentFootballer = new Player(tbName.Text.Trim(), tbSurname.Text.Trim(), Convert.ToByte(cbAge.Text), (float)slweight.Value);
                        bool isOnList = false;
                        foreach (var p in lb_LisOfPlayers.Items)
                        {
                            var pilkarz = p as Player;
                            if (pilkarz.isInList(currentFootballer))
                            {
                                isOnList = true;
                                break;
                            }
                        }
                        if (isOnList == false)
                        {
                            lb_LisOfPlayers.Items.Remove(lb_LisOfPlayers.SelectedItem);
                            lb_LisOfPlayers.Items.Insert(index, currentFootballer);
                        }
                        else
                        {
                            var dialog2 = MessageBox.Show("Już taki piłkarz jest na liście, wprowadź innego!", "Uwaga", MessageBoxButton.OK);
                        }
                    }
                    ResetValues();
                }
            }
        }

        private void IsSelect(object sender, SelectionChangedEventArgs e)
        {
            //lb_LisOfPlayers.SelectedIndex != -1
            if (sender != null && lb_LisOfPlayers.SelectedIndex != -1)
            {
                Player player = (Player)lb_LisOfPlayers.SelectedItem;
                tbName.Text = player.getName();
                tbSurname.Text = player.getSurname();
                slweight.Value = player.getWeight();
                cbAge.Text = player.getAge().ToString();

            }
        }
        private void ResetValues()
        {
            tbName.Text = "";
            tbSurname.Text = "";
            slweight.Value = 50;
            cbAge.SelectedIndex = 0;
        }

     

        }
    }


