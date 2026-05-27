using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSVFile
{
    public partial class frmTSVFile : Form
    {
        /// <summary>
        /// 關於視窗
        /// </summary>
        frmAbout about = new frmAbout();

        /// <summary>
        /// 單字清單
        /// </summary>
        WordCollection _WordList = new WordCollection();

        public frmTSVFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 更新 ListView 的內容
        /// </summary>
        private void UpdateListView()
        {
            lvwWord.BeginUpdate(); //暫停重繪
            // 清除 ListView 的所有項目
            lvwWord.Items.Clear();
            // 將 WordCollection 物件中的資料載入到 ListView 中
            foreach (WordItem item in _WordList)
            {
                // 建立 ListViewItem 物件
                ListViewItem lvi = new ListViewItem(item.Word);
                lvi.SubItems.Add(item.Phonogram);
                lvi.SubItems.Add(item.SoundPath);
                lvi.SubItems.Add(item.Explain);
                // 將 ListViewItem 物件加入到 ListView 中
                lvwWord.Items.Add(lvi);
            }
            lvwWord.EndUpdate(); //重繪;
        }

        /// <summary>
        /// 根據關鍵字更新 ListView
        /// </summary>
        private void UpdateListView(string keyword)
        {
            lvwWord.BeginUpdate();
            lvwWord.Items.Clear();

            keyword = keyword.Trim().ToLower();

            foreach (WordItem item in _WordList)
            {
                bool isMatch =
                    item.Word.ToLower().Contains(keyword) ||
                    item.Phonogram.ToLower().Contains(keyword) ||
                    item.SoundPath.ToLower().Contains(keyword) ||
                    item.Explain.ToLower().Contains(keyword);

                if (isMatch)
                {
                    ListViewItem lvi = new ListViewItem(item.Word);
                    lvi.SubItems.Add(item.Phonogram);
                    lvi.SubItems.Add(item.SoundPath);
                    lvi.SubItems.Add(item.Explain);

                    lvwWord.Items.Add(lvi);
                }
            }

            lvwWord.EndUpdate();

            this.tsslMessage.Text = $"搜尋完成，共找到 {lvwWord.Items.Count} 筆資料";
        }
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            // 顯示關於視窗
            about.ShowDialog(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;

            if (keyword.Trim() == "")
            {
                MessageBox.Show("請輸入搜尋關鍵字", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateListView(keyword);
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            UpdateListView();

            this.tsslMessage.Text = $"已顯示全部，共 {_WordList.Count} 筆資料";
        }
        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            // 設定檔案類型過濾器，讓使用者只能選擇 TSV、TXT 或所有檔案
            ofd.Filter = "TSV files (*.tsv)|*.tsv|Text files (*.txt)|*.txt|All files (*.*) | *.* ";
            // 設定視窗標題
            ofd.Title = "開啟檔案";
            // 設定初始目錄為程式所在目錄
            ofd.InitialDirectory = Application.StartupPath;

            DialogResult dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                // 讀取檔案並且將每一行的資料放入字串陣列
                string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);

                // 將字串陣列的資料載入到 WordCollection 物件中
                _WordList.LoadFromStringArray(lines);

                // 將 WordCollection 物件中的資料載入到 ListView 中
                UpdateListView();

                this.tsslMessage.Text = $"{_WordList.Count} 單字已成功載入";
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTSVFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("確定要離開嗎?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true; // 取消關閉
            }
        }

        private void frmTSVFile_Load(object sender, EventArgs e)
        {
            this.tsslMessage.Text = "";
        }


    }
}
