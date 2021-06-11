using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RammsteinFan.Domain.Repositories
{
    public interface IUserRepository<DiscussionSubject,Replica,Content,User,Role>
    {
        #region Авторизация и права пользователя
        /// <summary>
        /// Получить пользователя по почте и паролю
        /// </summary>
        /// <param name="emailAdress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> GetUserAsync(string emailAdress, string password);

        /// <summary>
        /// Проверка на наличие аккаунта с заданной электронной почтой
        /// </summary>
        /// <param name="emailAdress"></param>
        /// <returns></returns>
        Task<User> AccountByEmailAsync(string emailAdress);

        /// <summary>
        /// Получить права пользователя
        /// </summary>
        /// <returns></returns>
        Task<Role> UserRights();

        /// <summary>
        /// Добавить простого пользователя
        /// </summary>
        /// <param name="name"></param>
        /// <param name="emailAdress"></param>
        /// <param name="age"></param>
        /// <param name="password"></param>
        /// <param name="userRole"></param>
        Task AddUserAsync(User user);
        #endregion

        #region Добавить новое сообщение
        /// <summary>
        /// Добавить ответ привязанный к вопросу или к другому ответу
        /// </summary>
        /// <param name="author">Атор ответа</param>
        /// <param name="text">Текст ответа</param>
        /// <param name="subjectId">Идентификатор вопроса, к которому привязан объект</param>
        /// <param name="replicaId">Идентификатор ответа (если он есть), к которому объект</param>
        void AddReplica(string author, string text, int subjectId, int replicaId=0);

        /// <summary>
        /// Добавить вопрос
        /// </summary>
        /// <param name="topHeading">Надтема</param>
        /// <param name="topic">Тема</param>
        /// <param name="author">Автор</param>
        /// <param name="text">Текст вопроса</param>
        void AddDiscussionSubject(string topHeading, string topic, string author, string text);
        #endregion

        #region Вернуть данные из бд
        /// <summary>
        /// Вернуть все темы обсуждений
        /// </summary>
        /// <returns></returns>
        IEnumerable<DiscussionSubject> GetAllDiscussionSubjects();

        /// <summary>
        /// Вернуть определённую тему дискуссии
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DiscussionSubject GetDiscussionSubject(int id);

        /// <summary>
        /// Вернуть конкретную реплику
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Replica GetReplica(int id);

        /// <summary>
        /// Вернуть реплики, привязанные к определённому вопросу или другой реплике
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Replica> GetReplicas(int id);

        /// <summary>
        /// Вернуть весь контент
        /// </summary>
        /// <returns></returns>
        IEnumerable<Content> GetAllContent();

        /// <summary>
        /// Вернуть контент по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Content GetContentForId(int id);

        /// <summary>
        /// Вернуть контент определённого типа
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<Content> GetContentForType(string type);

        /// <summary>
        /// Вернуть контент с названием начинающимся на title
        /// </summary>
        /// <param name="title">Первые буквы названия</param>
        /// <returns></returns>
        IEnumerable<Content> GetContentByFirstLetter(string title);

        /// <summary>
        /// Вернуть контент по заголовку
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Content GetContentForTitle(string title, string type);

        /// <summary>
        /// Вернуть весь контент определённого типа
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        IEnumerable<Content> GetContentForLocation(string location);
        #endregion

        #region Статистика
        /// <summary>
        /// Венруть любимый альбом пользователя
        /// </summary>
        /// <param name="emailAdress"></param>
        /// <returns></returns>
        string GetFavoriteAlbum(string emailAdress);

        /// <summary>
        /// Установить любимый альбом пользователя
        /// </summary>
        /// <param name="emailAdress"></param>
        /// <param name="titleAlbum">Название альбома</param>
        void SetFavoriteAlbum(string emailAdress, string titleAlbum);

        /// <summary>
        /// Вернуть рейтинг альбомов
        /// </summary>
        /// <returns></returns>
        Dictionary<string, int> AlbumRating();
        #endregion

    }
}
