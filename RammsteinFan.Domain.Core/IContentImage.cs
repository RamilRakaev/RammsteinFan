using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Core
{
    public interface IContentImage
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Название картинки
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Двоичный формат изображения
        /// </summary>
        public byte[] ImageData { get; set; }

        /// <summary>
        /// Формат изображения
        /// </summary>
        public string ImageMimeType { get; set; }

        /// <summary>
        /// Истоичники изображения
        /// </summary>
        public string Sources { get; set; }
    }
}
