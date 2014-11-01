using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Script.Serialization;
using System.Globalization;

namespace TranslateChineseByStep
{
    public partial class Form1 : Form
    {
        JavaScriptSerializer serializer;
        public Form1()
        {
            InitializeComponent();
            serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
        }
        string[] lstLoadedFiles = null;
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Environment.CurrentDirectory;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = folderBrowserDialog1.SelectedPath;
                loadFile();
            }
        }
        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            string[] searchPatterns = searchPattern.Split('|');
            List<string> files = new List<string>();
            foreach (string sp in searchPatterns)
                files.AddRange(System.IO.Directory.GetFiles(path, sp, searchOption));
            files.Sort();
            return files.ToArray();
        }
        private void loadFile()
        {
            if (label1.Text != string.Empty)
            {
                lstLoadedFiles = GetFiles(label1.Text, txtPatternFileLoad.Text, SearchOption.AllDirectories);
                lblCountFile.Text = lstLoadedFiles.Length.ToString();
            }
        }
        int readIndex = 0;
        bool nextFile = true;
        string fileContent = string.Empty;
        string fileName = string.Empty;
        string PLang = string.Empty;
        bool mustSave = false;
        private void btnNext_Click(object sender, EventArgs e)
        {
            PLang = (comboBox1.SelectedItem as MyLang)._key;
            if (nextFile)//next file
            {
                nextFile = false;
                if (lstLoadedFiles != null && lstLoadedFiles.Length > nmFileIndex.Value)
                {
                    fileName = lstLoadedFiles[(int)nmFileIndex.Value];
                    nmFileIndex.Value = nmFileIndex.Value + 1;
                    fileContent = File.ReadAllText(fileName, Encoding.UTF8);
                    readIndex = 0;
                    richText_Vi.Text = fileContent;
                    richText_En.Text = fileContent;
                }
                else
                {
                    MessageBox.Show("Finish");
                    return;
                }
            }
            if (mustSave)
            {
                mustSave = false;
                dicts.Add(txtSelectCN.Text, new MyDict() { Vi = txtSelectVi.Text, En = txtSelectEN.Text });
                SaveRichtext();
            }
            //ReadNext(readIndex, fileContent);
            ReadNext2(readIndex, fileContent, false);
        }
        string showFormat = " {0} ";
        private void SaveRichtext()
        {

            richText_En.Text = richText_En.Text.Replace(txtSelectCN.Text, string.Format(showFormat, txtSelectEN.Text.Replace("'", "\\'")));

            fileContent = richText_En.Text;
            var fname = Path.GetFileNameWithoutExtension(fileName);
            var fext = Path.GetExtension(fileName);
            var fpath = Path.GetDirectoryName(fileName);
            if (PLang != "en")
            {
                richText_Vi.Text = richText_Vi.Text.Replace(txtSelectCN.Text, string.Format(showFormat, txtSelectVi.Text.Replace("'", "\\'")));
                File.WriteAllText(Path.Combine(fpath, fname + "_" + PLang + fext + "x"), richText_Vi.Text);
            }
            File.WriteAllText(Path.Combine(fpath, fname + "_en" + fext + "x"), richText_En.Text);
            selectedstring.Clear();
        }

        private readonly Regex cjkCharRegex = new Regex(@"\p{IsCJKUnifiedIdeographs}");
        public bool IsChinese(char c)
        {
            UnicodeCategory cat = char.GetUnicodeCategory(c);
            return (cat == UnicodeCategory.OtherLetter);
            //bool _return=false;
            //try
            //{
            //    _return = cjkCharRegex.IsMatch(c.ToString());
            //}
            //catch (Exception)
            //{

            //}
            //return _return;
        }
        //public bool IsChinese(char c)
        //{
        //    return (c >= 0x20000 && c <= 0xFA2D);
        //}
        int StartIndex = -1;
        int EndIndex = -1;
        StringBuilder selectedstring = new StringBuilder();
        MyPostGet mypostget = null;
        Dictionary<string, MyDict> dicts = new Dictionary<string, MyDict>();
        private void ReadNext2(int readIndex, string fileContent, bool _auto)
        {
            if (mypostget == null)
            {
                mypostget = new MyPostGet(_auto);
            }
            while (readIndex < fileContent.Length)
            {
                if (IsChinese(fileContent[readIndex]))
                {
                    selectedstring.Append(fileContent[readIndex]);
                    if (StartIndex == -1)
                    {
                        StartIndex = readIndex;
                    }
                }
                else if (StartIndex > -1)
                {

                    cbChines.Items.Clear();
                    txtSelectCN.Text = selectedstring.ToString();
                    if (dicts.ContainsKey(txtSelectCN.Text))
                    {
                        var objTranslated = dicts[txtSelectCN.Text];
                        txtSelectVi.Text = objTranslated.Vi;
                        txtSelectEN.Text = objTranslated.En;
                        SaveRichtext();
                        StartIndex = -1;
                    }
                    else
                    {
                        EndIndex = readIndex - StartIndex;
                        richText_Vi.Select(StartIndex, EndIndex);
                        richText_En.Select(StartIndex, EndIndex);
                        richText_Vi.Select(StartIndex, EndIndex);
                        richText_En.SelectionColor = Color.Red;
                        //using (WebClient wcl = new WebClient())
                        //{
                        //    wcl.Encoding = Encoding.UTF8;
                        //    string download = wcl.DownloadString("https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=en&hl=en-US&dt=t&dt=bd&dj=1&source=icon&q=" + Uri.EscapeDataString(txtSelectCN.Text));
                        string download = mypostget.GET("https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=en&hl=en-US&dt=t&dt=bd&dj=1&source=icon&q=" + Uri.EscapeDataString(txtSelectCN.Text), string.Empty);
                        if (download != string.Empty)
                        {

                            dynamic obj = serializer.Deserialize(download, typeof(object));
                            if (obj.sentences != null)
                            {
                                txtSelectEN.Text = obj.sentences[0].trans;
                            }
                            if (obj.dict != null && obj.dict[0].entry != null)
                            {

                                changeSelect = false;
                                foreach (var item in obj.dict[0].entry)
                                {

                                    cbChines.Items.Add(item.word);
                                }
                                if (cbChines.Items.Count > 1)
                                {
                                    cbChines.SelectedIndex = 1;
                                }
                                else if (cbChines.Items.Count == 1)
                                {
                                    cbChines.SelectedIndex = 0;
                                }
                            }

                            //}
                        }
                        StartIndex = -1;
                        txtSelectVi.Text = string.Empty;
                        txtSelectVi.Focus();
                        mustSave = true;
                        if (_auto)
                        {
                            button5_Click(null, null);
                            dicts.Add(txtSelectCN.Text, new MyDict() { Vi = txtSelectVi.Text, En = txtSelectEN.Text });
                            SaveRichtext();
                        }
                        //button5.PerformClick();
                        //btnNext.PerformClick();
                        return;
                    }
                }
                readIndex++;
                //ReadNext(readIndex, fileContent);
            }
            if (!_auto)
            {
                nextFile = true;
                //MessageBox.Show("next file");
                btnNext.PerformClick();
            }
        }

        bool changeSelect = false;
        private void cbChines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changeSelect)
            {
                txtSelectEN.Text = cbChines.SelectedItem.ToString();
            }
            else
            {

                changeSelect = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PLang = (comboBox1.SelectedItem as MyLang)._key;
            if (label1.Text != string.Empty)
            {
                string basefolder = label1.Text;
                string my_path = string.Empty;
                var listFiles = GetFiles(basefolder, "*.htmlx|*.jsx", SearchOption.AllDirectories);
                foreach (var fullpath in listFiles)
                {

                    var fname = Path.GetFileNameWithoutExtension(fullpath);
                    var fpath = Path.GetDirectoryName(fullpath);
                    var fext = Path.GetExtension(fullpath).Replace("x", string.Empty);
                    if (fullpath.EndsWith("en.htmlx") || fullpath.EndsWith("en.jsx"))
                    {
                        my_path = fpath.Replace(basefolder, basefolder + "_en");
                        fname = fname.Replace("_en", string.Empty);
                        //fname = fname.Replace(".", "");
                    }
                    else if (fullpath.EndsWith(PLang + ".htmlx") || fullpath.EndsWith(PLang + ".jsx"))
                    {
                        my_path = fpath.Replace(basefolder, basefolder + "_" + PLang);
                        fname = fname.Replace("_" + PLang, string.Empty);
                        //fname = fname.Replace(".", "");
                    }
                    else
                    {
                        continue;
                    }
                    if (!Directory.Exists(my_path))
                    {
                        Directory.CreateDirectory(my_path);
                    }
                    string dataFile = File.ReadAllText(fullpath, Encoding.UTF8);
                    File.WriteAllText(my_path + "\\" + fname + fext, dataFile, Encoding.UTF8);
                }
                MessageBox.Show("Finish");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mypostget == null)
            {
                mypostget = new MyPostGet(false);
            }
            string download = mypostget.GET("https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=" + PLang + "&hl=en-US&dt=t&dt=bd&dj=1&source=icon&q=" + Uri.EscapeDataString(txtSelectCN.Text), string.Empty);
            if (download != string.Empty)
            {

                dynamic obj = serializer.Deserialize(download, typeof(object));
                if (obj.sentences != null)
                {
                    txtSelectVi.Text = obj.sentences[0].trans;
                    txtSelectVi.Focus();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (mypostget == null)
            {
                mypostget = new MyPostGet(false);
            }
            string download = mypostget.GET("https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=" + PLang + "&hl=en-US&dt=t&dt=bd&dj=1&source=icon&q=" + Uri.EscapeDataString(txtSelectEN.Text), string.Empty);
            if (download != string.Empty)
            {

                dynamic obj = serializer.Deserialize(download, typeof(object));
                if (obj.sentences != null)
                {
                    txtSelectVi.Text = obj.sentences[0].trans;
                    txtSelectVi.Focus();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(new MyLang() { _key = "af", _value = "Afrikaans" });
            comboBox1.Items.Add(new MyLang() { _key = "ar", _value = "Arabic" });
            comboBox1.Items.Add(new MyLang() { _key = "az", _value = "Azerbaijani" });
            comboBox1.Items.Add(new MyLang() { _key = "be", _value = "Belarusian" });
            comboBox1.Items.Add(new MyLang() { _key = "bg", _value = "Bulgarian" });
            comboBox1.Items.Add(new MyLang() { _key = "bn", _value = "Bengali" });
            comboBox1.Items.Add(new MyLang() { _key = "bs", _value = "Bosnian" });
            comboBox1.Items.Add(new MyLang() { _key = "ca", _value = "Catalan" });
            comboBox1.Items.Add(new MyLang() { _key = "ceb", _value = "Cebuano" });
            comboBox1.Items.Add(new MyLang() { _key = "cs", _value = "Czech" });
            comboBox1.Items.Add(new MyLang() { _key = "cy", _value = "Welsh" });
            comboBox1.Items.Add(new MyLang() { _key = "da", _value = "Danish" });
            comboBox1.Items.Add(new MyLang() { _key = "de", _value = "German" });
            comboBox1.Items.Add(new MyLang() { _key = "el", _value = "Greek" });
            comboBox1.Items.Add(new MyLang() { _key = "en", _value = "English" });
            comboBox1.Items.Add(new MyLang() { _key = "eo", _value = "Esperanto" });
            comboBox1.Items.Add(new MyLang() { _key = "es", _value = "Spanish" });
            comboBox1.Items.Add(new MyLang() { _key = "et", _value = "Estonian" });
            comboBox1.Items.Add(new MyLang() { _key = "eu", _value = "Basque" });
            comboBox1.Items.Add(new MyLang() { _key = "fa", _value = "Persian" });
            comboBox1.Items.Add(new MyLang() { _key = "fi", _value = "Finnish" });
            comboBox1.Items.Add(new MyLang() { _key = "fr", _value = "French" });
            comboBox1.Items.Add(new MyLang() { _key = "ga", _value = "Irish" });
            comboBox1.Items.Add(new MyLang() { _key = "gl", _value = "Galician" });
            comboBox1.Items.Add(new MyLang() { _key = "gu", _value = "Gujarati" });
            comboBox1.Items.Add(new MyLang() { _key = "ha", _value = "Hausa" });
            comboBox1.Items.Add(new MyLang() { _key = "hi", _value = "Hindi" });
            comboBox1.Items.Add(new MyLang() { _key = "hmn", _value = "Hmong" });
            comboBox1.Items.Add(new MyLang() { _key = "hr", _value = "Croatian" });
            comboBox1.Items.Add(new MyLang() { _key = "ht", _value = "Haitian Creole" });
            comboBox1.Items.Add(new MyLang() { _key = "hu", _value = "Hungarian" });
            comboBox1.Items.Add(new MyLang() { _key = "hy", _value = "Armenian" });
            comboBox1.Items.Add(new MyLang() { _key = "id", _value = "Indonesian" });
            comboBox1.Items.Add(new MyLang() { _key = "ig", _value = "Igbo" });
            comboBox1.Items.Add(new MyLang() { _key = "is", _value = "Icelandic" });
            comboBox1.Items.Add(new MyLang() { _key = "it", _value = "Italian" });
            comboBox1.Items.Add(new MyLang() { _key = "iw", _value = "Hebrew" });
            comboBox1.Items.Add(new MyLang() { _key = "ja", _value = "Japanese" });
            comboBox1.Items.Add(new MyLang() { _key = "jw", _value = "Javanese" });
            comboBox1.Items.Add(new MyLang() { _key = "ka", _value = "Georgian" });
            comboBox1.Items.Add(new MyLang() { _key = "km", _value = "Khmer" });
            comboBox1.Items.Add(new MyLang() { _key = "kn", _value = "Kannada" });
            comboBox1.Items.Add(new MyLang() { _key = "ko", _value = "Korean" });
            comboBox1.Items.Add(new MyLang() { _key = "la", _value = "Latin" });
            comboBox1.Items.Add(new MyLang() { _key = "lo", _value = "Lao" });
            comboBox1.Items.Add(new MyLang() { _key = "lt", _value = "Lithuanian" });
            comboBox1.Items.Add(new MyLang() { _key = "lv", _value = "Latvian" });
            comboBox1.Items.Add(new MyLang() { _key = "mi", _value = "Maori" });
            comboBox1.Items.Add(new MyLang() { _key = "mk", _value = "Macedonian" });
            comboBox1.Items.Add(new MyLang() { _key = "mn", _value = "Mongolian" });
            comboBox1.Items.Add(new MyLang() { _key = "mr", _value = "Marathi" });
            comboBox1.Items.Add(new MyLang() { _key = "ms", _value = "Malay" });
            comboBox1.Items.Add(new MyLang() { _key = "mt", _value = "Maltese" });
            comboBox1.Items.Add(new MyLang() { _key = "ne", _value = "Nepali" });
            comboBox1.Items.Add(new MyLang() { _key = "nl", _value = "Dutch" });
            comboBox1.Items.Add(new MyLang() { _key = "no", _value = "Norwegian" });
            comboBox1.Items.Add(new MyLang() { _key = "pa", _value = "Punjabi" });
            comboBox1.Items.Add(new MyLang() { _key = "pl", _value = "Polish" });
            comboBox1.Items.Add(new MyLang() { _key = "pt", _value = "Portuguese" });
            comboBox1.Items.Add(new MyLang() { _key = "ro", _value = "Romanian" });
            comboBox1.Items.Add(new MyLang() { _key = "ru", _value = "Russian" });
            comboBox1.Items.Add(new MyLang() { _key = "sk", _value = "Slovak" });
            comboBox1.Items.Add(new MyLang() { _key = "sl", _value = "Slovenian" });
            comboBox1.Items.Add(new MyLang() { _key = "so", _value = "Somali" });
            comboBox1.Items.Add(new MyLang() { _key = "sq", _value = "Albanian" });
            comboBox1.Items.Add(new MyLang() { _key = "sr", _value = "Serbian" });
            comboBox1.Items.Add(new MyLang() { _key = "sv", _value = "Swedish" });
            comboBox1.Items.Add(new MyLang() { _key = "sw", _value = "Swahili" });
            comboBox1.Items.Add(new MyLang() { _key = "ta", _value = "Tamil" });
            comboBox1.Items.Add(new MyLang() { _key = "te", _value = "Telugu" });
            comboBox1.Items.Add(new MyLang() { _key = "th", _value = "Thai" });
            comboBox1.Items.Add(new MyLang() { _key = "tl", _value = "Filipino" });
            comboBox1.Items.Add(new MyLang() { _key = "tr", _value = "Turkish" });
            comboBox1.Items.Add(new MyLang() { _key = "uk", _value = "Ukrainian" });
            comboBox1.Items.Add(new MyLang() { _key = "ur", _value = "Urdu" });
            comboBox1.Items.Add(new MyLang() { _key = "vi", _value = "Vietnamese" });
            comboBox1.Items.Add(new MyLang() { _key = "yi", _value = "Yiddish" });
            comboBox1.Items.Add(new MyLang() { _key = "yo", _value = "Yoruba" });
            comboBox1.Items.Add(new MyLang() { _key = "zh-CN", _value = "Chinese (Simplified)" });
            comboBox1.Items.Add(new MyLang() { _key = "zh-TW", _value = "Chinese (Traditional)" });
            comboBox1.Items.Add(new MyLang() { _key = "zu", _value = "Zulu" });
            comboBox1.SelectedIndex = 14;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var rs = MessageBox.Show("Are you sure ?", "Confirm", MessageBoxButtons.OKCancel);
            //if (rs == DialogResult.OK)
            //{
                Environment.Exit(0);
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (lstLoadedFiles != null && lstLoadedFiles.Length > nmFileIndex.Value)
            {
                int iniindex = (int)nmFileIndex.Value;
                for (int i = iniindex; i < lstLoadedFiles.Length; i++)
                {
                    fileName = lstLoadedFiles[i];

                    fileContent = File.ReadAllText(fileName, Encoding.UTF8);
                    readIndex = 0;
                    this.Invoke(new Action(() =>
                    {
                        nmFileIndex.Value = nmFileIndex.Value + 1;
                    }));
                    this.Invoke(new Action(() =>
                    {
                        richText_Vi.Text = fileContent;
                        richText_En.Text = fileContent;
                        ReadNext2(readIndex, fileContent, true);
                    }));
                }

            }
            else
            {
                MessageBox.Show("Finish");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            btnNext.Enabled = false;
            PLang = (comboBox1.SelectedItem as MyLang)._key;
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
