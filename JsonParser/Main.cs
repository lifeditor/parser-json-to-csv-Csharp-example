using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace JsonParser
{
    public partial class frmMain : Form
    {
        private class DictionaryKey
        {
            public const string DELTA = "delta";
            public const string BM = "bm";
            public const string DESC = "desc";
            public const string ID = "id";
            public const string ODDS = "odds";
        }


        public frmMain()
        {
            InitializeComponent();
        }


        private void progressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            messageText.Text = Constants.MSG_DOWNLOAD_PROGRESS + e.BytesReceived + progressBar.Value;
        }


        private void completed(object sender, AsyncCompletedEventArgs e)
        {
            progressBar.Value = 0;
            messageText.Text = (e.Error != null) ? e.Error.Message : Constants.MSG_DOWNLOAD_COMPLETED;
        }


        private void downloadFile()
        {
            WebClient webCl = new WebClient();
            webCl.DownloadFileAsync(new Uri(Constants.URL), String
                .Concat(Constants.SOURCE_DIRECTORY_NAME, "/", Constants.DOWNLOAD_FILE_NAME));
            webCl.DownloadProgressChanged += new DownloadProgressChangedEventHandler(progressChanged);
            webCl.DownloadFileCompleted += new AsyncCompletedEventHandler(completed);
        }


        private void buttonDownload_Click(object sender, EventArgs e)
        {
            downloadFile();
        }


        private Dictionary<string, object> SelectDictionary(object obj)
        {
            return (Dictionary<string, object>)obj;
        }


        private List<string> convertToCSV(string dataJson)
        {
            List<string> stringList = new List<string>();

            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;

            try
            {
                Dictionary<string, object> JSONObj = serializer.Deserialize<Dictionary<string, object>>(dataJson);

                var delta = SelectDictionary(JSONObj[DictionaryKey.DELTA]);
                var bm = SelectDictionary(delta[DictionaryKey.BM]);

                foreach (KeyValuePair<string, object> bookmaker in bm)
                {
                    var data = SelectDictionary(bookmaker.Value);
                    var desc = SelectDictionary(data[DictionaryKey.DESC]);
                    string id = desc[DictionaryKey.ID].ToString();

                    foreach (KeyValuePair<string, object> item in data)
                    {
                        if (item.Key != DictionaryKey.DESC)
                        {
                            var oddsData = SelectDictionary(item.Value);
                            if (oddsData.Keys.Contains(DictionaryKey.ODDS))
                            {
                                var odds = SelectDictionary(oddsData[DictionaryKey.ODDS]);
                                foreach (KeyValuePair<string, object> odd in odds)
                                {
                                    stringList.Add(String
                                        .Concat(id, Constants.CSV_DELIMITER, odd.Key, Constants.CSV_DELIMITER, odd.Value));
                                }
                            }
                        }
                    }

                }
            }
            catch
            {
                stringList.Add(Constants.STRING_BAD_FORMAT);
            }

            if (stringList.Count == 0) stringList.Add(Constants.STRING_NO_ODDS);

            return stringList;
        }


        private void buttonParse_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = Directory.GetFiles(Constants.SOURCE_DIRECTORY_NAME, Constants.FILE_SOURCE_FILTER);

                foreach (string file in files)
                {
                    using (StreamReader reader = File.OpenText(file))
                    {
                        using (FileStream DestinationStream = File
                            .Create(String
                                .Concat(Constants.SOURCE_DIRECTORY_NAME, "/", Path.GetFileNameWithoutExtension(file), Constants.FILE_DESTINATION_EXTENSION)))
                        {
                            List<string> stringList = convertToCSV(reader.ReadToEnd());
                            using (StreamWriter writeInCsv = new StreamWriter(DestinationStream, Encoding.Unicode))
                            {
                                foreach (var line in stringList)
                                {
                                    writeInCsv.WriteLine(line);
                                }
                            }
                        }
                    }
                }

                messageText.Text = Constants.MSG_CONVERTED;
            }
            catch(Exception ex)
            {
                messageText.Text = ex.Message;
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            urlText.Text = Constants.URL;
        }
    }
}
