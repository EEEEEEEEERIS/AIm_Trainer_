using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aim_Trainer.RankingList
{
    public class ListsForm : Form
    {
        private readonly List<RankingEntry> _rankingList;
        private readonly bool _Ismedals;
        private readonly RichTextBox _textboxForForm;

        public ListsForm(List<RankingEntry> rankingliste, string titel, bool medals = false)
        {
            this._rankingList = rankingliste;
            this._Ismedals = medals;

            Text = titel;
            Size = new Size(640, 420);
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = false;
            MaximizeBox = false;

            _textboxForForm = new RichTextBox
            {
                ReadOnly = true,
                WordWrap = false,
                ScrollBars = (RichTextBoxScrollBars)ScrollBars.Both,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Consolas", 10),
                BackColor = Color.FromArgb(20, 20, 30),
                ForeColor = Color.FromArgb(230, 230, 240),
            };

            Controls.Add(_textboxForForm); }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await FadeIn();
        }

        private async Task FadeIn()
        {
            string complete = ListLayout.RankingEntrysToText(_rankingList);
            string[] rows = complete.Split('\n');

            _textboxForForm.Clear();
            int pause = Math.Clamp(1200 / Math.Max(1, rows.Length), 10, 70);

            foreach (string zeile in rows)
            {
                if (_textboxForForm.IsDisposed) return;
                _textboxForForm.AppendText(zeile + "\n");
                await Task.Delay(pause);
            }
            Colour();
            _textboxForForm.SelectionStart = 0;
            _textboxForForm.ScrollToCaret();
        }

        private void Colour()
        {
            EnlargeSymbol(_textboxForForm, "♛", 14);
            if (_Ismedals)
            {
                const int Kopfzeilen = 2;
                ColouringForLines(_textboxForForm, Kopfzeilen + 0, Color.Gold);
                ColouringForLines(_textboxForForm, Kopfzeilen + 1, Color.Silver);
                ColouringForLines(_textboxForForm, Kopfzeilen + 2, Color.FromArgb(205, 127, 50));
            }
        }
        private void EnlargeSymbol(RichTextBox box, string symbol, float size)
        {
            int position = 0;
            while (true)
            {
                position = box.Text.IndexOf(symbol, position);
                if (position < 0) break;

                box.Select(position, symbol.Length);
                box.SelectionFont = new System.Drawing.Font("Consolas", size);
                box.SelectionColor = Color.Gold;

                position += symbol.Length;
            }
            box.Select(0, 0);
        }

        private void ColouringForLines(RichTextBox box, int lineNumber, Color colour)
        {
            string[] row = box.Text.Split('\n');
            if (lineNumber < 0 || lineNumber >= row.Length) return;

            //zeichen aller vorherigen zeilen zusammenzählen (+1 für das \n)
            int start = 0;
            for (int i = 0; i < lineNumber; i++)
                start += row[i].Length + 1;

            box.Select(start, row[lineNumber].TrimEnd('\r').Length);
            box.SelectionColor = colour;
            box.Select(0, 0);
        }
    }
}
