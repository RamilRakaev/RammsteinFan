using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace RammsteinFan.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository<DiscussionSubject,Replica,Content, User, Role>
    {
        public UserRepository(DataContext context)
        {
            db = context;
        }
        readonly protected DataContext db;

        #region Авторизация и права пользователя
        public async Task<User> GetUserAsync(string emailAdress, string password)
        {
            return await db.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.EmailAdress == emailAdress && u.Password == password);
        }

        public async Task<User> AccountByEmailAsync(string emailAdress) => await db.Users.
            FirstOrDefaultAsync(u => u.EmailAdress == emailAdress);

        public async Task<Role> UserRights() => await db.Roles.FirstOrDefaultAsync(r => r.Name == "user");

        public async Task AddUserAsync(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }
        #endregion

        #region Добавить новое сообщение
        public void AddReplica(string author, string Text, int discussionSubjectId, int replicaId = 0)
        {
            db.Replicas.Add(new Replica(author, Text, discussionSubjectId, replicaId));
            if (replicaId != 0)
            {
                GetDiscussionSubject(discussionSubjectId).Comments++;
                GetReplica(replicaId).Comments++;
            }
            else
            {
                GetDiscussionSubject(discussionSubjectId).Comments++;
            }
            db.SaveChanges();
        }

        public void AddDiscussionSubject(string topHeading, string topic, string author, string text)
        {
            db.DiscussionSubjects.Add(new DiscussionSubject(topHeading, topic, author, text));
            db.SaveChanges();
        }
        #endregion

        #region Вернуть данные из бд
        public IEnumerable<DiscussionSubject> GetAllDiscussionSubjects() => db.DiscussionSubjects.OrderByDescending(d => d.CreationDate);

        public DiscussionSubject GetDiscussionSubject(int id) => db.DiscussionSubjects.FirstOrDefault(ds => ds.Id == id);

        public Replica GetReplica(int id) => db.Replicas.FirstOrDefault(ds => ds.Id == id);

        public IEnumerable<Replica> GetReplicas(int id) => db.Replicas.Where(a => a.ReplicaId == id || a.DiscussionSubjectId == id).OrderByDescending(c => c.CreationDate);

        public IEnumerable<Content> GetAllContent() => db.DbContent;

        public Content GetContentForId(int id) => db.DbContent.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Content> GetContentForType(string type) => db.DbContent.Where(c => c.Type == type);

        public IEnumerable<Content> GetContentForLocation(string location) => db.DbContent.Where(c => c.Location == location);

        public Content GetContentForTitle(string title, string type) => db.DbContent.FirstOrDefault(c => c.Title == title && c.Type == type);

        public IEnumerable<Content> GetContentByFirstLetter(string title) => db.DbContent.Where(c => c.Title.StartsWith(title));

        #endregion

        #region Статистика
        public string GetFavoriteAlbum(string emailAdress) =>
            db.Users.Where(u => u.EmailAdress == emailAdress).ToList().DefaultIfEmpty(new User() {FavoriteAlbum="No favorite" }).First().FavoriteAlbum;
        

        public void SetFavoriteAlbum(string emailAdress, string titleAlbum)
        {
               var user = db.Users.FirstOrDefault(u => u.EmailAdress == emailAdress);
            if(user != null)
            {
                if (titleAlbum == user.FavoriteAlbum)
                {
                    user.FavoriteAlbum = "No favorite";
                }
                else
                {
                    user.FavoriteAlbum = titleAlbum;
                }
                db.SaveChanges();
            }
        }

        public Dictionary<string, int> AlbumRating()
        {
            Dictionary<string, int> rating = new Dictionary<string, int>();
            var albums = GetContentForLocation("SongTranslationsMain&AlbumsMain");
            var users = db.Users.ToList();
            foreach(var album in albums)
            {

                var popularity = users.Where(u => u.FavoriteAlbum == album.Title).Count();
                rating.Add(album.Title, popularity);
            }
            return rating;
        }
        #endregion
    }
}
