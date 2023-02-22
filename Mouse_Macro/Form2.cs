using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Mouse_Macro
{
    public partial class TimePicker : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo); //마우스 클릭 이벤트를 위해서 필요한 코드
        private const int MOUSEEVENTF_MOVE = 0x8000; // 마우스 이동
        private const int MOUSEEVENTF_LEFTDOWN = 0x02; //마우스 왼쪽 버튼 누르기
        private const int MOUSEEVENTF_LEFTUP = 0x04; //마우스 왼쪽 버튼 떼기
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08; //마우스 오른쪽 버튼 누르기
        private const int MOUSEEVENTF_RIGHTUP = 0x10; //마우스 오른쪽 버튼 떼기

        System.Timers.Timer timer_time = new System.Timers.Timer(); // timer_time(특정 시간에 작동하는 타이머)할당

        // 재정렬시 사용할 리스트
        List<DataGrid> list = new List<DataGrid>();

        public class DataGrid
        {
            public string sDate { get; set; }
            public string sTime { get; set; }
            public string sFilename { get; set; }
        }

        DataTable table = new DataTable(); //DataTable table로 선언
        string sMsg = "";

        public TimePicker()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // datapicker를 날짜와 시간으로 구분
            DP.Value = DateTime.Now;
            TP.Value = DateTime.Now;

            // 테이블은 날짜형이 아닌 스트링으로
            table.Columns.Add("날짜", typeof(string));
            table.Columns.Add("동작시간", typeof(string));
            table.Columns.Add("파일명", typeof(string));

            dataGridView.DataSource = table;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ReadOnly = true;

        }

        // 그리드와 입력값 체크
        private bool F_ValueCheck(string tDate, string tTime, string tFile)
        {
            bool bCheck = true;

            if (dataGridView.Rows.Count == 0) return bCheck;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if(dataGridView.Rows[i].Cells[0].Value.ToString() == tDate && dataGridView.Rows[i].Cells[1].Value.ToString() == tTime)
                {
                    sMsg = "";
                    sMsg += "동일한 날짜와 시간이 존재합니다." + Environment.NewLine;
                    sMsg += "날짜와 시간을 확인하세요." + Environment.NewLine;
                    MessageBox.Show(sMsg, "동일한 시간 존재", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    goto ValueFail;
                }

                if (dataGridView.Rows[i].Cells[2].Value.ToString() == tFile)
                {
                    sMsg = "";
                    sMsg += "동일한 파일명이 존재합니다." + Environment.NewLine;
                    sMsg += "파일명을 확인하세요." + Environment.NewLine;
                    MessageBox.Show(sMsg, "동일한 파일명 존재", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    goto ValueFail;
                }
            }

            return bCheck;

        ValueFail:
            bCheck = false;
            return bCheck;
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            string sDate = DP.Text.ToString();
            string sTime = TP.Text.ToString();
            string sFile = Textbox_filename.Text.Trim().ToString();

            if (F_ValueCheck(sDate, sTime, sFile) == false) return;

            table.Rows.Add(sDate, sTime, sFile);
        }

        private void Btn_del_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0) return;

            dataGridView.Rows.Remove(dataGridView.Rows[dataGridView.CurrentCell.RowIndex]);            
        }

        private void Btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0) return;

            string sDate = DP.Text.ToString();
            string sTime = TP.Text.ToString();
            string sFile = Textbox_filename.Text.Trim().ToString();

            if (F_ValueCheck(sDate, sTime, sFile) == false) return;

            DataGridViewRow cRow = dataGridView.Rows[dataGridView.CurrentCell.RowIndex];

            cRow.Cells[0].Value = sDate;
            cRow.Cells[1].Value = sTime;
            cRow.Cells[2].Value = sFile;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows.Count == 0) return;

            DataGridViewRow cRow = dataGridView.Rows[dataGridView.CurrentCell.RowIndex];

            DP.Value = Convert.ToDateTime(cRow.Cells[0].Value);
            TP.Value = Convert.ToDateTime(cRow.Cells[1].Value);
            Textbox_filename.Text = cRow.Cells[2].Value.ToString();
        }

        private void Textbox_filename_Click(object sender, EventArgs e)
        {
            Textbox_filename.SelectAll();
        }

        private void Btn_order_Click(object sender, EventArgs e)
        {
            //리스트
            list.Clear();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                list.Add(new DataGrid
                {
                    sDate = dataGridView.Rows[i].Cells[0].Value.ToString(),
                    sTime = dataGridView.Rows[i].Cells[1].Value.ToString(),
                    sFilename = dataGridView.Rows[i].Cells[2].Value.ToString()
                });
            }
            
            //linq로 재정렬 후 바인딩
            var query = list.OrderBy(x => x.sDate).ThenBy(x => x.sTime).ToList();

            dataGridView.DataSource = query;
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0) //열이 존재하지 않을 경우(예외처리)
            {                
                sMsg = "";
                sMsg += "입력값이 없습니다." + Environment.NewLine;
                sMsg += "매크로가 시작되지 않습니다." + Environment.NewLine;
                MessageBox.Show(sMsg, "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (Textbox_entertime.Text == "") //입력시간(분)이 없을 경우(예외처리)
            {   
                sMsg += "입력시간(분) 이 없습니다" + Environment.NewLine;
                sMsg += "매크로가 시작되지 않습니다." + Environment.NewLine;
                MessageBox.Show(sMsg, "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            label1.Text = "마우스 매크로 동작중";

            timer_time.Interval = 1000; //1초 간격으로 시간 받기
            timer_time.Elapsed += new ElapsedEventHandler(Timer_time_Elapsed);
            timer_time.AutoReset = true; //timer_time이벤트를 반복적으로 발생 (false => 간격으로 한번만 발생)
            timer_time.Enabled = true; //timer_time 실행 활성화

            Btn_add.Enabled = false;
            Btn_del.Enabled = false;
            Btn_edit.Enabled = false;
            Btn_order.Enabled = false;
            Btn_start.Enabled = false;
            DP.Enabled = false;
            TP.Enabled = false;

            Btn_end.Enabled = true;
            Textbox_entertime.Enabled = false;
            Textbox_filename.Enabled = false;
        }

        private void Timer_time_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime current_time = DateTime.Now; // 현재시간 선언
            for (int j = 0; j < table.Rows.Count; j++) //반복문을 통해 datagridview의 [날짜][동작시간]의 값을 읽음
            {
                DateTime picker_date = Convert.ToDateTime(dataGridView.Rows[j].Cells[0].Value.ToString());
                DateTime text_time = Convert.ToDateTime(dataGridView.Rows[j].Cells[1].Value.ToString());

                if (current_time.Date == picker_date.Date && current_time.Hour == text_time.Hour && current_time.Minute == text_time.Minute && current_time.Second == 0)
                { // 현재시간과 입력된 동작 시간을 비교한후, 만약 전부 같은 경우, if문 실행한다.
                    Cursor.Position = new Point(300, 350);
                    mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
                    Thread.Sleep(5000);

                    int text_timeenter = Convert.ToInt32(Textbox_entertime.Text); //입력시간(분)을 convert를 사용해 int로 변환
                    Thread.Sleep(text_timeenter * 1000); //일단 초 단위로 받는다.

                    Cursor.Position = new Point(400, 350);
                    mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
                    Thread.Sleep(5000);
                }
            }

        }

        private void Btn_end_Click(object sender, EventArgs e)
        {
            sMsg = "";
            sMsg += "매크로가 작동중입니다." + Environment.NewLine;
            sMsg += "매크로를 종료하시겠습니까?";
            if (MessageBox.Show(sMsg, "종료여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            label1.Text = "마우스 매크로 종료";
            Btn_add.Enabled = true;
            Btn_del.Enabled = true;
            Btn_edit.Enabled = true;
            Btn_order.Enabled = true;
            Btn_start.Enabled = true;            
            DP.Enabled = true;
            TP.Enabled = true;

            Btn_end.Enabled = true;
            Textbox_entertime.Enabled = true;
            Textbox_filename.Enabled = true;            
        }
    }
}
