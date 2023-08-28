using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssembely.Shared
{
    public class PlayerResponseDto
    {
        public List<Player> Players { get; set; } = new();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
