using System;
using System.IO.Ports;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HX711WeightReceiver
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cấu hình cổng COM: chỉnh sửa "COM3" theo cổng thực tế của bạn
            serialPort = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            serialPort.DataReceived += SerialPort_DataReceived;
            try
            {
                serialPort.Open();
                AppendText("Serial Port Opened...\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening COM3: " + ex.Message);
            }
        }

        // Xử lý sự kiện khi có dữ liệu từ cổng COM
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Đọc một dòng dữ liệu kết thúc bởi \n
                string data = serialPort.ReadLine();
                // Chuyển về UI thread để cập nhật TextBox
                this.Invoke((MethodInvoker)delegate {
                    AppendText(data + Environment.NewLine);
                });
            }
            catch (Exception ex)
            {
                // Có thể ghi log lỗi nếu cần
            }
        }

        // Hàm bổ trợ để thêm text vào TextBox
        private void AppendText(string text)
        {
            textBox1.AppendText(text);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
