namespace PBI_Planespotting.Lib
{
    public class TextualReportBuilder
    {
        protected int Columns { get; set; }

        #region Padding Properties
        protected int PaddingTop { get; set; } = 0;
        protected int PaddingLeft { get; set; } = 0;
        protected int PaddingRight { get; set; } = 0;
        #endregion

        protected List<string> Lines { get; set; }

        public TextualReportBuilder(int cols = 16)
        {
            Columns = cols;

            Lines = new List<string>();
        }

        public void DoTopPadding()
        {
            for (int i = 0; i < PaddingTop; i++)
                NewLine();
        }
        private string LeftPaddingString()
        {
            return RepeatString(' ', PaddingLeft);
        }

        private void NewLine()
        {
            Lines.Add("");
        }
        public void StartLine()
        {
            NewLine();
            CurrentLine += LeftPaddingString();
        }
        public void Write(string message, bool clip=true)
        {
            if (clip && message.Length > LineRemainingChars)
                message= message.Substring(0, LineRemainingChars);
            CurrentLine += message;
        }
        public void WriteLeft(string message, int? width = null)
        {
            // Write message, then add padding until width is satisfied
        }
        public void WriteCentered(string message, int? width = null)
        {
            // Write half padding, write message, write other half padding
        }
        // Say this out loud lol
        public void WriteRight(string message, int? width = null)
        {
            // Write padding, write message
        }
        public void FinishLine()
        {
            StartLine();
        }
        public void FinishLineCentered(string message)
        {
            // Use the rest of the space on the line to write a centered message
        }
        public void FinishLineRight(string message)
        {
            // Use the rest of the space on the line to write a right aligned message
        }
        public void TitleLine(string title)
        {
            // Generic == title == sort of thing
        }
        public string Render()
        {
            return string.Join('\n', Lines);
        }


        private string RepeatString(char toRepeat, int amount)
        {
            return new string(toRepeat, amount);
        }
        private string CurrentLine
        {
            get
            {
                return Lines[Lines.Count() - 1];
            }
            set
            {
                Lines[Lines.Count() - 1] = value;
            }
        }
        private int LineMaxLength
        {
            get
            {
                return PaddingLeft + Columns;
            }
        }
        private int LineRemainingChars
        {
            get
            {
                return LineMaxLength - CurrentLine.Length;
            }
        }
    }
}
