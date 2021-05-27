using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Repositories
{
    public interface IAdminRepository<DiscussionSubject, Replica, Content, User, Role> : IUserRepository<DiscussionSubject, Replica, Content, User, Role>
    {
        /// <summary>
        /// Добавить новый фрагмент контента
        /// </summary>
        /// <param name="title">Заголовок контента</param>
        /// <param name="text">Текст контента</param>
        /// <param name="location">Относительное местоположение контента по разделам</param>
        /// <param name="type">Разновидность контента (текст, видео, аудио, картинка)</param>
        void AddContent(string title, string type, string text, string location);

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

        /// <summary>
        /// Удалить фрагмент контента
        /// </summary>
        /// <param name="id"></param>
        void RemoveContent(int id);

        /// <summary>
        /// Удалить  ответ из бд
        /// </summary>
        /// <param name="id"></param>
        void RemoveReplica(int id);

        /// <summary>
        /// Удалить  вопрос из бд
        /// </summary>
        /// <param name="id"></param>
        void RemoveSubject(int id);
    
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
       
         
    }
}
