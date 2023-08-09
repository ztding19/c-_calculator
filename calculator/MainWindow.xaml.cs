using System;
using System.Collections.Generic;
using System.Data.Common;
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
        private readonly string operators = "+-*/";
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
            preorder.Text = InorderToPreorder(inorder.Text);
            resultDec.Text = PostorderCalculate(postorder.Text);
            resultBin.Text = Convert.ToString(Convert.ToInt32(resultDec.Text), 2);
            inorder.Text = "";
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            inorder.Text = null;
        }

        private void historyBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO : Connect database.
        }

        private string InorderToPostorder(string inorder) 
        {
            string postorder = "";
            Stack<char> stack = new();
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

        private string InorderToPreorder(string inorder)
        {
            inorder = new string(inorder.Reverse().ToArray());
            string preorder = new(InorderToPostorder(inorder).Reverse().ToArray());
            return preorder;
        }

        private string PostorderCalculate(string postorder)
        {
            float a, b;
            Stack<float> stack = new();
            for (int i = 0; i < postorder.Length; i++)
            {
                switch (postorder[i]) 
                {
                    case '+':
                        b = (float)stack.Pop();
                        a = (float)stack.Pop();
                        stack.Push(a + b);
                        break;
                    case '-':
                        b = (float)stack.Pop();
                        a = (float)stack.Pop();
                        stack.Push(a - b);
                        break;
                    case '*':
                        b = (float)stack.Pop();
                        a = (float)stack.Pop();
                        stack.Push(a * b);
                        break;
                    case '/':
                        b = (float)stack.Pop();
                        a = (float)stack.Pop();
                        stack.Push(a / b);
                        break;
                    default:
                        stack.Push(postorder[i]-48);
                        break;
                }
            }

            return Math.Round(stack.Peek(), 0).ToString();
            //return stack.Peek().ToString();
        }

        private static int OperatorPriority(char oper)
        {
            return oper switch
            {
                '+' => 1,
                '-' => 1,
                '*' => 2,
                '/' => 2,
                _ => 0,
            };
        }
    }
}
