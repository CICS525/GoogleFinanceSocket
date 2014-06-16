using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoogleFinanceDownloader;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace GoogleFinanceDownloaderTest {
    public partial class FormGoogleFinanceTest : Form {
        #region Variables
        string downloadedData;
        #endregion

        #region Initialization
        public FormGoogleFinanceTest() {
            InitializeComponent();            
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            setTextBoxDataContentToDownloadData();
            updateURL();            
        }
        #endregion

        #region Control events
        private void buttonSave_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(richTextBoxData.Text)) {
                errorFunction("No data to save!");
                return;
            }

            try {
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName)) {
                        sw.Write(richTextBoxData.Text);
                    }
                }
            } catch (Exception exc) {
                errorFunction(exc.Message);
            }
        }

        private void uriParameterControl_ValueChanged(object sender, EventArgs e) {
            dateTimePickerSinceDate.Enabled = radioButtonSince.Checked;
            updateURL();
        }


        private void textBoxData_TextChanged(object sender, EventArgs e) {
            buttonSave.Enabled = !String.IsNullOrEmpty(richTextBoxData.Text);            
        }
        
        private void textBoxURL_TextChanged(object sender, EventArgs e) {            
            buttonDownload.Enabled = !String.IsNullOrEmpty(textBoxURL.Text);
        }
        
        private void buttonDownload_Click(object sender, EventArgs e) {
            Cursor currentCursor = Cursor.Current;
            currentCursor = Cursors.WaitCursor;

            try {
                downloadData();
            } catch (Exception exc) {
                errorFunction(exc.Message);
            } finally {
                Cursor.Current = currentCursor;
            }
        }

        private void downloadData() {
            string uri = textBoxURL.Text;

            if (String.IsNullOrEmpty(uri))
                return;

            using (WebClient wClient = new WebClient()) {
                downloadedData = wClient.DownloadString(uri);                
            }

            if (checkBoxRawData.Checked) {
                richTextBoxData.Text = downloadedData;
            }
            else {
                setTextBoxDataContentToDownloadData();
            }
        }
        
        private void checkBoxRawData_CheckedChanged(object sender, EventArgs e) {
            setTextBoxDataContentToDownloadData();
        }

        private void setTextBoxDataContentToDownloadData() {            
            if (String.IsNullOrEmpty(downloadedData)) {
                richTextBoxData.Text = string.Empty;
                return;
            }

            if (checkBoxRawData.Checked) {
                richTextBoxData.Text = downloadedData;
            }
            else {
                fillTextBoxWithProcessedData();
            }
        }

        private void fillTextBoxWithProcessedData() {
            using (MemoryStream ms = new MemoryStream(System.Text.Encoding.Default.GetBytes(downloadedData))) {
                DataProcessor dp = new DataProcessor();
                string errorMessage;
                string resultValue;

                resultValue = radioButtonLastQuoute.Checked ? dp.processStreamMadeOfOneMinuteBarsToExtractMostRecentOHLCVForCurrentDay(ms, out errorMessage) :
                    dp.processStreamMadeOfOneDayLinesToExtractHistoricalData(ms, out errorMessage);

                if (!String.IsNullOrEmpty(errorMessage)) {
                    richTextBoxData.Text = string.Empty;
                    throw new Exception(errorMessage);
                }
                else {
                    richTextBoxData.Text = resultValue;
                }
            }
        }
        #endregion

        #region Useful methods
        private void errorFunction(string errorMessage) {
            if (String.IsNullOrEmpty(errorMessage)) {
                Debug.Fail("No error message.");
                return;
            }

            MessageBox.Show(errorMessage, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Interaction with GoogleFinanceDownloader
        private void updateURL() {
            textBoxURL.Text = getDownloadURI();
        }

        private string getDownloadURI() {
            string ticker = textBoxTicker.Text;
            string exchange = textBoxExchange.Text;

            if (String.IsNullOrEmpty(ticker)) {                
                return string.Empty;
            }
            
            DownloadURIBuilder uriBuilder = new DownloadURIBuilder(exchange, ticker);
                        
            if (radioButtonAllData.Checked) {
                return uriBuilder.getGetPricesUrlToDownloadAllData(DateTime.Now);
            }
            else if (radioButtonLastQuoute.Checked) {
                return uriBuilder.getGetPricesUrlForLastQuote();
            }
            else if (radioButtonSince.Checked) {
                DateTime startDate = dateTimePickerSinceDate.Value.Date, 
                    endDate = DateTime.Now.Date;
                if (endDate < startDate) { //It's impossible to download data from the future. That's why no URL is returned in this case.
                    return string.Empty;
                }
                else {
                    return uriBuilder.getGetPricesUrlForRecentData(startDate, endDate);
                }
            }
            else {
                return string.Empty;
            }
        }
        #endregion
    }
}