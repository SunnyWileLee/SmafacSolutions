using Smafac.Framework.Core.Repositories;
using Smafac.Sales.DeliveryNote.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Repositories
{
    class DeliveryNoteContext : SmafacContext
    {
        public DbSet<DeliveryNoteCategoryEntity> DeliveryNoteCategories { get; set; }
        public DbSet<DeliveryNoteCategoryPropertyEntity> DeliveryNoteCategoryProperties { get; set; }
        public DbSet<DeliveryNoteEntity> DeliveryNotes { get; set; }
        public DbSet<DeliveryNoteCategoryItemPropertyEntity> DeliveryNoteItemCategoryProperties { get; set; }
        public DbSet<DeliveryNoteItemEntity> DeliveryNoteItems { get; set; }
        public DbSet<DeliveryNoteItemPropertyEntity> DeliveryNoteItemProperties { get; set; }
        public DbSet<DeliveryNoteItemPropertyValueEntity> DeliveryNoteItemPropertyValues { get; set; }
        public DbSet<DeliveryNotePropertyEntity> DeliveryNoteProperties { get; set; }
        public DbSet<DeliveryNotePropertyValueEntity> DeliveryNotePropertyValues { get; set; }
    }
}
