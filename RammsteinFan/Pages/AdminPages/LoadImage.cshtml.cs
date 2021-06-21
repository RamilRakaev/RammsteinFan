using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using RammsteinFan.Infrastructure.Core;
using System.IO;
using RammsteinFan.Pages.UserPages;
using RammsteinFan.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace RammsteinFan.Pages.AdminPages
{
    public class LoadImageModel : GeneralAdminPageTemplate
    {
        public LoadImageModel(IAdminRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb, 
            IManagementPictures _pict, IWebHostEnvironment _webHost):base(_userdb)
        {
            pictures = _pict;
            webHost = _webHost;
        }

        public void OnGet()
        {
            var galeryContent = admindb.GetContentByTitle("photoGalery", "albumsGalleries");
            var videoGaleryContent = admindb.GetContentByTitle("videoGalery", "albumsGalleries");
            if (galeryContent != null)
            {
                LocationsRelativePhotoGalery = LineHandler.SplitSpaces(galeryContent.Text);
                LocationsRelativeVideoGalery = LineHandler.SplitSpaces(videoGaleryContent.Text);
            }
            else
            {
                LocationsRelativePhotoGalery = new List<string>();
                LocationsRelativeVideoGalery = new List<string>();
            }
        }

        public void OnGetVideoGalery()
        {

        }


        readonly private IManagementPictures pictures;
        readonly private IWebHostEnvironment webHost;

        public List<string> LocationsRelativePhotoGalery { get; set; }
        public List<string> LocationsRelativeVideoGalery { get; set; }

        public IActionResult OnPost(string title, string location, IFormFile uploadedImage, string sources, string locationRelativeImg)
        {
            var path = "/img/"+ locationRelativeImg + "/" + location + "/" + title;
            pictures.SaveImageAsync(uploadedImage, webHost.WebRootPath + path);
            admindb.AddContent(title, "image", locationRelativeImg + "/" + location, sources);
            return RedirectToPage("AdminPanel");
        }

    }
}
