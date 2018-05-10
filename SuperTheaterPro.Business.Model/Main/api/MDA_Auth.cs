using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SuperTheaterPro.Business.Model.api
{
    public class MDA_IN_TokenVerify
    {
        [Required(ErrorMessage = "600100")]
        [Range(byte.MinValue + 1, byte.MaxValue, ErrorMessage = "600101")]
        public byte type { get; set; }

        [Required(ErrorMessage = "600102")]
        [StringLength(32, MinimumLength = 32, ErrorMessage = "600103")]
        public string token { get; set; }
    }

    public class MDA_IN_Login
    {
        [Required(ErrorMessage = "600100")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "600101")]
        public string name { get; set; }

        [Required(ErrorMessage = "600102")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "600103")]
        public string pwd { get; set; }

        [Required(ErrorMessage = "600104")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "600105")]
        public string captcha { get; set; }
    }

    public class MDA_OUT_AuthLogin
    {
        public string token { get; set; }

        public string gid { get; set; }
    }
}
