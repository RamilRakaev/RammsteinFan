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

        /// <summary>
        /// Вернуть все темы обсуждений
        /// </summary>
        /// <returns></returns>
        IEnumerable<DS> GetAllDiscussionSubjects();

        /// <summary>
        /// Вернуть определённую тему дискуссии
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DS GetDiscussionSubject(int id);

        /// <summary>
        /// Вернуть ответы, привязанные к определённому вопросу или ответу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<R> GetReplicas(int id);

        /// <summary>
        /// Вернуть весь контент
        /// </summary>
        /// <returns></returns>
        IEnumerable<C> GetAllContent();

        /// <summary>
        /// Вернуть контент определённого типа
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<C> GetContentForType(string type);

        /// <summary>
        /// Вернуть контент по заголовку
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        C GetContentForTitle(string title, string type);

        /// <summary>
        /// Вернуть весь контент определённого типа
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<C> GetContentForLocation(string type);
    }
}
