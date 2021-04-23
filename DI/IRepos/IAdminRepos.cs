using System;
using System.Collections.Generic;
using System.Text;

namespace DI.IRepos
{
    public interface IAdminRepos<Q,A,C>: IUserRepos<Q, A, C>
    {
        /// <summary>
        /// Добавить новый фрагмент контента
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="location"></param>
        void AddContent(string title, string text, string location);

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
        /// Удалить фрагмент контента
        /// </summary>
        /// <param name="id"></param>
        void RemoveContent(int id);

        /// <summary>
        /// Удалить вопрос или ответ
        /// </summary>
        /// <param name="id"></param>
        void RemoveDiscussion(int id);
    }
}
