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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculator
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

        private void _1btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "1";
        }

        private void _2btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "2";
        }

        private void _3btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "3";
        }

        private void _4btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "4";
        }

        private void _5btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "5";
        }

        private void _6btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "6";
        }

        private void _7btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "7";
        }

        private void _8btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "8";
        }

        private void _9btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "9";
        }

        private void _0btn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "0";
        }

        private void divBtn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "/";
        }

        private void mulBtn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "*";
        }

        private void subBtn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "-";
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text += "+";
        }

        private void equalBtn_Click(object sender, RoutedEventArgs e)
        {
            postorder.Text = InorderToPostorder(inorder.Text);
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text = null;
        }

        private void historyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private string InorderToPostorder(string inorder) 
        {
            string postorder = "";
            Stack<char> stack = new Stack<char>();
            string operators = "+-*/";
            for(int i = 0; i<inorder.Length; i++)
            {
                if (operators.Contains(inorder[i])){
                    while ( stack.Count != 0 && OperatorPriority(stack.Peek()) >= OperatorPriority(inorder[i]))
                    {
                        postorder += stack.Pop();
                    }
                    stack.Push(inorder[i]);
                }
                else
                {
                    postorder += inorder[i];
                }
            }
            while( stack.Count != 0 )
            {
                postorder += stack.Pop();
            }
            return postorder;
        }

        private int OperatorPriority(char oper)
        {
            switch (oper)
            {
                case '+':
                    return 1;
                case '-':
                    return 1;
                case '*':
                    return 2;
                case '/':
                    return 2;
                default: 
                    return 0;
            }
        }
    }
}
