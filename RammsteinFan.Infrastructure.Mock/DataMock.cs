using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Mock
{
    public class DataMock
    {
        public DataMock()
        {

        }
        public List<Replica> Replicas { get; set; } = new List<Replica>()
        {
            new Replica("Саша","Я не знаю, блин",2){Id=3 },
            new Replica("Данил","Это Тиль",1){Id=4}
        };
        public List<DiscussionSubject> DiscussionSubjects { get; set; } = new List<DiscussionSubject>() 
        { 
            new DiscussionSubject(
                "Участники группы",
                "Кто лидер группы Тиль или Рихард?",
                "Иван",
                "С одной стороны основателем группы является Рихард, с другой Тиль является главным фронтменом.")
            {Id=1},
            new DiscussionSubject(
                "Символика группы",
                "Логотип",
                "Иван",
                "Откуда взялся логотип группы?")
            {Id=2}
        };
        public List<Content> DbContent { get; set; } = new List<Content>()
        {
            new Content("Заголовок","Article","Текст","Index/History"){Id=1},
            new Content("Liebe ist Fur alle da","ListOfSongs","Rammlied,Ich tu dir weh, Waidmanns Heil, Haifisch, " +
                "B * *******, Fruhling in Paris, Wiener Blut, Pussy, Liebe ist Fur alle da, Mehr,Roter Sand, " +
                "Fuhre mich, Donaukinder, Halt, Liese","SongTranslationsMain")
        };
 
        
            
    }
}
