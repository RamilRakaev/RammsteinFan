using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Repositories
{
    public interface IAdminRepos<Q,A,C>: IUserRepos<Q, A, C>
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
        /// Удалить  ответ из бд
        /// </summary>
        /// <param name="id"></param>
        void RemoveAnswer(int id);

        /// <summary>
        /// Удалить  вопрос из бд
        /// </summary>
        /// <param name="id"></param>
        void RemoveQuestion(int id);
    }
}
