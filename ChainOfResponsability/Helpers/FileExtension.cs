using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChainOfResponsability.Attribute;

namespace ChainOfResponsability.Helpers
{
    public enum FileExtension
    {
       [StringValue(".mp3")]
       Mp3 = 0,
       [StringValue(".txt")]
       Txt = 1,
       [StringValue(".png")]
       Png = 3,
       [StringValue(".zip")]
       Zip = 4,
       [StringValue(".exe")]
       Exe = 5,
       [StringValue(".rar")]
       Rar = 6,

    }
}
