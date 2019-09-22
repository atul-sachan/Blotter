using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.DataLayer
{
    public class Entity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt
        {
            get
            {
                return DateTime.Now;
            }
        }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int _version { get; set; }
    }
}
