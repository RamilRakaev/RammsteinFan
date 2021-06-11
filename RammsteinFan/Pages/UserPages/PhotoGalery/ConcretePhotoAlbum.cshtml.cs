using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace RammsteinFan.Pages.UserPages
{
    public class ConcretePhotoAlbumModel : GeneralUserPageTemplate
    {
        public ConcretePhotoAlbumModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb):base(_userdb)
        {}
        private int quantity=0;
        public int Quantity 
        {
            get { return quantity; }
            set 
            { 
                if (quantity == 0) quantity = value; 
            } 
        }
        public string Title { get; set; }
        public List<string> ImagesLocation { get; set; }
        public List<string> ImagesTitles { get; set; }
        public List<string> ImagesSources { get; set; }

        public void OnGet(string title)
        {
            ImagesTitles = new List<string>();
            ImagesLocation = new List<string>();
            ImagesSources = new List<string>();
            Title = title;
            foreach(var image in userdb.GetContentForLocation("photoGalery/" + Title))
            {
                ImagesTitles.Add(image.Title);
                ImagesLocation.Add(image.Location);
                ImagesSources.Add(image.Text);
            }
        }
    }
}
