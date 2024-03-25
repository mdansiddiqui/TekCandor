/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using System.Linq;

namespace NohaFMS.Services
{
    public class AttachmentService : BaseService, IAttachmentService
    {
        #region Fields

        private readonly IRepository<Attachment> _attachmentRepository;
        private readonly IRepository<EntityAttachment> _entityAttachmentRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public AttachmentService(IRepository<Attachment> attachmentRepository,
            IRepository<EntityAttachment> entityAttachmentRepository,
            DapperContext dapperContext,
            IDbContext dbContext)
        {
            this._attachmentRepository = attachmentRepository;
            this._entityAttachmentRepository = entityAttachmentRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
        }

        #endregion

        #region Methods

        public virtual void CopyAttachments(long fromEntityId, string fromEntityType, long toEntityId, string toEntityType)
        {
            var from = _entityAttachmentRepository.GetAll()
                .Where(e => e.EntityId == fromEntityId && e.EntityType == fromEntityType)
                .ToList();
            foreach(var ea in from)
            {
                _entityAttachmentRepository.Insert(new EntityAttachment
                {
                    EntityId = toEntityId,
                    EntityType = toEntityType,
                    AttachmentId = ea.AttachmentId
                });
            } 
        }

        #endregion
    }
}
