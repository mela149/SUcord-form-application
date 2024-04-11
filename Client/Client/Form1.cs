using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;


namespace Client
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
            button_disconnect.Enabled = false; // Disable disconnect button initially
            button_subscribe_if.Enabled = false;
            button_subscribe_sps.Enabled = false;
            button_unsubscribe_if.Enabled = false;
            button_unsubscribe_sps.Enabled = false;
            button_send_if.Enabled = false;
            button_send_sps.Enabled = false;
            button_login.Enabled = false;
        }

        private void portnum_TextChanged(object sender, EventArgs e)
        {

        }

        private void ipnum_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            string IP = ipnum.Text;
            int portNum;

            if (Int32.TryParse(portnum.Text, out portNum))
            {
                try
                {
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.Connect(IP, portNum);
                    button_connect.Enabled = false;
                    connected = true;
                    logs.AppendText("Connection established...\n");
                    button_login.Enabled = true;
                    button_disconnect.Enabled = true;
                }
                catch (SocketException ex)
                {
                    logs.AppendText($"SocketException: {ex.ErrorCode}, {ex.Message}\n");
                }
                catch (Exception ex)
                {
                    logs.AppendText($"Error occurred while connecting: {ex.Message}\n");
                }
            }
            else
            {
                logs.AppendText("Invalid port number.\n");
            }
            if (connected)
            {
                Thread receiveThread = new Thread(ReceiveFromServer);
                receiveThread.Start();
            }
        }


        private string currentUsername;

        private void button_login_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                logs.AppendText("Please connect to the server first.\n");
                return;
            }

            string username = usernametextbox.Text;

            // Send a login request to the server
            SendMessage("LOGIN", username);

            // The response will be handled by the ReceiveFromServer method
        }


        private void SendMessage(string header, string body)
        {
            if (connected)
            {
                try
                {
                    // Format the message with a header and body
                    string message = $"{header}\n{body}";
                    byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                }
                catch (Exception ex)
                {
                    logs.AppendText($"Error sending message: {ex.Message}\n");
                }
            }
            else
            {
                logs.AppendText("Not connected to the server...\n");
            }
        }

        private void ReceiveFromServer()
        {
            try
            {
                while (connected)
                {
                    if (clientSocket.Poll(1000000, SelectMode.SelectRead) && clientSocket.Available == 0)
                    {
                        // Connection has been closed
                        break;
                    }
                    byte[] buffer = new byte[1024];
                    int bytesRead = clientSocket.Receive(buffer);
                    if (bytesRead > 0)
                    {
                        string receivedData = Encoding.Default.GetString(buffer, 0, bytesRead);
                        this.Invoke((MethodInvoker)delegate
                        {
                            // Process the received data based on its content
                            if (receivedData.Contains("SUBSCRIBED_SUCCESS"))
                            {
                                HandleSubscribeSuccess(receivedData);
                            }
                            else if (receivedData.Contains("UNSUBSCRIBE_SUCCESS"))
                            {
                                HandleUnsubscribeSuccess(receivedData);
                            }
                            else if (receivedData.Contains("login_success"))
                            {
                                HandleLoginSuccess(receivedData);
                            }
                            else if (receivedData.Contains("login_failure"))
                            {
                                HandleLoginFailure(receivedData);
                            }
                            else if (receivedData.StartsWith("MESSAGEif"))
                            {
                                // Assuming the message format is "MESSAGEif\nmessage_body"
                                string body = receivedData.Split(new[] { '\n' }, 2)[1];
                                logs.AppendText("Received a message on IF100\n");
                                if100.AppendText($"{body}\n");
                            }
                            else if (receivedData.StartsWith("MESSAGEsps"))
                            {
                                logs.AppendText("Received a message on SPS101\n");
                                string body = receivedData.Split(new[] { '\n' }, 2)[1];
                                sps101.AppendText($"{body}\n");
                            }
                            else
                            {
                                logs.AppendText($"Received unknown data: {receivedData}\n");
                            }
                        });
                    }
                }
            }
            catch (SocketException)
            {
                if (!terminating)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        logs.AppendText("Lost connection to the server.\n");
                    });
                }
                connected = false;
            }
            finally
            {
                connected = false;
            }
        }

        private void HandleSubscribeSuccess(string receivedData)
        {
            if (receivedData.Contains("IF100"))
            {
                logs.AppendText("Subscribed to IF100.\n");
                button_subscribe_if.Enabled = false;
                button_unsubscribe_if.Enabled = true;
                button_send_if.Enabled = true;
            }
            else if (receivedData.Contains("SPS101"))
            {
                logs.AppendText("Subscribed to SPS101.\n");
                button_subscribe_sps.Enabled = false;
                button_unsubscribe_sps.Enabled = true;
                button_send_sps.Enabled = true;
            }
            else
            {
                logs.AppendText("Unknown subscription success.\n");
            }
        }

        private void HandleUnsubscribeSuccess(string receivedData)
        {
            if (receivedData.Contains("IF100"))
            {
                logs.AppendText("Unsubscribed from IF100.\n");
                button_subscribe_if.Enabled = true;
                button_unsubscribe_if.Enabled = false;
                button_send_if.Enabled = false;
            }
            else if (receivedData.Contains("SPS101"))
            {
                logs.AppendText("Unsubscribed from SPS101.\n");
                button_subscribe_sps.Enabled = true;
                button_unsubscribe_sps.Enabled = false;
                button_send_sps.Enabled = false;
            }
            else
            {
                logs.AppendText("Unknown unsubscription success.\n");
            }
        }


        private void HandleLoginSuccess(string receivedData)
        {
            currentUsername = usernametextbox.Text;
            logs.AppendText("Login successful!\n");

            // Enable/Disable UI elements post successful login
            button_login.Enabled = false; // Disable login button
            button_subscribe_if.Enabled = true; // Enable subscribe button for IF100
            button_subscribe_sps.Enabled = true; // Enable subscribe button for SPS101
        }


        private void HandleLoginFailure(string receivedData)
        {
            string username = usernametextbox.Text;
            logs.AppendText($"Login failed: {username} username already in use.\n");

            // You can clear the username textbox or take other appropriate actions
            usernametextbox.Clear();
            // Optionally, you can keep the login button enabled for retrying
            button_login.Enabled = true;
        }







        private void button_disconnect_Click(object sender, EventArgs e)
        {
            connected = false;
            terminating = true;

            // Send disconnect message to the server
            SendMessage("DISCONNECT", currentUsername);
            button_connect.Enabled = true;
            clientSocket.Close();
            Environment.Exit(0);
        }


        private void logs_TextChanged(object sender, EventArgs e)
        {

        }

        private void if100_TextChanged(object sender, EventArgs e)
        {

        }

        private void sps101_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_subscribe_if_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                SendMessage("SUBSCRIBEif", currentUsername);
                // Response will be handled in ReceiveFromServer
            }
            else
            {
                logs.AppendText("Not connected to the server.\n");
            }
        }

        private void button_unsubscribe_if_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                SendMessage("UNSUBSCRIBEif", currentUsername);
                // Response will be handled in ReceiveFromServer
            }
            else
            {
                logs.AppendText("Not connected to the server.\n");
            }
        }
        // Similar modifications for sps

        private void button_subscribe_sps_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                SendMessage("SUBSCRIBEsps", currentUsername);
                // Response will be handled in ReceiveFromServer
            }
            else
            {
                logs.AppendText("Not connected to the server.\n");
            }
        }

        private void button_unsubscribe_sps_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                SendMessage("UNSUBSCRIBEsps", currentUsername);
                // Response will be handled in ReceiveFromServer
            }
            else
            {
                logs.AppendText("Not connected to the server.\n");
            }
        }



        private void button_send_if_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                string messageBody = textBox_if.Text;
                SendMessage("MESSAGEif", $"{currentUsername}:{messageBody}");
            }
            else
            {
                logs.AppendText("Not connected to the server.\n");
            }
        }

        private void button_send_sps_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                // Example: Send a message to the server
                string messageBody = textBox_sps.Text;
                SendMessage("MESSAGEsps", $"{currentUsername}:{messageBody}");
            }
            else
            {
                logs.AppendText("Not connected to the server.\n");
            }
        }

        private void textBox_if_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_sps_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connected = false;
            terminating = true;
            clientSocket.Close();
            Environment.Exit(0);
        }


    }
}