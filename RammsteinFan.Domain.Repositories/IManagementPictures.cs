using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RammsteinFan.Domain.Repositories
{
    public interface IManagementPictures
    {
        /// <summary>
        /// Сохранить изображение с заданным именем и добавить расширение
        /// </summary>
        /// <param name="uploadedImage"></param>
        /// <param name="path"></param>
        Task SaveImageAsync(IFormFile uploadedImage, string path);

        /// <summary>
        /// Вернуть все изображения по указанному пути
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerable<string> GetImages(string path);

        /// <summary>
        /// Удалить изображение
        /// </summary>
        void RemoveImages(string path);
    }
}
