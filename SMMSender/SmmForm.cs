using SMMSender.Constants;
using SMMSender.DTO;
using SMMSender.Factories;
using SMMSender.Factories.Implementations;
using SMMSender.Processors;
using SMMSender.Utils;
using SMMSender.Utils.Extensions;

namespace SMMSender
{
    public partial class SmmForm : Form
    {

        public SmmForm()
        {
            InitializeComponent();
            PlaceInTheCenter();
            HideEmailForm();
            UploadedData.RemoveAllUploadedFiles();
        }

        #region Event Handlers

        private void btnLoadPicture_Click(object sender, EventArgs e) =>
            AddFileUsingDialog(
                DialogFileFilter.Image,
                fileDestinationPath: UploadedData.JpgFile,
                onSuccess: (OpenFileDialog fd) =>
                              pbUploadedImage.Image = new Bitmap(fd.FileName));


        private void btnLoadExcel_Click(object sender, EventArgs e) =>
            AddFileUsingDialog(
                DialogFileFilter.Excel,
                fileDestinationPath: UploadedData.XlsFile,
                onSuccess: (OpenFileDialog fd) =>
                              lblUploadedExcelFileSuccess.Text = $@"Excel File ""{fd.FileName}"" has been uploaded successfully.");


        private void btnSend_Click(object sender, EventArgs e)
        {
            var errors = GetErrorList();
            DisplayErrors(errors);
            RunCheckedProcessors(new ProcessorFactories());
        }

        private void chbMail_CheckedChanged(object sender, EventArgs e) =>
            ((CheckBox)sender).Checked
                              .Then(() => DisplyEmailForm())
                              .Else(() => HideEmailForm());

        #endregion

        #region Private Methods

        private void DisplayErrors(IEnumerable<string> errors)
        {
            if (errors is null)
                throw new ArgumentNullException(nameof(errors));

            if (!errors.Any())
                return;

            var message = string.Concat(errors);

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
            }
        }

        private IEnumerable<string> GetErrorList()
        {
            var commonForm = new List<(bool condition, string error)>
            {
                (string.IsNullOrEmpty(rtbContent.Text), "Content should not be empty."),
                (!File.Exists(UploadedData.JpgFile), "Image should be selected."),
            };

            var emailForm = new List<(bool, string)>
            {
                (string.IsNullOrEmpty(txtFromAddress.Text), "Your email should not be empty."),
                (string.IsNullOrEmpty(txtName.Text), "Your name should not be empty."),
                (string.IsNullOrEmpty(txtPassword.Text), "Your password should not be empty."),
                (!File.Exists(UploadedData.XlsFile), "Contacts file should be selected."),
                (string.IsNullOrEmpty(rtbSubject.Text), "Subject should not be empty."),
            };

            var fieldsToValidate = chbMail.Checked
               ? commonForm.Concat(emailForm)
               : commonForm;

            var errors = fieldsToValidate
                            .Where(a => a.Item1)
                            .Select(a => $"{a.Item2}{Environment.NewLine}");
            return errors;
        }

        private void RunCheckedProcessors(IProcessorFactories factory)
        {
            var processors = new Dictionary<CheckBox, Func<IProcessor>>
            {
                { chbTelegram, () => factory.CreateTelegramProcessor() },
                { chbViber, () => factory.CreateViberProcessor() },
                { chbFacebook, () => factory.CreateFacebookProcessor() },
                { chbMail, () => factory.CreateEmailProcessor(GetMessageDto()) },
            };

            processors
                 .Where(i => i.Key.Checked)
                 .Select(i => i.Value())
                 .ForEach(processor => processor.Send());
        }

        private void AddFileUsingDialog(
                                    DialogFileFilter dialogFile,
                                    string fileDestinationPath,
                                    Action<OpenFileDialog> onSuccess)
        {
            var opnfd = new OpenFileDialog();

            opnfd.Filter = dialogFile.Filter;

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fileDestinationPath))
                {
                    File.Delete(fileDestinationPath);
                }

                File.Copy(opnfd.FileName, fileDestinationPath);

                onSuccess(opnfd);
            }
        }

        private void HideEmailForm()
        {
            Size = new Size(this.Size.Width, 650);
            panel.Visible = false;
        }

        private void DisplyEmailForm()
        {
            Size = new Size(this.Size.Width, 950);
            panel.Visible = true;
        }

        private void PlaceInTheCenter()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Top = 0;
        }

        private MailMessageDto GetMessageDto() =>
           new MailMessageDto(
               txtFromAddress.Text,
               txtPassword.Text,
               rtbSubject.Text,
               rtbContent.Text,
               UploadedData.GetEmailListFromXls());

        #endregion

        public FormDto GetFormDto() =>
           new FormDto(
               body: rtbContent.Text,
               imagePath: UploadedData.JpgFile);
    }
}