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
        public HistoryWindow()
        {
            InitializeComponent();
            /*
            try
            {
                conn.ConnectionString = connectionString;
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sql = @"SELECT Infix, Postfix, Prefix FROM calculator_history";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader myData = cmd.ExecuteReader();
                    if (!myData.HasRows)
                    {
                        MessageBox.Show("No data.");
                    }
                    else
                    {
                        while (myData.Read())
                        {
                            MessageBox.Show(myData.GetString(0));
                        }
                        myData.Close();
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " : " + ex.Message);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }
    }
}
