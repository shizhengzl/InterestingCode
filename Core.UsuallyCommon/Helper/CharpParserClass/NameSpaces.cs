using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class NameSpaces
    {
        public NameSpaces()
        {
            Classses = new List<Classs>();
        }
        public List<Classs> Classses { get; set; }

        public string SpaceName { get; set; }
    }
}
