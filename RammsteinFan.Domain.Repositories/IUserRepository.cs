using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Repositories
{
    public interface IUserRepository<DS,R,C>
    {
        /// <summary>
        /// Добавить ответ привязанный к вопросу или к другому ответу
        /// </summary>
        /// <param name="author">Атор ответа</param>
        /// <param name="text">Текст ответа</param>
        /// <param name="questionId">Идентификатор вопроса, к которому привязан объект</param>
        /// <param name="answerId">Идентификатор ответа (если он есть), к которому объект</param>
        void AddAnswer(string author, string text, int questionId, int answerId=0);

        /// <summary>
        /// Добавить вопрос
        /// </summary>
        /// <param name="topHeading">Надтема</param>
        /// <param name="topic">Тема</param>
        /// <param name="author">Автор</param>
        /// <param name="text">Текст вопроса</param>
        void AddQuestion(string topHeading, string topic, string author, string text);

        /// <summary>
        /// Вернуть все вопросы
        /// </summary>
        /// <returns></returns>
        IEnumerable<DS> GetAllQuestions();

        /// <summary>
        /// Вернуть ответы, привязанные к определённому вопросу или ответу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<R> GetAnswer(int id);

        /// <summary>
        /// Вернуть весь контент
        /// </summary>
        /// <returns></returns>
        IEnumerable<C> GetAllContent();

        /// <summary>
        /// Вернуть определённый фрагмент контента
        /// </summary>
        /// <param name="type"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        IEnumerable<C> GetContent(string type, string location);

        /// <summary>
        /// Вернуть по заголовку
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        IEnumerable<C> GetContentForTitle(string title);

        /// <summary>
        /// Вернуть весь контент определённого типа
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<C> GetContentForType(string type);
    }
}
