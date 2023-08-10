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
        public HistoryWindow()
        {
            InitializeComponent();
            Refresh();
            
        }

        private void Refresh()
        {
            try
            {
                conn.ConnectionString = connectionString;
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
    }
}
