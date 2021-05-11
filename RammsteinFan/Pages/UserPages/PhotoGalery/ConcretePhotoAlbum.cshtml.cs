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
    public class ConcretePhotoAlbumModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
        public ConcretePhotoAlbumModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }
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
        public void OnGet(string title)
        {
            
            Title = title;
            Quantity = LineHandler.GetNumberOfPhotos(userdb.GetContentForTitle("NumberOfPhotos", "NumberOfPhotos").Text, title);
            
        }
    }
}