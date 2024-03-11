namespace WinFormsApp1
{
    public partial class Form1 : Form, IFormObserver
    {
        private Interval _interval;
        
        public Form1()
        {
            InitializeComponent();

            _interval = new Interval();
            _interval.AddObserver(this);
            Update(_interval, null);
        }

        public void Update(IFormObservable observed, object? arg)
        {
            if (observed is Interval interval)
            {
                textBoxStart.Text = interval.Start.ToString();
                textBoxEnd.Text = interval.End.ToString();
                textBoxLength.Text = interval.Length.ToString();
            }
        }

        private void textBoxStart_Leave(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;
            _interval.Start = int.TryParse(text, out var value) ? value : 0;
        }

        private void textBoxEnd_Leave(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;
            _interval.End = int.TryParse(text, out var value) ? value : 0;
        }

        private void textBoxLength_Leave(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;
            _interval.Length = int.TryParse(text, out var value) ? value : 0;
        }
    }
}
