using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace calculator
{
    /// <summary>
    /// HistoryWindow.xaml 的互動邏輯
    /// </summary>
    public partial class HistoryWindow : Window
    {
        private readonly string connectionString = "server=127.0.0.1;uid=root;database=csharp";
        MySqlConnection conn = new MySqlConnection();
        List<string> ids = new List<string>();
        public HistoryWindow()
        {
            InitializeComponent();
            conn.ConnectionString = connectionString;
            Refresh();
            
        }

        private void Refresh()
        {
            ids.Clear();
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                string sql = @"SELECT Id, Infix, Prefix, Postfix, DecimalResult, BinaryResult  FROM calculator_history";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader myData = cmd.ExecuteReader();
                if (!myData.HasRows)
                {
                    MessageBox.Show("No data.");
                    myData.Close();
                    return;
                }
                
                int i = 1;
                //MessageBox.Show(myData.FieldCount.ToString());
                while (myData.Read() && i <= 8)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Content = myData.GetString(0);
                    checkBox.HorizontalAlignment = HorizontalAlignment.Center;
                    checkBox.VerticalAlignment = VerticalAlignment.Center;
                    checkBox.Width = 15;
                    checkBox.Checked += CheckBox_Checked;
                    checkBox.Unchecked += CheckBox_Unchecked;
                    historyGrid.Children.Add(checkBox);
                    Grid.SetRow(checkBox, i);
                    for (int j = 1; j <= 5; j++)
                    {
                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = myData.GetString((int)j);
                        textBlock.TextWrapping = TextWrapping.Wrap;
                        textBlock.HorizontalAlignment = HorizontalAlignment.Right;
                        textBlock.VerticalAlignment = VerticalAlignment.Center;
                        textBlock.FontSize = 16;
                        textBlock.Margin = new Thickness(0, 0, 10, 0);
                        historyGrid.Children.Add(textBlock);
                        Grid.SetRow(textBlock, i);
                        Grid.SetColumn(textBlock, j);
                    }
                    i++;
                }
                myData.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " : " + ex.Message);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                ids.Remove(((CheckBox)sender).Content.ToString());
            }
            catch
            {
                MessageBox.Show("Ids removing failed.");
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show(((CheckBox)sender).Content.ToString());
            ids.Add(((CheckBox)sender).Content.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                //MessageBox.Show(ids.Count.ToString());
                bool isAnyBoxChecked = false;
                string condition = "Id IN (";
                foreach (string id in ids)
                {
                    condition += "'" + id + "', ";
                }
                condition = condition.Substring(0, condition.Length - 2);
                condition += ")";

                string sql = @"DELETE FROM calculator_history WHERE "+ condition;
                MessageBox.Show(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int index = cmd.ExecuteNonQuery();
                MessageBox.Show(index.ToString());
            }
            catch (MySqlException ex)
            {
                    MessageBox.Show(ex.Message);
            } 
        }
    }
}
