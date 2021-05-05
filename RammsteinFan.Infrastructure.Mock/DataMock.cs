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
            new Content("Liebe ist Fur alle da","AlbumWithSongs","Rammlied,Ich tu dir weh, Waidmanns Heil, Haifisch, " +
                "B * *******, Fruhling in Paris, Wiener Blut, Pussy, Liebe ist Fur alle da, Mehr,Roter Sand, " +
                "Fuhre mich, Donaukinder, Halt, Liese","SongTranslationsMain"),
            new Content("Mutter","AlbumWithSongs","Mein Herz brennt, Links 2 3 4, Sonne, Ich will, Feuer frei!," +
                " Mutter, Spieluhr, Zwitter, Rein raus, Adios, Nebel","SongTranslationsMain"),
            new Content("Links 2 3 4","SongText","Links 2 3 4\n" +
           "\n" +
"Kann man[1] Herzen brechen[2]\n" +
"können Herzen sprechen\n" +
"kann man Herzen quälen\n" +
"kann man Herzen stehlen\n" +
"\n" +
"Sie wollen mein Herz am rechten Fleck[3]\n" +
"doch seh ich dann nach unten weg[4]\n" +
"da schlägt es links[5]\n" +
"Links\n" +
"\n" +
"Können Herzen singen\n" +
"kann ein Herz zerspringen\n" +
"können Herzen rein sein\n" +
"kann ein Herz aus Stein sein\n" +
"\n" +
"Sie wollen mein Herz am rechten Fleck\n" +
"doch seh ich dann nach unten weg\n" +
"da schlägt es links\n" +
"Links(3x)\n" +
"\n" +
"Links zwo drei vier\n" +
"Links zwo(3x) drei vier links(2x)\n" +
"Links zwo drei vier\n" +
"\n" +
"Kann man Herzen fragen\n" +
"ein Kind darunter tragen\n" +
"kann man es verschenken\n" +
"mit dem Herzen denken\n" +
"\n" +
"Sie wollen mein Herz am rechten Fleck\n" +
"doch seh ich dann nach unten weg\n" +
"da schlägt es in der linken Brust\n" +
"der Neider hat es schlecht gewusst[6]\n" +
"\n" +
"Links(4x)\n" +
"Links zwo drei vier links\n" +
"\n" +
"Links zwo drei vier\n" +
"Links zwo(3x) drei vier links(2x)\n" +
"Links zwo(3x) drei vier(4x)\n","SongTranslationsMain/Links 2 3 4")
        };
 
        
            
    }
}
