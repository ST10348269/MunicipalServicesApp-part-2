using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        // Simple list to store reported issues (for Part 1)
        public static List<string> reportedIssues = new List<string>();

        public ReportIssuesForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Hide();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Files|*.pdf|All Files|*.*";
            openFile.Title = "Select a file to attach";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                lblFileName.Text = openFile.FileName;
                UpdateProgress();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please provide a description of the issue.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save the issue
            string issue = $"Location: {txtLocation.Text} | Category: {cmbCategory.SelectedItem} | Description: {rtbDescription.Text} | File: {lblFileName.Text}";
            reportedIssues.Add(issue);

            // Success message
            MessageBox.Show("Thank you! Your issue has been submitted successfully.\n\nYou are helping improve your community!",
                            "Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset the form
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            lblFileName.Text = "No file selected";
            progressBar.Value = 0;
            lblEngagement.Text = "You're helping your community!";
        }

        // This method updates the progress bar and encouraging message
        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                progress += 25;
            if (cmbCategory.SelectedIndex != -1)
                progress += 25;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
                progress += 25;
            if (lblFileName.Text != "No file selected")
                progress += 25;

            progressBar.Value = progress;

            // Encouraging messages
            if (progress == 0)
                lblEngagement.Text = "You're helping your community!";
            else if (progress <= 25)
                lblEngagement.Text = "Good start! Keep going...";
            else if (progress <= 50)
                lblEngagement.Text = "You're doing great!";
            else if (progress <= 75)
                lblEngagement.Text = "Almost done – your report will make a difference!";
            else
                lblEngagement.Text = "Excellent! Ready to submit.";
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void txtLocation_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void rtbDescription_TextChanged_1(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please provide a description of the issue.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save the issue
            string issue = $"Location: {txtLocation.Text} | Category: {cmbCategory.SelectedItem} | Description: {rtbDescription.Text} | File: {lblFileName.Text}";
            reportedIssues.Add(issue);

            // Success message
            MessageBox.Show("Thank you! Your issue has been submitted successfully.\n\nYou are helping improve your community!",
                            "Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset the form
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            lblFileName.Text = "No file selected";
            progressBar.Value = 0;
            lblEngagement.Text = "You're helping your community!";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            rtbIssues.Clear();

            if (reportedIssues.Count == 0)
            {
                rtbIssues.Text = "No issues have been reported yet.";
            }
            else
            {
                rtbIssues.AppendText("=== REPORTED ISSUES ===\n\n");

                for (int i = 0; i < reportedIssues.Count; i++)
                {
                    rtbIssues.AppendText((i + 1) + ". " + reportedIssues[i] + "\n\n");
                }
            }
        }
    }
}