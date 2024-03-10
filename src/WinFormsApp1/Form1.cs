namespace WinFormsApp1
{
    public partial class Form1 : Form, IObserver
    {
        private Interval _interval;

        public string Start
        {
            get => _interval.Start;
            set => _interval.Start = value;
        }

        public string End
        {
            get => _interval.End;
            set => _interval.End = value;
        }

        public string Length
        {
            get => _interval.Length;
            set => _interval.Length = value;
        }

        public Form1()
        {
            InitializeComponent();

            _interval = new Interval();
            _interval.AddObserver(this);
            Update(_interval, null);
        }

        public void Update(IObservable observed, object arg)
        {
            textBoxStart.Text = _interval.Start;
            textBoxEnd.Text = _interval.End;
            textBoxLength.Text = _interval.Length;
        }

        private void textBoxStart_Leave(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;
            Start = int.TryParse(text, out _) ? textBoxStart.Text : "0";
        }

        private void textBoxEnd_Leave(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;
            End = int.TryParse(text, out _) ? textBoxEnd.Text : "0";
        }

        private void textBoxLength_Leave(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;
            Length = int.TryParse(text, out _) ? textBoxLength.Text : "0";
        }
    }
}
