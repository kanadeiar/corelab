namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;
            if (sender == textBoxStart)
            {
                startField_FocusLost(text);
            }
            else if (sender == textBoxEnd)
            {
                endField_FocusLost(text);
            }
            else if (sender == textBoxLength)
            {
                lengthField_FocusLost(text);
            }
        }

        private void startField_FocusLost(string text)
        {
            if (int.TryParse(text, out _))
            {
                calculateLength();
            }
            else
            {
                textBoxStart.Text = "0";
            }
        }    
        
        private void endField_FocusLost(string text)
        {
            if (int.TryParse(text, out _))
            {
                calculateLength();
            }
            else
            {
                textBoxEnd.Text = "0";
            }
        }    
        
        private void lengthField_FocusLost(string text)
        {
            if (int.TryParse(text, out _))
            {
                calculateEnd();
            }
            else
            {
                textBoxLength.Text = "0";
            }
        }

        private void calculateLength()
        {
            try
            {
                var start = int.Parse(textBoxStart.Text);
                var end = int.Parse(textBoxEnd.Text);
                var length = end - start;
                textBoxLength.Text = length.ToString();
            }
            catch
            {
                throw new ApplicationException("Некорректный формат числа");
            }
        }

        private void calculateEnd()
        {
            try
            {
                var start = int.Parse(textBoxStart.Text);
                var length = int.Parse(textBoxLength.Text);
                var end = start + length;
                textBoxEnd.Text = end.ToString();
            }
            catch 
            {
                throw new ApplicationException("Некорректный формат числа");
            }
        }
    }
}
