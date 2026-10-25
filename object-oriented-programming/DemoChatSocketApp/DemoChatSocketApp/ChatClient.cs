using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoChatSocketApp
{

    public partial class ChatClient : Form
    {
        private string _username;
        private string _ipAddress;
        private int _port;
        private TcpClient _client;
        private NetworkStream _stream;
        private bool _isConnected = false;
        private string _serverUsername = string.Empty;

        public ChatClient(string username, string ipAddress, int port)
        {
            InitializeComponent();
            _username = username;
            _ipAddress = ipAddress;
            _port = port;

            this.FormClosing += ChatClient_FormClosing;
        }

        private async void ChatClient_Load(object sender, EventArgs e)
        {
            this.Text = $"Chat Client - {_username}";
            lbnBaglantiDurum.Text = "Bağlanıyor...";
            lbnBaglantiDurum.ForeColor = Color.Orange;
            lbnServerUsername.Text = "Sunucu: Bağlanıyor...";

            txtClientMesaj.Enabled = false;
            btnClientGonder.Enabled = false;

            await ConnectToServer();
        }
        private async Task ConnectToServer()
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(_ipAddress, _port);
                _stream = _client.GetStream();
                _isConnected = true;

                // Server'dan username'i al
                byte[] buffer = new byte[1024];
                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (receivedData.StartsWith("USERNAME:"))
                {
                    _serverUsername = receivedData.Substring(9);
                    lbnServerUsername.Text = $"Sunucu: {_serverUsername}";
                }

                // Kendi username'ini gönder
                byte[] usernameData = Encoding.UTF8.GetBytes($"USERNAME:{_username}");
                await _stream.WriteAsync(usernameData, 0, usernameData.Length);
                await _stream.FlushAsync();

                lbnBaglantiDurum.Text = "Bağlandı";
                lbnBaglantiDurum.ForeColor = Color.Green;

                txtClientMesaj.Enabled = true;
                btnClientGonder.Enabled = true;

                AddMessage($"Sunucuya bağlanıldı: {_ipAddress}:{_port}");
                AddMessage($"Sunucu sahibi: {_serverUsername}");

                // Mesaj dinlemeye başla
                await ReceiveMessages();
            }
            catch (Exception ex)
            {
                AddMessage($"Bağlantı hatası: {ex.Message}");
                lbnBaglantiDurum.Text = "Bağlantı başarısız";
                lbnBaglantiDurum.ForeColor = Color.Red;
                lbnServerUsername.Text = "Sunucu: Bağlantı başarısız";

                MessageBox.Show($"Sunucuya bağlanılamadı!\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (_isConnected && _client != null && _client.Connected)
                {
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        // Bağlantı kapandı
                        AddMessage("Sunucu bağlantıyı kesti.");
                        lbnServerUsername.Text = "Sunucu: Bağlantı kesildi";
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // USERNAME: protokolünü göz ardı et (mesajlaşma sırasında gelebilir)
                    if (!message.StartsWith("USERNAME:"))
                    {
                        AddMessage($"{_serverUsername}: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                if (_isConnected)
                {
                    AddMessage($"Mesaj alma hatası: {ex.Message}");
                }
            }
            finally
            {
                Disconnect();
            }
        }

        private async void btnClientGonder_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async void txtClientMesaj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                await SendMessage();
            }
        }


        private async Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(txtClientMesaj.Text))
                return;

            try
            {
                if (_stream != null && _client != null && _client.Connected)
                {
                    string message = txtClientMesaj.Text.Trim();
                    byte[] data = Encoding.UTF8.GetBytes(message);

                    await _stream.WriteAsync(data, 0, data.Length);
                    await _stream.FlushAsync();

                    AddMessage($"{_username}: {message}");
                    txtClientMesaj.Clear();
                    txtClientMesaj.Focus();
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
            _isConnected = false;

            try
            {
                _stream?.Close();
                _client?.Close();
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

            if (lbnServerUsername.InvokeRequired)
            {
                lbnServerUsername.Invoke(new Action(() =>
                {
                    lbnServerUsername.Text = "Sunucu: Bağlantı kesildi";
                }));
            }
            else
            {
                lbnServerUsername.Text = "Sunucu: Bağlantı kesildi";
            }

            if (txtClientMesaj.InvokeRequired)
            {
                txtClientMesaj.Invoke(new Action(() =>
                {
                    txtClientMesaj.Enabled = false;
                    btnClientGonder.Enabled = false;
                }));
            }
            else
            {
                txtClientMesaj.Enabled = false;
                btnClientGonder.Enabled = false;
            }
        }

        private void AddMessage(string message)
        {
            if (txtClientMesajlar.InvokeRequired)
            {
                txtClientMesajlar.Invoke(new Action(() =>
                {
                    txtClientMesajlar.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
                }));
            }
            else
            {
                txtClientMesajlar.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            }
        }

        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
            Application.Exit();
        }

        private void txtClientMesaj_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

