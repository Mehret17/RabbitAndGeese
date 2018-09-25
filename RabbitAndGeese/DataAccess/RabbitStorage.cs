using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitAndGeese.Models;

namespace RabbitAndGeese.DataAccess
{
    public class RabbitStorage
    {
        static List<Rabbit> _hutch = new List<Rabbit>(); // by defalut it is null since its a refrence type
    
        public void Add(Rabbit rabbit) // make sure yous change the access modifire to public from internal
        {
            rabbit.Id = _hutch.Any() ? _hutch.Max(r => r.Id) + 1 : 1; // checking if there is any rabbit in the hutch and creating a unique id 
            _hutch.Add(rabbit);
        }

        public Rabbit GetById(int id)
        {
            return _hutch.FirstOrDefault(rabbit => rabbit.Id == id);
        }
    }
}
