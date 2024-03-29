﻿using Library.Domain.Entities;
using Library.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Application.DTO
{
    public class BookDTO
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Description { get; set; }
        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression("^(\\d{13})?$")]
        public string ISBN { get; set; }
        public DateTime? TakeDateTime { get; set; }
        [JsonIgnore]
        public DateTime? ReturnDateTime { get; set; }
        public BookAvailability Status { get; set; }
    }
}
