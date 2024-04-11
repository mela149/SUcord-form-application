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
using System.Threading;


namespace Server
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        List<string> clientusernames = new List<string>();
        List<string> usernamesif = new List<string>();
        List<string> usernamessps = new List<string>();
        private Dictionary<string, Socket> clientSocketDictionary = new Dictionary<string, Socket>();



        bool terminating = false;
        bool listening = false;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void actions_TextChanged(object sender, EventArgs e)
        {

        }

        private void if100_TextChanged(object sender, EventArgs e)
        {

        }

        private void portnum_TextChanged(object sender, EventArgs e)
        {

        }

        // Connect button
        private void button1_Click(object sender, EventArgs e)
        {
            int port;
            if (Int32.TryParse(portnum.Text, out port))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port); //listen in any interface, initialize end point here. 
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button1.Enabled = false;

                //When client disconnect no problem in the server so no need to check here with try. 
                Thread acceptThread = new Thread(Accept); // Thread to accept new clients from now on. 
                acceptThread.Start();

                actions.AppendText("Started listening on port: " + port + "\n");

            }
            else
            {
                actions.AppendText("Please check port number \n");
            }

        }


        // Disconnect button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop listening for new connections
                listening = false;
                serverSocket.Close();

                // Close all existing client sockets
                foreach (Socket clientSocket in clientSockets)
                {
                    clientSocket.Close();
                }

                // Clear lists and update UI
                clientSockets.Clear();
                clientusernames.Clear();
                clientSocketDictionary.Clear();

                actions.AppendText("Server has been disconnected.\n");
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                actions.AppendText($"Error during disconnection: {ex.Message}\n");
            }
        }

        private void Accept() // Accepting new clients to the server.
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept(); // accept corresponding sockets for clients.

                    // Start a new thread to handle the client's requests
                    Thread clientThread = new Thread(() => HandleClient(newClient));
                    clientThread.Start();
                }
                catch
                {
                    if (terminating) // If we close the server. No crash, correctly closed and not listening from now on. 
                    {
                        listening = false;
                    }
                    else // Problem occurred here. 
                    {
                        actions.AppendText("The socket stopped working.\n");
                    }
                }
            }
        }

        private void HandleClient(Socket thisClient)
        {
            try
            {
                clientSockets.Add(thisClient);

                // After the client is connected, receive information from the client's actions.
                Thread receiveThread = new Thread(() => Receive(thisClient));
                receiveThread.Start();
            }
            catch
            {
                actions.AppendText("Server: Problem handling the client.\n");
            }
        }

        

        private void Receive(Socket clientSocket)
        {
            try
            {
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = clientSocket.Receive(buffer);
                    if (bytesRead == 0)
                    {
                        // Client has disconnected
                        HandleClientDisconnection(clientSocket);
                        break;
                    }

                    string receivedData = Encoding.Default.GetString(buffer, 0, bytesRead);

                    // Split the received data into header and body
                    string[] parts = receivedData.Split(new[] { '\n' }, 2, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length == 2)
                    {
                        string header = parts[0].Trim();
                        string body = parts[1].Trim();

                        // Process the data based on the header
                        switch (header)
                        {
                            case "LOGIN":
                                // Handle login request
                                HandleLogin(body, clientSocket);
                                break;
                            case "MESSAGEif":
                                HandleMessage(header, body);
                                break;
                            case "MESSAGEsps":
                                // Handle regular message
                                HandleMessage(header, body);
                                break;
                            case "SUBSCRIBEif":
                                HandleSubscribe(clientSocket, header, body);
                                break;
                            case "UNSUBSCRIBEif":
                                HandleUnsubscribe(clientSocket, header, body);
                                break;
                            case "SUBSCRIBEsps":
                                HandleSubscribe(clientSocket, header, body);
                                break;
                            case "UNSUBSCRIBEsps":
                                HandleUnsubscribe(clientSocket, header, body);
                                break;
                            case "DISCONNECT":
                                HandleClientDisconnection(clientSocket);
                                break;
                            // Add more cases for other headers as needed
                            default:
                                // Unknown header, handle accordingly
                                actions.AppendText($"Unknown header: {header}\n");
                                break;
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                actions.AppendText($"SocketException in Receive: {ex.Message}\n");

                // Handle the exception, e.g., remove the client from the list
                HandleClientDisconnection(clientSocket);
            }
            catch (Exception ex)
            {
                actions.AppendText($"Exception in Receive: {ex.Message}\n");
            }
        }

        private void HandleLogin(string username, Socket clientSocket)
        {
            // Check if the user is already logged in
            if (clientSocketDictionary.ContainsKey(username))
            {
                // Send a response to the client indicating login failure
                SendMessage(clientSocket, "login_failure");
                actions.AppendText($"Login failed for {username}. User already logged in.\n");
            }

            else
            {
                // Handle the login request, check the username, etc.
                // ...

                // Send a response to the client indicating login success
                SendMessage(clientSocket, "login_success");

                // Add the username to the list of logged-in users
                clientusernames.Add(username);

                // Add the username and socket to the dictionary
                clientSocketDictionary[username] = clientSocket;

                // Optionally, update the connected clients list
                UpdateConnectedClients();

                actions.AppendText($"{username} logged in successfully.\n");
            }
        }


        private void HandleMessage(string header, string body)
        {

            // Determine the channel name based on the header
            string channelName = header == "MESSAGEif" ? "IF100" : header == "MESSAGEsps" ? "SPS101" : "Unknown";

            // Append the message to the actions rich text box with the channel name
            actions.AppendText($"({channelName}) {body}\n");

            // Broadcast the message to all subscribed clients of the channel
            switch (header)
            {
                case "MESSAGEif":
                    BroadcastMessage(body, usernamesif, "MESSAGEif");
                    break;
                case "MESSAGEsps":
                    BroadcastMessage(body, usernamessps, "MESSAGEsps");
                    break;
                // Add more cases for other headers as needed
                default:
                    actions.AppendText($"Unknown header: {header}\n");
                    break;
            }
        }

        private void BroadcastMessage(string message, List<string> targetUsernames, string channelHeader)
        {
            string fullMessage = $"{channelHeader}\n{message}";
            foreach (var entry in clientSocketDictionary)
            {
                string username = entry.Key;
                Socket clientSocket = entry.Value;

                if (targetUsernames.Contains(username))
                {
                    SendMessage(clientSocket, fullMessage);
                }
            }
        }



        private void SendMessage(Socket clientSocket, string message)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
            catch (Exception ex)
            {
                actions.AppendText($"Error sending message to client: {ex.Message}\n");
            }
        }


        private void HandleSubscribe(Socket clientSocket, string header, string body)
        {
            string subscribe = header;
            string username = body;
            string response = "SUBSCRIBE_NotSUCCESS";
            if (header == "SUBSCRIBEif")
            {
                if (!usernamesif.Contains(username))
                {
                    response = "IF100_SUBSCRIBED_SUCCESS";
                    usernamesif.Add(username);
                    actions.AppendText(username + " subscribed to IF100.\n");
                    UpdateIF100SubscribersDisplay();
                }
     
            }
            if (header == "SUBSCRIBEsps")
            {
                if (!usernamessps.Contains(username))
                {
                    response = "SPS101_SUBSCRIBED_SUCCESS";
                    usernamessps.Add(username);
                    actions.AppendText(username + " subscribed to SPS101.\n");
                    UpdateSPS101SubscribersDisplay();
                }

            }



            SendMessage(clientSocket, response);
        }

        private void HandleUnsubscribe(Socket clientSocket, string header, string body)
        {
            string subscribe = header;
            string username = body;
            string response = "UNSUBSCRIBE_NotSUCCESS";
            if (header == "UNSUBSCRIBEif")
            {
                if (usernamesif.Contains(username))
                {
                    response = "IF100_UNSUBSCRIBE_SUCCESS";
                    usernamesif.Remove(username);
                    actions.AppendText(username + " unsubscribed to IF100.\n");
                    UpdateIF100SubscribersDisplay();
                }

            }
            if (header == "UNSUBSCRIBEsps")
            {
                if (usernamessps.Contains(username))
                {
                    actions.AppendText(username + " unsubscribed to SPS101.\n");
                    response = "SPS101_UNSUBSCRIBE_SUCCESS";
                    usernamessps.Remove(username);
                    UpdateSPS101SubscribersDisplay();
                }

            }



            SendMessage(clientSocket, response);
        }


        private void HandleUsername(string receivedUsername, string currentUsername, Socket clientSocket)
        {
            // Implement logic to handle the received username
            // For example, check if the received username is valid and update the client list
        }

        


        private void HandleClientDisconnection(Socket clientSocket)
        {
            // Find the username associated with the disconnected socket
            var disconnectedUser = clientSocketDictionary.FirstOrDefault(x => x.Value == clientSocket).Key;

            // Remove the entry from the dictionary
            if (!string.IsNullOrEmpty(disconnectedUser))
            {
                clientSocketDictionary.Remove(disconnectedUser);
                clientusernames.Remove(disconnectedUser);
                // Remove the client socket
                clientSockets.Remove(clientSocket);
                // Update the connected clients list

                UpdateConnectedClients();
                if (usernamesif.Contains(disconnectedUser))
                {
                    usernamesif.Remove(disconnectedUser);
                }
                if (usernamessps.Contains(disconnectedUser))
                {
                    usernamessps.Remove(disconnectedUser);
                }
                UpdateIF100SubscribersDisplay();
                UpdateSPS101SubscribersDisplay();

                actions.AppendText($"{disconnectedUser} disconnected.\n");
            }



            // Update UI or perform other disconnection-related tasks
            UpdateIF100SubscribersDisplay();
            UpdateSPS101SubscribersDisplay();
            UpdateConnectedClients();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clients_TextChanged(object sender, EventArgs e)
        {

        }

        private void sps101_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateIF100SubscribersDisplay()
        {
            if100.Invoke(new Action(() =>
            {
                if100.Text = string.Join("\n", usernamesif);
            }));
        }

        private void UpdateSPS101SubscribersDisplay()
        {
            sps101.Invoke(new Action(() =>
            {
                sps101.Text = string.Join("\n", usernamessps);
            }));
        }


        private void UpdateConnectedClients()
        {
            string connectedClients = "Connected Clients:\n";

            foreach (string username in clientusernames)
            {
                connectedClients += username + "\n";
            }

            // Assuming you have a RichTextBox named clientsTextBox
            clients.Invoke(new Action(() => clients.Text = connectedClients));
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listening = false;
            terminating = true;
            serverSocket.Close();

            // Close all existing client sockets
            foreach (Socket clientSocket in clientSockets)
            {
                clientSocket.Close();
            }

            // Clear lists and update UI
            clientSockets.Clear();
            clientusernames.Clear();
            clientSocketDictionary.Clear();

            Environment.Exit(0);
        }

    }
}
