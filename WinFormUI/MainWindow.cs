using CsvHelper;
using System.ComponentModel;
using System.Globalization;
using USPS;

namespace WinFormUI;

public partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();
        PromptForUserIdIfNeeded();
    }
    string userId;
    BindingList<Record> records = [];

    private void PromptForUserIdIfNeeded()
    {
        while (UspsUserId.TryGetValue(out userId) == false)
        {
            using UserId usedIdWindow = new();
            usedIdWindow.ShowDialog();
            usedIdWindow.Activate();
            userId = usedIdWindow.userId;
        }
    }
    private void PromptForUserId()
    {
        do
        {
            using UserId usedIdWindow = new();
            usedIdWindow.ShowDialog();
            usedIdWindow.Activate();
            userId = usedIdWindow.userId;
        }
        while (UspsUserId.TryGetValue(out userId) == false);
    }
    private void SaveFile_Click(object sender, EventArgs e)
    {
        using var saveFileDialog = new SaveFileDialog();

        // Set default file extension
        saveFileDialog.DefaultExt = "csv";
        saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
        saveFileDialog.FileName = "Addresses";

        // Show save file dialog
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            // Write content to the selected file
            File.WriteAllText(saveFileDialog.FileName, records.ToCSV());
        }

    }

    private async void UplaodFile_Click(object sender, EventArgs e)
    {
        SaveFile.Visible = false;
        records = ReadRecordsFromFile();
        DataGrid.DataSource = records;

        var uspsApi = new UspsApi();
        for (var i = 0; i < records.Count; i++)
        {
            try
            {
                records[i] = await USPSHelper.ValidateAddress(records[i], userId, uspsApi);
                DataGrid.FirstDisplayedScrollingRowIndex = i;
                if (records[i].Error == null)
                {
                    DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (records[i].Error == "address not found")
                {
                    DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
                else
                {
                    DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
            catch
            {
                continue;
            }
        }
        SaveFile.Visible = true;

    }
    private static BindingList<Record> ReadRecordsFromFile()
    {
        using var openFileDialog = new OpenFileDialog();

        // Set file dialog properties
        openFileDialog.Filter = "CSV files (*.csv)|*.csv";
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string filePath = openFileDialog.FileName;

                using var streamReader = new StreamReader(filePath);
                using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
                var records = csvReader.GetRecords<Record>().ToList();

                return new BindingList<Record>(records);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        return [];
    }

    private void template_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        using var saveFileDialog = new SaveFileDialog();

        // Set default file extension
        saveFileDialog.DefaultExt = "csv";
        saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
        saveFileDialog.FileName = "Addresses template";

        // Show save file dialog
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            // Write content to the selected file
            File.WriteAllText(saveFileDialog.FileName, "ID,Street,Apartment,City,State,Zip");
        }
    }

    private void USPSlogo_Click(object sender, EventArgs e)
    {
        PromptForUserId();
    }
}
