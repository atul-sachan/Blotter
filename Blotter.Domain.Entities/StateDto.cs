using Blotter.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.Domain.Dtos
{
    public class StateDto: Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string CountryId { get; set; }
    }
}
