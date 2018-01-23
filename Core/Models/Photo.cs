using System.ComponentModel.DataAnnotations;

namespace NextSugarCat.Core.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public int MenuItemId { get; set; }
        public string FileName { get; set; }

        public byte[] Data { get; set; }
        public long Length { get; set; }
        public string ContentType { get; set; }
    }
}
