using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoCard.Domain.Entities
{
    public class TwittCard
    {
        public string UserName { get; set; }
        public string ProfileDescription { get; set; }
        public string ProfileImage { get; set; }
        public long IdTwitt { get; set; }
        public string Text { get; set; }
    }
}
