using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Infrastructure.SqlContext;

namespace Quiplogs.Infrastructure.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlDbContext _context;
        private readonly IBlobStorage _blobStorage;

        public BlobRepository(SqlDbContext context, IMapper mapper, IBlobStorage blobStorage)
        {
            _context = context;
            _mapper = mapper;
            _blobStorage = blobStorage;
        }

        public async Task<Blob> Get(Guid foreignKeyId, string applicationType)
        {
            var model = await _context.BlobEntities.FirstOrDefaultAsync(x => x.ForeignKeyId == foreignKeyId && x.ApplicationType == applicationType);

            var modelMapped = _mapper.Map<Blob>(model);
            return modelMapped;
        }

        public async Task RemoveBlob(Guid foreignKeyId, string applicationType)
        {
            var model = await _context.BlobEntities.FirstOrDefaultAsync(x => x.ForeignKeyId == foreignKeyId && x.ApplicationType == applicationType);

            if (model != null)
            {
                await _blobStorage.DeleteBlobImage(new DeleteFileRequest
                {
                    Container = model.CompanyId.ToString(),
                    SubContainer = model.ForeignKeyId.ToString(),
                    FileName = model.FileName
                });

                _context.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

        public async Task PersistBlob(Blob model)
        {
            //persist to blob storage
            var persistedBlob = await _blobStorage.UploadImageAsync(new SaveFileRequest
            {
                Container = model.CompanyId.ToString(),
                SubContainer = model.ForeignKeyId.ToString(),
                FileName = model.FileName,
                FileBase64 = model.Base64,
                MimeType = model.MimeType
            });

            model.FileUrl = persistedBlob.FileUrl;

            var modelMapped = _mapper.Map<BlobEntity>(model);
            if (model.Id == Guid.Empty)
            {
                await _context.BlobEntities.AddAsync(modelMapped);
            }
            else
            {
                var entry = _context.BlobEntities.First(e => e.Id == model.Id);
                _context.Entry(entry).CurrentValues.SetValues(model);
            }

            await _context.SaveChangesAsync();
        }
    }
}
