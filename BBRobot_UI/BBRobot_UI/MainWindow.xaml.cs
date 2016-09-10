﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace BBRrobotUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Socket client;
        private IPEndPoint ipe;
        private int motion;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AsynTCPConnect()
        {
            if (textbox_TCPIP.Text == string.Empty || textbox_TCPPORT.Text == string.Empty)
            {
                MessageBox.Show("Please input server address and port!");
            }

             ipe = new IPEndPoint(IPAddress.Parse(textbox_TCPIP.Text), Int32.Parse(textbox_TCPPORT.Text));
            //创建套接字
             client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipe);
            if (client != null)
            {
                textbox_TCP.Dispatcher.Invoke(new Action(() =>
                {
                    textbox_TCP.Text = "Connected!";
                    textbox_TCP.Background = Brushes.Green;
                }));
            }
            else
            {
                textbox_TCP.Dispatcher.Invoke(new Action(() =>
                {
                    textbox_TCP.Text = "failed!";
                    textbox_TCP.Background = Brushes.Red;
                }));
            }
        }

        public void TCPSend()
        {
            byte[] data;
            if (client == null) return;
            //编码
            if (motion == 3)
            {
                data = Encoding.ASCII.GetBytes("3");
                try
                {
                    
                    client.Send(data, data.Length, 0);
                    Console.WriteLine("3");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("excep：{0}", ex.Message);
                }
            }
            else if (motion == 0)
            {
                data = Encoding.ASCII.GetBytes("0");
                try
                {                 
                    client.Send(data, data.Length, 0);
                    Console.WriteLine("0");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("excep：{0}", ex.Message);
                }
            }
            else if (motion == 4)
            {
                data = Encoding.ASCII.GetBytes("4");
                try
                {
                    client.Send(data, data.Length, 0);
                    Console.WriteLine("4");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("excep：{0}", ex.Message);
                }
            }
            else if (motion == 1)
            {
                data = Encoding.ASCII.GetBytes("1");
                try
                {
                    client.Send(data, data.Length, 0);
                    Console.WriteLine("1");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("excep：{0}", ex.Message);
                }
            }
            else if (motion == 2)
            {
                data = Encoding.ASCII.GetBytes("2");
                try
                {
                    client.Send(data, data.Length, 0);
                    Console.WriteLine("2");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("excep：{0}", ex.Message);
                }
            }
            else if (motion == 11)
            {
                data = Encoding.ASCII.GetBytes("l");
                try
                {
                    client.Send(data, data.Length, 0);
                    Console.WriteLine("l");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("excep：{0}", ex.Message);
                }
            }
            client.Close();      
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="socket"></param>


        private void button_left_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            motion = 3;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Turn Left";
            textbox_motion.Background = Brushes.LawnGreen;           
        }

        private void button_left_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            motion = 0;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Stop";
            textbox_motion.Background = Brushes.Red;
        }

        private void button_right_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            motion = 4;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Turn Right";
            textbox_motion.Background = Brushes.LawnGreen;
       
        }

        private void button_right_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            motion = 0;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Stop";
            textbox_motion.Background = Brushes.Red;


        }

        private void button_backward_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            motion = 2;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Backward";
            textbox_motion.Background = Brushes.LawnGreen;

        }

        private void button_backward_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            motion = 0;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Stop";
            textbox_motion.Background = Brushes.Red;
        }

        private void button_stop_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            motion = 0;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Break";
            textbox_motion.Background = Brushes.LawnGreen;
        }

        private void button_stop_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            motion = 0;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Stop";
            textbox_motion.Background = Brushes.Red;
        }

        private void button_forward_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            motion = 1;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Forward";
            textbox_motion.Background = Brushes.LawnGreen;
        }

        private void button_forward_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            motion = 0;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            textbox_motion.Text = "Stop";
            textbox_motion.Background = Brushes.Red;
        }
/// <summary>
/// buttons for PTZ control
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button_ptzreset_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "PTZ reset";
            textbox_ptzangle.Background = Brushes.LawnGreen;
        }

        private void button_ptzreset_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "Stop";
            textbox_ptzangle.Background = Brushes.Red;
        }

        private void button_ptzleft_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "PTZ Left";
            textbox_ptzangle.Background = Brushes.LawnGreen;
        }

        private void button_ptzleft_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "Stop";
            textbox_ptzangle.Background = Brushes.Red;
        }

        private void button_ptzright_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "PTZ right";
            textbox_ptzangle.Background = Brushes.LawnGreen;
        }

        private void button_ptzright_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "Stop";
            textbox_ptzangle.Background = Brushes.Red;
        }

        private void button_ptzup_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "PTZ up";
            textbox_ptzangle.Background = Brushes.LawnGreen;
        }

        private void button_ptzup_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "Stop";
            textbox_ptzangle.Background = Brushes.Red;
        }

        private void button_ptzdown_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "PTZ down";
            textbox_ptzangle.Background = Brushes.LawnGreen;
        }

        private void button_ptzdown_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            textbox_ptzangle.Text = "Stop";
            textbox_ptzangle.Background = Brushes.Red;
        }

        private void button_videostream_Click(object sender, RoutedEventArgs e)
        {
            BrowerFPV.Navigate(textbox_videoaddress.Text);
            // "http://192.168.1.79:8080/javascript_simple.html"  
        }

        private void button_laser_Checked(object sender, RoutedEventArgs e)
        {
            motion = 11;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            label_laser.Content = "ON";
            label_laser.Background = Brushes.LawnGreen;
        }

        private void button_laser_Unchecked(object sender, RoutedEventArgs e)
        {
            motion = 11;
            AsynTCPConnect();
            Thread sendthread = new Thread(new ThreadStart(TCPSend));
            sendthread.Start();
            label_laser.Content = "OFF";
            label_laser.Background = Brushes.Red;
        }
    }
}
