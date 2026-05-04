using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                           // MessageBox.Show($"Сервер отключился...","Server error connection");
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
            string client_id = "";
            try
            {
                NetworkStream stream = client.GetStream();
                StreamWriter SendMS = new StreamWriter(stream, Encoding.UTF8);
                StreamReader ReadMS = new StreamReader(stream, Encoding.UTF8);


                SendMS.AutoFlush = true;
                await SendMS.WriteLineAsync("PINGID");
                client_id = await ReadMS.ReadLineAsync(Cansel_tok);

                lock (Clients)
                {
                    if (!Clients.ContainsKey(client_id))
                    {
                        
                        Clients.Add(client_id, client);
                        
                    }

                }
                while (!Cansel_tok.IsCancellationRequested && client.Connected)
                {


                    await Task.Delay(5000, Cansel_tok);
                    if (client == null || client.Client == null)
                    {
                        break;
                    }
                    try
                    {
                        if (client.Client.Poll(0, SelectMode.SelectRead) && client.Client.Available == 0)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        break;
                    }
                    

                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (client_id != null)
                {
                    lock (Clients)
                    {
                        Clients.Remove(client_id);
                    }
                }
                client?.Close();
            }
            
        }
        // тестовый запрос
        public async Task dev(string key_id)
        {
            try
            {
                if (Clients.ContainsKey(key_id))
                {
                    NetworkStream stream = Clients[key_id].GetStream();
                    StreamWriter WriteMS = new StreamWriter(stream, Encoding.UTF8);
                    StreamReader ReadMS = new StreamReader(stream, Encoding.UTF8);
                    var time =  Stopwatch.StartNew();
                    WriteMS.AutoFlush = true;
                    await WriteMS.WriteLineAsync("STATUS");
                    string client_ms = await ReadMS.ReadLineAsync();
                    time.Stop();
                    MessageBox.Show($"ID: {key_id}\nStatus: {client_ms}\nPing: {time.ElapsedMilliseconds} mc");
                }
                else
                {
                    MessageBox.Show("Клиент потерян", "Client error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Клиент потерян", "Client error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // запрос для получения данных
        public async Task<string> GetinfoClient(string Key_ID)
        {
            try
            {
                if (Clients.ContainsKey(Key_ID))
                {
                    NetworkStream stream = Clients[Key_ID].GetStream();
                    StreamReader ReadMS = new StreamReader(stream, Encoding.UTF8);
                    StreamWriter WriteMS = new StreamWriter(stream, Encoding.UTF8);
                    WriteMS.AutoFlush = true;
                    await WriteMS.WriteLineAsync("GETINFO");
                    string Client_ms = await ReadMS.ReadLineAsync();

                    return Client_ms;
                }
                else
                {
                    MessageBox.Show("Клиент потерян", "Client error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "er";
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                Clients[Key_ID].Close();
                Clients.Remove(Key_ID);
                return "er";
            }
        }
        public async Task<bool> SendShutDown(string Key_ID)
        {
            try
            {
                if (Clients.ContainsKey(Key_ID) && Clients[Key_ID] != null && Clients[Key_ID].Connected )
                {
                    
                    using (NetworkStream stream = Clients[Key_ID].GetStream())
                    using (StreamReader ReadMS = new StreamReader(stream, Encoding.UTF8))
                    using (StreamWriter WriteMS = new StreamWriter(stream, Encoding.UTF8))
                    {
                        WriteMS.AutoFlush = true;
                        await WriteMS.WriteLineAsync("SHUTDOWN");
                        Clients[Key_ID].Close();
                        Clients.Remove(Key_ID);
                    }
                    return true;
                }
                else
                {
                   
                    return false;
                }
            }
            catch (IOException ex)
            {
                
                Clients[Key_ID].Close();
                Clients.Remove(Key_ID);
                return false;
            }
        }
        public async Task<bool> SendRestart(string Key_ID)
        {
            try
            {
                if (Clients.ContainsKey(Key_ID) && Clients[Key_ID] != null && Clients[Key_ID].Connected)
                {
                    using (NetworkStream stream = Clients[Key_ID].GetStream())
                    using (StreamReader ReadMS = new StreamReader(stream, Encoding.UTF8))
                    using (StreamWriter WriteMS = new StreamWriter(stream, Encoding.UTF8))
                    {
                        WriteMS.AutoFlush = true;
                        await WriteMS.WriteLineAsync("RESTART");
                        Clients[Key_ID].Close();
                        Clients.Remove(Key_ID);
                    }
                    return true;
                }
                else
                {
                   
                    return false;
                }
            }
            catch (IOException ex)
            {
                //MessageBox.Show(ex.Message);
                Clients[Key_ID].Close();
                Clients.Remove(Key_ID);
                return false;
            }
        }
        public async Task<bool> SendMS(string Key_ID,string MS)
        {
            try
            {
                if (Clients.ContainsKey(Key_ID))
                {
                    StringBuilder MSserver = new StringBuilder();
                    NetworkStream stream = Clients[Key_ID].GetStream();
                    StreamReader ReadMS = new StreamReader(stream, Encoding.UTF8);
                    StreamWriter WriteMS = new StreamWriter(stream, Encoding.UTF8);
                    WriteMS.AutoFlush = true;
                    MSserver.Append("MS:");
                    MSserver.Append(MS);
                    await WriteMS.WriteLineAsync(MSserver.ToString());
                    string Client_ms = await ReadMS.ReadLineAsync();
                    if (Client_ms == "OK")
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
                else
                {
                   
                    return false;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                Clients[Key_ID].Close() ;
                Clients.Remove(Key_ID);
                return false;
            }
        }
    }
}
