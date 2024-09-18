using System.Diagnostics.Metrics;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace ArgentinaGeneraCMS
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnFileSearch_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Certificates PKCS#12 (*.pfx*)|*.pfx*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath.Text = openFileDialog.FileName;

                    password.Focus();
                }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string servicioSolicitado = GetServicio();
            bool isOk = true;

            if (filePath.Text.Trim().Length <= 0)
            {
                isOk = false;
                MessageBox.Show("Seleccione el Certificado!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (password.Text.Trim().Length <= 0 && isOk)
            {
                isOk = false;
                MessageBox.Show("Informe la Contraseña del Certificado!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (servicioSolicitado.Trim().Length <= 0 && isOk)
            {
                isOk = false;
                MessageBox.Show("Seleccione el Servicio!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!isOk)
            {
                return;
            }

            Random random = new Random();

            Encoding EncodedMsg = Encoding.UTF8;
           
            X509Certificate2 certFirmante = new X509Certificate2(filePath.Text, password.Text);


            string XmlStrLoginTicketRequestTemplate = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>";
            UInt32 uniqueId = (UInt32)random.Next(0, int.MaxValue);

            XmlDocument XmlLoginTicketRequest = null;
            XmlNode xmlNodoUniqueId = default(XmlNode);
            XmlNode xmlNodoGenerationTime = default(XmlNode);
            XmlNode xmlNodoExpirationTime = default(XmlNode);
            XmlNode xmlNodoService = default(XmlNode);

            XmlLoginTicketRequest = new XmlDocument();
            XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate);

            xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
            xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
            xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
            xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service");
            xmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s");
            xmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s");
            xmlNodoUniqueId.InnerText = Convert.ToString(uniqueId);
            xmlNodoService.InnerText = "wsmtxca"; //"wsct" //"wsmtxca"


            byte[] msgBytes = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml);

            ContentInfo infoContenido = new ContentInfo(msgBytes);
            SignedCms cmsFirmado = new SignedCms(infoContenido);

            // Creo objeto CmsSigner que tiene las caracteristicas del firmante
            CmsSigner cmsFirmante = new CmsSigner(certFirmante);
            cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly;

            // Firmo el mensaje PKCS #7
            cmsFirmado.ComputeSignature(cmsFirmante);
            string cmsFirmadoBase64 = Convert.ToBase64String(cmsFirmado.Encode());

            CMS.Text = cmsFirmadoBase64;

            Clipboard.SetText(cmsFirmadoBase64);

            MessageBox.Show("CMS generado y copiado!", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetServicio()
        {
            string servicioSeleccionado = "";
            switch (servicio.SelectedIndex)
            {
                case 0:
                    servicioSeleccionado = "wsmtxca";
                    break;
                case 1:
                    servicioSeleccionado = "wsct";
                    break;
                case 2:
                    servicioSeleccionado = "wsfexv1";
                    break;

            }
            return servicioSeleccionado;
        }
    }
}
