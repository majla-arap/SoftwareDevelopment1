using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilesAway.Helper
{
    public class ImageHelper
    {
        public static string ByteToString(byte[] plakat)
        {
            return plakat != null ? $"data:image/jpg;base64,{Convert.ToBase64String(plakat)}" : null;
        }

        public static byte[] FileToByte(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var fs = file.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            return null;
        }
    }
}
