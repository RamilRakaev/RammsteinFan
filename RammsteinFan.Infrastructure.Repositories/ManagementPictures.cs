using Microsoft.AspNetCore.Http;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace RammsteinFan.Infrastructure.Repositories
{
    public class ManagementPictures : IManagementPictures
    {
        public ManagementPictures()
        {
                
        }

        public async Task SaveImageAsync(IFormFile uploadedImage, string path)
        {
            if (uploadedImage != null)
            {
                using (var fileStream = new FileStream(path, FileMode.CreateNew))
                {
                    await uploadedImage.CopyToAsync(fileStream);
                }
            }
        }

        public IEnumerable<string> GetImages(string path)
        {
            foreach (var image in new DirectoryInfo(@path).GetFiles())
            {
                yield return image.FullName;
            }
        }

        public void RemoveImages(string path)
        {
            DirectoryInfo d = new DirectoryInfo(@path);
            FileInfo[] files = d.GetFiles();
            foreach(var file in files)
            {
                var full = file.FullName;
                File.Delete(path + "/" + file.Name);
            }
        }
    }
}
