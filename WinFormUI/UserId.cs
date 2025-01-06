using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USPS;

namespace WinFormUI
{
    public partial class UserId : Form
    {
        public UserId()
        {
            InitializeComponent();
            UspsUserId.TryGetValue(out userId);
            userIdTextBox.Text = userId;
        }
        public string userId;

        private async void Submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(userIdTextBox.Text))
            {
                userId = userIdTextBox.Text;
                if (await IsValidUserId())
                {
                    try
                    {
                        UspsUserId.SetUserId(userId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error setting up account: {ex.Message}", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show($"Not a valid user id", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async Task<bool> IsValidUserId()
        {
            var uspsApi = new UspsApi();
            var whiteHouseAddress = new Record
            {
                Id = "1",
                Street = "1600 PENNSYLVANIA AVE NW",
                Apartment = "",
                City = "WASHINGTON",
                State = "DC",
                Zip = "20500"
            };
            try
            {
                var results = await USPSHelper.ValidateAddress(whiteHouseAddress, userId, uspsApi);
                return results.Error == null;
            }
            catch
            {
                return false;
            }

        }

        private void createAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://reg.usps.com/entreg/RegistrationAction_input",
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }
    }
}
