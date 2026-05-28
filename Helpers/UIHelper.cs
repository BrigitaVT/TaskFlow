using System.Drawing;
using System.Windows.Forms;

namespace TaskFlow.Helpers
{
    public static class UIHelper
    {
        public static void StyleSidebarButtons(Button[] buttons)
        {
            int top = 80;

            foreach (Button btn in buttons)
            {
                btn.Width = 180;
                btn.Height = 45;
                btn.Left = 20;
                btn.Top = top;

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.SteelBlue;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;

                top += 60;
            }
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.BorderStyle = BorderStyle.FixedSingle;

            dgv.BackgroundColor = Color.White;

            dgv.GridColor = Color.DarkGray;

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv.MultiSelect = false;

            dgv.RowHeadersVisible = false;

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            dgv.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.SteelBlue;

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgv.ColumnHeadersHeight = 45;

            dgv.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 230, 245);

            dgv.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgv.RowTemplate.Height = 38;

            dgv.AllowUserToAddRows = false;

            dgv.ReadOnly = true;
        }
    }
}