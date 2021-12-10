using System.ComponentModel.DataAnnotations;

namespace TranslatorApp
{
    public class Word
    {
        [Key]
        public int Id { get; set; }        
        public string Term { get; set; }
        public string Translation { get; set; }
        public string Category { get; set; }
    }
}
