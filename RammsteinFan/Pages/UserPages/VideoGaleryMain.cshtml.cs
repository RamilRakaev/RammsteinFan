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
    public class VideoGaleryMainModel : GeneralUserPageTemplate
    {
        public VideoGaleryMainModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb):base(_userdb)
        {}

        public void OnGet()
        {
            Videos = new List<List<Content>>();
            Albums = LineHandler.SplitSpaces(userdb.GetContentForTitle("videoGalery", "albumsGalleries").Text);
            foreach(var album in Albums)
            {
                var videos = userdb.GetContentForLocation("videoGalery" + "/" + album).ToList();
                if(videos !=null)
                Videos.Add(videos);
            }
        }

        public List<string> Albums { get; set; }
        public List<List<Content>> Videos { get; set; }
    }
}
