using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryWebApi.Controllers.Resources
{
    public class ItemPhotoDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }

        public long Length { get; set; }
        public string ContentType { get; set; }
    }
}
