using RestSharp;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Clipformy
{
    public partial class Form1 : Form
    {
        private RestClient _transformyRestClient;

        public Form1()
        {
            InitializeComponent();
            _transformyRestClient = new RestClient("https://www.transformy.io/api/transform");
        }

        #region Form methods

        private void btnTransform_Click(object sender, EventArgs e)
        {
            // TODO: Add some UI notification of the request going on
            // TODO: Make the request non ui-blocking
            txtResult.Text = Transform(txtSource.Text, txtTarget.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!TryToFillFromClipboard()) return;

            btnTransform_Click(null, null);
            Clipboard.SetText(txtResult.Text);
            Console.Beep();
            Application.Exit();
        }

        private void txtTarget_TextChanged(object sender, EventArgs e)
        {
            btnTransform.Enabled = txtTarget.Text.Length > 0;
        }

        #endregion Form methods

        #region Private methods

        /// <summary>
        /// Tries to fill the controls of the form from the data available in the clipboard (if any).
        /// The data must be in an specific format in order to be understood, it expects 1 line of text (target), 
        /// followed by two blank lines (can contain tabs or spaces), and 1 or more lines of text (source).
        /// Ie:
        ///     Lucas is 31 years old!
        ///
        ///
        ///     Lucas 31
        ///     Mauro 30
        /// </summary>
        /// <returns>true if there was data in the clipboard and it mached the required format.</returns>
        private bool TryToFillFromClipboard()
        {
            if (!Clipboard.ContainsText()) return false;

            var clipboardText = Clipboard.GetText();
            var lines = clipboardText.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            // Very nasty format checking :P
            if (lines.Count() >= 4
                && lines[0].Trim().Length > 0
                && lines[1].Trim(' ', '\n').Length == 0
                && lines[2].Trim(' ', '\n').Length == 0)
            {
                txtTarget.Text = lines[0];
                txtSource.Text = string.Join(Environment.NewLine, lines.Skip(3));
                return true;
            }

            txtSource.Text = clipboardText;
            return false;
        }

        private string Transform(string source, string target)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { source, target });

            // Transformy returns "\n" for new lines, we need to replace those
            return _transformyRestClient.Execute(request).Content.Replace("\n", Environment.NewLine);
        }

        #endregion Private methods
    }
}
