using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoChatSocketApp
{
    public partial class ChatServer : Form
    {
        private string _username;
        private string _ipAddress;
        private int _port;
        private TcpListener _server;
        private TcpClient _client;
        private NetworkStream _stream;
        private bool _isRunning = false;
        private string _clientUsername = string.Empty;

        public ChatServer(string username, string ipAddress, int port)
        {
            InitializeComponent();
            _username = username;
            _ipAddress = ipAddress;
            _port = port;

            this.FormClosing += ChatServer_FormClosing;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void ChatServer_Load(object sender, EventArgs e)
        {
            this.Text = $"Chat Server - {_username}";
            lbnBaglantiDurum.Text = "Bağlantı bekleniyor...";
            lbnBaglantiDurum.ForeColor = Color.Orange;
            lbnClientUsername.Text = "Katılımcı: Bekleniyor...";

            txtServerMesaj.Enabled = false;
            btnServerGonder.Enabled = false;

            await StartServer();
        }

        private async Task StartServer()
        {
            try
            {
                _server = new TcpListener(IPAddress.Parse(_ipAddress), _port);
                _server.Start();
                _isRunning = true;

                AddMessage($"Sunucu başlatıldı: {_ipAddress}:{_port}");
                AddMessage("İstemci bekleniyor...");

                _client = await _server.AcceptTcpClientAsync();
                _stream = _client.GetStream();

                // İlk olarak kendi username'ini gönder
                byte[] usernameData = Encoding.UTF8.GetBytes($"USERNAME:{_username}");
                await _stream.WriteAsync(usernameData, 0, usernameData.Length);
                await _stream.FlushAsync();

                // Client'ın username'ini al
                byte[] buffer = new byte[1024];
                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (receivedData.StartsWith("USERNAME:"))
                {
                    _clientUsername = receivedData.Substring(9);
                    lbnClientUsername.Text = $"Katılımcı: {_clientUsername}";
                }

                lbnBaglantiDurum.Text = "Bağlandı";
                lbnBaglantiDurum.ForeColor = Color.Green;

                txtServerMesaj.Enabled = true;
                btnServerGonder.Enabled = true;

                AddMessage($"İstemci bağlandı: {_clientUsername}");

                // Mesaj dinlemeye başla
                await ReceiveMessages();
            }
            catch (Exception ex)
            {
                AddMessage($"Hata: {ex.Message}");
                lbnBaglantiDurum.Text = "Bağlantı hatası";
                lbnBaglantiDurum.ForeColor = Color.Red;
            }
        }

        private async Task ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (_isRunning && _client != null && _client.Connected)
                {
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        // Bağlantı kapandı
                        AddMessage("İstemci bağlantıyı kesti.");
                        lbnClientUsername.Text = "Katılımcı: Bağlantı kesildi";
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // USERNAME: protokolünü göz ardı et (mesajlaşma sırasında gelebilir)
                    if (!message.StartsWith("USERNAME:"))
                    {
                        AddMessage($"{_clientUsername}: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                if (_isRunning)
                {
                    AddMessage($"Mesaj alma hatası: {ex.Message}");
                }
            }
            finally
            {
                Disconnect();
            }
        }

        private async void btnServerGonder_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async void txtServerMesaj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                await SendMessage();
            }
        }

        private async Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(txtServerMesaj.Text))
                return;

            try
            {
                if (_stream != null && _client != null && _client.Connected)
                {
                    string message = txtServerMesaj.Text.Trim();
                    byte[] data = Encoding.UTF8.GetBytes(message);

                    await _stream.WriteAsync(data, 0, data.Length);
                    await _stream.FlushAsync();

                    AddMessage($"{_username}: {message}");
                    txtServerMesaj.Clear();
                    txtServerMesaj.Focus();
                }
                else
                {
                    MessageBox.Show("Bağlantı yok!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                AddMessage($"Mesaj gönderme hatası: {ex.Message}");
            }
        }
        private void Disconnect()
        {
            _isRunning = false;

            try
            {
                _stream?.Close();
                _client?.Close();
                _server?.Stop();
            }
            catch { }

            if (lbnBaglantiDurum.InvokeRequired)
            {
                lbnBaglantiDurum.Invoke(new Action(() =>
                {
                    lbnBaglantiDurum.Text = "Bağlantı kesildi";
                    lbnBaglantiDurum.ForeColor = Color.Red;
                }));
            }
            else
            {
                lbnBaglantiDurum.Text = "Bağlantı kesildi";
                lbnBaglantiDurum.ForeColor = Color.Red;
            }

            if (lbnClientUsername.InvokeRequired)
            {
                lbnClientUsername.Invoke(new Action(() =>
                {
                    lbnClientUsername.Text = "Katılımcı: Bağlantı kesildi";
                }));
            }
            else
            {
                lbnClientUsername.Text = "Katılımcı: Bağlantı kesildi";
            }

            if (txtServerMesaj.InvokeRequired)
            {
                txtServerMesaj.Invoke(new Action(() =>
                {
                    txtServerMesaj.Enabled = false;
                    btnServerGonder.Enabled = false;
                }));
            }
            else
            {
                txtServerMesaj.Enabled = false;
                btnServerGonder.Enabled = false;
            }
        }

        private void AddMessage(string message)
        {
            if (txtServerMesajlar.InvokeRequired)
            {
                txtServerMesajlar.Invoke(new Action(() =>
                {
                    txtServerMesajlar.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
                }));
            }
            else
            {
                txtServerMesajlar.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            }
        }

        private void ChatServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
            Application.Exit();
        }

        private void btnServerBaglantiyiKes_Click(object sender, EventArgs e)
        {
            Disconnect();
            MessageBox.Show("Bağlantı kesildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
