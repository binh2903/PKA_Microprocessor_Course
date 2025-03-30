using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace Giaotiep
{
    public partial class Form1 : Form
    {
        // Khai báo đối tượng SerialPort
        SerialPort _mySerialPort = new SerialPort();
        double Weight = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        // Khi Form load, liệt kê các cổng COM hiện có
        private void Form1_Load(object sender, EventArgs e)
        {
            cboBoxCOM.DataSource = SerialPort.GetPortNames();
        }

        // Nút Connect
        private void butConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _mySerialPort.PortName = cboBoxCOM.Text;
                _mySerialPort.BaudRate = 9600;
                _mySerialPort.DataReceived += new SerialDataReceivedEventHandler(_mySerialPort_DataReceived);
                _mySerialPort.Open();

                if (_mySerialPort.IsOpen)
                {
                    labelTrangThai.Text = "Connected";
                    labelTrangThai.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to COM: " + ex.Message);
            }
        }

        // Nút Disconnect
        private void butDisconect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mySerialPort.IsOpen)
                {
                    _mySerialPort.Close();
                }
                labelTrangThai.Text = "Disconnected";
                labelTrangThai.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disconnecting: " + ex.Message);
            }
        }

        // Nút Exit
        private void butExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mySerialPort.IsOpen)
                    _mySerialPort.Close();
            }
            catch { }
            Application.Exit();
        }

        // Xử lý sự kiện nhận dữ liệu từ PIC
        private void _mySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Đọc một dòng dữ liệu từ Serial
                string incomingData = _mySerialPort.ReadLine().Trim();

                // Kiểm tra xem dữ liệu có hợp lệ không
                if (double.TryParse(incomingData, out double receivedWeight))
                {
                    this.Invoke(new Action(() =>
                    {
                        Weight = receivedWeight;
                        labelWeight.Text = Weight.ToString("F2") + " g"; // Hiển thị 2 số lẻ
                    }));
                }
                else
                {
                    Console.WriteLine("Dữ liệu không hợp lệ: " + incomingData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhận dữ liệu: " + ex.Message);
            }
        }

        // Nút tính toán BMI
        private void btBMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txHeight.Text))
                {
                    MessageBox.Show("Vui lòng nhập chiều cao (m)!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txHeight.Focus();
                    return;
                }

                double weightKg = Weight / 1000.0; // Chuyển gam sang kg
                double height = double.Parse(txHeight.Text);
                double bmi = weightKg / (height * height);

                string classification;
                if (bmi < 16)
                    classification = "Gầy độ III";
                else if (bmi < 17)
                    classification = "Gầy độ II";
                else if (bmi < 18.5)
                    classification = "Gầy độ I";
                else if (bmi < 25)
                    classification = "Bình thường";
                else if (bmi < 30)
                    classification = "Thừa cân";
                else if (bmi < 35)
                    classification = "Béo phì độ I";
                else if (bmi < 40)
                    classification = "Béo phì độ II";
                else
                    classification = "Béo phì độ III";

                MessageBoxIcon icon = (classification.Contains("Gầy") || classification.Contains("Béo"))
                                        ? MessageBoxIcon.Warning
                                        : MessageBoxIcon.Information;

                MessageBox.Show($"Cân nặng: {weightKg:F2} kg\n" +
                                $"Chiều cao: {height:F2} m\n" +
                                $"BMI: {bmi:F2} - {classification}",
                                "Kết quả BMI",
                                MessageBoxButtons.OK,
                                icon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính BMI: " + ex.Message);
            }
        }
    }
}
