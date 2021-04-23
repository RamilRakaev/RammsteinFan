using System;
using System.Collections.Generic;
using System.Text;

namespace DI.IRepos
{
    public interface IUserRepos<Q,A,C>
    {
        /// <summary>
        /// Добавить ответ
        /// </summary>
        /// <param name="author"></param>
        /// <param name="Text"></param>
        /// <param name="questionId"></param>
        /// <param name="answerId"></param>
        void AddAnswer(string author, string Text, int questionId, int answerId);
        
        /// <summary>
        /// Добавить вопрос
        /// </summary>
        /// <param name="author"></param>
        /// <param name="text"></param>
        void AddQuestion(string author, string text);

        /// <summary>
        /// Вернуть все вопросы
        /// </summary>
        /// <returns></returns>
        IEnumerable<Q> GetAllQuestions();

        /// <summary>
        /// Вернуть все ответы
        /// </summary>
        /// <returns></returns>
        IEnumerable<A> GetAllAnswers();

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
    }
}
