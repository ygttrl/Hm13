using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class CarImage :IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

    }
}
