using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Repositories
{
    public interface IAdminRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> : 
        IUserRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage>
    {
        #region Добавить, удалить
        /// <summary>
        /// Удалить пользователя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        void RemoveUser(int id);

        /// <summary>
        /// Создать и добавить новый фрагмент контента
        /// </summary>
        /// <param name="title">Заголовок контента</param>
        /// <param name="location">Текст контента</param>
        /// <param name="text">Относительное местоположение контента по разделам</param>
        /// <param name="type">Разновидность контента (текст, видео, аудио, картинка)</param>
        void AddContent(string title, string type, string location, string text);

        /// <summary>
        /// Добавить готовый фрагмент контента
        /// </summary>
        void AddContent(Content newContent);

        /// <summary>
        /// Удалить объект Content по заголовку и типу
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        void RemoveContent(string title, string type);

        /// <summary>
        /// Удалить объект Content по идентификатору
        /// </summary>
        /// <param name="id"></param>
        void RemoveContent(int id);

        /// <summary>
        /// Удалить тему обсуждения из бд
        /// </summary>
        /// <param name="id"></param>
        void RemoveSubject(int id);

        /// <summary>
        /// Удалить реплику из бд
        /// </summary>
        /// <param name="id"></param>
        void RemoveReplica(int id);

        /// <summary>
        /// Удалить сообщение пользователя
        /// </summary>
        /// <param name="id"></param>
        void RemoveUserMessage(int id);
        #endregion

        #region Редактирование
        /// <summary>
        /// Полностью заменить контент
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newcontent"></param>
        void ReplaceContent(int id, Content newcontent);

        /// <summary>
        /// Изменить заголовок содержимого
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTitle"></param>
        void ChangeTitleContent(int id, string newTitle);

        /// <summary>
        /// Редактировать текст контента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        void EditTextContent(int id, string text);

        /// <summary>
        /// Изменить расположение контента
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="newLocation"></param>
        void ChangeLocationContent(int Id, string newLocation);

        /// <summary>
        /// Изменить тип содержимого
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newType"></param>
        void ChangeTypeContent(int id, string newType);
        #endregion

        #region Вернуть данные

        /// <summary>
        /// Вернуть все типы контента
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetTypes();

        /// <summary>
        /// Вернуть все типы расположения
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetLocations();

        /// <summary>
        /// Вернуть все сообщения пользователей
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserMessage> GetAllUserMessages();
        #endregion

        #region Авторизация
        /// <summary>
        /// Разрешение на вход
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool PermissionEnter(string name, string password);

        /// <summary>
        /// Выдача сообщения об ошибке
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string ErrorAuthorizationMessage(string name, string password);
        #endregion

    }
}
