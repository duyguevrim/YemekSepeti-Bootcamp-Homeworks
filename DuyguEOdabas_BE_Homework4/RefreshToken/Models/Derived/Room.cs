using RefreshToken.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshToken.Models.Derived
{
    public class Room : Resource
    {
        public string Name { get; set; }
        public int Rate { get; set; }
    }
}
