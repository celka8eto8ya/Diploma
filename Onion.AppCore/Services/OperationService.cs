using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Onion.AppCore.Services
{
    public class OperationService : IOperation
    {
        private readonly IGenericRepository<Operation> _operationRepository;

        public OperationService(IGenericRepository<Operation> operationRepository)
            => _operationRepository = operationRepository;


        public IEnumerable<OperationDTO> GetList()
            => _operationRepository.GetList().Select(x => new OperationDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Date = x.Date,
                Author = x.Author,
                Object = x.Object,

                ProjectId = x.ProjectId
            });


        public void Create(string type, string object0, string name, string author, int projectId)
           => _operationRepository.Create(new Operation()
           {
               Name = name,
               Type = type,
               Date = DateTime.Now,
               Author = author,
               Object = object0,

               ProjectId = projectId
           });

        public byte[] ExportToWord(IEnumerable<OperationDTO> operationDTO)
        {
            DataTable dtProduct = GetDataTable(operationDTO);

            if (dtProduct.Rows.Count > 0)
            {
                StringBuilder sbDocumentBody = new StringBuilder();

                sbDocumentBody.Append("<table width=\"100%\" style=\"background-color:#ffffff;\">");
                if (dtProduct.Rows.Count > 0)
                {
                    sbDocumentBody.Append("<tr><td>");
                    sbDocumentBody.Append("<table width=\"600\" cellpadding=0 cellspacing=0 style=\"border: 1px solid gray;\">");

                    // Add Column Headers dynamically from datatable  
                    sbDocumentBody.Append("<tr>");
                    for (int i = 0; i < dtProduct.Columns.Count; i++)
                    {
                        sbDocumentBody.Append("<td class=\"Header\" width=\"120\" style=\"border: 1px solid gray; text-align:center; font-family:Verdana; font-size:12px; font-weight:bold;\">" + dtProduct.Columns[i].ToString().Replace(".", "<br>") + "</td>");
                    }
                    sbDocumentBody.Append("</tr>");

                    // Add Data Rows dynamically from datatable  
                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        sbDocumentBody.Append("<tr>");
                        for (int j = 0; j < dtProduct.Columns.Count; j++)
                        {
                            sbDocumentBody.Append("<td class=\"Content\"style=\"border: 1px solid gray;\">" + dtProduct.Rows[i][j].ToString() + "</td>");
                        }
                        sbDocumentBody.Append("</tr>");
                    }
                    sbDocumentBody.Append("</table>");
                    sbDocumentBody.Append("</td></tr></table>");
                }
                return ASCIIEncoding.ASCII.GetBytes(sbDocumentBody.ToString());
            }
            return ASCIIEncoding.ASCII.GetBytes("none");
        }

        public byte[] ExportToXML(IEnumerable<OperationDTO> operationDTO)
        {
            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement("Operations");
            xml.AppendChild(root);
            foreach (var operation in operationDTO)
            {
                XmlElement child = xml.CreateElement("Operation");
                child.SetAttribute("Name", operation.Name);
                child.SetAttribute("Type", operation.Type);
                child.SetAttribute("Date", operation.Date.ToString());
                child.SetAttribute("Author", operation.Author);
                child.SetAttribute("UpdateDate", operation.Object);

                root.AppendChild(child);
            }
            return ASCIIEncoding.ASCII.GetBytes(xml.OuterXml.ToString());
        }

        private DataTable GetDataTable(IEnumerable<OperationDTO> operationDTO)
        {
            DataTable dtEmployee = new DataTable("Operations");
            dtEmployee.Columns.AddRange(new DataColumn[5] {
                new DataColumn("Name"),
                new DataColumn("Type"),
                new DataColumn("Date"),
                new DataColumn("Author"),
                new DataColumn("Object")
        });

            foreach (var operation in operationDTO)
            {
                dtEmployee.Rows.Add(
                    operation.Name,
                    operation.Type,
                    operation.Date,
                    operation.Author,
                    operation.Object);
            }

            return dtEmployee;
        }

    }
}
