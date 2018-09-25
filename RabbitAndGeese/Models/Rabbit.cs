using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitAndGeese.Models
{
    public class Rabbit
    {       
            public int Id { get; set; } // adding a unique id 
            public string Name { get; set; }
            public string Color { get; set; }
            public int MaxFeetPerSecond { get; set; }
            public Size Size { get; set; }
            public Sex Sex { get; set; }
            public List<Goose> OwnedGeese { get; set; } = new List<Goose>(); // adding a goose to the rabbit and intializing it
            public List<Saddle> OwnedSaddle { get; set; } = new List<Saddle>(); // adding a saddle to the rabbit and intialiing it

        public void SaddleThatGoose(Goose goose, Saddle saddle)// was created from unittesting when ctrl. was hit
        {
            // Refactoring

            if (goose.Saddle != null)
            {
                
                goose.EmotinalState = "Exhausted";
                return; // adding this code for the thrid scneario 
            }
            if (goose.Size == saddle.Size)
            {
                goose.Saddle = saddle;
                saddle.InUse = true;
            }
            else if (goose.Size > saddle.Size)
            {
                goose.EmotinalState = "Distraught by fat shaming";
            }
           
        }

        
    }
}
