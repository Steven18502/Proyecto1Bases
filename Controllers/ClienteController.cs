using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto1Bases.Dtos;
using Proyecto1Bases.Models;
using Proyecto1Bases.Repositories;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Xml;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Element;

namespace Proyecto1Bases.Controllers
{
    [ApiController]
    [Route("api/Clientes")]

    public class ClienteController: ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
        _clienteRepository = clienteRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.GetAll();
            return Ok(clientes);
        }
    
        [HttpGet("{ccedula}")]
        public async Task<ActionResult<Cliente>> GetCliente(string ccedula)
        {
            var cliente = await _clienteRepository.Get(ccedula);
            if(cliente == null)
                return NotFound();
    
            return Ok(cliente);
        }
    
        [HttpPost]
        public async Task<ActionResult> CreateCliente(CreateClienteDto createClienteDto)
        {
            Cliente cliente = new()
            {
                ccedula = createClienteDto.ccedula,
                cusuario = createClienteDto.cusuario,
                cconstrasenia = createClienteDto.cconstrasenia,
                cnombre_completo = createClienteDto.cnombre_completo,
                cedad = createClienteDto.cedad,
                cfecha_nacimiento = createClienteDto.cfecha_nacimiento,
                ctelefono = createClienteDto.ctelefono
            };
    
            await _clienteRepository.Add(cliente);
            return Ok();
        }
    
        [HttpDelete("{ccedula}")]
        public async Task<ActionResult> DeleteCliente(string ccedula)
        {
            await _clienteRepository.Delete(ccedula);
            return Ok();
        }
    
        [HttpPut("{ccedula}")]
        public async Task<ActionResult> UpdateCliente(string ccedula, UpdateClienteDto updateClienteDto)
        {
            Cliente cliente = new()
            {
                cusuario = updateClienteDto.cusuario,
                cconstrasenia = updateClienteDto.cconstrasenia,
                cnombre_completo = updateClienteDto.cnombre_completo,
                cedad = updateClienteDto.cedad,
                cfecha_nacimiento = updateClienteDto.cfecha_nacimiento,
                ctelefono = updateClienteDto.ctelefono
            };
            
    
            await _clienteRepository.Update(cliente);
            return Ok();
    
        }

        [HttpGet("pdf")]
        public async void GetPdf()
        {   
            var nombreArchivo = "Prueba";
            // Se crea un memorystream para la codificacion de los archivos
            MemoryStream mS = new MemoryStream();
            // Se crea un memorystream para la codificacion de los archivos
            MemoryStream memoryS = new MemoryStream();
            // Se genera un Path para la descarga del Pdf
            var folder = "/home/chago/Documents/Bases/Proyecto1Bases/Factura/";
            var file = System.IO.Path.Combine(folder , nombreArchivo + ".pdf");

            // Se crean las variables para el manejo de la informacion en el Pdf y su estructura
            var writer = new PdfWriter(mS);
            var pdf = new PdfDocument(writer);
            var doc = new Document(pdf);

            // Se establece un tamaño para el documento
            pdf.SetDefaultPageSize(PageSize.A4);

            // Se crea la Tabla para el encabezado, se define que sea de 2 columnas ademas de sus propiedades graficas
            float []columnWidth = {280f, 280f};
            Table table = new Table(columnWidth);
            table.SetBackgroundColor(new DeviceRgb(63,170,220))
                .SetFontColor(new DeviceRgb(255,255,255));
            // Se agrega la informacion de cada columna y se definen sus propiedaes graficas
            table.AddCell(new Cell().Add(new Paragraph("CINE TEC"))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER))
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .SetMarginTop(30f)
                .SetMarginBottom(30f)
                .SetFontSize(15f)
                .SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            table.AddCell(new Cell().Add(new Paragraph("Instituto Tecnologico de Costa Rica \n Cartago Costa Rica ")))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .SetMarginTop(30f)
                .SetMarginBottom(30f)
                .SetMarginRight(10f)
                .SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            // Se crea la Tabla para la informacion del usuario
            float []colWidth = {140,140,140,140};
            Table clienteinfo = new Table(colWidth);
            // Se agrega la informacion del Cliente a la tabla en las distintas columnas 
            clienteinfo.AddCell(new Cell(0,4).Add(new Paragraph("Información del Cliente").SetBackgroundColor(new DeviceRgb(63,170,220))
                       .SetBold()));
            clienteinfo.AddCell(new Cell().Add(new Paragraph("Nombre:")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            clienteinfo.AddCell(new Cell().Add(new Paragraph("Cédula:")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            clienteinfo.AddCell(new Cell().Add(new Paragraph("Teléfono:")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            clienteinfo.AddCell(new Cell().Add(new Paragraph("Fecha de Nacimiento")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            clienteinfo.AddCell(new Cell().Add(new Paragraph("Pedro Jimenez")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            clienteinfo.AddCell(new Cell().Add(new Paragraph("222555333888")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            clienteinfo.AddCell(new Cell().Add(new Paragraph("24454524")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            clienteinfo.AddCell(new Cell().Add(new Paragraph("12/10/2000")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

            //Se agrega la Tabla para la informacion de la compra
            float []Width = {187,187,186};
            Table comprainfo = new Table(Width);
            // Se agrega la informacion de la Compra a la tabla en las distintas columnas 
            comprainfo.AddCell(new Cell(0,4).Add(new Paragraph("Información de la Compra").SetBackgroundColor(new DeviceRgb(63,170,220))
                       .SetBold()));
            comprainfo.AddCell(new Cell().Add(new Paragraph("Pelicula:")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("Sala:")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("Hora:")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("Matrix")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("4")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("3:45pm")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("# de Asientos:")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("Precio unidad(colones):")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("Precio Total(colones):")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("3")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("3000")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            comprainfo.AddCell(new Cell().Add(new Paragraph("9000")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

            // Se agregan las tablas con la informacion al Documento
            doc.Add(table);
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(clienteinfo);
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(comprainfo);
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph("Número de Factura: ").SetBackgroundColor(new DeviceRgb(63,170,220)).SetBold());
            doc.Add(new Paragraph("121212121212121212 "));

            // Se cierra el documento
            doc.Close();

            //Se carga un xml desde una plantilla y se editan los nodos correspondientes para que contega la informacion de la compra
            XmlDocument docxml = new XmlDocument();
            docxml.Load("/home/chago/Documents/Bases/Proyecto1Bases/FacturaPlantilla.xml");           
            XmlNode clave = docxml.DocumentElement.FirstChild;
            clave.InnerText = "12121121312";
            XmlNode nombreEmisor = clave.NextSibling;
            XmlNode tIdE = nombreEmisor.NextSibling;
            XmlNode idE = tIdE.NextSibling;
            XmlNode nombreReceptor = idE.NextSibling;
            nombreReceptor.InnerText = "Steven";
            XmlNode tIdR = nombreReceptor.NextSibling;
            XmlNode idR = tIdR.NextSibling;
            idR.InnerText = "2020202255";
            XmlNode mensaje = idR.NextSibling;
            XmlNode detalleM = mensaje.NextSibling;
            XmlNode montoImpuesto = detalleM.NextSibling;
            XmlNode total = montoImpuesto.NextSibling;
            total.InnerText = "10000";
            docxml.Save("/home/chago/Documents/Bases/Proyecto1Bases/Factura" + nombreArchivo + ".xml");

            // Se crea un mensaje email con el correo de salida y el de entrada
            MailMessage mmesage = new MailMessage("basesdatoss2@gmail.com","steven18502@gmail.com");
            // Se edita la información que contiene el mensaje  y se agrega el xml
            mmesage.Subject = "Factura";
            mmesage.Body = "Factura Cine Tec";
            mmesage.Attachments.Add(new Attachment("/home/chago/Documents/Bases/Proyecto1Bases/Factura" + nombreArchivo + ".xml"));
            // se crea un smtp client y se definen sus propiedades
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            // Se crea un networkCredential para contener la informacion del correo emisor
            NetworkCredential networkCredential = new NetworkCredential();
            networkCredential.UserName = "basesdatoss2@gmail.com";
            networkCredential.Password = "bases123datos";
            // Se asignan las credenciales y el puerto al smtp client  
            smtpClient.Credentials = networkCredential;
            smtpClient.Port = 587;
            // Se envia el mensaje
            smtpClient.Send(mmesage);

            using (mS){
                // Se serializa el pdf
                byte[] bytes = mS.ToArray();
                mS.Close();
                // Se crea un mensaje email con el correo de salida y el de entrada
                MailMessage mm = new MailMessage("basesdatoss2@gmail.com","steven18502@gmail.com");
                // Se edita la información que contiene el mensaje y se agrega el pdf
                mm.Subject = "Factura";
                mm.Body = "Factura Cine Tec";
                mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Factura.pdf"));
                // se crea un smtp client y se definen sus propiedades
                SmtpClient smpt = new SmtpClient();
                smpt.Host = "smtp.gmail.com";
                smpt.EnableSsl = true;
                smpt.UseDefaultCredentials = false;
                // Se crea un networkCredential para contener la informacion del correo emisor
                NetworkCredential networkCred = new NetworkCredential();
                networkCred.UserName = "basesdatoss2@gmail.com";
                networkCred.Password = "bases123datos";
                // Se asignan las credenciales y el puerto al smtp client  
                smpt.Credentials = networkCred;
                smpt.Port = 587;
                // Se envia el mensaje
                smpt.Send(mm);
            }
        }    

        
    }
}