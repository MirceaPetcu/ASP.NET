﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectV1.Models.Base
{
    
        public class BaseEntity : IBaseEntity
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public DateTime? DateCreated { get; set; }
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime? DateModified { get; set; }
        }
    }


