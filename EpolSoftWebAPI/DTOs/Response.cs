using System.Collections.Generic;

namespace EpolSoft.WebAPI.DTOs
{
    public class Response
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> ValidationMessages { get; set; }
    }
}
