using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class ContentImage : IContentImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string Sources { get; set; }
    }
}
