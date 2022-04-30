using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Onion.AppCore.Services
{
    public class DocumentService : IDocument
    {
        private readonly IGenericRepository<Document> _documentRepository;

        public DocumentService(IGenericRepository<Document> documentRepository)
        {
            _documentRepository = documentRepository;
        }


        public IEnumerable<DocumentDTO> GetList()
            => _documentRepository.GetList().Select(x => new DocumentDTO()
            {
                Id = x.Id,
                Name = x.Name,
                File = x.File,
                Type = x.Type,
                CreateDate = x.CreateDate,
                AddDate = x.AddDate,
                Adder = x.Adder,
                Size = x.Size,

                ProjectId = x.ProjectId
            });


        public bool IsUnique(DocumentDTO documentDTO)
           => _documentRepository.GetList().Any(x => x.Name == documentDTO.Name && x.Id != documentDTO.Id);


        public void Create(DocumentDTO documentDTO)
        {
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(documentDTO.FormFile.OpenReadStream()))
            {
                fileData = binaryReader.ReadBytes((int)documentDTO.FormFile.Length);
            };

            _documentRepository.Create(new Document()
            {
                Name = documentDTO.FormFile.FileName,
                File = fileData,
                Type = documentDTO.FormFile.ContentType,
                CreateDate = documentDTO.CreateDate,
                AddDate = DateTime.Now,
                Adder = documentDTO.Adder,
                Size = documentDTO.FormFile.Length*(double)decimal.Round(Convert.ToDecimal(BankData.ByteToMB),3),

                ProjectId = documentDTO.ProjectId
            });
        }

        public void Delete(int id)
            => _documentRepository.Delete(id);


        public void Update(DocumentDTO documentDTO)
            => _documentRepository.Update(new Document
            {
                Id = documentDTO.Id,
                Name = documentDTO.Name,
                File = documentDTO.File,
                Type = documentDTO.Type,
                CreateDate = documentDTO.CreateDate,
                AddDate = documentDTO.AddDate,
                Adder = documentDTO.Adder,
                Size = documentDTO.Size,

                ProjectId = documentDTO.ProjectId
            });


        public DocumentDTO GetById(int id)
        {
            Document document = _documentRepository.GetById(id);
            return new DocumentDTO()
            {
                Id = document.Id,
                Name = document.Name,
                File = document.File,
                Type = document.Type,
                CreateDate = document.CreateDate,
                AddDate = document.AddDate,
                Adder = document.Adder,
                Size = document.Size,

                ProjectId = document.ProjectId
            };
        }


    }
}
