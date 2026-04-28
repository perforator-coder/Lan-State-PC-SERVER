using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lan_State_PC_SERVER
{
    public class LanSERVERacts
    {
        private int port;
        private bool isEnable = false;
        private Dictionary<string,TcpClient> Clients = new Dictionary<string,TcpClient>();
        private TcpListener Server;
        private CancellationTokenSource CanselTask;
        public LanSERVERacts(int port) 
        {
            this.port = port;
            Server = new TcpListener(IPAddress.Any, port);
        }
        // для получения состояния сервера
        public bool IsEnable
        {
            get { return isEnable; }
        }
        // для получения словоря
        public Dictionary<string, TcpClient> GetClients
        {
            get
            {
                lock (Clients) { return Clients; }
            }
        }
        public bool StartServer()
        {
            try
            {
                Server.Start();
                isEnable = true;
                CanselTask = new CancellationTokenSource();
                // запуск паралельной задачи для прослушивания и записывания в словарь клиентов
                _ = Task.Run(async() =>
                {
                    while (!CanselTask.Token.IsCancellationRequested) 
                    {
                        try
                        {
                            TcpClient client = await Server.AcceptTcpClientAsync(CanselTask.Token);
                            _ = ConnectClientstatus(client, CanselTask.Token);
                        }
                        catch (OperationCanceledException ex)
                        {
                            MessageBox.Show($"Сервер отключился...","Server error connection");
                        }
                    }
                });
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка запуска сервера","Server start error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        //остановка сервера
        public bool StopServer() 
        {
            try
            {
                
                isEnable = false;
                CanselTask?.Cancel();
                lock (Clients)
                {
                    Clients.Clear();
                }
                Server.Stop();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка выключения сервера", "Server shutdown error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // метод для обработки каждого клиента
        private async Task ConnectClientstatus(TcpClient client, CancellationToken Cansel_tok)
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter SendMS = new StreamWriter(stream, Encoding.UTF8))
            using (StreamReader ReadMS = new StreamReader(stream, Encoding.UTF8))
            {

                SendMS.AutoFlush = true;
                await SendMS.WriteLineAsync("PING_ID");
                string client_id = await ReadMS.ReadLineAsync();
                
                lock (Clients)
                {
                    if (!Clients.ContainsKey(client_id))
                    {
                        //Clients[client_id].Close
                        Clients.Add(client_id, client);
                       // MessageBox.Show($"Есть клиент{client_id}");
                    }
                    
                }
                while (!Cansel_tok.IsCancellationRequested && client.Connected)
                {
                    await Task.Delay(1000,Cansel_tok);
                }
            }
        }
        // тестовый запрос
        public async Task dev(string key_id)
        {
            using (NetworkStream stream = Clients[key_id].GetStream())
            using (StreamWriter WriteMS = new StreamWriter(stream,Encoding.UTF8))
            using (StreamReader ReadMS = new StreamReader(stream,Encoding.UTF8))
            {
                WriteMS.AutoFlush = true;
                await WriteMS.WriteLineAsync("STATUS");
                string client_ms = await ReadMS.ReadLineAsync();
                MessageBox.Show($"{key_id},{client_ms}");
            }
        }
    }
}
