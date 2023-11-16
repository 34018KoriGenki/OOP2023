using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace RssReader {
    public partial class Form1 : Form {
        IEnumerable<ItemData> items;
        string defaultSite = @"https://news.yahoo.co.jp/rss/";
        Dictionary<string, string> categorys = new Dictionary<string, string>();
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            wbBrowser.Navigated += WbBrowser_Navigated;
            wbBrowser.ProgressChanged += WbBrowser_ProgressChanged;
            wbBrowser.DocumentCompleted += WbBrowser_DocumentCompleted;
            var data = "";
            try {
                using (var wc = new WebClient()) {
                    wc.Encoding = Encoding.UTF8;

                    var tem = true;
                    do {
                        try {
                            var st = wc.DownloadString(defaultSite);
                            var matches = Regex.Matches(st, "<script((?!<script|/script>).|<script(?<depth>)|/script>(?<-depth>))*(?(depth)(?!))/script>");
                            foreach (var match in matches) {
                                if (match.ToString().Contains("{")) {
                                    data = match.ToString();
                                }
                            }
                            tem = false;

                        } catch (WebException ex) {
                            MessageBox.Show(ex.ToString().Contains("404") ? ex.Message : "ネット遅すぎ");
                        } catch (Exception ex) {
                            MessageBox.Show(ex.ToString());
                        }
                    } while (tem);
                    int first = data.IndexOf("{") - 1;
                    int end = data.LastIndexOf("}") - first + 1;

                    data = data.Substring(first, end);

                    var jsonDatas = JsonConvert.DeserializeXNode(data, "rssUrlList");

                    AddTitleList(jsonDatas, "categoryArticleRssItems");
                    AddTitleList(jsonDatas, "mediaArticleRssItems");
                    cbUrl.Text = defaultSite;
                    cbUrl.Items.Add(defaultSite);
                    wbBrowser.Navigate(defaultSite);

                }
            } catch (Exception) {
                MessageBox.Show("何かしらの問題発生");
                throw;
            }
        }

        private void AddTitleList(XDocument jsonDatas, string desc) {
            items = jsonDatas.Root.Descendants("rssUrlList").Descendants(desc)
                                .Select(x => new ItemData() {
                                    Name = x.Element("name").Value,
                                    Link = x.Element("url").Value,
                                });
            foreach (var item in items) {
                categorys.Add(item.Name, item.Link);
            }
            foreach (var category in categorys) {
                if (!cbCategory.Items.Contains(category.Key.ToString())) {
                    cbCategory.Items.Add(category.Key.ToString());
                }
            }
        }

        private void btGetUrl_Click(object sender, EventArgs e) {
            UpdateUrl();
            if (!cbUrl.Items.Contains(cbUrl.Text)) {
                cbUrl.Items.Add(cbUrl.Text);
            }
        }

        private void UpdateUrl() {
            if (cbUrl.Text == defaultSite) {
                wbBrowser.Navigate(defaultSite);

            }
            if (cbUrl.Text == "" || cbUrl.Text == defaultSite) return;
            items = null;
            lbRssTitle.Items.Clear();

            using (var wc = new WebClient()) {
                var tem = false;
                do {
                    try {
                        var url = wc.OpenRead(cbUrl.Text);
                        try {
                            XDocument xdoc = XDocument.Load(url);
                            items = xdoc.Root.Descendants("item")
                            .Select(x => new ItemData() {
                                Name = x.Element("title").Value,
                                Link = x.Element("link").Value,
                            });

                            foreach (var item in items) {
                                lbRssTitle.Items.Add(item.Name);
                            }
                            tem = false;
                        } catch (XmlException ex) {
                            wbBrowser.Navigate(cbUrl.Text);
                        }
                        tem = false;
                    } catch (WebException ex) {

                        MessageBox.Show("URLが無効です。\n入力しなおしてください。");
                        cbUrl.Text = defaultSite;
                        tem = true;
                    }
                } while (tem);
            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex != -1) {
                wbBrowser.Navigate(items.ToArray()[lbRssTitle.SelectedIndex].Link);
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e) {
            cbUrl.Text = defaultSite.Substring(0, defaultSite.Length - 5) +
                categorys[cbCategory.SelectedItem.ToString()];
            UpdateUrl();
        }

        private void WbBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
            ProgressBarChange();
        }

        private void WbBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) {
            progressBar1.Value = 10;
        }

        private void WbBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            progressBar1.Value = progressBar1.Maximum;
        }


        private void ProgressBarChange() {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)wbBrowser.DocumentStream.Length;
            progressBar1.Value = 0;
        }
    }
}

