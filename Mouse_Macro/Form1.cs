using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Timers;
using Timer = System.Timers.Timer;


namespace Mouse_Macro
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo); //마우스 클릭 이벤트를 위해서 필요한 코드
        private const int MOUSEEVENTF_MOVE = 0x8000; // 마우스 이동
        private const int MOUSEEVENTF_LEFTDOWN = 0x02; //마우스 왼쪽 버튼 누르기
        private const int MOUSEEVENTF_LEFTUP = 0x04; //마우스 왼쪽 버튼 떼기
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08; //마우스 오른쪽 버튼 누르기
        private const int MOUSEEVENTF_RIGHTUP = 0x10; //마우스 오른쪽 버튼 떼기


        System.Timers.Timer timer_time = new System.Timers.Timer(); // timer_time(특정 시간에 작동하는 타이머)할당
        DataTable table = new DataTable(); //DataTable table로 선언
        public Form1()
        {
            InitializeComponent();

            table.Columns.Add("날짜", typeof(DateTime));
            table.Columns.Add("동작시간", typeof(DateTime));
            table.Columns.Add("파일명", typeof(string));

            dataGridView.DataSource = table;

            this.Cursor = new Cursor(Cursor.Current.Handle); //커서 사용 선언
            this.Cursor = Cursors.Default; //커서 기본 형태(화살표)

            Btn_end.Enabled = false; // 입력할 경우에 종료 버튼 비활성화.
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            if(table.Rows.Count < 12)  //row값을 12개까지만 입력 가능하게 만듦 (예외처리)
            {
                if (Textbox_filename.Text == "") //만약 Textbox_file.Text값이 공백이라면 (예외처리)
                {
                    MessageBox.Show("파일명을 입력해주세요", "파일명이 입력되지 않았습니다.");
                    return; // 리턴으로 돌리기
                }
                if(Textbox_time.Text =="  시  분") // 시간을 입력 하지않았을 경우, (예외처리)
                {
                    MessageBox.Show("시간을 입력해주세요.", "시간이 입력되지 않았습니다."); 
                    return;
                }
                else if(Textbox_time.Text == " 1시  분" || Textbox_time.Text == "1 시  분" || Textbox_time.Text == " 2시  분" || Textbox_time.Text == "2 시  분" || Textbox_time.Text == " 3시  분" || Textbox_time.Text == "3 시  분"
                          || Textbox_time.Text == " 4시  분" || Textbox_time.Text == "4 시  분" || Textbox_time.Text == " 5시  분" || Textbox_time.Text == "5 시  분" || Textbox_time.Text == " 6시  분" || Textbox_time.Text == "6 시  분" || Textbox_time.Text == " 7시  분" || Textbox_time.Text == "7 시  분"
                          || Textbox_time.Text == " 8시  분" || Textbox_time.Text == "8 시  분" || Textbox_time.Text == " 9시  분" || Textbox_time.Text == "9 시  분" || Textbox_time.Text == "10시  분" || Textbox_time.Text == "11시  분" || Textbox_time.Text == "12시  분" || Textbox_time.Text == "13시  분"
                          || Textbox_time.Text == "14시  분" || Textbox_time.Text == "15시  분" || Textbox_time.Text == "16시  분" || Textbox_time.Text == "17시  분" || Textbox_time.Text == "18시  분" || Textbox_time.Text == "19시  분" || Textbox_time.Text == "20시  분" || Textbox_time.Text == "21시  분"
                          || Textbox_time.Text == "22시  분" || Textbox_time.Text == "23시  분" || Textbox_time.Text == "24시  분") // (예외처리) => 많은 게 아니라 전부 다 예외처리 가능
                {
                    MessageBox.Show("분을 입력해주세요.", "분이 입력되어 있찌 않습니다.");
                    return;
                }
                if(dateTimePicker.Value == null) // datetimepicker의 값이 없으면
                {
                    MessageBox.Show("날짜를 선택하여 주세요.", "날짜가 선택되지 않았습니다.");
                    return;
                }

                DateTime txt = Convert.ToDateTime(Textbox_time.Text);
                Textbox_time.Text = txt.ToString("HH시mm분");

                for (int i = 0; i < table.Rows.Count; i++) //for 반복문을 통해 datagridview의 table을 읽어주기
                {
                     if(dataGridView.Rows[i].Cells[0].Value.ToString() == dateTimePicker.Value.ToString()
                        && dataGridView.Rows[i].Cells[1].Value.ToString() == txt.ToString())
                    {
                        MessageBox.Show("동일한 시간대가 존재합니다.", "동일한 시간 존재");
                        return;
                    }
                } 
                table.Rows.Add(dateTimePicker.Value, Textbox_time.Text, Textbox_filename.Text);
                dataGridView.Columns[0].DefaultCellStyle.Format = "yyyy/MM/dd";
                dataGridView.Columns[1].DefaultCellStyle.Format = "HH: mm";
                dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.Rows.Count - 1; //스크롤

                foreach(DataGridViewRow row in dataGridView.Rows)
                {
                    row.HeaderCell.Value = string.Format("{0}", row.Index + 1); //format을 index+1(0부터시작하기에 +1)
                }
            }
            else
            {
                MessageBox.Show("12개까지만 입력이 가능합니다.", "갯수를 확인해주세요");
                return;
            }

        }

        private void Btn_del_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0) // 선택하는 row의 갯수가 0보다 큰 경우
            {
                int iselectrow = dataGridView.SelectedRows[0].Index; //선택될 row를 선언
                dataGridView.Rows.Remove(dataGridView.Rows[iselectrow]); //iselectrow=>선택한 row 삭제 

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.HeaderCell.Value = string.Format("{0}", row.Index + 1); //format을 index+1(0부터시작하기에 +1)
                }
                return;
            }
                if(dataGridView.Rows.Count == 0) //row가 없는 경우(예외처리)
                {
                    MessageBox.Show("삭제할 열이 존재하지 않습니다.","열의 존재 여부 확인");
                    return; 
                }
                if(dataGridView.SelectedRows.Count == 0) //row가 선택되지 않았을 경우(예외처리)
                {
                    MessageBox.Show("열이 선택되지 않았습니다.", "열의 선택 여부 확인");
                    return;
                }
            
        }

        private void Btn_edit_Click(object sender, EventArgs e)
        {
            DateTime txt = Convert.ToDateTime(Textbox_time.Text);
            Textbox_time.Text = txt.ToString("HH시mm분");

            for (int c = 0; c < table.Rows.Count; c++)
            {
                if(dataGridView.Rows[c].Cells[0].Value.ToString() == dateTimePicker.Value.ToString() 
                    && dataGridView.Rows[c].Cells[1].Value.ToString() == txt.ToString())
                {
                    MessageBox.Show("동일한 시간대가 존재합니다.");
                    return;
                }
              
            }
            int iselectrow2 = dataGridView.SelectedRows[0].Index;
            DataGridViewRow editrow = dataGridView.Rows[iselectrow2];
            editrow.Cells[0].Value = dateTimePicker.Value;
            editrow.Cells[1].Value = Textbox_time.Text;
            editrow.Cells[2].Value = Textbox_filename.Text;
            return;
        }

        private void Btn_order_Click(object sender, EventArgs e)
        {
            for(int a = 0; a < table.Rows.Count; a++)
            {   
                for(int b = 0; b < table.Rows.Count; b++)
                {
                    if (dataGridView.Rows[a].Cells[0].Value.ToString() == dataGridView.Rows[b].Cells[0].Value.ToString()) //날짜가 같은경우에는 
                    {
                        table.DefaultView.Sort = "동작시간 ASC"; //동작시간의 정렬 확인
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            row.HeaderCell.Value = string.Format("{0}", row.Index + 1); //format을 index+1(0부터시작하기에 +1)
                        }
                    }
                    if(dataGridView.Rows[a].Cells[1].Value.ToString() == dataGridView.Rows[b].Cells[1].Value.ToString()) //동작시간이 같은 경우에는
                    {
                        table.DefaultView.Sort = "날짜 ASC"; //날짜의 정렬을 확인
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            row.HeaderCell.Value = string.Format("{0}", row.Index + 1); //format을 index+1(0부터시작하기에 +1)
                        }
                    }
                } 
            }
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            if(dataGridView.Rows.Count == 0) //열이 존재하지 않을 경우(예외처리)
            {
                MessageBox.Show("입력값이 없습니다.", "확인");
                return;
            }
            if(Textbox_entertime.Text == "") //입력시간(분)이 없을 경우(예외처리)
            {
                MessageBox.Show("입력시간(분) 이 없습니다.", "확인");
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
            dateTimePicker.Enabled = false;

            Btn_end.Enabled = true;
            Textbox_entertime.Enabled = false;
            Textbox_filename.Enabled = false;
            Textbox_time.Enabled = false;

        }

        private void Timer_time_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime current_time = DateTime.Now; // 현재시간 선언
            for (int j = 0; j < table.Rows.Count; j++) //반복문을 통해 datagridview의 [날짜][동작시간]의 값을 읽음
            {
                DateTime picker_date = Convert.ToDateTime(dataGridView.Rows[j].Cells[0].Value.ToString());
                DateTime text_time = Convert.ToDateTime(dataGridView.Rows[j].Cells[1].Value.ToString());

                if(current_time.Date == picker_date.Date && current_time.Hour == text_time.Hour && current_time.Minute == text_time.Minute && current_time.Second == 0)
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

        private void Btn_end_Click(object sender, EventArgs e) //타이머 이벤트가 다돌고 나서 
        {
            DialogResult dialog = MessageBox.Show("종료하시겠습니까?", "종료여부", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(dialog == DialogResult.Yes)
            {
                label1.Text = "마우스 매크로 종료";
                Btn_add.Enabled = true;
                Btn_del.Enabled = true;
                Btn_edit.Enabled = true;
                Btn_order.Enabled = true;
                Btn_start.Enabled = true;
                dateTimePicker.Enabled = true;

                Btn_end.Enabled = true;
                Textbox_entertime.Enabled = true;
                Textbox_filename.Enabled = true;
                Textbox_time.Enabled = true;
            }
            else if(dialog == DialogResult.No)
            {
                return;
            }
        }

        private void Textbox_entertime_KeyPress(object sender, KeyPressEventArgs e) //숫자만 입력할 수 있게 하기 위한 메소드
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e) //셀 클릭했을 경우 -> 텍스트박스에 띄울수 있게 
        {
            if(this.dataGridView.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DataGridViewRow row2 = this.dataGridView.Rows[e.RowIndex];
                dateTimePicker.Value = Convert.ToDateTime(dataGridView.SelectedRows[0].Cells[0].Value.ToString());

                DateTime cell_date = Convert.ToDateTime(dataGridView.SelectedRows[0].Cells[1].Value.ToString());
                Textbox_time.Text = cell_date.ToString("HH시mm분");

                Textbox_filename.Text = row2.Cells[2].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimePicker fm = new TimePicker();
            fm.ShowDialog();
        }
    }
}
