using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RammsteinFan.Domain.Repositories
{
    public interface IUserRepository<DiscussionSubject,Replica,Content,User,Role, UserMessage>
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
        Task<Role> UserRightsAsync();
        Role UserRights();

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
        /// <param name="subjectId">Идентификатор темы, к которой привязан объект, если привязан к реплике, то равен нулю</param>
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

        #region Вернуть DiscussionMessage
        /// <summary>
        /// Вернуть все темы обсуждений
        /// </summary>
        /// <returns></returns>
        IEnumerable<DiscussionSubject> GetAllDiscussionSubjects();

        /// <summary>
        /// Вернуть определённую тему дискуссии по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DiscussionSubject GetDiscussionSubject(int id);

        /// <summary>
        /// Вернуть определённую тему дискуссии по заголовку
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        DiscussionSubject GetDiscussionSubject(string topic);

        /// <summary>
        /// Вернуть конкретную реплику
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Replica GetReplica(int id);

        /// <summary>
        /// Вернуть все реплики по первым буквам текста
        /// </summary>
        /// <param name="startOfText"></param>
        /// <returns></returns>
        IEnumerable<Replica> GetReplicasByFirstLetter(string startOfText);

        /// <summary>
        /// Вернуть реплики, привязанные к определённой теме или другой реплике по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Replica> GetReplicasBySubject(int id);

        /// <summary>
        /// Вернуть реплики, привязанные к определённой теме или другой реплике по заголовку 
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        IEnumerable<Replica> GetReplicasBySubject(string topic);
        #endregion

        #region Вернуть Content
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
        Content GetContentById(int id);

        /// <summary>
        /// Вернуть контент определённого типа
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<Content> GetContentByType(string type);

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
        Content GetContentByTitle(string title, string type);

        /// <summary>
        /// Вернуть весь контент определённого типа
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        IEnumerable<Content> GetContentByLocation(string location);
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
        /// <param name="location"></param>
        /// <returns></returns>
        Dictionary<string, int> AlbumRating(string location);

        /// <summary>
        /// Отправить сообщение администратору
        /// </summary>
        /// <param name="message"></param>
        void SendMessage(UserMessage message);
        #endregion

    }
}
