using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Data.Entities
{
    public class Position
    {
        public Guid PositionId { get; set; }
        public string PositionId_
        {
            get
            {
                return PositionId.ToString();
            }
        }
        public string PositionName { get; set; }
        public string Description { get; set; }
    }
}
