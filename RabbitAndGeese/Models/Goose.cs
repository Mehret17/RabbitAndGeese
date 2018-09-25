using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitAndGeese.Models
{
    public class Goose
    {
     
            public string Name { get; set; }
            public Sex Sex { get; set; }
            public Size Size { get; set; }
            public bool Social { get; set; }
            public Saddle Saddle { get; set; }
            public string EmotinalState { get; set; }
    }
}
